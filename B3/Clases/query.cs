using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client; 

namespace B3.Clases
{
    public class query 
    {
        public string OracleConnString()
        {
            return String.Format(
              "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
              "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
              "localhost",
              "1521",
              "xe",
              "system",
              "12345");
        }

        public DataTable querydt(string text)
        {
            DataTable dt = new DataTable();
            OracleConnection conn = new OracleConnection(OracleConnString()); // C#                
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = text;

            try
            {
                conn.Open();
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                dt.Load(dr);
            }
            catch
            {
            }
            finally
            {
                conn.Dispose();
            }
            return dt;
        }
    }
}