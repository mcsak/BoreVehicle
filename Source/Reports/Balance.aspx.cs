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
    public partial class Balance : System.Web.UI.Page
    {
        ReportsD ReportsDAL = new ReportsD();
        DataSet Ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PageBind();
                lnkViewAll.Enabled = false;
            }
        }

        protected void PageBind(Byte SearchFlag = 0,string SearchText="")
        {
           Ds= ReportsDAL.GetBalanceDetails(SearchFlag,SearchText);
            if(Ds!=null)
                if(Ds.Tables.Count>0)
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        gvBalance.DataSource = Ds.Tables[0];
                        ViewState["dtBalancedata"] = Ds.Tables[0];
                        gvBalance.DataBind();
                    }
        }

        protected void OnPageIndexChanging_gvBalance(object sender,GridViewPageEventArgs pe)
        {
            gvBalance.PageIndex = pe.NewPageIndex;
            gvBalance.DataSource = (DataTable)ViewState["dtBalancedata"];
            gvBalance.DataBind();
        }
        protected void gvBalance_OnRowCommand(object sender, GridViewCommandEventArgs Re)
        {
            DataSet dsViews = new DataSet();
            if (Re.CommandName == "ViewParticularLeads")
            {
                dsViews = ReportsDAL.GetBalanceTransactionsForLead(Convert.ToInt32(Re.CommandArgument.ToString()));
                if(dsViews!=null)
                    if(dsViews.Tables.Count>0)
                    {
                        if(dsViews.Tables[0].Rows.Count>0)
                        {
                            lblPointNumbetrVal.Text = dsViews.Tables[0].Rows[0]["PointNumber"].ToString();
                            lblAmountTotalVal.Text = dsViews.Tables[0].Rows[0]["BilledAmount"].ToString();
                            lblAmountPaidVal.Text = dsViews.Tables[0].Rows[0]["PaidAmount"].ToString();
                            lblAmountRemainingVal.Text = dsViews.Tables[0].Rows[0]["BalanceAmount"].ToString();
                        }
                        if (dsViews.Tables[1].Rows.Count > 0)
                        {
                            gvBalanceDetails.DataSource = dsViews.Tables[1];
                            gvBalanceDetails.DataBind();
                        }

                        
                    }

                updpnlpopup.Update();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showdetail();", true);
            }
        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (ddlsearchby.SelectedIndex != 0)
                PageBind(Convert.ToByte(ddlsearchby.SelectedIndex), txtsearch.Text.Trim());
            else
                PageMessageUpdate(6, "Please select search by.");
            lnkViewAll.Enabled = true;
        }

        protected void PageMessageUpdate(int ResultVal, string Message = "")
        {
            InnerMaster inm = Master as InnerMaster;
            UpdatePanel updpnl = (UpdatePanel)inm.FindControl("updpnlMaster");
            // updpnl.ChildrenAsTriggers = false;
            if (ResultVal == 0)
            {
                // No message
            }
            else if (ResultVal == 1)
            {
                ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("Your data has been saved successfuly.");
                updpnl.Update();
            }
            else if (ResultVal == 2)
            {
                ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("There are no records found.");
                updpnl.Update();
            }
            else if (ResultVal == 3)
            {
                ((PageMessage)(Page.Master.FindControl("PageMessage"))).ErrorMessage("No data.");
                updpnl.Update();
            }
            else if (ResultVal == 4)
            {
                ((PageMessage)(Page.Master.FindControl("PageMessage"))).ErrorMessage("Server error.");
                updpnl.Update();
            }
            else if (ResultVal == 5)
            {
                ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage(Message);
                updpnl.Update();
            }
            else if (ResultVal == 6)
            {
                ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage(Message);
                updpnl.Update();
            }
            else
            {
                ((PageMessage)(Page.Master.FindControl("PageMessage"))).ErrorMessage("Unknown error.");
                updpnl.Update();
            }
        }

        protected void lnkViewAll_Click(object sender, EventArgs e)
        {
            PageBind();
            ddlsearchby.SelectedIndex = 0;
            txtsearch.Text = "";
            lnkViewAll.Enabled = false;
        }


    }
}