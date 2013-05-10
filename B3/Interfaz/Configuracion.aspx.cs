using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B3.Clases;
using System.Configuration;
using System.Data;
using Oracle.DataAccess.Client;

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
                query name = new query();
                OracleConnection con = new OracleConnection(name.OracleConnString());
                OracleCommand cmd = new OracleCommand("modificar_privilegios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", OracleDbType.Varchar2).Value = ddlNombre.SelectedValue;
                cmd.Parameters.Add("@privilegio", OracleDbType.Varchar2).Value = tipo;
                con.Open();
                OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
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