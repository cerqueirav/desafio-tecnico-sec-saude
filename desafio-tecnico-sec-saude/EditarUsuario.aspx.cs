using DesafioTecnicoSecSaude.Usuarios.Controller;
using DesafioTecnicoSecSaude.Usuarios.DTO;
using DesafioTecnicoSecSaude.Usuarios.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesafioTecnicoSecSaude
{
    public partial class EditarUsuario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string usuarioId = Request.QueryString["usuarioId"];
                if (!string.IsNullOrEmpty(usuarioId))
                {
                    CarregarDadosUsuario(usuarioId);
                }
            }
        }

        private void CarregarDadosUsuario(string usuarioId)
        {
            UsuarioController controller = new UsuarioController();

            var usuario = controller.ListarPorId(Convert.ToInt32(usuarioId));

            if (usuario != null)
            {
                nome.Text = usuario.Nome;
                email.Text = usuario.Email;
                cpf.Text = usuario.CPF;
                senha.Text = usuario.Senha;
                dataNascimento.Text = usuario.DataNascimento.ToString("yyyy-MM-dd");
                dropPerfis.SelectedValue = usuario.Perfil;
                telefone.Text = usuario.Telefones;
                endereco.Text = usuario.Endereco;
            }
        }

        protected void SalvarEdicao_Click(object sender, EventArgs e)
        {
            UsuarioController controller = new UsuarioController();

            string usuarioId = Request.QueryString["usuarioId"];
            
            UsuarioDTO usuarioDTO = new UsuarioDTO(
                nome.Text, 
                email.Text, 
                senha.Text, 
                cpf.Text,
                DateTime.Parse(dataNascimento.Text), 
                telefone.Text, 
                dropPerfis.SelectedValue, 
                endereco.Text
            );

            try
            {
                controller.Atualizar(usuarioDTO, Convert.ToInt32(usuarioId));
                Response.Redirect("DetalharUsuario.aspx?usuarioId=" + usuarioId);
            }
            catch (Exception)
            {
                Response.Redirect("ConsultarUsuarios.aspx");
            }
        }
    }
}