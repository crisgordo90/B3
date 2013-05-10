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
    public partial class AgregarLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                query name = new query();
                if (!IsPostBack)
                {
                    ddlAutor.DataSource = name.querydt("select * from tabla_Autor");
                    ddlAutor.DataTextField = "Nombre";
                    ddlAutor.DataValueField = "id_Autor";
                    ddlAutor.DataBind();
                    ddlTema.DataSource = name.querydt("select * from tabla_Tema");
                    ddlTema.DataTextField = "Tema";
                    ddlTema.DataBind();
                }
                msgError2.Text = "Ultimo agregado";
                gvLibros.DataSource = name.querydt("select * from tabla_Libro where ISBM=(select max(ISBM) from tabla_Libro)");
                gvLibros.DataBind();
            }
            catch (Exception ex)
            {
                msgError2.Text = ex.Message;
                imgError2.Visible = true;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
           

            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                SqlCommand cmd = new SqlCommand("insertar_Libro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ISBM", SqlDbType.Int).Value = txtISBM.Text;
                cmd.Parameters.Add("@titulo", SqlDbType.VarChar).Value = txtTitulo.Text;
                cmd.Parameters.Add("@anio_publicacion", SqlDbType.Int).Value = txtAnio.Text;
                cmd.Parameters.Add("@stock", SqlDbType.Int).Value = txtStock.Text;
                cmd.Parameters.Add("@costo", SqlDbType.Int).Value = txtCosto.Text;
                SqlParameter message = cmd.Parameters.Add("@strMessage", SqlDbType.VarChar, 200);
                message.Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                msgError.Text = cmd.Parameters["@strMessage"].Value.ToString();
                con.Close();
                Insertar_AutorLibro();
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
            Response.Redirect("~/Interfaz/AgregarLibro.aspx");
        }

        protected void Insertar_AutorLibro()
        {
                while (lbxAutor.Items.Count > 0)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("insertar_autor_libro", con);
                    cmd.Parameters.Add("@libro", SqlDbType.Int).Value = txtISBM.Text;
                    cmd.Parameters.Add("@autor", SqlDbType.Int).Value = lbxAutor.SelectedValue;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    lbxAutor.Items.RemoveAt(lbxAutor.Items.IndexOf(lbxAutor.SelectedItem));
                }
        }

        protected void Insertar_TemaLibro()
        {
            while (lbxTema.Items.Count > 0)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                SqlCommand cmd = new SqlCommand("insertar_tema_libro", con);
                cmd.Parameters.Add("@libro", SqlDbType.Int).Value = txtISBM.Text;
                cmd.Parameters.Add("@theme", SqlDbType.Int).Value = lbxTema.SelectedValue;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                lbxTema.Items.RemoveAt(lbxTema.Items.IndexOf(lbxTema.SelectedItem));
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
            txtISBM.Text ="";
            txtTitulo.Text = "";
            txtAnio.Text = "";
            txtStock.Text = "";
            txtCosto.Text = "";
        }


        protected void btnAgregarAutor_Click(object sender, EventArgs e)
        {
            if (!lbxAutor.Items.Contains(ddlAutor.SelectedItem))
            {
                lbxAutor.Items.Add(ddlAutor.SelectedItem);
            }
        }

        protected void btnAgregarTema_Click(object sender, EventArgs e)
        {
            if (!lbxTema.Items.Contains(ddlTema.SelectedItem))
            {
                lbxTema.Items.Add(ddlTema.SelectedItem);
            }
        }

        protected void btnEliminarTema_Click(object sender, EventArgs e)
        {
            if (lbxTema.Items.Count > 0)
            {
               lbxTema.Items.RemoveAt(lbxTema.Items.IndexOf(lbxTema.SelectedItem)); 
            }
        }

        protected void btnEliminarAutor_Click(object sender, EventArgs e)
        {
            if (lbxAutor.Items.Count > 0)
            {
                lbxAutor.Items.RemoveAt(lbxAutor.Items.IndexOf(lbxAutor.SelectedItem));
            }
        }
    }
}