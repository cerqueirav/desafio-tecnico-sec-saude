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
            //UsuarioController controller = new UsuarioController();
            // Lista todos os usuários
            //var usuarios = controller.ListarTodos();

            // Busca o usuário pelo Id
            //var usuario = controller.ListarPorId(3);

            // Cadastro do usuário
            //controller.Cadastrar(GetUsuarioCadastrarMock());

            // Edição do usuário
            //controller.Atualizar(GetUsuarioAtualizarMock(), 3);

            // Exclusão do usuário
            //TODO: Implementar exclusão em um dos modos: Cascade, Set Null or Set Default
            //controller.Deletar(3);
        }

        public UsuarioDTO GetUsuarioCadastrarMock()
        {
            return new UsuarioDTO()
            {
                Nome = "Victor Cerqueira",
                Email = "dev.cerqueira@gmail.com",
                CPF = "123.456.789-00",
                Senha = "#1x1mp10$!",
                DataNascimento = DateTime.Parse("10/01/1988"),
                Perfil = "Administrador",
            };
        }

        public UsuarioDTO GetUsuarioAtualizarMock()
        {
            return new UsuarioDTO()
            {
                Nome = "Victor Lima Cerqueira",
                Perfil = "Operador",
            };
        }
    }
}