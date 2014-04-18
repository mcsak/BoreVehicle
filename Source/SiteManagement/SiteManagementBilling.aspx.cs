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

namespace Source.SiteManagement
{
    public partial class SiteManagementBilling : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        SiteManagementD dMgmt = new SiteManagementD();
        GeneralProperty pBilling = new GeneralProperty();
        int loadcase, VehicleID;
        Int64 UserID, LeadID;

        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            VehicleID = Convert.ToInt16(HttpContext.Current.Session["SelectedVehicleID"].ToString());
            if (!IsPostBack)
            {
               // InnerMaster inm = Master as InnerMaster;
                //UpdatePanel updpnl = (UpdatePanel)inm.FindControl("updpnlMaster");
                txtFromDate.Text = DateTime.Now.Month.ToString() +"-"+DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                bindTaxDeduction();
                getPointNumberList();
            }
        }

        public void getPointNumberList()
        {
            ds = dMgmt.getPointNumberList(VehicleID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlPointNumber.DataTextField = "PointNumber";
                        ddlPointNumber.DataValueField = "LeadID";
                        ddlPointNumber.DataSource = ds;
                        ddlPointNumber.DataBind();
                        ddlPointNumber.Items.Insert(0, new ListItem("<--Select-->", "0"));
                    }
                    else
                    {
                        ddlPointNumber.Items.Insert(0, new ListItem("--No Data--", "0"));
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {

                pBilling.PointNo = ddlPointNumber.SelectedValue;
                pBilling.BillingDrillingRate = Convert.ToDecimal(txtDrillingDepthRate.Text.Trim());
                pBilling.BillingCasingRate = Convert.ToDecimal(txtCasingDepthRate.Text.Trim());
                pBilling.BillingWeldingRate = Convert.ToDecimal(txtWeldingRate.Text.Trim());
                pBilling.BillingHolesPipeRate = Convert.ToDecimal(txtHolePipeRate.Text.Trim());
                pBilling.BillingCollarRate = Convert.ToDecimal(txtCollarRate.Text.Trim());


                pBilling.BillingDrillingTotal = Convert.ToDecimal(txtDrillingDepthRateTotal.Text.Trim());
                pBilling.BillingCasingTotal = Convert.ToDecimal(txtCasingDepthRateTotal.Text.Trim());
                pBilling.BillingWeldingTotal = Convert.ToDecimal(txtWeldingRateTotal.Text.Trim());
                pBilling.BillingHolesPipeTotal = Convert.ToDecimal(txtHolePipeRateTotal.Text.Trim());
                pBilling.BillingCollarTotal = Convert.ToDecimal(txtCollarRateTotal.Text.Trim());

                pBilling.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text.Trim());
                pBilling.AmountPaid = Convert.ToDecimal(txtAmountPaid.Text.Trim());
                pBilling.LeadID = Convert.ToInt64(ddlPointNumber.SelectedValue);
                //pBilling.PartyName = txtpartyname.Text.Trim();
                //pBilling.PartyNumber = txtPartyno.Text.Trim();
                //pBilling.PartyAddress = txtAddress.Text;
                pBilling.Remarks = txtRemarks.Text;
                ds = dMgmt.InsertBillingDetails(pBilling, UserID, VehicleID);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Result"].ToString() == "S")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";                            
                            PageMessageUpdate(5, "Your data has been added successfully.");
                            
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "U")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            PageMessageUpdate(5, "Your data has been updated successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "D")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            PageMessageUpdate(5, "Your data has been deleted successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "AEx")
                        {
                            
                            PageMessageUpdate(6, "This record already exists.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "ND")
                        {
                            PageMessageUpdate(6, "Contact to Administrator..");
                        }
                    }
                }

            }
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
        }

        public Boolean Validation()
        {
            if (ddlPointNumber.SelectedValue == "0")
            {
                return false;
            }
            else if (Convert.ToDecimal(txtGrandTotal.Text) < ((Convert.ToDecimal(txtAmountPaid.Text)) + (Convert.ToDecimal(txtPreviousPaid.Text))))
            {

                return false;
            }
            else
            {
                return true;
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


        protected void ddlPointNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            LeadID = Convert.ToInt64(ddlPointNumber.SelectedValue);

            ds = dMgmt.GetLeadDetail(LeadID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtpartyname.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
                        txtPartyno.Text = ds.Tables[0].Rows[0]["PartyPhoneNumber"].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0]["PartyAddress"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                        lblDrillingDepth.Text = ds.Tables[0].Rows[0]["DrillingDepth"].ToString();
                        lblCasingDepth.Text = ds.Tables[0].Rows[0]["CasingDepth"].ToString();
                        lblWeldingDepth.Text = ds.Tables[0].Rows[0]["Welding"].ToString();
                        lblHolePipe.Text = ds.Tables[0].Rows[0]["HolesPipe"].ToString();
                        lblCollar.Text = ds.Tables[0].Rows[0]["Collar"].ToString();  

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txtDrillingDepthRate.Text = ds.Tables[1].Rows[0]["DrillingDepthRate"].ToString();
                        txtCasingDepthRate.Text = ds.Tables[1].Rows[0]["CasingDepthRate"].ToString();
                        txtWeldingRate.Text = ds.Tables[1].Rows[0]["WeldingRate"].ToString();
                        txtHolePipeRate.Text = ds.Tables[1].Rows[0]["HolesPipeRate"].ToString();
                        txtCollarRate.Text = ds.Tables[1].Rows[0]["CollarRate"].ToString();
                        txtGrandTotal.Text = ds.Tables[1].Rows[0]["TotalBillingAmount"].ToString();
                        txtPreviousPaid.Text = ds.Tables[1].Rows[0]["PreviousPaid"].ToString();

                        txtDrillingDepthRateTotal.Text = ds.Tables[1].Rows[0]["DrillingDepthTotal"].ToString();
                        txtCasingDepthRateTotal.Text = ds.Tables[1].Rows[0]["CasingDepthTotal"].ToString();
                        txtWeldingRateTotal.Text = ds.Tables[1].Rows[0]["WeldingTotal"].ToString();
                        txtHolePipeRateTotal.Text = ds.Tables[1].Rows[0]["HolesPipeTotal"].ToString();
                        txtCollarRateTotal.Text = ds.Tables[1].Rows[0]["CollarTotal"].ToString();
                        //txtCollarRateTotal.Text = Convert.ToString(Convert.ToDecimal(lblHolePipe.Text) * Convert.ToDecimal(txtHolePipeRate.Text));
                       // txtGrandTotal.Text =Convert.ToString(Convert.ToDecimal(txtDrillingDepthRateTotal.Text) + Convert.ToDecimal(txtCasingDepthRateTotal.Text) + Convert.ToDecimal(txtWeldingRateTotal.Text) + Convert.ToDecimal(txtHolePipeRateTotal.Text));                        
                    }
                    else
                    {
                        txtDrillingDepthRate.Text = "0.00";
                        txtCasingDepthRate.Text = "0.00";
                        txtWeldingRate.Text = "0.00";
                        txtHolePipeRate.Text = "0.00";
                        txtCollarRate.Text = "0.00";
                        txtGrandTotal.Text = "0.00";
                        txtPreviousPaid.Text = "0.00";

                        txtDrillingDepthRateTotal.Text = "0.00";
                        txtCasingDepthRateTotal.Text = "0.00";
                        txtWeldingRateTotal.Text = "0.00";
                        txtHolePipeRateTotal.Text = "0.00";
                        txtCollarRateTotal.Text = "0.00";
                    }
                }
            }
        }

        public void bindTaxDeduction()
        {
            MasterD dMaster = new MasterD();
            ds = new DataSet();
            ds = dMaster.GetTaxDeduction();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Value"].ToString() == "")
                        {
                            txtTaxDeduction.Text = "0";
                        }
                        else
                        {
                            txtTaxDeduction.Text = ds.Tables[0].Rows[0]["Value"].ToString();
                        }


                    }
                }
            }
        }

        public void GetGrandTotalCalc()
        {
            decimal Grandtotal = 0;
            txtGrandTotal.Text = "0.00";
          //  Grandtotal = Convert.ToDecimal(txtDrillingDepthRate.Text) + Convert.ToDecimal(txtCasingDepthRate.Text) + Convert.ToDecimal(txtWeldingRate.Text) + Convert.ToDecimal(txtHolePipeRate.Text);
            //if (rdbdrillingvariationyes.Checked == true && rdbcasingvariationyes.Checked==true)
            //{
            //    Grandtotal = Convert.ToDecimal(txtDrillingvariation.Text) + Convert.ToDecimal(txtCasingVariation.Text) + Convert.ToDecimal(txtWeldingRateTotal.Text) + Convert.ToDecimal(txtHolePipeRateTotal.Text);
            //    txtGrandTotal.Text = Convert.ToString(Grandtotal);
            //    drillingdepthrate.Visible = false;
            //    caseingdepthrate.Visible = false;
            //    totaldrillingvariation.Visible = true;
            //    totalcasingvariation.Visible = true;
            //}
            //if (rdbdrillingvariationyes.Checked == false && rdbcasingvariationyes.Checked == false)
            //{
            Grandtotal = Convert.ToDecimal(txtDrillingDepthRateTotal.Text) + Convert.ToDecimal(txtCasingDepthRateTotal.Text) + Convert.ToDecimal(txtWeldingRateTotal.Text) + Convert.ToDecimal(txtHolePipeRateTotal.Text) + Convert.ToDecimal(txtCollarRateTotal.Text);
                txtGrandTotal.Text = Convert.ToString(Grandtotal);
                drillingdepthrate.Visible = true;
                caseingdepthrate.Visible = true;
                //totaldrillingvariation.Visible = false;
                //totalcasingvariation.Visible = false;
            //}
            //if (rdbdrillingvariationyes.Checked == true && rdbcasingvariationyes.Checked == false)
            //{
            //    Grandtotal = Convert.ToDecimal(txtDrillingvariation.Text) + Convert.ToDecimal(txtCasingDepthRateTotal.Text) + Convert.ToDecimal(txtWeldingRateTotal.Text) + Convert.ToDecimal(txtHolePipeRateTotal.Text);
            //    txtGrandTotal.Text = Convert.ToString(Grandtotal);
            //    drillingdepthrate.Visible = false;
            //    caseingdepthrate.Visible = true;
            //    totaldrillingvariation.Visible = true;
            //    totalcasingvariation.Visible = false;
            //}
            //if (rdbdrillingvariationyes.Checked == false && rdbcasingvariationyes.Checked == true)
            //{
            //    Grandtotal = Convert.ToDecimal(txtDrillingDepthRateTotal.Text) + Convert.ToDecimal(txtCasingVariation.Text) + Convert.ToDecimal(txtWeldingRateTotal.Text) + Convert.ToDecimal(txtHolePipeRateTotal.Text);
            //    txtGrandTotal.Text = Convert.ToString(Grandtotal);
            //    drillingdepthrate.Visible = true;
            //    caseingdepthrate.Visible = false;
            //    totaldrillingvariation.Visible = false;
            //    totalcasingvariation.Visible = true;
            //}
            updpnlMainContentBilling.Update();
        }
        protected void txtCasingVariation_TextChanged(object sender, EventArgs e)
        {
            GetGrandTotalCalc();
        }

        protected void txtDrillingvariation_TextChanged(object sender, EventArgs e)
        {
            GetGrandTotalCalc();
        }

        protected void txtDrillingDepthRate_TextChanged(object sender, EventArgs e)
        {
            decimal Drilleachtotal;
            Drilleachtotal=Convert.ToDecimal(lblDrillingDepth.Text)*Convert.ToDecimal(txtDrillingDepthRate.Text);
            txtDrillingDepthRateTotal.Text =Convert.ToString(Drilleachtotal);
            GetGrandTotalCalc();
            updpnlMainContentBilling.Update();
        }

        protected void txtCasingDepthRate_TextChanged(object sender, EventArgs e)
        {
            decimal Casingeachtotal;
            Casingeachtotal = Convert.ToDecimal(lblCasingDepth.Text) * Convert.ToDecimal(txtCasingDepthRate.Text);
            txtCasingDepthRateTotal.Text = Convert.ToString(Casingeachtotal);
            GetGrandTotalCalc();
            updpnlMainContentBilling.Update();
        }

        protected void txtWeldingRate_TextChanged(object sender, EventArgs e)
        {
            decimal Weldingeachtotal;
            Weldingeachtotal = Convert.ToDecimal(lblWeldingDepth.Text) * Convert.ToDecimal(txtWeldingRate.Text);
            txtWeldingRateTotal.Text = Convert.ToString(Weldingeachtotal);
            GetGrandTotalCalc();
            updpnlMainContentBilling.Update();
        }

        protected void txtHolePipeRate_TextChanged(object sender, EventArgs e)
        {
            decimal holdingeachtotal;
            holdingeachtotal = Convert.ToDecimal(lblHolePipe.Text) * Convert.ToDecimal(txtHolePipeRate.Text);
            txtHolePipeRateTotal.Text = Convert.ToString(holdingeachtotal);
            GetGrandTotalCalc();
            updpnlMainContentBilling.Update();
        }

        public void ViewAllDetail()
        {
            MasterD dMaster = new MasterD();
            ds = dMaster.GetViewAllDetails(12, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvBillingDetails.DataSource = ds.Tables[0];
                        gvBillingDetails.DataBind();
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
               // btnViewAll.Visible = false;
            }
            //OnClientClick="return showdetail()"
           // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "showdetail()", "showdetail()");
            updpnlPopup.Update();
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showdetail();", true);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //PageMessageUpdate(6, "TestMessage..");
            Response.Redirect("~/SiteManagement/SiteManagementBilling.aspx");
        }

        protected void txtCollar_TextChanged(object sender, EventArgs e)
        {
            decimal collareachtotal;
            collareachtotal = Convert.ToDecimal(lblCollar.Text) * Convert.ToDecimal(txtCollarRate.Text);
            txtCollarRateTotal.Text = Convert.ToString(collareachtotal);
            GetGrandTotalCalc();
            updpnlMainContentBilling.Update();
        }

        protected void txtDrillingDepthRateTotal_TextChanged(object sender, EventArgs e)
        {
            GetGrandTotalCalc();
        }

        protected void txtCasingDepthRateTotal_TextChanged(object sender, EventArgs e)
        {
            GetGrandTotalCalc();
        }

        protected void txtWeldingRateTotal_TextChanged(object sender, EventArgs e)
        {
            GetGrandTotalCalc();
        }

        protected void txtHolePipeRateTotal_TextChanged(object sender, EventArgs e)
        {
            GetGrandTotalCalc();
        }

        protected void txtCollarRateTotal_TextChanged(object sender, EventArgs e)
        {
            GetGrandTotalCalc();
        }

        //Calculate funtionality Total in pop up of  drilling rate

        protected void txtDrilldepthqtybox1_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal1.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox1.Text) * Convert.ToDecimal(txtDrilldepthratebox1.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
           

        }

        protected void txtDrilldepthqtybox2_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal2.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox2.Text) * Convert.ToDecimal(txtDrilldepthratebox2.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
        }

        protected void txtDrilldepthqtybox3_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal3.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox3.Text) * Convert.ToDecimal(txtDrilldepthratebox3.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthqtybox4_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal4.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox4.Text) * Convert.ToDecimal(txtDrilldepthratebox4.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthqtybox5_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal5.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox5.Text) * Convert.ToDecimal(txtDrilldepthratebox5.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthqtybox6_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal6.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox6.Text) * Convert.ToDecimal(txtDrilldepthratebox6.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthqtybox7_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal7.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox7.Text) * Convert.ToDecimal(txtDrilldepthratebox7.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthqtybox8_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal8.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox8.Text) * Convert.ToDecimal(txtDrilldepthratebox8.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

         
        protected void txtDrilldepthratebox1_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal1.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox1.Text) * Convert.ToDecimal(txtDrilldepthratebox1.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthratebox2_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal2.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox2.Text) * Convert.ToDecimal(txtDrilldepthratebox2.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthratebox3_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal3.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox3.Text) * Convert.ToDecimal(txtDrilldepthratebox3.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthratebox4_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal4.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox4.Text) * Convert.ToDecimal(txtDrilldepthratebox4.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthratebox5_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal5.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox5.Text) * Convert.ToDecimal(txtDrilldepthratebox5.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthratebox6_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal6.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox6.Text) * Convert.ToDecimal(txtDrilldepthratebox6.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthratebox7_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal7.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox7.Text) * Convert.ToDecimal(txtDrilldepthratebox7.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }

        protected void txtDrilldepthratebox8_TextChanged(object sender, EventArgs e)
        {
            txtdrillpopuptotal8.Text = Convert.ToString(Convert.ToDecimal(txtDrilldepthqtybox8.Text) * Convert.ToDecimal(txtDrilldepthratebox8.Text));
            GetDrillingGrandTotalValue();
            upddrill.Update();
            
        }
        

        public void GetDrillingGrandTotalValue()
        {
            txtpopupdrillinggrandtotal.Text = Convert.ToString(Convert.ToDecimal(txtdrillpopuptotal1.Text) + Convert.ToDecimal(txtdrillpopuptotal2.Text) + Convert.ToDecimal(txtdrillpopuptotal3.Text) + Convert.ToDecimal(txtdrillpopuptotal4.Text) + Convert.ToDecimal(txtdrillpopuptotal5.Text) + Convert.ToDecimal(txtdrillpopuptotal6.Text) + Convert.ToDecimal(txtdrillpopuptotal7.Text) + Convert.ToDecimal(txtdrillpopuptotal8.Text));
            upddrill.Update();
           // 
        }


        //Total calculation of grand total in casing pop up


        protected void txtCasedepthqtybox1_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal1.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox1.Text) * Convert.ToDecimal(txtCasedepthratebox1.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            

        }

        protected void txtCasedepthqtybox2_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal2.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox2.Text) * Convert.ToDecimal(txtCasedepthratebox2.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthqtybox3_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal3.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox3.Text) * Convert.ToDecimal(txtCasedepthratebox3.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthqtybox4_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal4.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox4.Text) * Convert.ToDecimal(txtCasedepthratebox4.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthqtybox5_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal5.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox5.Text) * Convert.ToDecimal(txtCasedepthratebox5.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthqtybox6_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal6.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox6.Text) * Convert.ToDecimal(txtCasedepthratebox6.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthqtybox7_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal7.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox7.Text) * Convert.ToDecimal(txtCasedepthratebox7.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthqtybox8_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal8.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox8.Text) * Convert.ToDecimal(txtCasedepthratebox8.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthratebox1_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal1.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox1.Text) * Convert.ToDecimal(txtCasedepthratebox1.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            

        }

        protected void txtCasedepthratebox2_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal2.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox2.Text) * Convert.ToDecimal(txtCasedepthratebox2.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthratebox3_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal3.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox3.Text) * Convert.ToDecimal(txtCasedepthratebox3.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthratebox4_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal4.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox4.Text) * Convert.ToDecimal(txtCasedepthratebox4.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthratebox5_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal5.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox5.Text) * Convert.ToDecimal(txtCasedepthratebox5.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthratebox6_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal6.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox6.Text) * Convert.ToDecimal(txtCasedepthratebox6.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthratebox7_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal7.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox7.Text) * Convert.ToDecimal(txtCasedepthratebox7.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }

        protected void txtCasedepthratebox8_TextChanged(object sender, EventArgs e)
        {
            txtCasingpopuptotal8.Text = Convert.ToString(Convert.ToDecimal(txtCasedepthqtybox8.Text) * Convert.ToDecimal(txtCasedepthratebox8.Text));
            GetCasingGrandTotalValue();
            updCasing.Update();
            
        }


        

        public void GetCasingGrandTotalValue()
        {
            txtpopupcasinggrandtotal.Text = Convert.ToString(Convert.ToDecimal(txtCasingpopuptotal1.Text) + Convert.ToDecimal(txtCasingpopuptotal2.Text) + Convert.ToDecimal(txtCasingpopuptotal3.Text) + Convert.ToDecimal(txtCasingpopuptotal4.Text) + Convert.ToDecimal(txtCasingpopuptotal5.Text) + Convert.ToDecimal(txtCasingpopuptotal6.Text) + Convert.ToDecimal(txtCasingpopuptotal7.Text) + Convert.ToDecimal(txtCasingpopuptotal8.Text));
            updCasing.Update();
            
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
        }

       }
}