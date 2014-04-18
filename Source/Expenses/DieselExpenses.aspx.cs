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
    public partial class DieselExpenses : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        ExpensesD dExpense = new ExpensesD();
        ExpensesProperty pAdmin = new ExpensesProperty();
        int loadcase, DiselExpenseID, VehicleID ;
        Int64 UserID;
        Double Feet;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadcase = 1;// Convert.ToInt16(Request.QueryString["op"]);
            btnBack.PostBackUrl = "~/General/Welcome.aspx";
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            getEndingRPM(Convert.ToInt16(Session["SelectedVehicleID"].ToString()));

            GetVehicleNumber();
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.Month.ToString() +"-"+DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                if (loadcase == 1)
                {

                    Title = "Diesel Expenses - Add";
                    HeaderTitle.InnerHtml = "Diesel Expenses  - Add";
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
                    Title = "Diesel Expenses  - Modify";
                    HeaderTitle.InnerHtml = "Diesel Expenses  - Modify";
                    btnSubmit.Text = "Modify";
                    DiselExpenseID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetDiselExpenseDetails(DiselExpenseID);
                }
                else if (loadcase == 3)
                {
                    Title = "Diesel Expenses  - Delete";
                    HeaderTitle.InnerHtml = "Diesel Expenses  - Delete";
                    btnSubmit.Text = "Delete";
                    txtVehicleNumber.Enabled = false;
                    txtDate.Enabled = false;
                    txtRpm.Enabled = false;
                    txtPersonName.Enabled = false;
                    txtAmount.Enabled = false;
                    txtRemarks.Enabled = false;
                    txtAmount.Enabled = false;
                    DiselExpenseID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetDiselExpenseDetails(DiselExpenseID);
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

        //Get Diesel Expenses Details

        public void GetVehicleNumber()
        {
            ds = new DataSet();
            ds = dExpense.GetVehicleNumber(UserID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtVehicleNumber.Text = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                        VehicleID = Convert.ToInt16(ds.Tables[0].Rows[0]["VehicleID"].ToString());
                        txtVehicleNumber.Enabled = false;

                    }
                }
            }
        }


        //Get Diesel Expenses Details

        public void GetDiselExpenseDetails(Int64 DiselExpenseID)
        {
            ds = new DataSet();
            ds = dExpense.GetDiselExpenseDetails(DiselExpenseID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtVehicleNumber.Text = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                        txtDate.Text = ds.Tables[0].Rows[0]["ExpenseDate"].ToString();
                        txtRpm.Text = ds.Tables[0].Rows[0]["RPM"].ToString();
                        //txtPersonName.Text = ds.Tables[0].Rows[0]["PersonName"].ToString();
                        txtAmount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString(); ;

                    }
                }
            }
        }

        public void getEndingRPM(int vehicleID)
        {
            ds = new DataSet();
            ds = dExpense.getEndingRPM(vehicleID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        hdnEndingRPM.Value = ds.Tables[0].Rows[0]["EndingRPM"].ToString();

                    }
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                pAdmin.VehicleNumber = Convert.ToInt64(txtVehicleNumber.Text.Trim());
                pAdmin.Date = txtDate.Text.Trim();
                pAdmin.RPM = Convert.ToDecimal(txtRpm.Text.Trim());
                pAdmin.Name = txtPersonName.Text;
                pAdmin.Amount = txtAmount.Text;
                pAdmin.Remarks = txtRemarks.Text;
                pAdmin.Amount = txtAmount.Text.Trim();
                pAdmin.NoOfLitre = Convert.ToDecimal(txtNooflitr.Text.Trim());
                pAdmin.Feet = Convert.ToDecimal(lblfeet.Text);
                pAdmin.DieselAvg = Convert.ToDecimal(lbldieselavg.Text);

                if (loadcase == 1)
                {
                    ds = dExpense.IUDDieselExpenses(pAdmin, DiselExpenseID, UserID, loadcase, Convert.ToInt16(HttpContext.Current.Session["SelectedVehicleID"].ToString()));
                }
                else
                {
                    DiselExpenseID = Convert.ToInt16(Request.QueryString["OID"]);
                    ds = dExpense.IUDDieselExpenses(pAdmin, DiselExpenseID, UserID, loadcase, Convert.ToInt16(HttpContext.Current.Session["SelectedVehicleID"].ToString()));
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
                            // ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been updated successfully.");
                            PageMessageUpdate(5, "Your data has been updated successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "D")
                        {
                            btnSubmit.Visible = false;
                            btnBack.Text = "Back";
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been deleted successfully.");
                            PageMessageUpdate(5, "Your data has been deleted successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "AEx")
                        {
                            ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("This record already exists.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "ND")
                        {
                            ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("Delete the model related to this brand before delete this record..");
                        }
                    }
                }

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Expenses/DieselExpenses.aspx");
        }

        public Boolean Validation()
        {
            if (txtVehicleNumber.Text == "")
            {
                return false;
            }
            else if (txtNooflitr.Text == "")
            {
                return false;
            }
            else if (txtDate.Text == "")
            {
                return false;
            }
            else if (txtRpm.Text == "")
            {
                return false;
            }
            //else if (txtPersonName.Text == "")
            //{
            //    return false;
            //}
            else if (txtAmount.Text == "")
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

        public void ViewAllDetail()
        {
            MasterD dMaster = new MasterD();
            ds = dMaster.GetViewAllDetails(8, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvDieselExpensesDetails.DataSource = ds.Tables[0];
                        gvDieselExpensesDetails.DataBind();
                        btnViewAll.Visible = true;
                    }
                    else
                    {
                        //btnViewAll.Visible = false;
                    }
                }
                else
                {
                    //btnViewAll.Visible = false;
                }

            }
            else
            {
                //btnViewAll.Visible = false;
            }
            updpnlPopup.Update();
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showdetail();", true);
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
        }

        protected void txtRpm_TextChanged(object sender, EventArgs e)
        {
            if (hdnEndingRPM.Value != "")
            {
                Feet = Convert.ToDouble(txtRpm.Text) - Convert.ToDouble(hdnEndingRPM.Value);
                lblfeet.Text = Convert.ToString(Feet);
                if (txtRpm.Text != "")
                {
                    Double DiselAvg = Convert.ToDouble(lblfeet.Text) / Convert.ToDouble(txtNooflitr.Text);
                    lbldieselavg.Text = Convert.ToString(DiselAvg);
                }
            }
            
        }

        protected void txtNooflitr_TextChanged(object sender, EventArgs e)
        {
            if (txtRpm.Text != "")
            {
                Feet = Convert.ToDouble(lblfeet.Text) / Convert.ToDouble(txtNooflitr.Text);
                lbldieselavg.Text = Convert.ToString(Feet);
            }

        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
        }
    }
}