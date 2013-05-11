using B3.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B3.Interfaz
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                query name = new query();
                querySQL name2 = new querySQL();
                DataTable consulta = name.querydt("SELECT tabla_venta.vendedor as VENDEDOR, tabla_libro.titulo AS LIBRO, tabla_venta.ventas AS VENTAS, tabla_venta.libro AS ISBM, tabla_venta.comprador AS COMPRADOR FROM tabla_venta inner join tabla_libro on tabla_venta.libro= tabla_libro.ISBM");
                DataTable consulta2 = name2.querydt("SELECT tabla_venta.vendedor as VENDEDOR, tabla_libro.titulo AS LIBRO, tabla_venta.ventas AS VENTAS, tabla_venta.libro AS ISBM, tabla_venta.comprador AS COMPRADOR FROM tabla_venta inner join tabla_libro on tabla_venta.libro= tabla_libro.ISBM");
                consulta.Merge(consulta2, true, MissingSchemaAction.Ignore);
                gvLibros.DataSource = consulta;
                gvLibros.DataBind();

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
    }
}