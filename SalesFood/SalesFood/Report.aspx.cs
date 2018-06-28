using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SalesFood
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*ReportDocument reportDocument = new ReportDocument();

            reportDocument.Load(Server.MapPath("CrystalReport1.rpt"));
            
            reportDocument.Database.Tables[0].SetDataSource(new DataSet1());
            
            //reportDocument.SetDatabaseLogon("sa", "suhao123", ".", "SalesFood");

            CrystalReportViewer1.ReportSource = reportDocument;
            */
            CrystalReportViewer1.RefreshReport();
        }
    }
}