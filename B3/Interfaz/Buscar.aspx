<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="B3.Interfaz.Buscar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <form id="Form1" runat="server">
        <div id="Div1" runat="server">
            <div id="Div2" class="inicio" runat="server">
                <nav id="Nav1" class="menu" runat="server">
                    <ul>
                        <li><a href="Default.aspx">Inicio</a></li>
                        <li><a href="AgregarPersona.aspx">Registrarse</a></li>
                        <li><a href="Buscar.aspx">Buscar</a></li>
                    </ul>
                </nav>
            </div>
        </div>
        <div id="Div3" class="registrar" runat="server">
        <div class="titulo">Buscar Libro</div>
        <br/>
        <table>
            <tr>
                <td><asp:TextBox ID="txtNombre" class="txt" runat="server" Height="20px" Width="200px" /></td>
            </tr>
            <tr>
                <td><asp:Image ID="imgError" Visible="false" class="imgError" runat="server" ImageUrl="/Images/error1.png" />
                    &nbsp;<asp:Label ID="msgError" class="error" runat="server" Text="" /></td>
            </tr>
            <tr>
                <td><br /><asp:Button class="btn" runat="server" Text="Buscar" ID="btnRegistrar" OnClick="btnRegistrar_Click"/></td>
            </tr>
        </table>
    </div>
        <br />
        <div class="registrar" runat="server">
            <asp:GridView ID="gvBuscar" runat="server" OnSelectedIndexChanged="gvBuscar_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField SelectText="Comprar" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
    
</asp:Content>