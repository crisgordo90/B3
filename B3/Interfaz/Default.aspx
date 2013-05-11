<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="B3._Default" %>
<asp:Content ID="head2" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Body" runat="server">
    <form id="Principal" runat="server">
        <div class="inicio" runat="server">
            <nav class="menu" runat="server">
                <ul>
                    <li><a href="Default.aspx">Inicio</a></li>
                    <li><a href="AgregarPersona.aspx">Registrarse</a></li>
                     <li><a href="Buscar.aspx">Buscar</a></li>
                </ul>
            </nav>
            <div id="Login" class="login">
                <asp:TextBox class="txtLogin" ID="txtCorreo" TextMode="SingleLine" Placeholder="Correo" runat="server" Height="15px" />
                <asp:TextBox class="txtLogin" ID="txtContrasena" TextMode="Password" Placeholder="Contraseña" runat="server" Height="15px" />
                <asp:Button class="btn" ID="btnIniciarSesion" Text="Iniciar Sesión" runat="server" OnClick="btnIniciarSesion_Click" />
                <asp:Label class="" ID="LblLogin" Text="" runat="server" Visible="true"></asp:Label>
                 <br /><br />
                <asp:Image ID="imgError" Visible="false" class="imgError" runat="server" ImageUrl="/Images/error1.png" />
                    &nbsp;<asp:Label ID="msgError" class="error" runat="server" Text="" />
               
            </div>
        </div>
        <div class="register">
            <div class="titulo"></div>
            <hr />
            <asp:ImageButton ID="btnComprar" runat="server" class="RegistroImagen" ImageUrl="~/Images/banner.png" OnClick="btnComprar_Click"  /><br />
            <asp:ImageButton ID="btnAgregarLibro" runat="server" class="RegistroImagen" ImageUrl="~/Images/banner (1).png" OnClick="btnAgregarLibro_Click" Visible="false" /><br />
            <asp:ImageButton ID="btnAgregarAutor" runat="server" class="RegistroImagen" ImageUrl="~/Images/banner (2).png" OnClick="btnAgregarAutor_Click" Visible="false" /><br />
            <asp:ImageButton ID="btnEditarPersona" runat="server" class="RegistroImagen" ImageUrl="~/Images/banner (7).png" OnClick="btnEditarPersona_Click" Visible="false" /><br />
            <asp:ImageButton ID="btnEditarLibro" runat="server" class="RegistroImagen" ImageUrl="~/Images/banner (6).png" OnClick="btnEditarLibro_Click"  Visible="false" /><br />
            <asp:ImageButton ID="btnEditarAutor" runat="server" class="RegistroImagen" ImageUrl="~/Images/banner (5).png" OnClick="btnEditarAutor_Click"  Visible="false" /><br />
            <asp:ImageButton ID="btnVentas" runat="server" class="RegistroImagen" ImageUrl="~/Images/banner (9).png"   Visible="false" OnClick="btnVentas_Click"  /><br />
            <asp:ImageButton ID="btnAdeudo" runat="server" class="RegistroImagen" ImageUrl="~/Images/banner (10).png"  Visible="false" OnClick="btnAdeudo_Click"  /><br />
            <asp:ImageButton ID="btnBajaPersona" runat="server" class="RegistroImagen" ImageUrl="~/Images/banner (4).png" OnClick="btnBajaPersona_Click" Visible="false" /><br />
            <asp:ImageButton ID="btnBajaLibro" runat="server" class="RegistroImagen" ImageUrl="~/Images/banner (3).png" OnClick="btnBajaLibro_Click"  Visible="false" /><br />
             <asp:ImageButton ID="btnConfiguracion" runat="server" class="RegistroImagen" ImageUrl="~/Images/banner (8).png" OnClick="btnConfiguracion_Click"  Visible="false" /><br />
              
             
       
        </div>
        <div class="registrar">
    <div class="titulo">Libros</div>
             <br />
                <asp:Image ID="imgError2" Visible="false" class="imgError" runat="server" ImageUrl="/Images/error1.png" />
                    &nbsp;<asp:Label ID="msgError2" class="error" runat="server" Text="" />
        <br/>
            <asp:GridView ID="gvLibros" runat="server">
            </asp:GridView>
        </div>

         <br/><br/>
        <div class="registrar">
    <div class="titulo">BestSeller</div>
        <br/>
            <asp:GridView ID="gvBest" runat="server">
            </asp:GridView>

        </div>
    </form>
</asp:Content>


