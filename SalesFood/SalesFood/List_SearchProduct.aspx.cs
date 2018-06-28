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
               // sqlcom.CommandText = "SELECT * FROM dbo.PRODUCTS";
                String sql = "SELECT PRODUCTS.Id as Id,PRODUCTS.Name as Name ,Price,Description,Img,CATEGORY.Name as Name2 FROM dbo.PRODUCTS JOIN dbo.CATEGORY ON CATEGORY.Id = PRODUCTS.Cate_id";
                if (!string.IsNullOrEmpty(searchstr))
                {
                    try
                    {
                        int d = int.Parse(searchstr);
                        sql+= " WHERE PRODUCTS.Id=" + searchstr + " or PRODUCTS.Name like N'%" + searchstr + "%' or price =" + searchstr + " or Description like N'%" + searchstr + "%' or CATEGORY.Name like N'%" + searchstr + "%'";

                    }
                    catch 
                    {
                        try
                        {
                            double d = double.Parse(searchstr);
                            sql += " WHERE PRODUCTS.Name like N'%" + searchstr + "%' or price =" + searchstr + " or Description like N'%" + searchstr + "%' or CATEGORY.Name like N'%" + searchstr + "%'";
                        }
                        catch
                        {
                           sql += " WHERE PRODUCTS.Name like N'%" + searchstr + "%' or Description like N'%" + searchstr + "%' or CATEGORY.Name like N'%" + searchstr + "%'";
                        }
                    }
                    
                
                }
                

                GridView1.DataSource = sqlUtil.execSelect(sql,null);
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