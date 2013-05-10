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
    public partial class AgregarAutor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                query name = new query();
                msgError2.Text = "Ultimo agregado";
                gvAutores.DataSource = name.querydt("select * from tabla_Autor where id_autor=(select max(id_autor) from tabla_Autor)");
                gvAutores.DataBind();
            }
            catch (Exception ex)
            {
                msgError2.Text = ex.Message;
                imgError2.Visible = true;
            }
        }
            
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            query name = new query();
            OracleConnection con = new OracleConnection(name.OracleConnString());
            OracleCommand cmd = new OracleCommand("insertar_autor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", OracleDbType.Varchar2).Value = txtNombre.Text;
            cmd.Parameters.Add("@fecha_nac", OracleDbType.Date).Value = txtNacimiento.Text;
            cmd.Parameters.Add("@fecha_fallecimiento", OracleDbType.Date).Value = txtFallecimiento.Text;
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
                Response.Redirect("~/Interfaz/AgregarAutor.aspx");
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
            txtNombre.Text="";
            txtNacimiento.Text="";
            txtFallecimiento.Text="";
            txtEdad.Text="";
            txtPais.Text="";
            txtBiografia.Text="";
        }

    }
}