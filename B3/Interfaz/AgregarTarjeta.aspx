<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarTarjeta.aspx.cs" Inherits="B3.Interfaz.AgregarTarjeta" %>
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
        <div class="titulo">Registrar Tarjeta</div>
        <br/>
        <table>
            <tr>
                <td><asp:Label ID="Label1" class="lblRegistrar" runat="server" Text="Numero de Tarjeta:" /></td>
                <td><asp:TextBox ID="txtTarjeta" class="txt" runat="server" Height="20px" Width="200px" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" class="lblRegistrar" runat="server" Text="Tipo:" /></td>
                <td><asp:TextBox ID="txtTipo" Class="txt" runat="server" Height="20px" Width="200px" /></td>               
            </tr>
            <tr>
                <td><asp:Label ID="Label3" class="lblRegistrar" runat="server" Text="Fecha Expiracion:" /></td>
                <td><asp:TextBox ID="txtFecha" class="txt" runat="server" placeholder="1990" Height="20px" Width="200px"/></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label8" class="lblRegistrar" runat="server" Text="Saldo:" /></td>
                <td><asp:TextBox ID="txtSaldo" class="txt" runat="server" placeholder="10" Height="20px" Width="200px" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Image ID="imgError" Visible="false" class="imgError" runat="server" ImageUrl="/Images/error1.png" />
                    &nbsp;<asp:Label ID="msgError" class="error" runat="server" Text="" /></td>
            </tr>
            <tr>
                <td><br /><asp:Button class="btn" runat="server" Text="Registrarse" ID="btnRegistrar" OnClick="btnRegistrar_Click" /></td>
                <td><br /><asp:Button class="btn" runat="server" Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" NavigateUrl="~/Default.aspx" /></td>
            </tr>
        </table>
            <br />
                        <asp:Image ID="imgError2" Visible="false" class="imgError" runat="server" ImageUrl="/Images/error1.png" />
                            &nbsp;<asp:Label ID="msgError2" class="error" runat="server" Text="" />
                       <br/>
                    <asp:GridView ID="gvLibros" runat="server">
                    </asp:GridView>
    </div>
    </form>
    
</asp:Content>