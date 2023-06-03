<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalharUsuario.aspx.cs" Inherits="DesafioTecnicoSecSaude.DetalharUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <hr />
        <h3 class="my-3">Detalhes do Usuário</h3> 
        
        <div class="row">
            <div class="col-lg-12">
                <fieldset>
                    <legend> Dados Básicos</legend>
                </fieldset>
            </div>

            <div class="col-lg-6">
                <div class="form-group">
                    <label for="nome">Nome</label>
                    <asp:TextBox class="form-control" type="text" ID="nome" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="email">Email</label>
                    <asp:TextBox class="form-control" type="email" ID="email" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="cpf">CPF</label>
                    <asp:TextBox class="form-control" type="text" ID="cpf" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="senha">Senha</label>
                    <asp:TextBox class="form-control" type="password" ID="senha" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
            
            <div class="col-md-6">
                <div class="form-group">
                    <label for="dataNascimento">Data de Nascimento</label>
                    <asp:TextBox class="form-control" type="datetime" ID="dataNascimento" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="dropPerfis">Perfil</label>
                    <asp:DropDownList class="form-control" ID="dropPerfis" runat="server" Enabled="false">
                        <asp:ListItem Text="" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Administrador" Value="1"> </asp:ListItem>
                        <asp:ListItem Text="Supervisor" Value="2"> </asp:ListItem>
                        <asp:ListItem Text="Operador" Value="3"> </asp:ListItem>
                    </asp:DropDownList>
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
                <asp:GridView ID="tabelaContatos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <HeaderStyle BackColor="#2e6da4" ForeColor="White" Font-Bold="true" />
                    <Columns>
                       <asp:TemplateField HeaderText="Tipo de Contato">
                            <ItemTemplate>
                                <%# GetTipoContatoText(Convert.ToInt32(Eval("TipoContatoId"))) %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="Descricao" HeaderText="Contato" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <fieldset>
                    <legend> Endereço</legend>
                </fieldset>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="endereco">Endereço</label>
                    <asp:TextBox class="form-control" type="text" ID="endereco" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>  
        </div>

        <div class="row">
            <div class="col-lg-12">
                <fieldset>
                    <legend> Cadastro</legend>
                </fieldset>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <label for="dataCriacao">Data de Criação</label>
                    <asp:TextBox class="form-control" type="datetime" ID="dataCriacao" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <label for="dataAtualizacao">Data de Atualização</label>
                    <asp:TextBox class="form-control" type="datetime" ID="dataAtualizacao" runat="server" Enabled="false"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="col-md-12" style="padding:unset">
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="btn bg-gradient-secondary w-100 mt-2 mb-4" OnClick="btnVoltar_Click" />
        </div>
    </div>
</asp:Content>
