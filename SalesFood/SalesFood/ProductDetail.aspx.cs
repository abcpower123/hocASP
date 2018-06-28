using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesFood
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        DataClassesDataContext db = new DataClassesDataContext();
        int productID;
        PRODUCT product;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["productID"] != null)
            {
                productID = int.Parse(Session["productID"] as String);
                Session["productID"] = null;
                product = db.PRODUCTs.Where(x => x.Id == productID).FirstOrDefault();
                Image1.ImageUrl = product.Img;
                lbName.Text = product.Name;
                lbprice.Text = product.Price.ToString();
                lbcate.Text = product.CATEGORY.Name;
                lbDes.Text = product.Description;
                lbID.Text = productID.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Order o = new Order();

            o.Usename = Session["username"] as String;
            o.ProductID = int.Parse(lbID.Text);
            o.Quantity = int.Parse(DropDownList1.SelectedValue);
            o.Date = DateTime.Now;
            o.Price = decimal.Parse(lbprice.Text.ToString());
              

            db.Orders.InsertOnSubmit(o);
            try
            {
                db.SubmitChanges();
                lbthongbao.Text = "Order successfully, Thank you!";
            }
            catch (Exception)
            {
                lbthongbao.Text = "Order failed";
                throw;
            }
            
        }
    }
}