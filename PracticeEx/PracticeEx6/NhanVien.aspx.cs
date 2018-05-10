using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticeEx6
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        List<SV> svlist;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            svlist = new List<SV>();
            if (!IsPostBack)
            {
                
                int n = 100;
                Random rd = new Random();
                for (int i = 0; i < n; i++)
                {
                    svlist.Add(new SV(i + 1, "Sinh Viên", rd.Next(1, n).ToString()));
                }
                
                ViewState["svlist"] = svlist;
                
                BindDataToGridView(0);
            }
        }

        public void BindDataToGridView(int pageIndex)
        {
            
            svlist = (ViewState["svlist"] != null) ? (ViewState["svlist"] as List<SV>) : null;
            GridView1.DataSource = svlist;
            if (pageIndex >= 0) GridView1.PageIndex = pageIndex;
            GridView1.DataBind();
            GridView1.HeaderRow.Cells[0].Text = "Mã SV";
            GridView1.HeaderRow.Cells[1].Text = "Họ lót";
            GridView1.HeaderRow.Cells[2].Text = "Tên";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            BindDataToGridView(e.NewPageIndex);
            
        }
    }
    [Serializable]
    class SV
    {
        public int iD { get; set; }
        public string hoLot { get; set; }
        public string ten { get; set; }
        public SV(int id, string hl, string t)
        {
            iD = id;
            hoLot = hl;
            ten = t;
        }
    }
}