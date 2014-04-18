using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Source.UC;
using BoreVehicleClassLibrary.DAL;

namespace Source.Report
{
    public partial class BalanceLedger : System.Web.UI.Page
    {
        ReportsD ReportsDAL = new ReportsD();
        DataSet Ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvBalanceLedger.PageSize = 25;
                txtFromDate.Text =DateTime.Now.Day.ToString() + "-"+ DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                txtToDate.Text =DateTime.Now.Day.ToString() + "-"+ DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                PageBind(0, "Page Load", txtFromDate.Text, txtToDate.Text);
            }
        }

        protected void PageBind(byte SearchFlag,String SearchText,string FromDate,String Todate)
        {
            Ds = ReportsDAL.GetBalanceLedgerDeatils(SearchFlag,SearchText,FromDate,Todate);
            if(Ds!=null)
                if(Ds.Tables.Count>0)
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        gvBalanceLedger.DataSource = Ds.Tables[0];
                        gvBalanceLedger.DataBind();
                        ViewState["DtLedger"] = Ds.Tables[0];
                    }
                    else
                    {
                        //There are no records.
                    }
        }

        protected void gvBalanceLedger_OnPageIndexChanging(object sender, GridViewPageEventArgs pe)
        {
            gvBalanceLedger.PageIndex = pe.NewPageIndex;
            gvBalanceLedger.DataSource = (DataTable)ViewState["DtLedger"];
            gvBalanceLedger.DataBind();
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            if(ddlsearchby.SelectedIndex!=0)
            PageBind(0, "Page Load", txtFromDate.Text, txtToDate.Text);
            else
                PageBind(Convert.ToByte(ddlsearchby.SelectedIndex), txtsearch.Text.Trim(), txtFromDate.Text, txtToDate.Text);
        }
    }
}