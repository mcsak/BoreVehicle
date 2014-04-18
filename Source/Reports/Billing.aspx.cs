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
    public partial class Billing : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        AdminD dAdmin = new AdminD();
        GeneralProperty pBilling = new GeneralProperty();
        int loadcase, DiselExpenseID;
        Int64 UserID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {

                pBilling.PointNo = ddlPointNumber.SelectedValue;
                pBilling.DrillingDepthRate = Convert.ToInt64(txtDrillingDepthRate.Text.Trim());
                pBilling.CasingDepthRate = Convert.ToInt64(txtCasingDepthRate.Text.Trim());
                pBilling.WeldingRate = Convert.ToInt64(txtWeldingRate.Text.Trim());
                pBilling.HolePipeRate = Convert.ToInt64(txtHolePipeRate.Text.Trim());
                pBilling.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text.Trim());
                pBilling.AmountPaid = Convert.ToDecimal(txtAmountPaid.Text.Trim());
                pBilling.PartyName = txtpartyname.Text.Trim();
                pBilling.PartyPhoneNumber = txtPartyno.Text.Trim();
                pBilling.PartyAddress = txtAddress.Text;
                pBilling.Remarks = txtReason.Text;
              //  ds = dAdmin.InsertBillingDetails(pBilling, UserID, loadcase);
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
            if (ddlPointNumber.SelectedValue == "0")
            {
                return false;
            }
            else if (txtDrillingDepthRate.Text == "")
            {
                return false;
            }
            else if (txtCasingDepthRate.Text == "")
            {
                return false;
            }
            else if (txtWeldingRate.Text == "")
            {
                return false;
            }
            else if (txtHolePipeRate.Text == "")
            {
                return false;
            }

            else if (txtGrandTotal.Text == "")
            {
                return false;
            }
            else if (txtAmountPaid.Text == "")
            {
                return false;
            }
            else if (txtpartyname.Text == "")
            {
                return false;
            }
            else if (txtPartyno.Text == "")
            {
                return false;
            }
            else if (txtAddress.Text == "")
            {
                return false;
            }
            else if (txtReason.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}