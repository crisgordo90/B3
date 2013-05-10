using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B3.Clases;

namespace B3.Interfaz
{
    public partial class EditarPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                query name = new query();
                if (!IsPostBack)
                {
                    ddlNombre.DataSource = name.querydt("select * from tabla_Usuario");
                    ddlNombre.DataTextField = "Nombre";
                    ddlNombre.DataValueField = "Email";
                    ddlNombre.DataBind();
                }
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
                imgError.Visible = true;
            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("modificar_usuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtNombre.Text;
            cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = txtDireccion.Text;
            cmd.Parameters.Add("@ciudad", SqlDbType.VarChar).Value = txtCiudad.Text;
            cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = txtEstado.Text;
            cmd.Parameters.Add("@codigo_postal", SqlDbType.VarChar).Value = txtCodigoPostal.Text;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar).Value = txtTelefono.Text;

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
                msgError.Text = "Se ha actualizado con exito";
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
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            msgError.Text = "";
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            query name = new query();
            DataTable table = name.querydt("select nombre, direccion,	ciudad,	estado,	codigo_postal, telefono from tabla_Usuario where email='" + ddlNombre.SelectedValue + "'");
            if (table != null)
            {
                txtNombre.Text = table.Rows[0].ItemArray[0].ToString();
                txtDireccion.Text = table.Rows[0].ItemArray[1].ToString();
                txtCiudad.Text = table.Rows[0].ItemArray[2].ToString();
                txtEstado.Text = table.Rows[0].ItemArray[3].ToString();
                txtCodigoPostal.Text = table.Rows[0].ItemArray[4].ToString();
                txtTelefono.Text = table.Rows[0].ItemArray[5].ToString();
            }
        }    
    }
}