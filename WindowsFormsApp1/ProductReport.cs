using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Security.Cryptography;
using System.Configuration;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class ProductReport : Form
    {
       ReportDocument ReportDocument=new ReportDocument();
        public ProductReport()
        {
            InitializeComponent();
        }
        private void loadreport()
        {
            string con = ConfigurationManager.ConnectionStrings[""].ConnectionString;
            string sql = "Select * from Items order by ProductName Asc";
            DataSet ds = new DataSet();
            SqlDataAdapter  adapter= new SqlDataAdapter(sql,con);
            adapter.Fill(ds);
            string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
            ReportDocument.Load( rootDirectory+"/rptitems.rpt"));
            ReportDocument.SetDataSource(ds.Tables[0]);
            //ReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, response:, true, "dt");
            ReportDocument.Close();
            ReportDocument.Dispose();
          //  Response.End();
        }
    }
}
