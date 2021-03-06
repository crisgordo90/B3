﻿using System;
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
    public partial class EditarLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                query name = new query();
                if (!IsPostBack)
                {
                    ddlNombre.DataSource = name.querydt("select * from tabla_Libro");
                    ddlNombre.DataTextField = "Titulo";
                    ddlNombre.DataValueField = "ISBM";
                    ddlNombre.DataBind();
                }
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;
                imgError.Visible = true;
            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            query name = new query();
            OracleConnection con = new OracleConnection(name.OracleConnString());
            OracleCommand cmd = new OracleCommand("modificar_libro", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@titulo", OracleDbType.Varchar2).Value = txtTitulo.Text;
            cmd.Parameters.Add("@anio_publicacion", OracleDbType.Varchar2).Value = txtAnio.Text;
            cmd.Parameters.Add("@stock", OracleDbType.Varchar2).Value = txtStock.Text;
            cmd.Parameters.Add("@costo", OracleDbType.Varchar2).Value = txtCosto.Text;
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
                msgError.Text = "Se ha actualizado con exito";
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
            txtTitulo.Text = "";
            txtAnio.Text = "";
            txtStock.Text = "";
            txtCosto.Text = "";
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            query name = new query();
            DataTable table = name.querydt("select titulo,  anio_publicacion, stock, costo from tabla_Libro where ISBM='" + ddlNombre.SelectedValue + "'");
            if (table != null)
            {
                txtTitulo.Text = table.Rows[0].ItemArray[0].ToString();
                txtAnio.Text = table.Rows[0].ItemArray[1].ToString();
                txtStock.Text = table.Rows[0].ItemArray[2].ToString();
                txtCosto.Text = table.Rows[0].ItemArray[3].ToString();
            }
        }
    }
}