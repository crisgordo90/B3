<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="EditarPersona.aspx.cs" Inherits="B3.Interfaz.EditarPersona" %>
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
        <div class="titulo">Editar Usuario</div>
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
                <td><asp:Label ID="Label3" class="lblRegistrar" runat="server" Text="Teléfono:" /></td>
                <td><asp:TextBox ID="txtTelefono" class="txt" runat="server" placeholder="506-4354-4323" Height="20px" Width="200px"/></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label8" class="lblRegistrar" runat="server" Text="Ciudad:" /></td>
                <td><asp:TextBox ID="txtCiudad" class="txt" runat="server" placeholder="" Height="20px" Width="200px" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label4" class="lblRegistrar" runat="server" Text="Estado:" /></td>
                <td><asp:TextBox ID="txtEstado" class="txt" runat="server" placeholder="" Height="20px" Width="200px"/></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label5" class="lblRegistrar" runat="server" Text="Codigo Postal:" /></td>
                <td><asp:TextBox ID="txtCodigoPostal" class="txt" runat="server" placeholder="" Height="20px" Width="200px"/></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label7" class="lblRegistrar" runat="server" Text="Dirección:" /></td>
                <td><asp:TextBox ID="txtDireccion" class="txta" runat="server" TextMode="MultiLine" Width="200px" /></td>
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