<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VentasAdeudos.aspx.cs" Inherits="B3.Interfaz.VentasAdeudos" %>
<asp:Content ID="head2" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">
    <form id="Principal" runat="server">
        <div id="Div1" class="inicio" runat="server">
            <nav id="Nav1" class="menu" runat="server">
                <ul>
                    <li><a href="Default.aspx">Inicio</a></li>
                    <li><a href="AgregarPersona.aspx">Registrarse</a></li>
                     <li><a href="Buscar.aspx">Buscar</a></li>
                </ul>
            </nav>
        </div>
        <div id="Div3" class="registrar" runat="server">
    <div class="titulo">Adeudos</div>
             <br />
                <asp:Image ID="imgError2" Visible="false" class="imgError" runat="server" ImageUrl="/Images/error1.png" />
                    &nbsp;<asp:Label ID="msgError2" class="error" runat="server" Text="" />
        <br/>
            <asp:GridView ID="gvLibros" runat="server">
            </asp:GridView>
        </div>
    </form>
    </asp:Content>