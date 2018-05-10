using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesFood
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        static SqlUtil sqlUtil = new SqlUtil();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //load data to dropdownlist
                if (sqlUtil.connect(lbNoti))
                {
                    {
                        //load dropdownlist
                        dpCategory.Items.Add(new ListItem("Select category", "-1"));

                        sqlUtil.sqlcom.CommandText = "SELECT * FROM Category";
                        SqlDataReader dr2 = sqlUtil.sqlcom.ExecuteReader();
                        if (dr2.HasRows)
                        {
                            while (dr2.Read())
                            {
                                ListItem li = new ListItem();
                                li.Value = dr2.GetString(0);
                                li.Text = dr2.GetString(1);
                                dpCategory.Items.Add(li);
                            }
                        }
                    }
                    sqlUtil.disconnect();

                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //check validate
            if (string.IsNullOrEmpty(FileUpload1.FileName))
            {
                lbNoti.Text = "Please upload image!";
                return;
            }
            if (txtName.Text.Trim()==""||txtDescription.Text==""||dpCategory.SelectedIndex==0)
            {
                lbNoti.Text = "Please input full information!";
                return;
            }
            try{
                Double.Parse(txtPrice.Text);
            }
            catch
            {
                lbNoti.Text = "Price must be a float number!";
                return;
            }
            //do
            if (sqlUtil.connect(lbNoti))
            {
                //get id nexrow
                var sqlcom = sqlUtil.sqlcom;
                sqlcom.CommandText = "select dbo.f_NextID()"; //funtion created in database
                SqlDataReader reader = sqlcom.ExecuteReader(); //alway have result
                reader.Read();
                int x = reader.GetInt32(0);
                reader.Close();
                lbNoti.Text = x.ToString();
                //save img to directory
                string path = "img/" + x.ToString() + FileUpload1.FileName;
                FileUpload1.SaveAs(Request.PhysicalApplicationPath+"/"+ path);
                //save to db
                sqlUtil.disconnect();
                sqlUtil.connect(lbNoti);
                var sqlcom2 = sqlUtil.sqlcom;
                sqlcom2.CommandText = "Insert into products values(@name,@price,@description,@img,@cate_id)";
                sqlcom2.Parameters.Add("name", System.Data.SqlDbType.NVarChar);
                sqlcom2.Parameters.Add("price", System.Data.SqlDbType.Money);
                sqlcom2.Parameters.Add("description", System.Data.SqlDbType.NVarChar);
                sqlcom2.Parameters.Add("img", System.Data.SqlDbType.NVarChar);
                sqlcom2.Parameters.Add("cate_id", System.Data.SqlDbType.VarChar);

                sqlcom2.Parameters["name"].Value = txtName.Text;
                sqlcom2.Parameters["price"].Value =txtPrice.Text;
                sqlcom2.Parameters["description"].Value = txtDescription.Text;
                sqlcom2.Parameters["img"].Value = path;
                sqlcom2.Parameters["cate_id"].Value = dpCategory.SelectedValue;
                    try
                         {
                    if (sqlcom2.ExecuteNonQuery() == 1)
                    {
                        lbNoti.Text = "Insert successfully!";
                    }
                        }
                catch (Exception ex)
                {
                    lbNoti.Text = ex.ToString();
                }
                
            }
            sqlUtil.disconnect();
        }
    }
}