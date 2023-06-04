using DesafioTecnicoSecSaude.NHibernate;
using DesafioTecnicoSecSaude.Usuarios.DTO;
using DesafioTecnicoSecSaude.Usuarios.Model;
using DesafioTecnicoSecSaude.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioTecnicoSecSaude.Usuarios.Controller
{
    public class UsuarioController
    {
        public void Cadastrar(UsuarioDTO usuarioDTO)
        {
            if (this.ValidarCamposCadastro(usuarioDTO))
            {
                var usuario = new Usuario
                {
                    Nome = usuarioDTO.Nome,
                    Email = usuarioDTO.Email,
                    Senha = usuarioDTO.Senha,
                    CPF = usuarioDTO.CPF,
                    DataCriacao = DateTime.Now,
                    DataNascimento = usuarioDTO.DataNascimento,
                    DataAtualizacao = null,
                    Perfil = usuarioDTO.Perfil,
                    CEP = usuarioDTO.Endereco.CEP,
                    Logradouro = usuarioDTO.Endereco.Logradouro,
                    Complemento = usuarioDTO.Endereco.Complemento,
                    Numero = usuarioDTO.Endereco.Numero,
                    Cidade = usuarioDTO.Endereco.Cidade,
                    Estado = usuarioDTO.Endereco.Estado,
                    Pais = usuarioDTO.Endereco.Pais,
                };

                try
                {
                    using (var session = NHibernateHelper.GetSession())
                    {
                        using (var transaction = session.BeginTransaction())
                        {
                            // Cadastro do usuário
                            var usuarioId = session.Save(usuario);

                            // Vinculação dos contatos
                            foreach (var contato in usuarioDTO.Contatos)
                            {
                                Contato contatoUsuario = new Contato()
                                {
                                    TipoContatoId = contato.TipoContatoId,
                                    Descricao = contato.Descricao,
                                    UsuarioId = (int)usuarioId  
                                };

                                session.Save(contatoUsuario);
                            }

                            transaction.Commit();
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao salvar o usuário!\n Detalhes sobre o erro : " + ex);
                }
            }
            else
            {
                throw new Exception("Os dados informados estão incorretos ou inválidos!");
            }
        }

        public void Atualizar(UsuarioAtualizarDTO usuarioAtualizarDTO, int id)
        {  
            if (this.ValidarCamposAtualizacao(usuarioAtualizarDTO))
            {
                try
                {
                    using (var session = NHibernateHelper.GetSession())
                    {
                        using (var transaction = session.BeginTransaction())
                        {
                            // Obtêm o usuário pelo Id
                            var usuario = session.Get<Usuario>(id);

                            if (usuario != null)
                            {
                                this.AtualizarCamposGeraisUsuario(ref usuario, usuarioAtualizarDTO);
                                this.AtualizarCamposEnderecoUsuario(ref usuario, usuarioAtualizarDTO);
                                session.Update(usuario);
                            }

                            // Atualização dos contatos (exclusões)
                            foreach (var contatoExcluido in usuarioAtualizarDTO.ContatosExcluidos)
                            {
                                var contato = session.Get<Contato>(contatoExcluido.Id);

                                if (contato != null)
                                    session.Delete(contato);
                            }

                            // Atualização dos contatos (novos)
                            foreach (var contatoNovo in usuarioAtualizarDTO.Contatos)
                            {
                                if (contatoNovo.Id.Equals(0))
                                {
                                    Contato contatoUsuario = new Contato()
                                    {
                                        TipoContatoId = contatoNovo.TipoContatoId,
                                        Descricao = contatoNovo.Descricao,
                                        UsuarioId = id
                                    };

                                    session.Save(contatoUsuario);
                                }
                            }

                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao atualizar o usuário!\n Detalhes sobre o erro : " + ex);
                }
            }
            else
            {
                throw new Exception("Os dados informados estão incorretos ou inválidos!");
            }
        }

        public void Deletar(int id)
        {
            if (!id.Equals(0))
            {
                try
                {
                    using (var session = NHibernateHelper.GetSession())
                    {
                        using (var transaction = session.BeginTransaction())
                        {
                            // Obtêm o usuário pelo Id
                            var usuario = session.Get<Usuario>(id);

                            if (usuario != null)
                                session.Delete(usuario);

                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao deletar o usuário!\n Detalhes sobre o erro : " + ex);
                }
            }
            else
            {
                throw new Exception("Ocorreu um erro ao deletar o usuário!");
            }
        }

        public List<Usuario> ListarTodos()
        {
            try
            {
                using (var session = NHibernateHelper.GetSession())
                {
                    return session.Query<Usuario>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar os usuários!\n Detalhes sobre o erro : " + ex);
            }
        }

        public Usuario ListarPorId(int usuarioId)
        {
            try
            {
                using (var session = NHibernateHelper.GetSession())
                {
                    return session.QueryOver<Usuario>()
                    .Where(u => u.Id == usuarioId)
                    .Fetch(u => u.Contatos).Eager
                    .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao listar os usuários!\n Detalhes sobre o erro : " + ex);
            }
        }

        #region VALIDAÇÕES

        private bool ValidarCamposAtualizacao(UsuarioAtualizarDTO usuarioAtualizarDTO)
        {
            if (String.IsNullOrEmpty(usuarioAtualizarDTO.Nome))
                return false;

            if (!Validation.ValidarEmail(usuarioAtualizarDTO.Email))
                return false;

            if (!Validation.ValidarCpf(usuarioAtualizarDTO.CPF))
                return false;

            if (!Validation.ValidarData(usuarioAtualizarDTO.DataNascimento.ToString()))
                return false;

            if (String.IsNullOrEmpty(usuarioAtualizarDTO.Perfil))
                return false;

            if (!ValidarCamposEnderecoCadastro(usuarioAtualizarDTO.Endereco))
                return false;

            if (!ValidarCamposEnderecoCadastro(usuarioAtualizarDTO.Endereco))
                return false;

            return true;
        }

        private bool ValidarCamposCadastro(UsuarioDTO usuarioDTO)
        {
            if (String.IsNullOrEmpty(usuarioDTO.Nome))
                return false;

            if (!Validation.ValidarEmail(usuarioDTO.Email))
                return false;

            if (!Validation.ValidarCpf(usuarioDTO.CPF))
                return false;

            if (String.IsNullOrEmpty(usuarioDTO.Senha))
                return false;

            if (!Validation.ValidarData(usuarioDTO.DataNascimento.ToString()))
                return false;

            if (String.IsNullOrEmpty(usuarioDTO.Perfil))
                return false;

            if (!ValidarCamposEnderecoCadastro(usuarioDTO.Endereco))
                return false;

            return true;
        }

        private bool ValidarCamposEnderecoCadastro(EnderecoDTO enderecoDTO)
        {
            if (String.IsNullOrEmpty(enderecoDTO.CEP))
                return false;

            if (String.IsNullOrEmpty(enderecoDTO.Logradouro))
                return false;

            if (String.IsNullOrEmpty(enderecoDTO.Numero))
                return false;

            if (String.IsNullOrEmpty(enderecoDTO.Cidade))
                return false;

            if (String.IsNullOrEmpty(enderecoDTO.Estado))
                return false;

            if (String.IsNullOrEmpty(enderecoDTO.Pais))
                return false;

            return true;
        }
        #endregion

        #region TRATAMENTO DE CAMPOS
        private void AtualizarCamposGeraisUsuario(ref Usuario usuarioAtual, UsuarioAtualizarDTO usuarioAtualizado)
        {
            if (!String.IsNullOrEmpty(usuarioAtualizado.Nome))
                usuarioAtual.Nome = usuarioAtualizado.Nome;

            if (!String.IsNullOrEmpty(usuarioAtualizado.Email))
                usuarioAtual.Email = usuarioAtualizado.Email;

            if (!String.IsNullOrEmpty(usuarioAtualizado.CPF))
                usuarioAtual.CPF = usuarioAtualizado.CPF;

            if (Validation.ValidarData(usuarioAtualizado.DataNascimento.ToString()))
                usuarioAtual.DataNascimento = usuarioAtualizado.DataNascimento;

            if (!String.IsNullOrEmpty(usuarioAtualizado.Perfil))
                usuarioAtual.Perfil = usuarioAtualizado.Perfil;

            usuarioAtual.DataAtualizacao = DateTime.Now;
        }

        private void AtualizarCamposEnderecoUsuario(ref Usuario usuarioAtual, UsuarioAtualizarDTO usuarioAtualizado)
        {
            if (!String.IsNullOrEmpty(usuarioAtualizado.Endereco.CEP))
                usuarioAtual.CEP = usuarioAtualizado.Endereco.CEP;

            if (!String.IsNullOrEmpty(usuarioAtualizado.Endereco.Logradouro))
                usuarioAtual.Logradouro = usuarioAtualizado.Endereco.Logradouro;

            if (!String.IsNullOrEmpty(usuarioAtualizado.Endereco.Complemento))
                usuarioAtual.Complemento = usuarioAtualizado.Endereco.Complemento;

            if (!String.IsNullOrEmpty(usuarioAtualizado.Endereco.Numero))
                usuarioAtual.Numero = usuarioAtualizado.Endereco.Numero;

            if (!String.IsNullOrEmpty(usuarioAtualizado.Endereco.Cidade))
                usuarioAtual.Cidade = usuarioAtualizado.Endereco.Cidade;

            if (!String.IsNullOrEmpty(usuarioAtualizado.Endereco.Estado))
                usuarioAtual.Estado = usuarioAtualizado.Endereco.Estado;

            if (!String.IsNullOrEmpty(usuarioAtualizado.Endereco.Pais))
                usuarioAtual.Pais = usuarioAtualizado.Endereco.Pais;
        }

        #endregion
    }
}