using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.DynamicData;
using B3.Clases;
using Oracle.DataAccess.Client;

namespace B3
{
    
    public partial class _Default : System.Web.UI.Page
    {
        string UserName
        {
            get { return ViewState["UserName"] as string; }
            set { ViewState["UserName"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
             try
             { 
                 query name = new query();
                 gvLibros.DataSource = name.querydt("select * from libros_home");
                 gvLibros.DataBind();
                 gvBest.DataSource = name.querydt("select * from best_seller");
                 gvBest.DataBind();
                 
             }
             catch (Exception ex)
             {
                 msgError2.Text = ex.Message;
             }
             if (!msgError2.Text.Equals(""))
             {
                 imgError2.Visible = true;
             }
           
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
             {
            query name = new query();
            OracleConnection con = new OracleConnection(name.OracleConnString()); // C#                
            OracleCommand cmd = new OracleCommand("loginCheck",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", OracleDbType.Varchar2).Value = txtCorreo.Text;
            cmd.Parameters.Add("@password", OracleDbType.Varchar2).Value = txtContrasena.Text;
            OracleParameter message = cmd.Parameters.Add("@strMessage", OracleDbType.Varchar2, 200);
            OracleParameter privilegio = cmd.Parameters.Add("@privilegio", OracleDbType.Int32);
            message.Direction = ParameterDirection.Output;
            privilegio.Direction = ParameterDirection.Output;
            con.Open();
            OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            if (Convert.ToInt32(cmd.Parameters["@privilegio"].Value.ToString()) != 4)
            {
                UserName = txtCorreo.Text;
                Limpiar();
                btnIniciarSesion.Visible = false;
                txtContrasena.Visible = false;
                txtCorreo.Visible = false;
                LblLogin.Visible = true;
                LblLogin.Text = cmd.Parameters["@strMessage"].Value.ToString();
                if (Convert.ToInt32(cmd.Parameters["@privilegio"].Value.ToString()) >= 2)
                {
                    btnAgregarLibro.Visible = true;
                    btnAgregarAutor.Visible = true;
                    btnEditarAutor.Visible = true;
                    btnEditarLibro.Visible = true;
                    btnEditarPersona.Visible = true;
                    btnAdeudo.Visible = true;
                    btnVentas.Visible = true;
                    if ((Int32)cmd.Parameters["@privilegio"].Value == 3)
                    {
                        btnConfiguracion.Visible = true;
                        btnBajaLibro.Visible = true;
                        btnBajaPersona.Visible = true;
                    }
                }
            }
            else
            {
                msgError.Text = cmd.Parameters["@strMessage"].Value.ToString();
            }
            
            dr.Close();
            con.Close();
             }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
            }
            if (msgError.Text.Equals(""))
            {
                //Limpiar();
            }
            else
            {
                imgError.Visible = true;
            }
            
        }

        protected void prueba_Click(object sender, EventArgs e)
        {
            
        }

         protected void Limpiar()
        {
            imgError.Visible = false;
            imgError2.Visible = false;
            txtContrasena.Text = "";
            txtCorreo.Text = "";
            msgError.Text = "";
            msgError2.Text = "";
        }
        protected void redirect(string name)
        {
            Response.Redirect("~/Interfaz/" + name + ".aspx?" + "&UserName=" + UserName);
        }

         protected void btnAgregarPersona_Click(object sender, ImageClickEventArgs e)
         {
             redirect("AgregarPersona");
         }

         protected void btnAgregarLibro_Click(object sender, ImageClickEventArgs e)
         {
             redirect("AgregarLibro");
         }

         protected void btnAgregarAutor_Click(object sender, ImageClickEventArgs e)
         {
             redirect("AgregarAutor");
         }

         protected void btnEditarPersona_Click(object sender, ImageClickEventArgs e)
         {
             redirect("EditarPersona");
         }

         protected void btnEditarLibro_Click(object sender, ImageClickEventArgs e)
         {
             redirect("EditarLibro");
         }

         protected void btnEditarAutor_Click(object sender, ImageClickEventArgs e)
         {
             redirect("EditarAutor");
         }

         protected void btnBajaPersona_Click(object sender, ImageClickEventArgs e)
         {
             redirect("BajaPersona");
         }

         protected void btnBajaLibro_Click(object sender, ImageClickEventArgs e)
         {
             redirect("BajaLibro");
         }

         protected void btnConfiguracion_Click(object sender, ImageClickEventArgs e)
         {
             redirect("Configuracion");
         }

         protected void btnComprar_Click(object sender, ImageClickEventArgs e)
         {
             redirect("Buscar");
         }

         protected void btnVentas_Click(object sender, ImageClickEventArgs e)
         {
             redirect("Ventas");
         }

         protected void btnAdeudo_Click(object sender, ImageClickEventArgs e)
         {
             redirect("VentasAdeudos");
         }
    }
}
