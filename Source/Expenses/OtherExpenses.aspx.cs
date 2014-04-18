using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BoreVehicleClassLibrary.DAL;
using BoreVehicleClassLibrary.PL;
using Source.UC;

namespace Source.Expenses
{
    public partial class OtherExpenses : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        ExpensesD dExpense = new ExpensesD();
        ExpensesProperty pAdmin = new ExpensesProperty();
        int loadcase, OtherExpensesID, VehicleID;
        Int64 UserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadcase = 1;// Convert.ToInt16(Request.QueryString["op"]);
            btnBack.PostBackUrl = "~/General/Welcome.aspx";
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                if (loadcase == 1)
                {

                    Title = "Other Expenses - Add";
                    HeaderTitle.InnerHtml = "Other Expenses  - Add";
                    btnSubmit.Text = "Submit";
                    //txtVehicleNumber.Text=Session["VehicleName"].ToString();
                    if (Request.QueryString["nav"] != null)
                    {
                        if (Request.QueryString["nav"].ToString() == "1")
                        {
                            btnBack.PostBackUrl = "~/Welcome.aspx";
                        }
                    }
                }
                else if (loadcase == 2)
                {
                    Title = "Other Expenses  - Modify";
                    HeaderTitle.InnerHtml = "Other Expenses  - Modify";
                    btnSubmit.Text = "Modify";
                    
                }
                else if (loadcase == 3)
                {
                    Title = "Other Expenses  - Delete";
                    HeaderTitle.InnerHtml = "Other Expenses  - Delete";
                    btnSubmit.Text = "Delete";
                    txtDate.Enabled = false;
                    txtParticulars.Enabled = false;
                    txtAmount.Enabled = false;
                   
                }
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                pAdmin.Date = txtDate.Text.Trim();
                pAdmin.Particulars = txtParticulars.Text.Trim();
                pAdmin.Amount = txtAmount.Text;

                if (loadcase == 1)
                {
                    ds = dExpense.IUDOtherExpenses(pAdmin, OtherExpensesID, UserID, loadcase, Convert.ToInt16(Session["SelectedVehicleID"].ToString()));
                }
                else
                {
                    OtherExpensesID = Convert.ToInt16(Request.QueryString["OID"]);
                    ds = dExpense.IUDOtherExpenses(pAdmin, OtherExpensesID, UserID, loadcase, Convert.ToInt16(Session["SelectedVehicleID"].ToString()));
                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Result"].ToString() == "S")
                        {
                            btnSubmit.Visible = false;
                            btnBack.Text = "Back";
                            btnBack.PostBackUrl = "~/General/Welcome.aspx";
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been added successfully.");
                            //btnBack.PostBackUrl = "~/Admin/BrandGrid.aspx";
                            PageMessageUpdate(5, "Your data has been added successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "U")
                        {
                            btnSubmit.Visible = false;
                            btnBack.Text = "Back";
                            btnBack.PostBackUrl = "~/General/Welcome.aspx";
                            // ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been updated successfully.");
                            PageMessageUpdate(5, "Your data has been updated successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "D")
                        {
                            btnSubmit.Visible = false;
                            btnBack.Text = "Back";
                            btnBack.PostBackUrl = "~/General/Welcome.aspx";
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been deleted successfully.");
                            PageMessageUpdate(5, "Your data has been deleted successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "AEx")
                        {
                            // ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("This record already exists.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "ND")
                        {
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("Delete the model related to this brand before delete this record..");
                        }
                    }
                }

            }            
        }


        public Boolean Validation()
        {
            if (txtDate.Text == "")
            {
                return false;
            }
            else if (txtParticulars.Text == "")
            {
                return false;
            }
            else if (txtAmount.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ViewAllDetail()
        {
            MasterD dMaster = new MasterD();
            ds = dMaster.GetViewAllDetails(13, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvOtherExpenseDetails.DataSource = ds.Tables[0];
                        gvOtherExpenseDetails.DataBind();
                        btnViewOtherExpenses.Visible = true;
                    }
                    else
                    {
                       // btnViewOtherExpenses.Visible = false;
                    }
                }
                else
                {
                    //btnViewOtherExpenses.Visible = false;
                }

            }
            else
            {
                //btnViewOtherExpenses.Visible = false;
            }
            updpnlPopup.Update();
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showdetail();", true);
        }

        protected void btnViewLabours_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
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

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
        }

        protected void btnViewOtherExpenses_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
        }
    }
}