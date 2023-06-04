<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalharUsuario.aspx.cs" Inherits="DesafioTecnicoSecSaude.DetalharUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <hr />
        <h3 class="my-3">Detalhes do Usuário</h3> 
        
                 <div class="row">
            <div class="col-lg-12">
                <fieldset>
                    <legend>Dados básicos</legend>
                </fieldset>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="nome">Nome</label>
                    <asp:TextBox ID="nome" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="nomeErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>

                <div class="form-group">
                    <label for="email">Email</label>
                    <asp:TextBox ID="email" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="emailErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>

                <div class="form-group">
                    <label for="cpf">CPF</label>
                    <asp:TextBox ID="cpf" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="cpfErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>

                <div class="form-group">
                    <label for="dataNascimento">Data de Nascimento</label>
                    <asp:TextBox ID="dataNascimento" type="datetime" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="dataNascimentoErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
                   
                <div class="form-group">
                    <label for="dropPerfis">Perfil</label>
                    <asp:DropDownList class="form-control" ID="dropPerfis" runat="server" Enabled="false">
                        <asp:ListItem Text="" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Administrador" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Supervisor" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Operador" Value="3"></asp:ListItem>
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
                    <legend>Endereço</legend>
                </fieldset>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="cep">CEP</label>
                    <asp:TextBox ID="cep" CssClass="form-control" runat="server"></asp:TextBox>
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

         <div class="row">
            <div class="col-lg-12">
                <fieldset>
                    <legend>Cadastro</legend>
                </fieldset>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="dataCriacao">Data de Cadastro</label>
                    <asp:TextBox ID="dataCriacao" type="datetime" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="dataCriacaoErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="dataAtualizacao">Data de Atualização</label>
                    <asp:TextBox ID="dataAtualizacao" type="datetime" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="dataAtualizacaoErro" runat="server" Text="" ForeColor="Red" Font-Size="Small"></asp:Label>
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-12">
                <asp:Button class="btn btn-primary" ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
