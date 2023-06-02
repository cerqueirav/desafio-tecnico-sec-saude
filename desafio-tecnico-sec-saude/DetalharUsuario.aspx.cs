using DesafioTecnicoSecSaude.Usuarios.Controller;
using DesafioTecnicoSecSaude.Usuarios.Model;
using System;
using System.Web.UI;

namespace DesafioTecnicoSecSaude
{
    public partial class DetalharUsuario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["usuarioId"] != null)
                {
                    string usuarioId = Request.QueryString["usuarioId"];
                    CarregarDetalhesUsuario(usuarioId);
                }
                else
                {
                    this.Response.Redirect("ConsultarUsuarios.aspx");
                }
            }
        }

        private void CarregarDetalhesUsuario(string usuarioId)
        {
            int id;
            if (int.TryParse(usuarioId, out id))
            {
                UsuarioController controller = new UsuarioController();
                Usuario usuario = controller.ListarPorId(id);

                if (usuario != null)
                {
                    nome.Text = usuario.Nome;
                    email.Text = usuario.Email;
                    cpf.Text = usuario.CPF;
                    senha.Text = usuario.Senha;

                    dataNascimento.Text = usuario.DataNascimento.ToString("dd/MM/yyyy");
                    telefone.Text = usuario.Telefones;
                    dropPerfis.SelectedValue = usuario.Perfil;
                    endereco.Text = usuario.Endereco;

                    // Desabilitar a edição dos campos
                    nome.Enabled = false;
                    email.Enabled = false;
                    cpf.Enabled = false;
                    senha.Enabled = false;
                    telefone.Enabled = false;
                    dropPerfis.Enabled = false;
                    endereco.Enabled = false;
                    dataCriacao.Text = usuario.DataCriacao.ToString("dd/MM/yyyy HH:mm");

                    DateTime dataPadrao = new DateTime(0001, 1, 1, 0, 0, 0);

                    if (usuario.DataAtualizacao != dataPadrao)
                    {
                        if (usuario.DataAtualizacao.HasValue)
                        {
                            dataAtualizacao.Text = usuario.DataAtualizacao.Value.ToString("dd/MM/yyyy HH:mm");
                        }
                    }
                    else
                        dataAtualizacao.Text = "N/A";
                }
                else
                {
                    this.Response.Redirect("ConsultarUsuarios.aspx");
                }
            }
            else
            {
                this.Response.Redirect("ConsultarUsuarios.aspx");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarUsuarios.aspx");
        }
    }
}