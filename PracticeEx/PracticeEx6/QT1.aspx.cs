using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticeEx6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region varbible
        string conString =null;
        SqlConnection sqlcon = null;
        SqlCommand sqlcom = null;
        #endregion
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
        private bool connect()
        {
            try
            {
               
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
                if (sqlcon.State == System.Data.ConnectionState.Open)
                    return true;
                else return false;
            }
            catch (Exception e)
            {
                lThongBao.Text = e.ToString();
                return false;
            }
        }
        int x=0;
   

        protected void Page_Load(object sender, EventArgs e)
        {
            conString = WebClass.getConnectionStringByName("sqlSConString");
            if (!IsPostBack)
            {
                if (connect())
                {
                    {
                        //load dropdownlist
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
                    }
                    disconnect();

                }
                //load gridview
                if (connect())
                {
                    BindDataToGridView(0, "ASC", "ID");
                   
                }
                disconnect();
            }
            
        }

        private void BindDataToGridView(int pageIndex, string sortDirection, string sortExpression)
        {
            if (connect())
            {
                try
                {
                    sqlcom.CommandText = "select ID,ten,maTheLoai from HangHoa order by "+sortExpression+" "+sortDirection;
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    //phan trang
                    if (pageIndex>-1)
                    {
                        GridView1.PageIndex = pageIndex;
                    }


                    ViewState["sortdirection"] = sortDirection;
                    ViewState["sortexpression"] = sortExpression;

                    GridView1.DataBind();
                    ((LinkButton) GridView1.HeaderRow.Cells[0].Controls[0]).Text = "Mã";
                    ((LinkButton)GridView1.HeaderRow.Cells[1].Controls[0]).Text = "Tên hàng";
                    ((LinkButton) GridView1.HeaderRow.Cells[2].Controls[0]).Text = "Mã thể loại";
                }
                catch (Exception e)
                {
                    lThongBao.Text = e.ToString();
                }
            }
            disconnect();
        }

       // private void BindDataToGridView(int pageIndex, String )
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindDataToGridView(e.NewPageIndex, ViewState["sortdirection"] as string, ViewState["sortexpression"] as string);
        }
        
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortdirection = ViewState["sortdirection"] as string;
            if (sortdirection == "ASC")
            {
                sortdirection = "DESC";
            }
            else sortdirection = "ASC";

    
            BindDataToGridView(GridView1.PageIndex, sortdirection, e.SortExpression);
           
        }
    }
}