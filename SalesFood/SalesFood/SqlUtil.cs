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
        public string conString = "";
        public SqlConnection sqlcon { get; set; }
        public SqlCommand sqlcom { get; set; }
        //get constring from xml config
        public string getConnectionStringByName(string connectionStringName)
        {
            System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/SalesFood");
            System.Configuration.ConnectionStringSettings connString;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString =
                    rootWebConfig.ConnectionStrings.ConnectionStrings[connectionStringName];
                if (connString != null)
                    return connString.ConnectionString;
            }
            return "";
        }
        //connect, disconnect db
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
                conString = getConnectionStringByName("SQLServer_connection_string");
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
        // crud
        public int execInsUpdDel(string sqlInsUpdDel, List<SqlParameter> sqlParams)
        {
           
           
            try
            {

                sqlcom.CommandText = sqlInsUpdDel;
               
                if (sqlParams != null)
                    foreach (SqlParameter pr in sqlParams)
                    {
                        sqlcom.Parameters.Add(pr);
                    }
                return sqlcom.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                throw exc;
            }
           
           
        }
        
        public DataTable execSelect(string sqlSelect, List<SqlParameter> sqlParams)
        {
            DataTable result = new DataTable() ;

          
            sqlcom.CommandText = sqlSelect;

                if (sqlParams != null)
                    foreach (SqlParameter pr in sqlParams)
                    {
                        sqlcom.Parameters.Add(pr);
                    }
                new SqlDataAdapter(sqlcom).Fill(result);
               
            
            
            return result;
        }
        
        public SqlDataReader execReader(string sqlSelect, List<SqlParameter> sqlParams)
        {
            try
            {

                sqlcom.CommandText = sqlSelect;

                if (sqlParams != null)
                    foreach (SqlParameter pr in sqlParams)
                    {
                        sqlcom.Parameters.Add(pr);
                    }
             
                return sqlcom.ExecuteReader();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        //destructor
        ~SqlUtil(){
            disconnect();
        }


    }
}