using DesafioTecnicoSecSaude.Usuarios.Controller;
using DesafioTecnicoSecSaude.Usuarios.DTO;
using System;
using System.Web.UI;

namespace DesafioTecnicoSecSaude
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
         {
            LoadNHibernate();
        }

        public void LoadNHibernate()
        {
            UsuarioController controller = new UsuarioController();
            controller.Cadastrar(GetUsuarioMock());
        }

        public UsuarioDTO GetUsuarioMock()
        {
            return new UsuarioDTO()
            {
                Nome = "Victor Cerqueira",
                Email = "dev.cerqueira@gmail.com",
                CPF = "123.456.789-00",
                Senha = "#1x1mp10$!",
                DataNascimento = "10/01/1988",
                Telefones = "71991087353",
                Perfil = "Administrador",
                Endereco = "Rua da Bolivia, 345, 40875322"
            };
        }
    }
}