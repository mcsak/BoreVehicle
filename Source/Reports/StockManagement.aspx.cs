using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BoreVehicleClassLibrary.DAL;
using System.Data;
using Source.UC;


namespace Source.Reports
{
    public partial class StockManagement : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        string LoadCase = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // Title = "Stock Details";
                LoadCase = Request.QueryString["View"];
                if (LoadCase == "Bit")
                {
                    bindGrid(1,0,"");
                    Title = "Stock Details - Bit";
                    divTitle.InnerText = "Stock Details - Bit";
                }
                else if (LoadCase == "Hammer")
                {
                    bindGrid(2, 0,"");
                    Title = "Stock Details - Hammer";
                    divTitle.InnerText = "Stock Details - Hammer";
                }
                
            }
        }
        public void bindGrid(Byte flag = 0, byte SearchFlag = 0, string Searchtxt = "")
        {//Convert.ToInt64(Session["UserID"]), Convert.ToInt64(Session["VehileID"])
            ReportsD ReportdDALObj = new ReportsD();
            ds = ReportdDALObj.GetCurrentStockDetails(flag, SearchFlag,Searchtxt);
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvStockManagement.DataSource = ds.Tables[0];
                        gvStockManagement.DataBind();
                    }
                    else
                    {
                        //There are no records.
                    }

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



       protected void imgSearch_Click(object sender, ImageClickEventArgs e)
       {
           if(imgSearch.CommandArgument=="S")
           {
               if (ddlsearchby.SelectedIndex == 0)
               {
                   ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("select a search by.");
               }

               if (txtsearch.Text == "")
               {
                   ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("Enter the search text.");
               }

               //bindGrid(txtsearch.Text.Trim(), Convert.ToByte(ddlsearchby.SelectedValue));
               imgSearch.ImageUrl = "~/Images/cancelsearch.png";
               imgSearch.ToolTip = "Close";
               imgSearch.CommandArgument = "C";
               txtsearch.Enabled = false;
           }
           else
           {
               ViewState["SearchText"] = null;

               bindGrid();
               imgSearch.ImageUrl = "~/Images/searchicongrid.png";
               imgSearch.ToolTip = "Go";
               imgSearch.CommandArgument = "S";
               txtsearch.Text = "";
               //((System.Web.UI.HtmlControls.HtmlContainerControl)(Page.Master.FindControl("PageMessage").FindControl("infomsg"))).Style.Add("visibility", "hidden");
               txtsearch.Enabled = true;
           }
       }
    }
 }
    
