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
            var usuarios = controller.ListarTodos();
            //var usuario = controller.ListarPorId(3);
            //controller.Cadastrar(GetUsuarioMock());
            //controller.Atualizar(GetUsuarioMock(), 1);
            //controller.Deletar(2);
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