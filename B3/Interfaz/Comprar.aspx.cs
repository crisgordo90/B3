using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using B3.Clases;
using System.Data;
using System.Configuration;
using Oracle.DataAccess.Client;

namespace B3.Interfaz
{
    public partial class Comprar : System.Web.UI.Page
    {
        string ISBM
        {
            get { return ViewState["ISBM"] as string; }
            set { ViewState["ISBM"] = value; }
        }

        string UserName
        {
            get { return ViewState["UserName"] as string; }
            set { ViewState["UserName"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                query name = new query();
                ISBM = Request.QueryString["ISBM"];
                UserName = Request.QueryString["UserName"];
                if (UserName != null)
                {
                    if (!UserName.Equals(""))
                    {
                        lblUsuario.Text = name.querydt("select nombre from tabla_Usuario where email='" + UserName + "'").Rows[0].ItemArray[0].ToString();
                        lblTarjeta.Text = name.querydt("select * from tabla_Tarjeta where email='" + UserName + "'").Rows[0].ItemArray[0].ToString();
                    }
                }
                else
                {
                    msgError.Text = "Debe loguearse para efectuar una compra";
                    imgError.Visible = true;
                }
                if (ISBM != null)
                    if (!ISBM.Equals(""))
                    {
                        DataTable table = name.querydt("select Titulo, Costo from tabla_Libro where ISBM=" + ISBM);
                        lblTitulo.Text = table.Rows[0].ItemArray[0].ToString();
                        lblCosto.Text = table.Rows[0].ItemArray[1].ToString();
                    }
            }
        }


        protected void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserName != null)
                    if (!UserName.Equals(""))
                    {
                        query name = new query();
                        OracleConnection con = new OracleConnection(name.OracleConnString());
                        OracleCommand cmd = new OracleCommand("Insertar_Venta", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@libro", OracleDbType.Varchar2).Value = ISBM;
                        cmd.Parameters.Add("@Comprador", OracleDbType.Varchar2).Value = UserName;
                        cmd.Parameters.Add("@Ventas", OracleDbType.Varchar2).Value = txtCantidad.Text;
                        OracleParameter message = cmd.Parameters.Add("@strMessage", OracleDbType.Varchar2, 200);
                        message.Direction = ParameterDirection.Output;
                        con.Open();
                        OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        con.Close();
                    }
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
                imgError.Visible = true;
            }
        }

    }
}