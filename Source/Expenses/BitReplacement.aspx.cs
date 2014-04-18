using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BoreVehicleClassLibrary.DAL;
using BoreVehicleClassLibrary.PL;

namespace Source.Expenses
{
    public partial class BitReplacement : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        ExpensesD dExpense = new ExpensesD();
        ExpensesProperty pAdmin = new ExpensesProperty();
        CasingD dCasing = new CasingD();
        Decimal Total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getVendorList();
                disable();
                GetBitMasterForDropDown();
            }
        }
        public void getVendorList()
        {
            
            ds = new DataSet();
            ds = dCasing.getVendorList();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlVendor.DataTextField = "vendorName";
                        ddlVendor.DataValueField = "VendorID";
                        ddlVendor.DataSource = ds;
                        ddlVendor.DataBind();
                        ddlVendor.Items.Insert(0, new ListItem("<--Select-->", "0"));
                        ddlVendorName.DataTextField = "";
                        ddlVendorName.DataValueField = "";
                        ddlVendorName.DataSource = ds;
                        ddlVendorName.DataBind();
                        ddlVendorName.Items.Insert(0, new ListItem("<--Select-->", "0"));
                    }

                    else
                    {
                        ddlVendor.Items.Insert(0, new ListItem("--No Data--", "0"));
                        ddlVendorName.Items.Insert(0, new ListItem("--No Data--", "0"));
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            pAdmin.BitNo = Convert.ToInt64(ddlBitExpenses.SelectedValue);
            pAdmin.TotalAmount = Convert.ToDecimal(txtGrandtotal.Text);
            pAdmin.VehicleNumber=Convert.ToInt64(Session["SelectedVehicleID"]);
            pAdmin.PaidAmount = pAdmin.TotalAmount * -1;
            pAdmin.Balance = 0;
            pAdmin.Remarks = txtRemarks.Text;
            pAdmin.Date = txtDate.Text;
            pAdmin.VendorID = Convert.ToInt16(ddlVendor.SelectedValue);
            if (txtFirstReplacement.Text != "0.00")
            {
                pAdmin.AmountDetails = txtFirstReplacement.Text + "," + "1" +";";
            }
            if (txtSecReplacement.Text != "0.00")
            {
                pAdmin.AmountDetails += txtSecReplacement.Text + "," + "2" + ";";

            }
            if (txtThirdRepalcement.Text != "0.00")
            {
                pAdmin.AmountDetails += txtThirdRepalcement.Text + "," + "3" + ";";
            }
            if (txtFourthReplacement.Text!="0.00")
            {
                pAdmin.AmountDetails += txtFourthReplacement.Text + "," + "4" + ";";
            }
            if (txtFifthReplacement.Text != "0.00")
            {
                pAdmin.AmountDetails += txtFifthReplacement.Text + "," + "5" + ";";
            }
            ds = dCasing.InserBitReplacement(pAdmin);
            
        }
        protected void txtFirstReplacement_TextChanged(object sender, EventArgs e)
        {
            decimal Replacement;
            Replacement = Convert.ToDecimal(txtFirstReplacement.Text);
            Total = Total + Convert.ToDecimal(txtGrandtotal.Text);
            txtGrandtotal.Text = (Total - Replacement).ToString();
            txtTotalAmount.Text = txtGrandtotal.Text;
 
        }
        protected void txtSecReplacement_TextChanged(object sender, EventArgs e)
        {
            decimal Replacement;
            Replacement = Convert.ToDecimal(txtSecReplacement.Text);
            Total = Total + Convert.ToDecimal(txtGrandtotal.Text);
            txtGrandtotal.Text = (Total - Replacement).ToString();
            txtTotalAmount.Text = txtGrandtotal.Text;
        }
        protected void txtThirdRepalcement_TextChanged(object sender, EventArgs e)
        {
            decimal Replacement;
            Replacement = Convert.ToDecimal(txtThirdRepalcement.Text);
            Total = Total + Convert.ToDecimal(txtGrandtotal.Text);
            txtGrandtotal.Text = (Total - Replacement).ToString();
            txtTotalAmount.Text = txtGrandtotal.Text;
        }
        protected void txtFourthReplacement_TextChanged(object sender, EventArgs e)
        {
            decimal Replacement;
            Replacement = Convert.ToDecimal(txtFourthReplacement.Text);
            Total = Total + Convert.ToDecimal(txtGrandtotal.Text);
            txtGrandtotal.Text = (Total - Replacement).ToString();
            txtTotalAmount.Text = txtGrandtotal.Text;
        }
        protected void txtFifthReplacement_TextChanged(object sender, EventArgs e)
        {
            decimal Replacement;
            Replacement = Convert.ToDecimal(txtFifthReplacement.Text);
            Total = Total + Convert.ToDecimal(txtGrandtotal.Text);
            txtGrandtotal.Text = (Total - Replacement).ToString();
            txtTotalAmount.Text = txtGrandtotal.Text;
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
        public void BalanceAmount()
        {
            decimal Balance, AmountPaid;
            AmountPaid = Convert.ToDecimal(txtPaidAmount.Text); //+ Convert.ToDecimal(txtRemaining.Text);
            Balance = Convert.ToDecimal(txtTotalAmount.Text) - AmountPaid;
            txtRemaining.Text = Convert.ToString(Balance);
        }
        protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt16(ddlVendor.SelectedValue);
            getBitexpenseID(ID);
        }
        protected void ddlBitExpenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBitReplacement(Convert.ToInt64(ddlBitExpenses.SelectedValue));
        }

        public void getBitexpenseID(int VendorID)
        {
            ExpensesD ExpenseDAL = new ExpensesD();
            ds = new DataSet();
            ds = ExpenseDAL.GetBitExpensesIDForDDL(VendorID);
            if (ds != null)
                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlBitExpenses.Dispose();
                        ddlBitExpenses.ClearSelection();
                        ddlBitExpenses.DataSource = ds.Tables[0];
                        ddlBitExpenses.DataValueField = "ExpenseID";
                        ddlBitExpenses.DataTextField = "ExpensesCharID";
                        ddlBitExpenses.DataBind();
                        ddlBitExpenses.Items.Insert(0, new ListItem("<--Select-->", "0"));
                    }
                    else
                    {                        
                        ddlBitExpenses.Items.Clear();
                        ddlBitExpenses.Items.Insert(0, new ListItem("--No Data--", "0"));
                    }
                else
                {
                    ddlBitExpenses.Items.Clear();
                    ddlBitExpenses.Items.Insert(0, new ListItem("--No Data--", "0"));
                }
            else
            {
                ddlBitExpenses.Items.Clear();
                ddlBitExpenses.Items.Insert(0, new ListItem("--No Data--", "0"));
            }

        }

        public void GetBitReplacement(Int64 BitID)
        {
            CasingD dCasing = new CasingD();
            ds = new DataSet();
            ds = dCasing.GetBitReplacement(BitID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //ddlFirst.Text = ds.Tables[0].Rows[0]["bitSize"].ToString();
                        //ddlSecond.Enabled = ds.Tables[0].Rows[0]["bitSize"].ToString();
                        //ddlThird.Enabled = ds.Tables[0].Rows[0]["bitSize"].ToString();
                        //ddlFour.Enabled = ds.Tables[0].Rows[0]["bitSize"].ToString();
                        //ddlFive.Enabled = ds.Tables[0].Rows[0]["bitSize"].ToString();
                        txtFirstQty.Text = ds.Tables[0].Rows[0]["BitQty"].ToString();
                        txtSecondQty.Text = ds.Tables[0].Rows[1]["BitQty"].ToString();
                        txtThirdQty.Text = ds.Tables[0].Rows[2]["BitQty"].ToString();
                        txtFourthQty.Text = ds.Tables[0].Rows[3]["BitQty"].ToString();
                        txtFifthQty.Text = ds.Tables[0].Rows[4]["BitQty"].ToString();
                        txtFirstRate.Text = ds.Tables[0].Rows[0]["RatePerQty"].ToString();
                        txtSecRate.Text = ds.Tables[0].Rows[1]["RatePerQty"].ToString();
                        txtThirdRate.Text = ds.Tables[0].Rows[2]["RatePerQty"].ToString();
                        txtFourthRate.Text = ds.Tables[0].Rows[3]["RatePerQty"].ToString();
                        txtFifthRate.Text = ds.Tables[0].Rows[4]["RatePerQty"].ToString();
                        txtFirstTotal.Text = ds.Tables[0].Rows[0]["TotalRate"].ToString();
                        txtSecTotal.Text = ds.Tables[0].Rows[1]["TotalRate"].ToString();
                        txtThirdTotal.Text = ds.Tables[0].Rows[2]["TotalRate"].ToString();
                        txtFourthTotal.Text = ds.Tables[0].Rows[3]["TotalRate"].ToString();
                        txtFifthTotal.Text = ds.Tables[0].Rows[4]["TotalRate"].ToString();
                        txtGrandtotal.Text = ds.Tables[0].Rows[4]["GrandTotalRate"].ToString();
                        txtTotalAmount.Text = ds.Tables[0].Rows[4]["GrandTotalRate"].ToString();
                    }

                    else
                    {
                        ddlBitExpenses.Items.Insert(0, new ListItem("--No Data--", "0"));
                    }
                }
            }
        }
        protected void BtnGo_Click(object sender, EventArgs e)
        {
        }
        public void disable()
        {
            //ddlFirst.Enabled = false;
            //ddlSecond.Enabled = false;
            //ddlThird.Enabled = false;
            //ddlFour.Enabled = false;
            //ddlFive.Enabled = false;
            txtFirstQty.Enabled = false;
            txtSecondQty.Enabled = false;
            txtThirdQty.Enabled = false;
            txtFourthQty.Enabled = false;
            txtFifthQty.Enabled = false;
            txtFirstRate.Enabled = false;
            txtSecRate.Enabled=false;
            txtThirdRate.Enabled = false;
            txtFourthRate.Enabled = false;
            txtFifthRate.Enabled = false;
            txtFirstTotal.Enabled = false;
            txtSecTotal.Enabled = false;
            txtThirdTotal.Enabled = false;
            txtFourthTotal.Enabled = false;
            txtFifthTotal.Enabled = false;
            txtGrandtotal.Enabled = false;
            txtFirstReplacement.Text = "0.00";
            txtSecReplacement.Text = "0.00";
            txtThirdRepalcement.Text = "0.00";
            txtFourthReplacement.Text = "0.00";
            txtFifthReplacement.Text = "0.00";

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
    }
}