using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesFood
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=.;Initial Catalog=SalesFood;User ID=sa;Password=suhao123";
            if (string.IsNullOrEmpty(FileUpload1.FileName))
            {
                return;
            }
            else
            {
                //byte[] bytes = FileUpload1.FileBytes;
                //string strBase64 = Convert.ToBase64String(bytes);
                //Image1.ImageUrl = "data:Image/png;base64," + strBase64;
                Response.Write("OK");
                SqlConnection sqlcon = new SqlConnection(constr);
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand();
                sqlcom.CommandType = System.Data.CommandType.Text;
                sqlcom.Connection = sqlcon;
                sqlcom.CommandText = "Insert into PRODUCTS VALUES ('Do aN 1',150,'hÀI',@IMG,'FF')";
                sqlcom.Parameters.Add("IMG", System.Data.SqlDbType.Binary);
                sqlcom.Parameters["IMG"].Value = FileUpload1.FileBytes;
                sqlcom.ExecuteNonQuery();
                Response.Write("OK2");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=.;Initial Catalog=SalesFood;User ID=sa;Password=suhao123";
            SqlConnection sqlcon = new SqlConnection(constr);
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandType = System.Data.CommandType.Text;
            sqlcom.Connection = sqlcon;
            sqlcom.CommandText = "select IMG from Products where id=1";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcom);
            DataTable table = new DataTable();
            adapter.Fill(table);
            byte[] bytes = (byte[])table.Rows[0]["img"];
            string strBase64 = Convert.ToBase64String(bytes);
            Image1.ImageUrl = "data:Image/png;base64," + strBase64;
        }
    }
    
}