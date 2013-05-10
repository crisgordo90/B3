using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B3.Clases;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace B3.Interfaz
{
    public partial class Configuracion : System.Web.UI.Page
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
                gvBuscar.DataSource = name.querydt("(select nombre, 'Administrador' as tipo  from tabla_Usuario u where privilegio=3) union (select nombre, 'Modificador' as tipo from tabla_Usuario where privilegio=2) union (select nombre, 'Consultor' as tipo from tabla_Usuario where privilegio=1)");
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

        protected void ConfiguracionTipo(int tipo)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                SqlCommand cmd = new SqlCommand("modificar_privilegios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = ddlNombre.SelectedValue;
                cmd.Parameters.Add("@privilegio", SqlDbType.VarChar).Value = tipo;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dr.Close();
                con.Close();
                Response.Redirect("~/Interfaz/Configuracion.aspx");
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
        
        protected void btnConsultor_Click(object sender, EventArgs e)
        {
            ConfiguracionTipo(1);
        }

        protected void btnMantenimiento_Click(object sender, EventArgs e)
        {
            ConfiguracionTipo(2);
        }

        protected void btnAdministrador_Click(object sender, EventArgs e)
        {
            ConfiguracionTipo(3);
        }
    }
}