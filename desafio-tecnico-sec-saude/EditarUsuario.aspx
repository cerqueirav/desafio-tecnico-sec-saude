<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="DesafioTecnicoSecSaude.EditarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <hr />
        <h3 class="my-3">Editar Usuário</h3> 
        
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
                    <asp:TextBox class="form-control" type="text" ID="cpf" runat="server"></asp:TextBox>
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
                        <asp:ListItem Text="" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Administrador" Value="1"> </asp:ListItem>
                        <asp:ListItem Text="Supervisor" Value="2"> </asp:ListItem>
                        <asp:ListItem Text="Operador" Value="3"> </asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="perfilErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <fieldset>
                    <legend>Contato</legend>
                </fieldset>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="telefone">Telefone</label>
                    <asp:TextBox class="form-control" type="text" ID="telefone" runat="server"></asp:TextBox>
                    <asp:Label ID="telefoneErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
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
                    <label for="endereco">Endereço</label>
                    <asp:TextBox class="form-control" type="text" ID="endereco" runat="server"></asp:TextBox>
                    <asp:Label ID="enderecoErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>  
        </div>

        <div class="col-md-12" style="padding:unset">
            <asp:Button ID="SalvarEdicao" runat="server" Text="Salvar" CssClass="btn bg-gradient-info w-100 mt-2 mb-4" OnClick="SalvarEdicao_Click" />
        </div>
    </div>
</asp:Content>
