using DesafioTecnicoSecSaude.Usuarios.Controller;
using DesafioTecnicoSecSaude.Usuarios.DTO;
using DesafioTecnicoSecSaude.Utils;
using System;
using System.Web.UI;

namespace DesafioTecnicoSecSaude
{
    public partial class CadastrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CadastrarUsuario_Click(object sender, EventArgs e)
        {
            if (FormularioInvalido())
                return;
           
            UsuarioController usuarioController = new UsuarioController();

            UsuarioDTO usuarioDTO = new UsuarioDTO(nome.Text
                                                , email.Text
                                                , senha.Text
                                                , cpf.Text
                                                , DateTime.Parse(dataNascimento.Text)
                                                , telefone.Text
                                                , dropPerfis.SelectedValue
                                                , endereco.Text
                                                );

            usuarioController.Cadastrar(usuarioDTO);
        }

        private void InicializarCampos()
        {
            nomeErro.Text = string.Empty;
            emailErro.Text = string.Empty;
            cpfErro.Text = string.Empty;
            perfilErro.Text = string.Empty;
            senhaErro.Text = string.Empty;
            dataNascimentoErro.Text = string.Empty;
            telefoneErro.Text = string.Empty;
            enderecoErro.Text = string.Empty;
        }

        private bool FormularioInvalido()
        {
            bool temDivergencia = false;

            InicializarCampos();

            #region NOME COMPLETO
            if (string.IsNullOrEmpty(nome.Text))
            {
                nomeErro.Text = "Informe o nome do usuário";
                temDivergencia = true;
            }
            else if (nome.Text.Length > 200)
            {
                nomeErro.Text = "O campo nome não deve ter mais que 200 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region EMAIL
            if (string.IsNullOrEmpty(email.Text))
            {
                emailErro.Text = "Informe o email do usuário";
                temDivergencia = true;
            }
            else if (!Validation.ValidarEmail(email.Text))
            {
                emailErro.Text = "O e-mail informado é inválido!";
                temDivergencia = true;
            }
            else if (email.Text.Length > 200)
            {
                emailErro.Text = "O campo e-mail não deve ter mais que 200 caracteres";
                temDivergencia = true;
            }

            #endregion

            #region SENHA
            if (string.IsNullOrEmpty(senha.Text))
            {
                senhaErro.Text = "Informe a senha do usuário";
                temDivergencia = true;
            }
            else if (senha.Text.Length > 100)
            {
                senhaErro.Text = "O campo senha não deve ter mais que 100 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region PERFIL
            var perfis = dropPerfis.SelectedValue;
            if (dropPerfis.SelectedValue == "-1")
            {
                perfilErro.Text = "O perfil deve ser selecionado";
                temDivergencia = true;
            }
            #endregion

            #region TELEFONE
            if (string.IsNullOrEmpty(telefone.Text))
            {
                telefoneErro.Text = "Informe o telefone do usuário";
                temDivergencia = true;
            }
            else if (telefone.Text.Length > 200)
            {
                enderecoErro.Text = "O campo telefone não deve ter mais do que 200 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region ENDERECO
            if (string.IsNullOrEmpty(endereco.Text))
            {
                enderecoErro.Text = "Informe o endereço do usuário";
                temDivergencia = true;
            }
            else if (endereco.Text.Length > 200)
            {
                enderecoErro.Text = "O campo endereço não deve ter mais do que 200 caracteres";
                temDivergencia = true;
            }
            #endregion

            #region CPF
            if (string.IsNullOrEmpty(cpf.Text))
            {
                cpfErro.Text = "Informe o CPF do usuário";
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
                dataNascimentoErro.Text = "Informe a data de nascimento do usuário";
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

            return temDivergencia;
        }
    }
}