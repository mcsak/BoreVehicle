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
    public partial class HammerExpenses : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        ExpensesD dExpense = new ExpensesD();
        ExpensesProperty pAdmin = new ExpensesProperty();
        int loadcase, HammerExpenseID;
        Int64 UserID,GrandTotal=0;
        string spareset;        

        protected void Page_Load(object sender, EventArgs e)
        {
            loadcase = 1;// Convert.ToInt16(Request.QueryString["op"]);
            btnCancel.PostBackUrl = "~/General/Welcome.aspx";
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.Month.ToString() +"-"+DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                getVendorList();
                if (loadcase == 1)
                {
                    Title = "Hammer Expense - Add";
                    HeaderTitle.InnerHtml = "Hammer Expense  - Add";
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
                    Title = "Hammer Expense  - Modify";
                    HeaderTitle.InnerHtml = "Hammer Expense  - Modify";
                    btnSubmit.Text = "Modify";
                    HammerExpenseID = 1;// Convert.ToInt16(Request.QueryString["RID"]);
                    GetHammerExpenseDetails(HammerExpenseID);
                }
                else if (loadcase == 3)
                {
                    Title = "Hammer Expense  - Delete";
                    HeaderTitle.InnerHtml = "Hammer Expense  - Delete";
                    btnSubmit.Text = "Delete";
                    txtHammerNumber.Enabled = false;
                    txtDate.Enabled = false;
                    txtFirstQty.Enabled = false;
                    txtSecondQty.Enabled = false;
                    txtThirdQty.Enabled = false;
                  
                    txtReplaceable.Enabled = false;
                    txtVendorName.Enabled = false;
                    txtDetails.Enabled = false;
                    txtTotalAmount.Enabled = false;
                    txtPaidAmount.Enabled = false;
                    txtRemaining.Enabled = false;
                    txtRemarks.Enabled = false;
                    txtSpares.Enabled = false;
                    HammerExpenseID = Convert.ToInt16(Request.QueryString["RID"]);
                    GetHammerExpenseDetails(HammerExpenseID);
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

        //Get Bit Expenses Details

        public void GetHammerExpenseDetails(Int64 HammerExpenseID)
        {
            ds = new DataSet();
            ds = dExpense.GetHammerExpenseDetails(HammerExpenseID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtHammerNumber.Text = ds.Tables[0].Rows[0]["HammerNumber"].ToString();
                        txtDate.Text = ds.Tables[0].Rows[0]["ExpenseDate"].ToString();
                        txtFirstQty.Text = ds.Tables[0].Rows[0]["HammerSize6Quantity"].ToString();
                        txtSecondQty.Text = ds.Tables[0].Rows[0]["HammerSize6p5Quantity"].ToString();
                        txtThirdQty.Text = ds.Tables[0].Rows[0]["HammerSize7Quantity"].ToString();

                       
                        txtReplaceable.Text = ds.Tables[0].Rows[0]["Replaceable"].ToString();
                       // txtSpares.Text = ds.Tables[0].Rows[0]["Spares"].ToString();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                //pAdmin.HammerNo = Convert.ToInt64(txtHammerNumber.Text.Trim());
                pAdmin.Date = txtDate.Text;
                //pAdmin.FirstQuantity = Convert.ToInt64(txtFirstQty.Text.Trim());
                //pAdmin.SecondQuantity = Convert.ToInt64(txtSecondQty.Text.Trim());
                //pAdmin.ThirdQuantity = Convert.ToInt64(txtThirdQty.Text.Trim());
                //pAdmin.FourthQuantity = Convert.ToInt64(txtFourthQty.Text.Trim());
                //pAdmin.FifthQuantity = Convert.ToInt64(txtFifthQty.Text.Trim());
                //pAdmin.Replacable = txtReplaceable.Text.Trim();
                pAdmin.Spares = txtSpares.Text.Trim();
                pAdmin.VendorName = txtVendorName.Text.Trim();
                pAdmin.VendorID = Convert.ToInt16(ddlVendorName.SelectedValue);
                pAdmin.Details = txtDetails.Text;
                pAdmin.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                pAdmin.PaidAmount = Convert.ToDecimal(txtPaidAmount.Text);
                pAdmin.RemainingAmount = Convert.ToDecimal(txtRemaining.Text.Trim());
                pAdmin.Remarks = txtRemarks.Text.Trim();

                DataTable dtbitHammersize = new DataTable();
                dtbitHammersize.Columns.Add("Size");
                dtbitHammersize.Columns.Add("Qty");
                dtbitHammersize.Columns.Add("RatePerQty");
                dtbitHammersize.Columns.Add("TotalRate");
                dtbitHammersize.Columns.Add("GrandTotalRate");
                dtbitHammersize.Rows.Add(ddlFirst.SelectedItem, txtFirstQty.Text, txtFirstRate.Text, txtFirstTotal.Text, txtGrandtotal.Text);
                dtbitHammersize.Rows.Add(ddlSecond.SelectedItem, txtSecondQty.Text, txtSecRate.Text, txtSecTotal.Text, txtGrandtotal.Text);
                dtbitHammersize.Rows.Add(ddlThird.SelectedItem, txtThirdQty.Text, txtThirdRate.Text, txtThirdTotal.Text, txtGrandtotal.Text);
                

                if (loadcase == 1)
                {
                    ds = dExpense.IUDHammerExpenses(pAdmin, HammerExpenseID, UserID, loadcase, dtbitHammersize, Convert.ToInt16(HttpContext.Current.Session["SelectedVehicleID"]));
                }
                else
                {
                    HammerExpenseID = 1;// Convert.ToInt16(Request.QueryString["RID"]);
                    ds = dExpense.IUDHammerExpenses(pAdmin, HammerExpenseID, UserID, loadcase, dtbitHammersize, Convert.ToInt16(HttpContext.Current.Session["SelectedVehicleID"]));
                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Result"].ToString() == "S")
                        {
                            string spare = hdnSpareSet.Value;
                            string[] spareset = spare.Split('#');
                            DataSet dSet = new DataSet();
                            for (int i = 0; i < spareset.Length - 1; i++)
                            {
                                dSet = dExpense.InsertSpareSet(Convert.ToInt64(ds.Tables[0].Rows[0]["HammerExpense"].ToString()), spareset[i].Split(',')[0], Convert.ToInt64(spareset[i].Split(',')[1]), UserID);
                            }                           
 
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            btnCancel.PostBackUrl = "~/General/Welcome.aspx";
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been added successfully.");
                            //btnCancel.PostBackUrl = "~/Admin/BrandGrid.aspx";
                            PageMessageUpdate(5, "Your data has been added successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "U")
                        {
                            if (hdnSpareSet.Value != "")
                            {
                                string spare = hdnSpareSet.Value;
                                string[] spareset = spare.Split('#');
                                DataSet dSet = new DataSet();
                                for (int i = 0; i < spareset.Length - 1; i++)
                                {
                                    dSet = dExpense.InsertSpareSet(Convert.ToInt64(ds.Tables[0].Rows[0]["HammerExpense"].ToString()), spareset[i].Split(',')[0], Convert.ToInt64(spareset[i].Split(',')[1]), UserID);
                                }
                            }
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            btnCancel.PostBackUrl = "~/General/Welcome.aspx";
                           // ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been updated successfully.");
                            PageMessageUpdate(5, "Your data has been updated successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "D")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            btnCancel.PostBackUrl = "~/General/Welcome.aspx";
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been deleted successfully.");
                            PageMessageUpdate(5, "Your data has been deleted successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "AEx")
                        {
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("This record already exists.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "ND")
                        {
                           // ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("Delete the model related to this brand before delete this record..");
                        }
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

        public Boolean Validation()
        {
           
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

       
           
            //else if (txtReplaceable.Text == "")
            //{
            //    return false;
            //}
            //else if (txtSpares.Text == "")
            //{
            //    return false;
            //}
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

        protected void btnAddSpares_Click(object sender, EventArgs e)
        {
            if (txtSpares.Text == "")
            {
                return;
            }
            else if (txtSpareAmount.Text == "")
            {
                return;
            }
            else
            {
                spareset = txtSpares.Text + "," + txtSpareAmount.Text + "#";
                hdnSpareSet.Value = hdnSpareSet.Value + spareset;
                txtSpares.Text = "";
                txtSpareAmount.Text = "";
            }
        }

        protected void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            BalanceAmount();
        }

        public void BalanceAmount()
        {
            decimal Balance,AmountPaid;
            AmountPaid = Convert.ToDecimal(txtPaidAmount.Text);// + Convert.ToDecimal(txtRemaining.Text); 
            Balance = Convert.ToDecimal(txtTotalAmount.Text) - AmountPaid ;
            txtRemaining.Text = Convert.ToString(Balance);
        }

        protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            BalanceAmount();
        }

        protected void txtRemaining_TextChanged(object sender, EventArgs e)
        {
            BalanceAmount();
        }

        public void ViewAllDetail()
        {
            MasterD dMaster = new MasterD();
            ds = dMaster.GetViewAllDetails(10, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvHammerExpensesDetails.DataSource = ds.Tables[0];
                        gvHammerExpensesDetails.DataBind();
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

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
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
        
            txtTotalAmount.Text = GrandTotal.ToString() + ".00";
        }

    }
}