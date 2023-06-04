using DesafioTecnicoSecSaude.Usuarios.Controller;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesafioTecnicoSecSaude
{
    public partial class ConsultarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Clear();
                var listaUsuarios = new UsuarioController().ListarTodos();
                if (listaUsuarios != null && listaUsuarios.Count > 0)
                {
                    this.grdDados.DataSource = listaUsuarios;
                    this.grdDados.DataBind();
                }
            }
        }

        protected void grdDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Editar"))
            {
                string usuarioId = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(usuarioId))
                    this.Response.Redirect("EditarUsuario.aspx?usuarioId=" + usuarioId);
            }

            if (e.CommandName.Equals("Detalhar"))
            {
                string usuarioId = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(usuarioId))
                    this.Response.Redirect("DetalharUsuario.aspx?usuarioId=" + usuarioId);
            }

            if (e.CommandName.Equals("Deletar"))
            {
                string usuarioId = e.CommandArgument.ToString();
                if (!String.IsNullOrEmpty(usuarioId))
                {
                    RemoverUsuario(usuarioId);
                    this.Response.Redirect("ConsultarUsuarios.aspx");
                }
                    
            }
        }
        protected void CadastroUsuario_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("CadastrarUsuario.aspx");
        }

        private void RemoverUsuario(string usuarioId)
        {
            try
            {
                UsuarioController controller = new UsuarioController();
                controller.Deletar(Convert.ToInt32(usuarioId));
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroRemoverUsuario", "Swal.fire('Erro ao remover!', 'Ocorreu um erro durante o processamento das informações!', 'error');", true);
            }
        }
    }
}