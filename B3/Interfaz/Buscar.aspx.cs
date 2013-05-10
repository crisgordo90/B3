using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B3.Interfaz
{
    public partial class Buscar : System.Web.UI.Page
    {
        string UserName
        {
            get { return ViewState["UserName"] as string; }
            set { ViewState["UserName"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserName = Request.QueryString["UserName"];
                if ((UserName == null) || (UserName.Equals("")))
                {
                    UserName= "";
                }
                
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("libros_search", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@parametro", SqlDbType.VarChar).Value = txtNombre.Text;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dt = new DataTable();
            dt.Load(dr);
                gvBuscar.DataSource = dt;
            gvBuscar.DataBind();
            con.Close();
        }

        protected void gvBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Interfaz/Comprar.aspx?"+"&ISBM="+ gvBuscar.SelectedRow.Cells[3].Text+"&UserName="+UserName);
        }
    }
}