﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesFood
{
    public partial class Employee : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"] == null)

                Response.Redirect("Login.aspx");
             
            else if (!Session["acc"].Equals("admin"))
            
                Response.Redirect("Login.aspx");
        }
    }
}