using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace SalesFood
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Account a = new Account()
            {
                Username = tbUserName.Text,
                Password = EncodeMD5.GetMd5Hash(MD5.Create(), tbPass.Text),
                Name = tbName.Text,
                Role = "customer"
            };
            DataClassesDataContext context = new DataClassesDataContext(new SqlUtil().getConnectionStringByName("SQLServer_connection_string"));
            context.Accounts.InsertOnSubmit(a);
            try
            {
                context.SubmitChanges();
                lbthongbao.Text = "Register successfully, you can login with this account!";
            }
            catch (Exception)
            {
                lbthongbao.Text = "Register failed, check another username!";
             
            }
        }
    }
}