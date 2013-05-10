using B3.Clases;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B3.Interfaz
{
    public partial class AgregarPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            query name = new query();
            OracleConnection con = new OracleConnection(name.OracleConnString());
            OracleCommand cmd = new OracleCommand("insertar_usuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", OracleDbType.Varchar2).Value = txtNombre.Text;
            cmd.Parameters.Add("@contrasenia", OracleDbType.Varchar2).Value = txtContrasenia.Text;
            cmd.Parameters.Add("@direccion", OracleDbType.Varchar2).Value = txtDireccion.Text;
            cmd.Parameters.Add("@ciudad", OracleDbType.Varchar2).Value = txtCiudad.Text;
            cmd.Parameters.Add("@estado", OracleDbType.Varchar2).Value = txtEstado.Text;
            cmd.Parameters.Add("@codigo_postal", OracleDbType.Varchar2).Value = txtCodigoPostal.Text;
            cmd.Parameters.Add("@telefono", OracleDbType.Varchar2).Value = txtTelefono.Text;
            cmd.Parameters.Add("@email", OracleDbType.Varchar2).Value = txtCorreo.Text;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }

            if (msgError.Text.Equals(""))
            {
                msgError.Text = txtNombre.Text+" Se ha agregado con exito";
                Limpiar();
            }
            else
            {
                imgError.Visible = true;
            }
            con.Close();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Interfaz/Default.aspx");
            Limpiar();
        }

        protected void Limpiar()
        {
            imgError.Visible = false;
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEstado.Text = "";
            txtCiudad.Text = "";
            txtCodigoPostal.Text = "";
        }
    }
}