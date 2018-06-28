using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesFood
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        SqlUtil sqlUtil = new SqlUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void LoadProduct()
        {
            if (sqlUtil.connect(lbnoti))
            {
                string sql = "SELECT Name,Price,IMG,Id FROM Products";
                DataList1.DataSource = (sqlUtil.execSelect(sql, null));
                DataList1.DataBind();
                sqlUtil.disconnect();
                
            }

        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Session["productID"] = ((Button)sender).ToolTip;
            Response.Redirect("ProductDetail.aspx");
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}