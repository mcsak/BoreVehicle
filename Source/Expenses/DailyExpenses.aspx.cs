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

namespace Source.Report
{
    public partial class DailyExpenses : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        ExpensesD dExpense = new ExpensesD();
        ExpensesProperty pExpense = new ExpensesProperty();
        int loadcase, DailyExpenseID, VehicleID;
        Int64 UserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadcase = 1;// Convert.ToInt16(Request.QueryString["op"]);
            btnCancel.PostBackUrl = "~/Admin/LabourGrid.aspx";
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            VehicleID = Convert.ToInt16(HttpContext.Current.Session["SelectedVehicleID"].ToString());
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.Month.ToString() +"-"+DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
               // ViewAllDetail();                
                string CurrentDate = Convert.ToString(DateTime.Now.ToString("dd")); 
                string Currentmonth =Convert.ToString(DateTime.Now.ToString("MM"));      

                string Currentyear = Convert.ToString(DateTime.Today.Year);
                txtDate.Text = CurrentDate + "/" + Currentmonth + "/" + Currentyear;
                if (loadcase == 1)
                {
                    Title = "Daily Expense - Add";
                    HeaderTitle.InnerHtml = "Daily Expense  - Add";
                    btnSubmit.Text = "Submit";
                    if (Request.QueryString["nav"] != null)
                    {
                        if (Request.QueryString["nav"].ToString() == "1")
                        {
                            btnCancel.PostBackUrl = "~/Welcome.aspx";
                        }
                    }
                }
                else if (loadcase == 2)
                {
                    Title = "Daily Expense  - Modify";
                    HeaderTitle.InnerHtml = "Daily Expense  - Modify";
                    btnSubmit.Text = "Modify";
                    DailyExpenseID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetDailyExpenseDetail(DailyExpenseID);
                }
                else if (loadcase == 3)
                {
                    Title = "Daily Expense  - Delete";
                    HeaderTitle.InnerHtml = "Daily Expense  - Delete";
                    btnSubmit.Text = "Delete";
                 
                    DailyExpenseID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetDailyExpenseDetail(DailyExpenseID);
                }

            }

        }

        public void GetDailyExpenseDetail(Int64 DailyExpenseID)
        {
            ds = new DataSet();
            ds = dExpense.GetDailyExpenseDetail(DailyExpenseID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtDate.Text = ds.Tables[0].Rows[0]["ExpenseDate"].ToString();
                        txtBillAmount.Text = ds.Tables[0].Rows[0]["BillAmount"].ToString();
                        txtBalance.Text = ds.Tables[0].Rows[0]["Balance"].ToString();
                        txtBitQuantity.Text = ds.Tables[0].Rows[0]["BitQuantity"].ToString();
                        txtBitExpenses.Text = ds.Tables[0].Rows[0]["BitExpenses"].ToString();
                        txtHammerQuantity.Text = ds.Tables[0].Rows[0]["HammerQuantity"].ToString();
                        txtHammerExpenses.Text = ds.Tables[0].Rows[0]["HammerExpenses"].ToString();
                        txtDieselQuantity.Text = ds.Tables[0].Rows[0]["DieselQuantity"].ToString();
                        txtDieselExpense.Text = ds.Tables[0].Rows[0]["DieselAmount"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                pExpense.Date = txtDate.Text.Trim();
                pExpense.BillAmount = Convert.ToDecimal(txtBillAmount.Text.Trim());
                pExpense.Balance = Convert.ToDecimal(txtBalance.Text.Trim());
                pExpense.BitQuantity = Convert.ToInt64(txtBitQuantity.Text);
                pExpense.BitExpenses = Convert.ToDecimal(txtBitExpenses.Text);
                pExpense.HammerQuantity = Convert.ToInt64(txtHammerQuantity.Text);
                pExpense.HammerExpenses = Convert.ToDecimal(txtHammerExpenses.Text);
                pExpense.DieselQuantity = Convert.ToDecimal(txtDieselQuantity.Text);
                pExpense.DieselExpenses = Convert.ToDecimal(txtDieselExpense.Text);
                pExpense.Remarks = txtRemarks.Text;
                if (loadcase == 1)
                {
                    ds = dExpense.IUDDailyExpenses(pExpense, DailyExpenseID, UserID, loadcase,VehicleID);
                }
                else
                {
                    DailyExpenseID = Convert.ToInt16(Request.QueryString["OID"]);
                    ds = dExpense.IUDDailyExpenses(pExpense, DailyExpenseID, UserID, loadcase,VehicleID);
                }

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Result"].ToString() == "S")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been added successfully.");
                            btnCancel.PostBackUrl = "~/Admin/BrandGrid.aspx";
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "U")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been updated successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "D")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been deleted successfully.");
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

        public Boolean Validation()
        {
            if (txtDate.Text == "")
            {
                return false;
            }
            else if (txtBillAmount.Text == "")
            {
                return false;
            }
            else if (txtBalance.Text == "")
            {
                return false;
            }
            else if (txtBitQuantity.Text == "")
            {
                return false;
            }

            else if (txtBitExpenses.Text == "")
            {
                return false;
            }
            else if (txtHammerQuantity.Text == "")
            {
                return false;
            }
            else if (txtHammerExpenses.Text == "")
            {
                return false;
            }
            else if (txtDieselExpense.Text == "")
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
            ds = dMaster.GetViewAllDetails(11, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvDailyExpensesDetails.DataSource = ds.Tables[0];
                        gvDailyExpensesDetails.DataBind();
                        btnViewAll.Visible = true;
                    }
                    else
                    {
                        //btnViewAll.Visible = false;
                    }
                }
                else
                {
                   // btnViewAll.Visible = false;
                }

            }
            else
            {
                //btnViewAll.Visible = false;
            }

            updpnlPopup.Update();
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showdetail();", true);
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
        }

    }
}