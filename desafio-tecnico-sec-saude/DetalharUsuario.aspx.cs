using DesafioTecnicoSecSaude.Usuarios.Controller;
using DesafioTecnicoSecSaude.Usuarios.Model;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesafioTecnicoSecSaude
{
    public partial class DetalharUsuario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                if (Request.QueryString["usuarioId"] != null)
                {
                    string usuarioId = Request.QueryString["usuarioId"];
                    CarregarDetalhesUsuario(Convert.ToInt32(usuarioId));
                    CarregarContatosUsuario();
                }
                else
                {
                    this.Response.Redirect("ConsultarUsuarios.aspx");
                }
            }
        }

        private void CarregarContatosUsuario()
        {
            var contatos = (List<Contato>)Session["Contatos"];

            tabelaContatos.DataSource = contatos;
            tabelaContatos.DataBind();
        }

        private void CarregarDetalhesUsuario(int usuarioId)
        {
            if (!usuarioId.Equals(0))
            {
                try
                {
                    UsuarioController controller = new UsuarioController();
                    Usuario usuario = controller.ListarPorId(usuarioId);

                    if (usuario != null)
                    {
                        nome.Text = usuario.Nome;
                        email.Text = usuario.Email;
                        cpf.Text = usuario.CPF;
                        senha.Text = usuario.Senha;
                        dataNascimento.Text = usuario.DataNascimento.ToString("dd/MM/yyyy");
                        dropPerfis.SelectedValue = usuario.Perfil;

                        nome.Enabled = false;
                        email.Enabled = false;
                        cpf.Enabled = false;
                        senha.Enabled = false;
                        dropPerfis.Enabled = false;
                        endereco.Enabled = false;
                        dataCriacao.Text = usuario.DataCriacao.ToString("dd/MM/yyyy HH:mm");

                        if (usuario.Contatos != null && usuario.Contatos.Count > 0)
                            Session["Contatos"] = new List<Contato>(usuario.Contatos);
                        
                        DateTime dataPadrao = new DateTime(0001, 1, 1, 0, 0, 0);

                        if (usuario.DataAtualizacao != dataPadrao)
                            dataAtualizacao.Text = (usuario.DataAtualizacao.HasValue) ? usuario.DataAtualizacao.Value.ToString("dd/MM/yyyy HH:mm") : "N/A";   
                        else
                            dataAtualizacao.Text = "N/A";
                    }
                    else
                    {
                        this.Response.Redirect("ConsultarUsuarios.aspx");
                    }
                }
                catch (Exception)
                {

                }                
            }
            else
            {
                this.Response.Redirect("ConsultarUsuarios.aspx");
            }
        }

        protected string GetTipoContatoText(int tipoContato)
        {
            switch (tipoContato)
            {
                case 1:
                    return "Telefone Fixo";
                case 2:
                    return "Celular";
                case 3:
                    return "E-mail";
                default:
                    return string.Empty;
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarUsuarios.aspx");
        }
    }
}