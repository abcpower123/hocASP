using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticeEx2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region varbible
        string conString = @"Data Source = DESKTOP-UMKGAQB\HAOSV; Initial Catalog=Sample;User id=sa;Password=suhao123";
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
        


        protected void Page_Load(object sender, EventArgs e)
        {
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
                    string dktruyvan = ViewState["dktruyvan"] != null ? ViewState["dktruyvan"] as string : "";
                    sqlcom.CommandText = "select ID,ten,maTheLoai from HangHoa " +dktruyvan+"order by " + sortExpression + " " + sortDirection; //sort by sql
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(sqlcom);
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    //phan trang
                    if (pageIndex > -1)
                    {
                        GridView1.PageIndex = pageIndex;
                    }


                    ViewState["sortdirection"] = sortDirection;
                    ViewState["sortexpression"] = sortExpression;

                    GridView1.DataBind();
                    ((LinkButton)GridView1.HeaderRow.Cells[0].Controls[0]).Text = "Mã";
                    ((LinkButton)GridView1.HeaderRow.Cells[1].Controls[0]).Text = "Tên hàng";
                    ((LinkButton)GridView1.HeaderRow.Cells[2].Controls[0]).Text = "Mã thể loại";
                }
                catch (Exception e)
                {
                    lThongBao.Text = e.ToString();
                }
            }
            disconnect();
        }

        // private void BindDataToGridView(int pageIndex, String )
        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            //check validate
            if (String.IsNullOrEmpty(tbIdHang.Text.Trim()) && String.IsNullOrEmpty(tbTenHang.Text.Trim()) && ddlLoaiHang.SelectedIndex == 0)
            {
                lThongBao.Text = "Vui lòng nhập đủ thông tin!";

                return;
            }
            string dktruyvan = "where ";
            dktruyvan = " where 1=1 "; 
            if (tbIdHang.Text.Trim() != "") dktruyvan += " AND ID = " + tbIdHang.Text.Trim();

            if (tbTenHang.Text.Trim() != "") dktruyvan += " AND ten LIKE N'%" + tbIdHang.Text.Trim() + "%'";

            if (ddlLoaiHang.SelectedValue != "-1")//"Không chọn"
                dktruyvan += " AND maTheLoai = " + ddlLoaiHang.SelectedValue;
            ViewState["dktruyvan"] = dktruyvan;
            BindDataToGridView(0, "ASC", "ID");
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
            

            BindDataToGridView(GridView1.PageIndex, sortdirection , e.SortExpression);
            
           
        }
    }
}