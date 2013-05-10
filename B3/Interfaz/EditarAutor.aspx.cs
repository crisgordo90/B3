using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B3.Clases;
using Oracle.DataAccess.Client;

namespace B3.Interfaz
{
    public partial class EditarAutor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                query name = new query();
                if (!IsPostBack)
                {
                    ddlNombre.DataSource = name.querydt("select * from tabla_Autor");
                    ddlNombre.DataTextField = "Nombre";
                    ddlNombre.DataValueField = "id_Autor";
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
            query name = new query();
            OracleConnection con = new OracleConnection(name.OracleConnString());
            OracleCommand cmd = new OracleCommand("modificar_autor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", OracleDbType.Varchar2).Value = txtNombre.Text;
            cmd.Parameters.Add("@fecha_nac", OracleDbType.Varchar2).Value = txtNacimiento.Text;
            cmd.Parameters.Add("@fecha_fallecimiento", OracleDbType.Varchar2).Value = txtFallecimiento.Text;
            cmd.Parameters.Add("@pais", OracleDbType.Varchar2).Value = txtPais.Text;
            cmd.Parameters.Add("@biografia", OracleDbType.Varchar2).Value = txtBiografia.Text;

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
            txtNacimiento.Text = "";
            txtFallecimiento.Text = "";
            txtPais.Text = "";
            txtBiografia.Text = "";
        }
        protected void btnCargar_Click(object sender, EventArgs e)
        {
            query name = new query();
            DataTable table = name.querydt("select nombre, fecha_nac,	pais, fecha_fallecimiento, biografia from tabla_Autor where id_Autor='" + ddlNombre.SelectedValue + "'");
            if (table != null)
            {
                txtNombre.Text = table.Rows[0].ItemArray[0].ToString();
                txtNacimiento.Text = table.Rows[0].ItemArray[1].ToString();
                txtFallecimiento.Text = table.Rows[0].ItemArray[2].ToString();
                txtPais.Text = table.Rows[0].ItemArray[3].ToString();
                txtBiografia.Text = table.Rows[0].ItemArray[4].ToString();
            }
        }

    }
}