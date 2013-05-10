<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="EditarAutor.aspx.cs" Inherits="B3.Interfaz.EditarAutor" %>
<asp:Content ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ContentPlaceHolderID="Body" runat="server">
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
        <div class="titulo">Editar Autor</div>
        <br/>
        <table>
            <tr><td><asp:Label ID="Label6" class="lblRegistrar" runat="server" Text="Nombre Completo:" /></td>
                <td><asp:DropDownList ID="ddlNombre" class="txt" runat="server" Height="20px" Width="200px"/></td>
                <td><asp:Button class="btn" runat="server" Text="Cargar" ID="btnCargar" OnClick="btnCargar_Click" /></td>
            </tr>
            <tr>
                <td><asp:Image ID="imgError2" Visible="false" class="imgError" runat="server" ImageUrl="/Images/error1.png" />
                    &nbsp;<asp:Label ID="msgError2" class="error" runat="server" Text="" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label1" class="lblRegistrar" runat="server" Text="Nombre Completo:" /></td>
                <td><asp:TextBox ID="txtNombre" class="txt" runat="server" Height="20px" Width="200px" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" class="lblRegistrar" runat="server" Text="Fecha Nacimiento:" /></td>
                <td><asp:TextBox ID="txtNacimiento" Class="txt" runat="server" placeholder="13/01/2013" Height="20px" Width="200px" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" class="lblRegistrar" runat="server" Text="Fecha Fallecimiento:" /></td>
                <td><asp:TextBox ID="txtFallecimiento" class="txt" runat="server" placeholder="13/01/2013" Height="20px" Width="200px"/></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label4" class="lblRegistrar" runat="server" Text="Pais:" /></td>
                <td><asp:TextBox ID="txtPais" class="txt" runat="server" placeholder="" Height="20px" Width="200px"/></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label7" class="lblRegistrar" runat="server" Text="Biografia:" /></td>
                <td><asp:TextBox ID="txtBiografia" class="txta" runat="server" TextMode="MultiLine" Width="200px" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Image ID="imgError" Visible="false" class="imgError" runat="server" ImageUrl="/Images/error1.png" />
                    &nbsp;<asp:Label ID="msgError" class="error" runat="server" Text="" /></td>
            </tr>
            <tr>
                <td><br /><asp:Button class="btn" runat="server" Text="Actualizar" ID="btnRegistrar" OnClick="btnRegistrar_Click" /></td>
                <td><br /><asp:Button class="btn" runat="server" Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" NavigateUrl="~/Default.aspx" /></td>
            </tr>
        </table>
    </div>
    </form>
    
</asp:Content>