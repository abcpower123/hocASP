using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticeEx2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string conString = @"Data Source = DESKTOP-UMKGAQB\HAOSV; Initial Catalog=Sample;User id=sa;Password=suhao123";
        SqlConnection sqlcon = null;
        SqlCommand sqlcom = null;
        private void disconnect()
        {
              if (sqlcom!=null)
                {
                    sqlcom.Dispose();
                    sqlcom = null;
                }
            
            if (sqlcon!=null)
                {
                try
                {
                    sqlcon.Close();
                    
                }
                catch (Exception) {}

                sqlcon = null;
            }
             
        }
        private void connect()
        {
            try
            {
                disconnect();
                sqlcon = new SqlConnection();
                sqlcom = new SqlCommand();
                sqlcon.ConnectionString = conString;
                sqlcon.Open();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    Response.Write("<BR/><BR/>KET NOI THANH CONG<BR/><BR/>");
                }
            }
            catch (Exception e)
            {
                Response.Write(e+"<br />");
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            connect();
           
            if (!IsPostBack)

            {
                
            
                ddlLoaiHang.Items.Add(new ListItem("Chọn loại hàng", "-1"));
            
                sqlcom.Connection = sqlcon;
                sqlcom.CommandType = CommandType.Text;
                sqlcom.CommandText = "SELECT maTheLoai, tenTheLoai FROM TheLoai";
                SqlDataReader dr2 = sqlcom.ExecuteReader();
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        ListItem li = new ListItem();
                        li.Value = dr2.GetInt32(0).ToString();
                        li.Text = dr2.GetString(1);
                        ddlLoaiHang.Items.Add(li);
                    }
                }
                
                disconnect();
                
            }
        }
        
    }
}