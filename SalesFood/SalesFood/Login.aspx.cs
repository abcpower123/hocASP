using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace SalesFood
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["acc"]!=null)
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataClassesDataContext context = new DataClassesDataContext(new SqlUtil().getConnectionStringByName("SQLServer_connection_string"));
            var account = context.Accounts.Where(x => x.Username.Trim().Equals(tbUser.Text)).FirstOrDefault();
            if (account!=null)
            {
                if (EncodeMD5.VerifyMd5Hash(MD5.Create(), tbPass.Text, account.Password))
                {
                    Session["acc"] = account.Role;
                    Session["name"] = account.Name;
                    Session["username"] = account.Username;
                    Response.Redirect("Home.aspx");
                    return;
                }
                    
                
            }
            lbnoti.Text = "Login failed";
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account.aspx");
        }
    }
}