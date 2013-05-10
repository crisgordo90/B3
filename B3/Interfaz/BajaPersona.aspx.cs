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
    public partial class BajaPersona : System.Web.UI.Page
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
                gvBuscar.DataSource = name.querydt("select Nombre, 'activo' as Estado from tabla_Usuario where activo_usuario=1 union select nombre, 'inactivo' as Estado from tabla_Usuario where activo_usuario=0");
                gvBuscar.DataBind();
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
                imgError.Visible = true;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Interfaz/Default.aspx");
            Limpiar();
        }

        protected void Limpiar()
        {
            imgError.Visible = false;
        }

        protected void ConfiguracionTipo(string text)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                SqlCommand cmd = new SqlCommand(text, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = ddlNombre.SelectedValue;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dr.Close();
                con.Close();
                Response.Redirect("~/Interfaz/BajaPersona.aspx");
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }
            if (msgError.Text.Equals(""))
            {
                Limpiar();
            }
            else
            {
                imgError.Visible = true;
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            ConfiguracionTipo("activar_usuario");
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            ConfiguracionTipo("desactivar_usuario");
        }
    }
}