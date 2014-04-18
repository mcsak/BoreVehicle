using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Source.UC;
using BoreVehicleClassLibrary.DAL;
using BoreVehicleClassLibrary.PL;

namespace Source.SiteManagement
{
    public partial class MonthStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblVehicleNameVal.Text = Session["VehicleName"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                Boolean ResultFlag;
                SiteManagementD dSiteMgmt=new SiteManagementD();
                ResultFlag = dSiteMgmt.InsertMonthStatus(Convert.ToInt16(txtRemainingDiesel.Text.Trim()), txtRemarks.Text, Convert.ToInt64(HttpContext.Current.Session["UserID"]), Convert.ToInt16(HttpContext.Current.Session["SelectedVehicleID"]));
                if (ResultFlag == true)
                {
                    PageMessageUpdate(5,"Your data has been added successfully.");
                }
                else
                {
                    PageMessageUpdate(6, "Your data has not been added please retry.");
                }
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



        public Boolean Validation()
        {            
            if (txtRemainingDiesel.Text == "")
            {
                return false;
            }
            else if (txtRemarks.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/General/Welcome.aspx");
        }

         
    }
}