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
                    this.Response.Redirect("DetalharUsuario.aspx?usuarioId=" + usuarioId);
            }
        }
    }
}