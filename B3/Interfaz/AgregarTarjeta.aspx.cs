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
    public partial class AgregarTarjeta : System.Web.UI.Page
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
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

        try
        {
            query name = new query();
            OracleConnection con = new OracleConnection(name.OracleConnString());
                OracleCommand cmd = new OracleCommand("insertar_Tarjeta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_credit_card", OracleDbType.Int32).Value = txtTarjeta.Text;
                cmd.Parameters.Add("@email", OracleDbType.Varchar2).Value = UserName;
                cmd.Parameters.Add("@type_card", OracleDbType.Int32).Value = txtTipo.Text;
                cmd.Parameters.Add("@fecha_expiracion", OracleDbType.Date).Value = txtFecha.Text;
                cmd.Parameters.Add("@saldo", OracleDbType.Int32).Value = txtSaldo.Text;
                OracleParameter message = cmd.Parameters.Add("@strMessage", OracleDbType.Varchar2, 200);
                message.Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                msgError.Text = cmd.Parameters["@strMessage"].Value.ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;

                imgError.Visible = true;
            }
        }
    }
}