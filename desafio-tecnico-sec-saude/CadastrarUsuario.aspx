<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastrarUsuario.aspx.cs" Inherits="DesafioTecnicoSecSaude.CadastrarUsuario" %>
<%@ Import Namespace="DesafioTecnicoSecSaude.Usuarios.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.inputmask/5.0.6/jquery.inputmask.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>

    <div class="container">
        <hr />
        <h3 class="my-3">Cadastro de Usuário</h3> 
          
        <div class="row">
            <div class="col-lg-12">
                <fieldset>
                    <legend>Dados Básicos</legend>
                </fieldset>
            </div>

            <div class="col-lg-6">
                <div class="form-group">
                    <label for="nome">Nome</label>
                    <asp:TextBox class="form-control" type="text" ID="nome" runat="server"></asp:TextBox>
                    <asp:Label ID="nomeErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="email">Email</label>
                    <asp:TextBox class="form-control" type="email" ID="email" runat="server"></asp:TextBox>
                    <asp:Label ID="emailErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="cpf">CPF</label>
                    <asp:TextBox class="form-control mask-cpf" type="text" ID="cpf" runat="server"></asp:TextBox>
                    <asp:Label ID="cpfErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="senha">Senha</label>
                    <asp:TextBox class="form-control" type="password" ID="senha" runat="server"></asp:TextBox>
                    <asp:Label ID="senhaErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>
            
            <div class="col-md-6">
                <div class="form-group">
                    <label for="dataNascimento">Data de Nascimento</label>
                    <asp:TextBox class="form-control" type="date" ID="dataNascimento" runat="server"></asp:TextBox>
                    <asp:Label ID="dataNascimentoErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="dropPerfis">Perfil</label>
                    <asp:DropDownList class="form-control" ID="dropPerfis" runat="server">
                        <asp:ListItem Text="Selecione um Perfil" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Administrador" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Supervisor" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Operador" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="perfilErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <fieldset>
                    <legend>Contatos</legend>
                </fieldset>  
            </div>
           
            <div class="col-md-6">
                <asp:GridView ID="tabelaContatos" runat="server" AutoGenerateColumns="False" 
                    OnRowCommand="grdDados_RowCommand" CssClass="table table-striped">
                    <HeaderStyle BackColor="#2e6da4" ForeColor="White" Font-Bold="true" />
                    <Columns>
                       <asp:TemplateField HeaderText="Tipo de Contato">
                            <ItemTemplate>
                                <%# GetTipoContatoText(Convert.ToInt32(Eval("TipoContatoId"))) %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Descricao" HeaderText="Contato" />
                        <asp:TemplateField>
                           <ItemTemplate>
                                <div class="btn-group">
                                    <asp:Button ID="btnExcluirContato" runat="server" CommandName="ExcluirContato" Text="Remover"  CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-sm btn-primary" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                <div class="form-group">
                    <label for="dropTipoContato">Tipo de Contato</label>
                    <asp:DropDownList class="form-control" ID="dropTipoContato" runat="server">
                        <asp:ListItem Text="Selecione o tipo do contato" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Telefone Fixo" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Celular" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="tipoContatoErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>
            <div class="col-md-3">
                <div class="form-group">
                    <label for="contato">Contato</label>
                    <asp:TextBox class="form-control mask-telefone" type="text" ID="contato" runat="server"></asp:TextBox>
                    <asp:Label ID="contatoErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>

            <div class="col-md-12" style="margin-bottom: 2%">
                <asp:Button ID="btnAdicionarContato" runat="server" Text="Adicionar Contato" CssClass="btn btn-primary" OnClick="btnAdicionarContato_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <fieldset>
                    <legend>Endereço</legend>
                </fieldset>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="cep">CEP</label>
                    <asp:TextBox ID="cep" CssClass="form-control mask-cep" runat="server"  OnTextChanged="carregarEndereco" AutoPostBack="true" ></asp:TextBox>
                    <asp:Label ID="cepErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="logradouro">Logradouro</label>
                    <asp:TextBox ID="logradouro" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="logradouroErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="complemento">Complemento</label>
                    <asp:TextBox ID="complemento" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="complementoErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="numero">Número</label>
                    <asp:TextBox ID="numero" CssClass="form-control" runat="server"></asp:TextBox>
                     <asp:Label ID="numeroErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="cidade">Cidade</label>
                    <asp:TextBox ID="cidade" CssClass="form-control" runat="server"></asp:TextBox>
                     <asp:Label ID="cidadeErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="estado">Estado</label>
                    <asp:TextBox ID="estado" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="estadoErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="pais">País</label>
                    <asp:TextBox ID="pais" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="paisErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>
        </div>

        <div class="col-md-12" style="padding:unset">
            <asp:Button ID="EnviarCadastro" runat="server" Text="Salvar" CssClass="btn btn-success bg-success w-100 mt-2 mb-4"  OnClick="CadastrarUsuario_Click" />
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.mask-cpf').inputmask('999.999.999-99');
            $('.mask-telefone').inputmask('(99) 9999-9999');
            $('.mask-cep').mask('00000-000');
        });
    </script>
</asp:Content>
