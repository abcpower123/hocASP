using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesFood
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)
                Response.Redirect("Home.aspx"); 
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["acc"] = null;
            Session["name"] =null;
            Session["username"] = null; 
            Response.Redirect("Login.aspx");

        }
    }
}