<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Configuracion.aspx.cs" Inherits="B3.Interfaz.Configuracion" %>
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
        <div class="titulo">Privilegios</div>
        <br/>
        <table>
            <tr>
                <td><asp:DropDownList ID="ddlNombre" class="txt" runat="server" Height="20px" Width="200px" /></td>
            </tr>
            <tr>
                <td><asp:Image ID="imgError" Visible="false" class="imgError" runat="server" ImageUrl="/Images/error1.png" />
                    &nbsp;<asp:Label ID="msgError" class="error" runat="server" Text="" /></td>
            </tr>
            <tr>
                <td><br />
                    <asp:Button class="btn" runat="server" Text="Consultor" ID="btnConsultor"  ToolTip="Solo puede registrarse, consultar y comprar" OnClick="btnConsultor_Click" />
                    <asp:Button class="btn" runat="server" Text="Mantenimiento" ID="btnMantenimiento" ToolTip="Puede Agregar, Modificar, Consultar y los privilegios de Consultor" OnClick="btnMantenimiento_Click" />
                    <asp:Button class="btn" runat="server" Text="Administrador" ID="btnAdministrador" ToolTip="Tiene todos lo privilegios de mantenimiento mas configuracion" OnClick="btnAdministrador_Click" />
                </td>
            </tr>
        </table>
    </div><div id="Div4" class="registrar" runat="server">
            <br />
                        <asp:Image ID="imgError2" Visible="false" class="imgError" runat="server" ImageUrl="/Images/error1.png" />
                            &nbsp;<asp:Label ID="msgError2" class="error" runat="server" Text="" />
                       <br/>
            <asp:GridView ID="gvBuscar" runat="server">
            </asp:GridView>

        </div>
    </form>
    
</asp:Content>