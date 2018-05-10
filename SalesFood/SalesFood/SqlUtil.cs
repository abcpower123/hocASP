using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SalesFood
{
    class SqlUtil
    {
        public const string conString = "Data Source=.;Initial Catalog=SalesFood;User ID=sa;Password=suhao123";
        public SqlConnection sqlcon { get; set; }
        public SqlCommand sqlcom { get; set; }
        public void disconnect()
        {
            if (sqlcom != null)
            {
                sqlcom.Dispose();
                sqlcom = null;
            }

            if (sqlcon != null)
            {
                try
                {
                    
                    sqlcon.Close();

                }
                catch (Exception) { }

                sqlcon = null;
            }

        }
        
        public bool connect(Label lThongBao)
        {
            try
            {

                sqlcon = new SqlConnection();
                sqlcom = new SqlCommand();
                sqlcon.ConnectionString = conString;
                sqlcon.Open();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    lThongBao.Text = "<BR/><BR/>Connect success<BR/><BR/>";
                }
                sqlcom.Connection = sqlcon;
                sqlcom.CommandType = CommandType.Text;
                if (sqlcon.State == System.Data.ConnectionState.Open)
                    return true;
                else return false;
            }
            catch (Exception e)
            {
                lThongBao.Text = e.ToString();
                return false;
            }
        }
    }
}