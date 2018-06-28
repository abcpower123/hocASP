using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesFood
{
    public partial class Custormer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Session["acc"] == null)

                    Response.Redirect("Login.aspx");

            Label1.Text ="Welcome "+ Session["name"];


        }
    }
}