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
    public partial class BitExpenses : System.Web.UI.Page
    {

        DataSet ds = new DataSet();
        ExpensesD dExpense = new ExpensesD();
        ExpensesProperty pAdmin = new ExpensesProperty();
        int loadcase, BitExpenseID, VehicleID;
        Int64 UserID,GrandTotal=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserID"].ToString()!="")
            {
            loadcase = 1;// Convert.ToInt16(Request.QueryString["op"]);
            //btnCancel.PostBackUrl = "~/Expenses/BitExpensesGrid.aspx";
            btnCancel.PostBackUrl = "~/General/Welcome.aspx";
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            VehicleID = Convert.ToInt16(HttpContext.Current.Session["SelectedVehicleID"].ToString());
            txtFirstTotal.Enabled = false;
            txtSecTotal.Enabled = false;
            txtThirdTotal.Enabled = false;
            txtFourthTotal.Enabled = false;
            txtFifthTotal.Enabled = false;
            if (!IsPostBack)
            {
                GetBitMasterForDropDown();
                getVendorList();

                txtFromDate.Text = DateTime.Now.Month.ToString() +"-"+DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                if (loadcase == 1)
                {
                    Title = "Bit Expense - Add";
                    HeaderTitle.InnerHtml = "Bit Expense  - Add";
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
                    Title = "Bit Expense  - Modify";
                    HeaderTitle.InnerHtml = "Bit Expense  - Modify";
                    btnSubmit.Text = "Modify";
                    BitExpenseID =  Convert.ToInt16(Request.QueryString["OID"]);
                    GetBitExpenseDetails(BitExpenseID);
                }
                else if (loadcase == 3)
                {
                    Title = "Bit Expense  - Delete";
                    HeaderTitle.InnerHtml = "Bit Expense  - Delete";
                    btnSubmit.Text = "Delete";
                    txtBitNumber.Enabled = false;
                    txtDate.Enabled = false;
                    txtFirstQty.Enabled = false;
                    txtSecondQty.Enabled = false;
                    txtThirdQty.Enabled = false;
                    txtFourthQty.Enabled = false;
                    txtFifthQty.Enabled = false;
                    txtGrandtotal.Enabled = false;
                    txtVendorName.Enabled = false;
                    txtDetails.Enabled = false;
                    txtTotalAmount.Enabled = false;
                    txtPaidAmount.Enabled = false;
                    txtRemaining.Enabled = false;
                    txtRemarks.Enabled = false;
                    BitExpenseID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetBitExpenseDetails(BitExpenseID);
                }

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

        //Get Bit Expenses Details

        public void GetBitExpenseDetails(Int64 BitExpenseID)
        {
            ds = new DataSet();
            ds = dExpense.GetBitExpenseDetails(BitExpenseID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtBitNumber.Text = ""; //ds.Tables[0].Rows[0]["BitNumber"].ToString();
                        txtDate.Text = ds.Tables[0].Rows[0]["ExpenseDate"].ToString();
                        txtFirstQty.Text = ds.Tables[0].Rows[0]["BitSize6Quantity"].ToString();
                        txtSecondQty.Text = ds.Tables[0].Rows[0]["BitSize6p5Quantity"].ToString();
                        txtThirdQty.Text = ds.Tables[0].Rows[0]["BitSize7Quantity"].ToString();

                        txtFourthQty.Text = ds.Tables[0].Rows[0]["BitSize7p5Quantity"].ToString();
                        txtFifthQty.Text = ds.Tables[0].Rows[0]["BitSize8Quantity"].ToString();
                        txtGrandtotal.Text = ds.Tables[0].Rows[0]["Replaceable"].ToString();
                        txtVendorName.Text = ds.Tables[0].Rows[0]["VendorName"].ToString();
                        txtDetails.Text = ds.Tables[0].Rows[0]["VendorAddress"].ToString();

                        txtTotalAmount.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                        txtPaidAmount.Text = ds.Tables[0].Rows[0]["PaidAmount"].ToString();
                        txtRemaining.Text = ds.Tables[0].Rows[0]["BalanceAmount"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                    }
                }
            }
        }

        public void getVendorList()
        {
            CasingD dCasing = new CasingD();
            ds = new DataSet();
            ds = dCasing.getVendorList();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlVendorName.DataTextField = "vendorName";
                        ddlVendorName.DataValueField = "VendorID";
                        ddlVendorName.DataSource = ds;
                        ddlVendorName.DataBind();
                        ddlVendorName.Items.Insert(0, new ListItem("<--Select-->", "0"));
                    }

                    else
                    {
                        ddlVendorName.Items.Insert(0, new ListItem("--No Data--", "0"));
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                pAdmin.BitNo = 0;//Convert.ToInt64(txtBitNumber.Text.Trim());
                pAdmin.Date = txtDate.Text.Trim();
                //pAdmin.FirstQuantity = Convert.ToInt64(txtFirstQty.Text.Trim());
                //pAdmin.SecondQuantity = Convert.ToInt64(txtSecondQty.Text.Trim());
                //pAdmin.ThirdQuantity = Convert.ToInt64(txtThirdQty.Text.Trim());
                //pAdmin.FourthQuantity = Convert.ToInt64(txtFourthQty.Text.Trim());
                //pAdmin.FifthQuantity = Convert.ToInt64(txtFifthQty.Text.Trim());
                //pAdmin.Replacable = txtGrandtotal.Text.Trim();
                pAdmin.VendorID = Convert.ToInt16(ddlVendorName.SelectedValue);
                pAdmin.Details = txtDetails.Text;
                pAdmin.TotalAmount =Convert.ToDecimal(txtTotalAmount.Text);
                pAdmin.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text); 
                pAdmin.RemainingAmount =Convert.ToDecimal(txtRemaining.Text.Trim());
                pAdmin.Remarks = txtRemarks.Text.Trim();

                DataTable dtbitSize = new DataTable();
                dtbitSize.Columns.Add("Size");
                dtbitSize.Columns.Add("Qty");
                dtbitSize.Columns.Add("RatePerQty");
                dtbitSize.Columns.Add("TotalRate");
                dtbitSize.Columns.Add("GrandTotalRate");
                dtbitSize.Rows.Add(ddlFirst.SelectedItem , txtFirstQty.Text , txtFirstRate.Text , txtFirstTotal.Text,txtGrandtotal.Text);
                dtbitSize.Rows.Add(ddlSecond.SelectedItem, txtSecondQty.Text, txtSecRate.Text, txtSecTotal.Text, txtGrandtotal.Text);
                dtbitSize.Rows.Add(ddlThird.SelectedItem, txtThirdQty.Text, txtThirdRate.Text, txtThirdTotal.Text, txtGrandtotal.Text);
                dtbitSize.Rows.Add(ddlFour.SelectedItem, txtFourthQty.Text, txtFourthRate.Text, txtFourthTotal.Text, txtGrandtotal.Text);
                dtbitSize.Rows.Add(ddlFive.SelectedItem, txtFifthQty.Text, txtFifthRate.Text, txtFifthTotal.Text, txtGrandtotal.Text);
                
                if (loadcase == 1)
                {
                    ds = dExpense.IUDBitExpenses(pAdmin, BitExpenseID, UserID, loadcase, VehicleID,dtbitSize);
                }
                else
                {
                    BitExpenseID = Convert.ToInt16(Request.QueryString["OID"]);
                    ds = dExpense.IUDBitExpenses(pAdmin, BitExpenseID, UserID, loadcase, VehicleID,dtbitSize);
                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Result"].ToString() == "S")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been added successfully.");
                            //btnCancel.PostBackUrl = "~/Admin/BrandGrid.aspx";
                            btnCancel.PostBackUrl = "~/General/Welcome.aspx";
                            PageMessageUpdate(5, "Your data has been added successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "U")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                           // ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been updated successfully.");
                            PageMessageUpdate(5, "Your data has been updated successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "D")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                           // ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been deleted successfully.");
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
            //if (txtBitNumber.Text == "")
            //{
            //    return false;
            //}
            if (txtDate.Text == "")
            {
                return false;
            }
            else if (txtFirstQty.Text == "")
            {
                return false;
            }
            else if (txtSecondQty.Text == "")
            {
                return false;
            }
            else if (txtThirdQty.Text == "")
            {
                return false;
            }

            else if (txtFourthQty.Text == "")
            {
                return false;
            }
            if (txtFifthQty.Text == "")
            {
                return false;
            }
            else if (txtGrandtotal.Text == "")
            {
                return false;
            }
            //else if (txtVendorName.Text == "")
            //{
            //    return false;
            //}
            else if (txtDetails.Text == "")
            {
                return false;
            }
            else if (txtTotalAmount.Text == "")
            {
                return false;
            }

            else if (txtPaidAmount.Text == "")
            {
                return false;
            }
            else if (txtRemaining.Text == "")
            {
                return false;
            }

            else if (txtRemarks.Text == "")
            {
                return false;
            }
            else if (txtRemaining.Text.Contains("-"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            BalanceAmount();
        }

        protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            BalanceAmount();
        }

        protected void txtRemaining_TextChanged(object sender, EventArgs e)
        {
            BalanceAmount();
        }
        protected void txtFirstQty_TextChanged(object sender, EventArgs e)
        {
            calTotal();
        }
        protected void txtSecondQty_TextChanged(object sender, EventArgs e)
        {
            calTotal();
        }
        protected void txtSecRate_TextChanged(object sender, EventArgs e)
        {
            calTotal();
        }
        protected void txtFirstRate_TextChanged(object sender, EventArgs e)
        {
            calTotal();
        }
        protected void txtThirdQty_TextChanged(object sender, EventArgs e)
        {
            calTotal();
        }
        protected void txtFourthQty_TextChanged(object sender, EventArgs e)
        {
            calTotal();
        }
        protected void txtFifthQty_TextChanged(object sender, EventArgs e)
        {
            calTotal();
        }
        protected void txtThirdRate_TextChanged(object sender, EventArgs e)
        {
            calTotal();
        }
        protected void txtFourthRate_TextChanged(object sender, EventArgs e)
        {
            calTotal();
        }
        protected void txtFifthRate_TextChanged(object sender, EventArgs e)
        {
            calTotal();
        }
       
        public void BalanceAmount()
        {
            decimal Balance, AmountPaid;
            AmountPaid = Convert.ToDecimal(txtPaidAmount.Text); //+ Convert.ToDecimal(txtRemaining.Text);
            Balance = Convert.ToDecimal(txtTotalAmount.Text) - AmountPaid;
            txtRemaining.Text = Convert.ToString(Balance);
        }

        public void ViewAllDetail()
        {
            MasterD dMaster = new MasterD();
            ds = dMaster.GetViewAllDetails(9, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvBitExpensesDetails.DataSource = ds.Tables[0];
                        gvBitExpensesDetails.DataBind();
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
        public void GetBitMasterForDropDown()
        {
          
            DataTable dt = new DataTable();
            dt = dExpense.GetBitMasterForDropDown();
            if (dt.Rows.Count > 0)
            {
                ddlFirst.DataSource = dt;
                ddlFirst.DataValueField = "Name";
                ddlFirst.DataTextField = "Value";
                ddlFirst.DataBind();
                ddlSecond.DataSource = dt;
                ddlSecond.DataValueField = "Name";
                ddlSecond.DataTextField = "Value";
                ddlSecond.DataBind();
                ddlThird.DataSource = dt;
                ddlThird.DataValueField = "Name";
                ddlThird.DataTextField = "Value";
                ddlThird.DataBind();
                ddlFour.DataSource = dt;
                ddlFour.DataValueField = "Name";
                ddlFour.DataTextField = "Value";
                ddlFour.DataBind();
                ddlFive.DataSource = dt;
                ddlFive.DataValueField = "Name";
                ddlFive.DataTextField = "Value";
                ddlFive.DataBind();
                ddlSecond.SelectedIndex = 1;
                ddlThird.SelectedIndex = 2;
                ddlFour.SelectedIndex = 3;
                ddlFive.SelectedIndex = 4;
            }
        }

        public void calTotal()
        {

            if (txtFirstQty.Text != "" && txtFirstRate.Text != "")
            {
                txtFirstTotal.Text = (Convert.ToInt64(txtFirstQty.Text) * Convert.ToInt64(txtFirstRate.Text)).ToString();
                GrandTotal = GrandTotal + Convert.ToInt64(txtFirstTotal.Text);
                txtGrandtotal.Text = GrandTotal.ToString();
                
            }
            if (txtSecondQty.Text != "" && txtSecRate.Text != "")
            {
                txtSecTotal.Text = (Convert.ToInt64(txtSecondQty.Text) * Convert.ToInt64(txtSecRate.Text)).ToString();
                GrandTotal = GrandTotal + Convert.ToInt64(txtSecTotal.Text);
                txtGrandtotal.Text = GrandTotal.ToString();
            }
            if (txtThirdQty.Text != "" && txtThirdRate.Text != "")
            {
                txtThirdTotal.Text = (Convert.ToInt64(txtThirdQty.Text) * Convert.ToInt64(txtThirdRate.Text)).ToString();
                GrandTotal = GrandTotal + Convert.ToInt64(txtThirdTotal.Text);
                txtGrandtotal.Text = GrandTotal.ToString();

            } 
            if (txtFourthQty.Text != "" && txtFourthRate.Text != "")
            {
                txtFourthTotal.Text = (Convert.ToInt64(txtFourthQty.Text) * Convert.ToInt64(txtFourthRate.Text)).ToString();
                GrandTotal = GrandTotal + Convert.ToInt64(txtFourthTotal.Text);
                txtGrandtotal.Text = GrandTotal.ToString();
            } 
            if (txtFifthQty.Text != "" && txtFifthRate.Text != "")
            {
                txtFifthTotal.Text = (Convert.ToInt64(txtFifthQty.Text) * Convert.ToInt64(txtFifthRate.Text)).ToString();
                GrandTotal = GrandTotal + Convert.ToInt64(txtFifthTotal.Text);
                txtGrandtotal.Text = GrandTotal.ToString();
            }
            txtTotalAmount.Text = GrandTotal.ToString() + ".00";
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
        }

    }
}