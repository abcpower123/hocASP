using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesFood
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Customer> list;
        protected void Page_Load(object sender, EventArgs e)
        {

            list = new List<Customer>();
            if (!IsPostBack)
            {

                int n = 30;
                Random rd = new Random();
                for (int i = 0; i < n; i++)
                {
                    int x = rd.Next(1, n);
                    list.Add(new Customer(x, "Customer ", x.ToString() ));
                }

                ViewState["list"] = list;

                BindDataToGridView(0);
            }
        }

        public void BindDataToGridView(int pageIndex)
        {

            list = (ViewState["list"] != null) ? (ViewState["list"] as List<Customer>) : null;
            GridView1.DataSource = list;
            if (pageIndex >= 0) GridView1.PageIndex = pageIndex;
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Text = "Customer id";
            GridView1.HeaderRow.Cells[1].Text = "First Name";
            GridView1.HeaderRow.Cells[2].Text = "Last Name";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            BindDataToGridView(e.NewPageIndex);

        }
    }
    [Serializable]
    class Customer
    {
        public int iD { get; set; }
        public string hoLot { get; set; }
        public string ten { get; set; }
        public Customer(int id, string hl, string t)
        {
            iD = id;
            hoLot = hl;
            ten = t;
        }
    }
}