using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace B3.Clases
{
    public class query 
    {
        public DataTable querydt(string text)
        {
             SqlConnection sqlConnection = new SqlConnection();
             String strcon = "Server=localhost; Initial Catalog=B3; User Id=Administrador; Password=123456;";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            sqlConnection.ConnectionString = strcon;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = text;
            try
            {
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                da.Fill(ds);
            }
            catch
            {
            }
            finally
            {
                sqlConnection.Close();
            }
            if (ds.Tables.Count>0)
            dt = ds.Tables[0];

            return dt;
        }
    }
}