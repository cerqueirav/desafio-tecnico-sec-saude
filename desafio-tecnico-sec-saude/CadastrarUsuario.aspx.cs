using DesafioTecnicoSecSaude.Usuarios.Controller;
using DesafioTecnicoSecSaude.Usuarios.DTO;
using DesafioTecnicoSecSaude.Utils;
using DesafioTecnicoSecSaude.Utils.Viacep.Model;
using DesafioTecnicoSecSaude.Utils.Viacep.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DesafioTecnicoSecSaude
{
    public partial class CadastrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SetSessionContatos(new List<ContatoDTO>());
        }
        protected void CadastrarUsuario_Click(object sender, EventArgs e)
        {
            if (FormularioInvalido())
                return;
            try
            {
                UsuarioController usuarioController = new UsuarioController();

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

                UsuarioCadastrarDTO usuarioDTO = new UsuarioCadastrarDTO()
                {
                    Nome = nome.Text,
                    Email = email.Text,
                    Senha = senha.Text,
                    CPF = cpf.Text,
                    DataNascimento = DateTime.Parse(dataNascimento.Text),
                    Perfil = dropPerfis.SelectedValue,
                    Contatos = GetSessionContatos(),
                    Endereco = endereco
                };

                usuarioController.Cadastrar(usuarioDTO);
                ScriptManager.RegisterStartupScript(this, GetType(), "UsuarioCadastrado", "Swal.fire('Usuário cadastrado!', 'O usuário foi cadastrado com sucesso!', 'success');", true);
            }
            catch(Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ErroCadastrarUsuario", "Swal.fire('Erro ao cadastrar!', 'Ocorreu um erro durante o processamento das informações!', 'error');", true);
            }
            Response.Redirect("~/ConsultarUsuarios.aspx");
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
            catch(Exception )
            {
                cepErro.Text = "O CEP informado é inválido!";
            }
        }

        protected void btnAdicionarContato_Click(object sender, EventArgs e)
        {
            if (FormularioContatoInvalido())
                return;

            List<ContatoDTO> contatos = GetSessionContatos();

            ContatoDTO novoContato = new ContatoDTO()
            {
                TipoContatoId = Convert.ToInt32(dropTipoContato.SelectedValue),
                Descricao = contato.Text
            };

            // Verifica se o contato já foi cadastrado anteriormente
            bool contatoExiste = contatos.Any(c => c.TipoContatoId.Equals(novoContato.TipoContatoId) && c.Descricao.Equals(novoContato.Descricao));
            
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

        protected void grdDados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<ContatoDTO> contatos = GetSessionContatos();

            if (e.CommandName.Equals("ExcluirContato"))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                contatos.RemoveAt(rowIndex);
                SetSessionContatos(contatos);

                ScriptManager.RegisterStartupScript(this, GetType(), "ContatoRemovido", "Swal.fire('Contato removido!', 'Contato removido com sucesso!', 'success');", true);

                ExibirContatos();
            }
        }

        private void InicializarCampos()
        {
            nomeErro.Text = string.Empty;
            emailErro.Text = string.Empty;
            cpfErro.Text = string.Empty;
            perfilErro.Text = string.Empty;
            senhaErro.Text = string.Empty;
            dataNascimentoErro.Text = string.Empty;
            cepErro.Text = string.Empty;
            logradouroErro.Text = string.Empty;
            complementoErro.Text = string.Empty;
            numeroErro.Text = string.Empty;
            cidadeErro.Text = string.Empty;
            estadoErro.Text = string.Empty;
            paisErro.Text = string.Empty;
        }

        private void InicializarCamposContato()
        {
            tipoContatoErro.Text = string.Empty;
            contatoErro.Text = string.Empty;
        }

        private bool FormularioInvalido()
        {
            bool temDivergencia = false;

            InicializarCampos();

            #region NOME COMPLETO
            if (string.IsNullOrEmpty(nome.Text))
            {
                nomeErro.Text = "Informe o nome";
                temDivergencia = true;
            }
            else if (nome.Text.Length > 200)
            {
                nomeErro.Text = "O nome deve ter no máximo 200 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region EMAIL
            if (string.IsNullOrEmpty(email.Text))
            {
                emailErro.Text = "Informe o email";
                temDivergencia = true;
            }
            else if (!Validation.ValidarEmail(email.Text))
            {
                emailErro.Text = "O e-mail informado é inválido!";
                temDivergencia = true;
            }
            else if (email.Text.Length > 200)
            {
                emailErro.Text = "O e-mail deve ter no máximo 200 caracteres";
                temDivergencia = true;
            }

            #endregion

            #region SENHA
            if (string.IsNullOrEmpty(senha.Text))
            {
                senhaErro.Text = "Informe a senha";
                temDivergencia = true;
            }
            else if (senha.Text.Length > 200)
            {
                senhaErro.Text = "A senha deve ter no máximo 100 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region PERFIL
            if (dropPerfis.SelectedValue == "-1")
            {
                perfilErro.Text = "O perfil deve ser selecionado";
                temDivergencia = true;
            }
            #endregion

            #region CPF
            if (string.IsNullOrEmpty(cpf.Text))
            {
                cpfErro.Text = "Informe o CPF";
                temDivergencia = true;
            }
            else if (!Validation.ValidarCpf(cpf.Text))
            {
                cpfErro.Text = "O CPF informado é inválido!";
                temDivergencia = true;
            }
            else if (cpf.Text.Length > 14)
            {
                cpfErro.Text = "O campo CPF não deve ter mais que 11 caracteres";
                temDivergencia = true;
            }

            #endregion

            #region DATA DE NASCIMENTO
            if (string.IsNullOrEmpty(dataNascimento.Text))
            {
                dataNascimentoErro.Text = "Informe a data de nascimento";
                temDivergencia = true;
            }
            else if (!Validation.ValidarData(dataNascimento.Text))
            {
                dataNascimentoErro.Text = "A data de nascimento informada é inválida!";
                temDivergencia = true;
            }
            else if (!string.IsNullOrEmpty(dataNascimento.Text))
            {
                var data = DateTime.Parse(dataNascimento.Text);
                if (data == DateTime.MinValue)
                {
                    dataNascimentoErro.Text = "A data de nascimento informada é inválida!";
                    temDivergencia = true;
                }
            }
            #endregion

            #region CEP
            if (string.IsNullOrEmpty(cep.Text))
            {
                cepErro.Text = "Informe o CEP";
                temDivergencia = true;
            }
            else if (cep.Text.Length > 100)
            {
                cepErro.Text = "O CEP deve ter no máximo 100 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region LOGRADOURO
            if (string.IsNullOrEmpty(logradouro.Text))
            {
                logradouroErro.Text = "Informe o logradouro";
                temDivergencia = true;
            }
            else if (logradouro.Text.Length > 100)
            {
                logradouroErro.Text = "O logradouro deve ter no máximo 100 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region COMPLEMENTO
            else if (complemento.Text.Length > 200)
            {
                complementoErro.Text = "O complemento deve ter no máximo 200 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region NUMERO
            if (string.IsNullOrEmpty(numero.Text))
            {
                numeroErro.Text = "Informe o número";
                temDivergencia = true;
            }
            else if (numero.Text.Length > 100)
            {
                numeroErro.Text = "O número deve ter no máximo 100 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region CIDADE
            if (string.IsNullOrEmpty(cidade.Text))
            {
                cidadeErro.Text = "Informe a cidade";
                temDivergencia = true;
            }
            else if (cidade.Text.Length > 100)
            {
                cidadeErro.Text = "A cidade deve ter no máximo 100 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region ESTADO
            if (string.IsNullOrEmpty(estado.Text))
            {
                estadoErro.Text = "Informe o estado (UF)";
                temDivergencia = true;
            }
            else if (estado.Text.Length > 100)
            {
                estadoErro.Text = "O estado deve ter no máximo 100 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region PAÍS
            if (string.IsNullOrEmpty(pais.Text))
            {
                paisErro.Text = "Informe o país";
                temDivergencia = true;
            }
            else if (pais.Text.Length > 100)
            {
                paisErro.Text = "O país deve ter no máximo 100 caracteres";
                temDivergencia = true;
            }
            #endregion

            return temDivergencia;
        }

        private bool FormularioContatoInvalido()
        {
            bool temDivergencia = false;

            InicializarCamposContato();

            #region TIPO DE CONTATO
            if (dropTipoContato.SelectedValue == "-1")
            {
                tipoContatoErro.Text = "O tipo do contato deve ser selecionado";
                temDivergencia = true;
            }
            #endregion

            #region DESCRICAO
            if (string.IsNullOrEmpty(contato.Text))
            {
                contatoErro.Text = "O contato deve ser informado";
                temDivergencia = true;
            }
            else if (!Validation.ValidarContato(contato.Text))
            {
                contatoErro.Text = "O contato informado é inválido!";
                temDivergencia = true;
            }
            else if (contatoErro.Text.Length > 50)
            {
                contatoErro.Text = "O contato deve ter no máximo 50 caracteres";
                temDivergencia = true;
            }
            #endregion

            return temDivergencia;
        }
        
        private void ExibirContatos()
        {
            dropTipoContato.SelectedIndex = 0;
            contato.Text = string.Empty;
            tabelaContatos.DataSource = GetSessionContatos();
            tabelaContatos.DataBind();
        }

        protected List<ContatoDTO> GetSessionContatos()
        {
            return (List<ContatoDTO>)Session["Contatos"];
        }

        protected void SetSessionContatos(List<ContatoDTO> contatos)
        {
            Session["Contatos"] = contatos;
        }

        #region METODOS PRIVADOS
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