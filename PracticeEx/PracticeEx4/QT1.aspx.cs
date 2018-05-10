using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticeEx4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string conString = @"Data Source = DESKTOP-UMKGAQB\HAOSV; Initial Catalog=Sample;User id=sa;Password=suhao123";
        SqlConnection sqlcon = null;
        SqlCommand sqlcom = null;
        private void disconnect()
        {
            if (sqlcom != null)
            {
                sqlcom.Dispose();
                sqlcom = null;
            }

            if (sqlcon != null)
            {
                try
                {
                    sqlcon.Close();

                }
                catch (Exception) { }

                sqlcon = null;
            }

        }
        private void connect()
        {
            try
            {
                disconnect();
                sqlcon = new SqlConnection();
                sqlcom = new SqlCommand();
                sqlcon.ConnectionString = conString;
                sqlcon.Open();
                if (sqlcon.State == System.Data.ConnectionState.Open)
                {
                    lThongBao.Text = "<BR/><BR/>KET NOI THANH CONG<BR/><BR/>";
                }
                sqlcom.Connection = sqlcon;
                sqlcom.CommandType = CommandType.Text;
            }
            catch (Exception e)
            {
                lThongBao.Text = e.ToString();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            connect();

            if (!IsPostBack)

            {
                ddlLoaiHang.Items.Add(new ListItem("Chọn loại hàng", "-1"));
              
                sqlcom.CommandText = "SELECT maTheLoai, tenTheLoai FROM TheLoai";
                SqlDataReader dr2 = sqlcom.ExecuteReader();
                if (dr2.HasRows)
                {
                    while (dr2.Read())
                    {
                        ListItem li = new ListItem();
                        li.Value = dr2.GetInt32(0).ToString();
                        li.Text = dr2.GetString(1);
                        ddlLoaiHang.Items.Add(li);
                    }
                }

                disconnect();

            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            //check validate
            if (String.IsNullOrEmpty(tbIdHang.Text) || String.IsNullOrEmpty(tbTenHang.Text)||ddlLoaiHang.SelectedIndex==0)
            {
                lThongBao.Text = "Vui lòng nhập đủ thông tin!";

                return;
            }
            connect();
            try
            {
                sqlcom.CommandType = CommandType.Text;
                sqlcom.CommandText = String.Format("insert into HangHoa values({0},N'{1}',{2})", tbIdHang.Text, tbTenHang.Text, ddlLoaiHang.SelectedItem.Value.ToString());
                int x = sqlcom.ExecuteNonQuery();
                lThongBao.Text = "Thêm " + x + " mặt hàng thành công!";
            }
            catch(Exception ex)
            {
                lThongBao.Text = "Lỗi " + ex.ToString();
            }
            finally
            {
                disconnect();
            }

        }
    }
}