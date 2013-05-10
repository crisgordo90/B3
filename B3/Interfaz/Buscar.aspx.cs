using B3.Clases;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            query name = new query(); 
            DataSet ds = new DataSet();
            OracleConnection con = new OracleConnection(name.OracleConnString());
            OracleCommand cmd = new OracleCommand("libros_search", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@parametro", OracleDbType.Varchar2).Value = txtNombre.Text;
            OracleParameter table = cmd.Parameters.Add("@p_ResultSet", OracleDbType.RefCursor, 200);
            table.Direction = ParameterDirection.Output;
            con.Open();
            cmd.ExecuteReader();
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds);

                gvBuscar.DataSource = ds.Tables[0];
            gvBuscar.DataBind();
            con.Close();
        }

        protected void gvBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Interfaz/Comprar.aspx?"+"&ISBM="+ gvBuscar.SelectedRow.Cells[3].Text+"&UserName="+UserName);
        }
    }
}