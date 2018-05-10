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
    public partial class WebForm2 : System.Web.UI.Page
    {
        static SqlUtil sqlUtil = new SqlUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGridView(0,"");
            }
           
        }
        private string getnametoSearch(string str)
        {
            return "N'%" + str + "%'";
        }
        private void loadGridView(int index, string searchstr)
        {
            if (sqlUtil.connect(lNoti))
            {
                DataTable table = new DataTable();
                var sqlcom = sqlUtil.sqlcom;
               // sqlcom.CommandText = "SELECT * FROM dbo.PRODUCTS";
                sqlcom.CommandText = "SELECT PRODUCTS.Id as Id,PRODUCTS.Name as Name ,Price,Description,Img,CATEGORY.Name as Name2 FROM dbo.PRODUCTS JOIN dbo.CATEGORY ON CATEGORY.Id = PRODUCTS.Cate_id";
                if (!string.IsNullOrEmpty(searchstr))
                {
                    try
                    {
                        int d = int.Parse(searchstr);
                        sqlcom.CommandText += " WHERE id=" + searchstr + " or PRODUCTS.Name like N'%" + searchstr + "%' or price =" + searchstr + " or Description like N'%" + searchstr + "%' or CATEGORY.Name like N'%" + searchstr + "%'";

                    }
                    catch 
                    {
                        try
                        {
                            double d = double.Parse(searchstr);
                            sqlcom.CommandText += " WHERE PRODUCTS.Name like N'%" + searchstr + "%' or price =" + searchstr + " or Description like N'%" + searchstr + "%' or CATEGORY.Name like N'%" + searchstr + "%'";
                        }
                        catch
                        {
                            sqlcom.CommandText += " WHERE PRODUCTS.Name like N'%" + searchstr + "%' or Description like N'%" + searchstr + "%' or CATEGORY.Name like N'%" + searchstr + "%'";
                        }
                    }
                    
                
                }
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcom);
                adapter.Fill(table);

                GridView1.DataSource = table;
                GridView1.PageIndex = index;
                GridView1.DataBind();
                
            }
            sqlUtil.disconnect();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            loadGridView(e.NewPageIndex,"");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            loadGridView(1,txtSearch.Text.Trim());
            
        }
    }
}