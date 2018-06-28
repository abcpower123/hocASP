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

                       string sql = "SELECT * FROM Category";
                        SqlDataReader dr2 = sqlUtil.execReader(sql,null);
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
                String sql = "select dbo.f_NextID()"; //funtion created in database
                SqlDataReader reader = sqlUtil.execReader(sql,null); //alway have result
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
               

                String sqlInsert = "Insert into products values(@name,@price,@description,@img,@cate_id)";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("name", System.Data.SqlDbType.NVarChar));
                parameters.Add(new SqlParameter("price", System.Data.SqlDbType.Money));
                parameters.Add(new SqlParameter("description", System.Data.SqlDbType.NVarChar));
                parameters.Add(new SqlParameter("img", System.Data.SqlDbType.NVarChar));
                parameters.Add(new SqlParameter("cate_id", System.Data.SqlDbType.VarChar));

                parameters[0].Value = txtName.Text;
                parameters[1].Value =txtPrice.Text;
                parameters[2].Value = txtDescription.Text;
                parameters[3].Value = path;
                parameters[4].Value = dpCategory.SelectedValue;
                    try
                         {
                    if (sqlUtil.execInsUpdDel(sqlInsert,parameters) == 1)
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