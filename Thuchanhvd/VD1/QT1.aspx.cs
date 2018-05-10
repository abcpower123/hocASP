using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string conString = @"Data Source=.;Initial Catalog = Sample; Integrated Security = True";
    protected void Page_Load(object sender, EventArgs e)
    {
            if (!Page.IsPostBack)
            {
                
                ListItem item0 = new ListItem();
                item0.Value = "-1";
                item0.Text = "Chọn thể loại";
               
                ddlTheLoai.Items.Add(item0);


                SqlConnection sqlcon = new SqlConnection();
                SqlCommand sqlcom2 = new SqlCommand();
                try
                {
                    sqlcon.ConnectionString = conString;
                    sqlcon.Open();
                    if (sqlcon.State == System.Data.ConnectionState.Open)
                    {
                        sqlcom2.Connection = sqlcon;
                        sqlcom2.CommandType = System.Data.CommandType.Text;
                        sqlcom2.CommandText = "SELECT maTheLoai, tenTheLoai FROM TheLoai ";
                        SqlDataReader sqlreader = sqlcom2.ExecuteReader();
                    
                        if (sqlreader.HasRows)
                        {
                            while (sqlreader.Read())
                            {
                                ListItem item = new ListItem();
                                item.Value = sqlreader.GetInt32(0).ToString();
                                item.Text = sqlreader.GetSqlString(1).ToString();
                                ddlTheLoai.Items.Add(item);
                            }
                        }
                        else { Response.Write("<script>alert('Không thể đọc danh sách thể loại từ db')</script>"); }
                    }
                }
                catch (Exception exc)
                {
                lThongBao.Text+=(String.Format("<br />Lỗi: {0}<br />", exc.Message));
                }
                finally
                {
                    try
                    {
                        sqlcon.Close();
                        sqlcom2.Dispose();
                    }
                    catch (Exception exc1)
                    {
                    lThongBao.Text += (String.Format("<br />Lỗi: {0}<br />", exc1.Message));
                }
                    finally
                    {

                    }
                }
                

            }
        
    }

    protected void bThemMoi_Click(object sender, EventArgs e)
    {
        DataClassesDataContext context = new DataClassesDataContext();
        var list = context.HangHoas;
        HangHoa s = new HangHoa();
        s.ID = int.Parse(tbID.Text);
        s.maTheLoai = int.Parse(ddlTheLoai.SelectedValue);
        s.ten = tbTen.Text;
        list.InsertOnSubmit(s);
        context.SubmitChanges();
    }
}