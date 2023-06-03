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

        public void Atualizar(UsuarioDTO usuarioDTO, int id)
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
                            this.AtualizarCamposUsuario(ref usuario, usuarioDTO);
                            session.Update(usuario);
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

        public void Deletar(int id)
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

        #region METODOS PRIVADOS
        // Métodos de validação
        private bool ValidarCamposCadastro(UsuarioDTO usuarioDTO)
        {
            //TODO: Adicionar validações dos campos
            return true;
        }

        // Preparação de campos
        private void AtualizarCamposUsuario(ref Usuario usuarioAtual, UsuarioDTO usuarioAtualizado)
        {
            if (!String.IsNullOrEmpty(usuarioAtualizado.Nome))
                usuarioAtual.Nome = usuarioAtualizado.Nome;

            if (!String.IsNullOrEmpty(usuarioAtualizado.Email))
                usuarioAtual.Email = usuarioAtualizado.Email;

            if (!String.IsNullOrEmpty(usuarioAtualizado.Senha))
                usuarioAtual.Senha = usuarioAtualizado.Senha;

            if (!String.IsNullOrEmpty(usuarioAtualizado.CPF))
                usuarioAtual.CPF = usuarioAtualizado.CPF;

            if (Validation.ValidarData(usuarioAtualizado.DataNascimento.ToString()))
                usuarioAtual.DataNascimento = usuarioAtualizado.DataNascimento;

            if (!String.IsNullOrEmpty(usuarioAtualizado.Perfil))
                usuarioAtual.Perfil = usuarioAtualizado.Perfil;

            usuarioAtual.DataAtualizacao = DateTime.Now;
        }

        #endregion
    }
}