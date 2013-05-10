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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("insertar_autor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtNombre.Text;
            cmd.Parameters.Add("@fecha_nac", SqlDbType.Date).Value = txtNacimiento.Text;
            cmd.Parameters.Add("@fecha_fallecimiento", SqlDbType.Date).Value = txtFallecimiento.Text;
            cmd.Parameters.Add("@pais", SqlDbType.VarChar).Value = txtPais.Text;
            cmd.Parameters.Add("@biografia", SqlDbType.VarChar).Value = txtBiografia.Text;

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