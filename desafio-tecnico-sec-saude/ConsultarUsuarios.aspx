<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarUsuarios.aspx.cs" Inherits="DesafioTecnicoSecSaude.ConsultarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar Usuário" CssClass="btn btn-primary w-100 mt-2 mb-4" OnClick="CadastroUsuario_Click" />
    <h2>Listagem de Usuários</h2>
    <div class="table-responsive">
        <asp:GridView ID="grdDados" runat="server" AutoGenerateColumns="false" OnRowCommand="grdDados_RowCommand" CssClass="table table-striped">
            <HeaderStyle BackColor="#2e6da4" ForeColor="White" Font-Bold="true" />
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="DataNascimento" HeaderText="Data de Nascimento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="DataCriacao" HeaderText="Data de Cadastro" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:TemplateField>
                   <ItemTemplate>
                        <div class="btn-group">
                            <asp:Button ID="btnDetalhar" runat="server" CommandName="Detalhar" Text="Detalhar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' CssClass="btn btn-sm btn-primary" />
                            <asp:Button ID="btnEditar" runat="server" CommandName="Editar" Text="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id") %>' CssClass="btn btn-sm btn-primary" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
