<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="AgregarLibro.aspx.cs" Inherits="B3.Interfaz.AgregarLibro" %>
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
        <div class="titulo">Registrar Libro</div>
        <br/>
        <table>
            <tr>
                <td><asp:Label ID="Label1" class="lblRegistrar" runat="server" Text="ISBM:" /></td>
                <td><asp:TextBox ID="txtISBM" class="txt" runat="server" placeholder="123456" Height="20px" Width="200px" /></td>
                <td><div class="asterisco"> *</div></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" class="lblRegistrar" runat="server" Text="Titulo:" /></td>
                <td><asp:TextBox ID="txtTitulo" Class="txt" runat="server" placeholder="Los Pollitos" Height="20px" Width="200px" /></td>
                <td><div class="asterisco"> *</div></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label3" class="lblRegistrar" runat="server" Text="Año Publicacion:" /></td>
                <td><asp:TextBox ID="txtAnio" class="txt" runat="server" placeholder="1990" Height="20px" Width="200px"/></td>
                <td><div class="asterisco"> *</div></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label8" class="lblRegistrar" runat="server" Text="Stock:" /></td>
                <td><asp:TextBox ID="txtStock" class="txt" runat="server" placeholder="10" Height="20px" Width="200px" /></td>
                <td><div class="asterisco"> *</div></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label4" class="lblRegistrar" runat="server" Text="Costo:" /></td>
                <td><asp:TextBox ID="txtCosto" class="txt" runat="server" placeholder="" Height="20px" Width="200px"/></td>
                <td><div class="asterisco"> *</div></td>
            </tr>
             <tr>
                <td><asp:Label ID="Label6" class="lblRegistrar" runat="server" Text="Autor(es):" /></td>
                <td> 
                    <asp:ListBox ID="lbxAutor" runat="server" Width="205px"  SelectionMode="Multiple" ></asp:ListBox>
                </td>
                <td>
                   <asp:DropDownList ID="ddlAutor" class="txt" runat="server" Height="20px" Width="200px"/>
                    <br /><asp:Button class="btn" runat="server" Text="Agregar" ID="btnAgregarAutor" OnClick="btnAgregarAutor_Click" /> 
                    <asp:Button class="btn" runat="server" Text="Eliminar" ID="btnEliminarAutor" OnClick="btnEliminarAutor_Click" /></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label5" class="lblRegistrar" runat="server" Text="Tema(s):" /></td>
                <td> <asp:ListBox ID="lbxTema" runat="server" Width="202px"  SelectionMode="Multiple" ></asp:ListBox>
                </td>
                <td>
                   <asp:DropDownList ID="ddlTema" class="txt" runat="server" Height="20px" Width="200px"/>
                    <br /><asp:Button class="btn" runat="server" Text="Agregar" ID="btnAgregarTema" OnClick="btnAgregarTema_Click" />
                    <asp:Button class="btn" runat="server" Text="Eliminar" ID="btnEliminarTema" OnClick="btnEliminarTema_Click" />
                </td>
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