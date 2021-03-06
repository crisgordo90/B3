﻿using B3.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B3.Interfaz
{
    public partial class VentasAdeudos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                querySQL name = new querySQL();
                DataTable consulta = name.querydt("SELECT tabla_venta.vendedor as VENDEDOR, tabla_libro.titulo AS LIBRO, tabla_venta.ventas AS VENTAS, tabla_venta.libro AS ISBM, tabla_venta.comprador AS COMPRADOR FROM tabla_venta inner join tabla_libro on tabla_venta.libro= tabla_libro.ISBM");
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