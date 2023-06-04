using DesafioTecnicoSecSaude.Usuarios.Controller;
using DesafioTecnicoSecSaude.Usuarios.DTO;
using DesafioTecnicoSecSaude.Usuarios.Model;
using DesafioTecnicoSecSaude.Utils.Viacep.Model;
using DesafioTecnicoSecSaude.Utils.Viacep.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                Session["ContatosExcluidos"] = new List<Contato>();
                Session["Contatos"] = new List<Contato>();

                string usuarioId = Request.QueryString["usuarioId"];
                if (!string.IsNullOrEmpty(usuarioId))
                {
                    CarregarDadosUsuario(usuarioId);
                    CarregarContatosUsuario();
                }
                else
                {
                    Response.Redirect("ConsultarUsuarios.aspx");
                }
            }
        }

        private void CarregarDadosUsuario(string usuarioId)
        {
            try
            {
                UsuarioController controller = new UsuarioController();

                var usuario = controller.ListarPorId(Convert.ToInt32(usuarioId));

                if (usuario != null)
                {
                    nome.Text = usuario.Nome;
                    email.Text = usuario.Email;
                    cpf.Text = usuario.CPF;
                    dataNascimento.Text = usuario.DataNascimento.ToString("yyyy-MM-dd");
                    dropPerfis.SelectedValue = usuario.Perfil;
                    cep.Text = usuario.CEP;
                    logradouro.Text = usuario.Logradouro;
                    complemento.Text = usuario.Complemento;
                    numero.Text = usuario.Numero;
                    cidade.Text = usuario.Cidade;
                    estado.Text = usuario.Estado;
                    pais.Text = usuario.Pais;

                    if (usuario.Contatos != null && usuario.Contatos.Count > 0)
                        Session["Contatos"] = new List<Contato>(usuario.Contatos);
                }
                else
                {
                    Response.Redirect("ConsultarUsuarios.aspx");
                }
            }
            catch (Exception)
            {
                Response.Redirect("ConsultarUsuarios.aspx");
            }
        }

        protected void carregarEndereco(object sender, EventArgs e)
        {
            cepErro.Text = "";
            try
            {
                ViaCepService cepService = new ViaCepService();
                var endereco = cepService.GetEnderecoByCep(cep.Text);

                if (endereco != null)
                {
                    SetCamposEndereco(endereco);
                    DesabilitarCampos(endereco);
                }
                else
                {
                    LimparCamposEndereco();
                    cepErro.Text = "O CEP informado é inválido!";
                }

            }
            catch (Exception)
            {
                cepErro.Text = "O CEP informado é inválido!";
            }
        }

        protected void SalvarEdicao_Click(object sender, EventArgs e)
        {
            try
            {
                string usuarioId = Request.QueryString["usuarioId"];
                
                UsuarioController controller = new UsuarioController();

                EnderecoDTO endereco = new EnderecoDTO()
                {
                    CEP = cep.Text,
                    Logradouro = logradouro.Text,
                    Complemento = complemento.Text,
                    Numero = numero.Text,
                    Cidade = cidade.Text,
                    Estado = estado.Text,
                    Pais = pais.Text,
                };

                UsuarioAtualizarDTO usuarioAtualizarDTO = new UsuarioAtualizarDTO()
                {
                    Nome = nome.Text,
                    Email = email.Text,
                    CPF = cpf.Text,
                    DataNascimento = DateTime.Parse(dataNascimento.Text),
                    Perfil = dropPerfis.SelectedValue,
                    Contatos = GetSessionContatos(),
                    ContatosExcluidos = GetSessionContatosExcluidos(),
                    Endereco = endereco
                };

                controller.Atualizar(usuarioAtualizarDTO, Convert.ToInt32(usuarioId));
                Response.Redirect("DetalharUsuario.aspx?usuarioId=" + usuarioId);
            }
            catch (Exception)
            {
                Response.Redirect("ConsultarUsuarios.aspx");
            }
        }

        protected void grdDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<Contato> contatos = GetSessionContatos();

            if (e.CommandName.Equals("ExcluirContato"))
            {
                string argumentos = e.CommandArgument.ToString();
                string[] parametros = argumentos.Split(';');

                int indice = Convert.ToInt32(parametros[0]);
                int contatoId = Convert.ToInt32(parametros[1]);

                if (!contatoId.Equals(0))
                {
                    List<Contato> contatosExcluidos = (List<Contato>)Session["ContatosExcluidos"];
                    contatosExcluidos.Add(contatos[indice]);
                    Session["ContatosExcluidos"] = contatosExcluidos;
                }

                contatos.RemoveAt(indice);
                SetSessionContatos(contatos);

                ScriptManager.RegisterStartupScript(this, GetType(), "ContatoRemovido", "Swal.fire('Contato removido!', 'Contato removido com sucesso!', 'success');", true);

                ExibirContatos();
            }
        }

        protected void btnAdicionarContato_Click(object sender, EventArgs e)
        {
            bool contatoExiste = false;
            //if (FormularioContatoInvalido())
            //    return;

            List<Contato> contatos = GetSessionContatos();

            Contato novoContato = new Contato()
            {
                TipoContatoId = Convert.ToInt32(dropTipoContato.SelectedValue),
                Descricao = contato.Text
            };

            // Verifica se o contato já foi cadastrado anteriormente
            if (contatos != null)
                contatoExiste = contatos.Any(c => c.TipoContatoId.Equals(novoContato.TipoContatoId) && c.Descricao.Equals(novoContato.Descricao));
            
            if (!contatoExiste)
            {
                contatos.Add(novoContato);
                SetSessionContatos(contatos);
                ScriptManager.RegisterStartupScript(this, GetType(), "ContatoCadastrado", "Swal.fire('Contato adicionado!', 'Contato adicionado com sucesso!', 'success');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ContatoDuplicado", "Swal.fire('Contato duplicado!', 'Este contato já foi adicionado anteriormente.', 'error');", true);
                return;
            }

            ExibirContatos();
        }

        protected List<Contato> GetSessionContatosExcluidos()
        {
            return (List<Contato>)Session["ContatosExcluidos"];
        }

        private void CarregarContatosUsuario()
        {
            var contatos = GetSessionContatos();

            tabelaContatos.DataSource = contatos;
            tabelaContatos.DataBind();
        }

        #region METODOS PRIVADOS
        private void ExibirContatos()
        {
            dropTipoContato.SelectedIndex = 0;
            contato.Text = string.Empty;
            tabelaContatos.DataSource = GetSessionContatos();
            tabelaContatos.DataBind();
        }
        protected List<Contato> GetSessionContatos()
        {
            return (List<Contato>)Session["Contatos"];
        }

        protected void SetSessionContatos(List<Contato> contatos)
        {
            Session["Contatos"] = contatos;
        }

        protected string GetTipoContatoText(int tipoContato)
        {
            switch (tipoContato)
            {
                case 1:
                    return "Telefone Fixo";
                case 2:
                    return "Celular";
                default:
                    return string.Empty;
            }
        }
        private void SetCamposEndereco(ViaCepModel endereco)
        {
            logradouro.Text = ConvertToUtf8(endereco.Logradouro);
            complemento.Text = ConvertToUtf8(endereco.Complemento);
            cidade.Text = ConvertToUtf8(endereco.Bairro);
            estado.Text = ConvertToUtf8(endereco.Uf);
            pais.Text = "Brasil";
        }

        private void DesabilitarCampos(ViaCepModel endereco)
        {
            if (!string.IsNullOrEmpty(endereco.Logradouro))
                logradouro.Enabled = false;

            if (!string.IsNullOrEmpty(endereco.Complemento))
                complemento.Enabled = false;

            if (!string.IsNullOrEmpty(endereco.Localidade))
                cidade.Enabled = false;

            if (!string.IsNullOrEmpty(endereco.Uf))
                estado.Enabled = false;

            if (!string.IsNullOrEmpty(endereco.Cep))
                pais.Enabled = false;
        }

        private void LimparCamposEndereco()
        {
            logradouro.Text = "";
            complemento.Text = "";
            cidade.Text = "";
            estado.Text = "";
            pais.Text = "";
        }

        private string ConvertToUtf8(string input)
        {
            byte[] isoBytes = Encoding.GetEncoding("iso-8859-1").GetBytes(input);
            return Encoding.UTF8.GetString(isoBytes);
        }
        #endregion
    }
}