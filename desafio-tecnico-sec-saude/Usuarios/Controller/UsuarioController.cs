using DesafioTecnicoSecSaude.NHibernate;
using DesafioTecnicoSecSaude.Usuarios.DTO;
using DesafioTecnicoSecSaude.Usuarios.Model;
using System;

namespace DesafioTecnicoSecSaude.Usuarios.Controller
{
    public class UsuarioController
    {

        public void Cadastrar(UsuarioDTO usuarioDTO)
        {
            if (this.ValidarCampos(usuarioDTO))
            {
                try
                {
                    using (var session = NHibernateHelper.GetSession())
                    {
                        var usuario = new Usuario
                        {
                            Nome = usuarioDTO.Nome,
                            Email = usuarioDTO.Email,
                            Senha = usuarioDTO.Senha,
                            CPF = usuarioDTO.CPF,
                            DataCriacao = DateTime.Now.ToString(),
                            DataNascimento = usuarioDTO.DataNascimento,
                            Telefones = usuarioDTO.Telefones,
                            Perfil = usuarioDTO.Perfil,
                            Endereco = usuarioDTO.Endereco
                        };

                        session.Save(usuario);
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

        #region METODOS PRIVADOS
        // Métodos de validação

        private bool ValidarCampos(UsuarioDTO usuarioDTO)
        {
            return false;
        }

        #endregion
    }
}