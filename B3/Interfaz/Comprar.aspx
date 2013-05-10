<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Comprar.aspx.cs" Inherits="B3.Interfaz.Comprar" %>
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
        <div class="titulo">Comprar</div>
        <br/>
        <table>
            <tr>
                <td><asp:Label ID="Label1" class="lblRegistrar" runat="server" Text="Nombre Libro:" /></td>
                <td><asp:Label ID="lblTitulo" text="" class="txt" runat="server" Height="20px" Width="200px" /></td>
            </tr>
            <tr> 
                <td><asp:Label ID="Label3" class="lblRegistrar" runat="server" Text="Costo:" /></td>
                <td><asp:Label ID="lblCosto" text="" class="txt" runat="server" Height="20px" Width="200px" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" Class="lblRegistrar" runat="server" Text="Nombre:"/></td>
                <td><asp:Label ID="lblUsuario" Class="lblRegistrar" runat="server" Text="" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label4" Class="lblRegistrar" runat="server" Text="Tarjeta:"/></td>
               <td><asp:Label ID="lblTarjeta" Class="lblRegistrar" runat="server" Text=""/></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label8" class="lblRegistrar" runat="server" Text="Cantidad:" /></td>
                <td><asp:TextBox ID="txtCantidad" class="txt" runat="server" placeholder="" Height="20px" Width="200px" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Image ID="imgError" Visible="false" class="imgError" runat="server" ImageUrl="/Images/error1.png" />
                    &nbsp;<asp:Label ID="msgError" class="error" runat="server" Text="" /></td>
            </tr>
            <tr>
                <td><br /><asp:Button class="btn" runat="server" Text="Comprar" ID="btnComprar" OnClick="btnComprar_Click"  /></td>
                <td><br /><asp:Button class="btn" runat="server" Text="Cancelar" ID="btnCancelar"  NavigateUrl="~/Default.aspx" /></td>
            </tr>
           
        </table>
    </div>
        
    </form>
    
</asp:Content>