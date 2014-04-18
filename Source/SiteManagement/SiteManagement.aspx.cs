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
    public partial class SiteManagement : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        SiteManagementD dSiteMgmt = new SiteManagementD();
        GeneralProperty pSiteMgmt = new GeneralProperty();
        int loadcase;
        Int64 UserID, SiteMgmtID;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["UserID"] = 1;
            loadcase = Convert.ToInt16(Request.QueryString["op"])==0 ? 1:  1;
            //btnCancel.PostBackUrl = "~/Admin/SiteManagementGrid.aspx";
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            if (!IsPostBack)
            {
                if (loadcase == 1 )
                {
                    loadcase = 1;
                    Title = "Site Management - Add";
                    HeaderTitle.InnerHtml = "Site Management  - Add";
                    btnSubmit.Text = "Submit";
                    //txtpointno.ReadOnly = true;
                    if (Request.QueryString["nav"] != null)
                    {
                        if (Request.QueryString["nav"].ToString() == "1")
                        {
                            btnCancel.PostBackUrl = "~/Welcome.aspx";
                        }
                    }
                    GetSiteManagementDetails(-1, Convert.ToInt32(Session["SelectedVehicleID"].ToString()));
                }
                else if (loadcase == 2)
                {
                    Title = "Site Management  - Modify";
                    HeaderTitle.InnerHtml = "Site Management  - Modify";
                    btnSubmit.Text = "Modify";
                    SiteMgmtID = Convert.ToInt64(Request.QueryString["OID"]);
                    GetSiteManagementDetails(SiteMgmtID, Convert.ToInt32(Session["SelectedVehicleID"].ToString()));
                }
                else if (loadcase == 3)
                {
                    Title = "Site Management  - Delete";
                    HeaderTitle.InnerHtml = "Site Management  - Delete";
                    btnSubmit.Text = "Delete";
                    txtpointno.Enabled = false;
                    txtdrillername.Enabled = false;
                    txtDrillingdepth.Enabled = false;
                    txtCasingdepth.Enabled = false;
                    txtWelding.Enabled = false;
                    txtCap.Enabled = false;
                    txtHolespipe.Enabled = false;
                    txtStartingrpm.Enabled = false;

                    txtEndinngrpm.Enabled = false;
                    txtpartyname.Enabled = false;
                    txtPartyPoneno.Enabled = false;
                    txtAddress.Enabled = false;
                    txtRemarks.Enabled = false;
                    SiteMgmtID = Convert.ToInt64(Request.QueryString["OID"]);
                    GetSiteManagementDetails(SiteMgmtID, Convert.ToInt32(Session["SelectedVehicleID"].ToString()));
                }

            }
        }

        //Get Site Management Details

        public void GetSiteManagementDetails(Int64 SiteMgmtID,int VehicleID)
        {
            ds = new DataSet();
            ds = dSiteMgmt.GetSiteManagementDetails(SiteMgmtID,VehicleID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0 && SiteMgmtID != -1)
                    {
                        txtpointno.Text = ds.Tables[0].Rows[0]["PointNo"].ToString();
                        txtdrillername.Text = ds.Tables[0].Rows[0]["DrillerName"].ToString();
                        txtDrillingdepth.Text = ds.Tables[0].Rows[0]["DrillerDepth"].ToString();
                        txtCasingdepth.Text = ds.Tables[0].Rows[0]["CasingDepth"].ToString();
                        txtWelding.Text = ds.Tables[0].Rows[0]["Welding"].ToString();
                        txtCap.Text = ds.Tables[0].Rows[0]["WeldingCap"].ToString();
                        txtHolespipe.Text = ds.Tables[0].Rows[0]["HolePipe"].ToString();
                        txtStartingrpm.Text = ds.Tables[0].Rows[0]["StartingRPM"].ToString();
                        txtEndinngrpm.Text = ds.Tables[0].Rows[0]["EndingRPM"].ToString();
                        txtpartyname.Text = ds.Tables[0].Rows[0]["PartyName"].ToString();
                        txtPartyPoneno.Text = ds.Tables[0].Rows[0]["PartyNo"].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                    }
                    else
                    {
                        txtpointno.ReadOnly = false;
                        txtpointno.Text = ds.Tables[0].Rows[0]["PointNo"].ToString();
                        txtStartingrpm.Text = ds.Tables[0].Rows[0]["EndingRPM"].ToString();
                        txtpointno.ReadOnly = true;
                        txtStartingrpm.ReadOnly = true;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                pSiteMgmt.PointNo = txtpointno.Text;
                pSiteMgmt.DrillerName = txtdrillername.Text;
                pSiteMgmt.DrillingDepthRate = Convert.ToInt64(txtDrillingdepth.Text);
                pSiteMgmt.CasingDepthRate = Convert.ToInt64(txtCasingdepth.Text);
                pSiteMgmt.Welding = Convert.ToInt32(txtWelding.Text);
                pSiteMgmt.Cap = Convert.ToInt32(txtCap.Text);
                pSiteMgmt.HolesPipe = Convert.ToInt32(txtHolespipe.Text);
                pSiteMgmt.StartingRPM = Convert.ToDecimal(txtStartingrpm.Text);
                pSiteMgmt.EndingRPM = Convert.ToDecimal(txtEndinngrpm.Text);
                pSiteMgmt.PartyName = txtpartyname.Text;
                pSiteMgmt.PartyPhoneNumber = txtPartyPoneno.Text;
                pSiteMgmt.PartyAddress = txtAddress.Text;
                pSiteMgmt.Remarks = txtRemarks.Text;
                pSiteMgmt.Collar = Convert.ToInt32(txtCollar.Text);
                pSiteMgmt.BitSiteMgmg = txtBit.Text;
                pSiteMgmt.HammerSiteMgmt = txtHammer.Text;
                pSiteMgmt.VehicleID = Convert.ToInt16(Session["SelectedVehicleID"].ToString());

                if (loadcase == 1)
                {
                    ds = dSiteMgmt.IUDSiteManagement(pSiteMgmt, SiteMgmtID, UserID, loadcase);
                }
                else
                {
                    SiteMgmtID = Convert.ToInt16(Request.QueryString["OID"]);
                    ds = dSiteMgmt.IUDSiteManagement(pSiteMgmt, SiteMgmtID, UserID, loadcase);
                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Result"].ToString() == "S")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";

                            if (ds.Tables[1].Rows.Count > 0)
                                PageMessageUpdate(5, "Your data has been added successfully. Point Number : " + ds.Tables[1].Rows[0]["PointNumber"].ToString());
                            else
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
                            PageMessageUpdate(6, "Delete the model related to this brand before delete this record..");
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
            if (txtpointno.Text == "")
            {
                return false;
            }
            else if (txtdrillername.Text == "")
            {
                return false;
            }
            else if (txtDrillingdepth.Text == "")
            {
                return false;
            }
            else if (txtCasingdepth.Text == "")
            {
                return false;
            }
            else if (txtCap.Text == "")
            {
                return false;
            }

            else if (txtHolespipe.Text == "")
            {
                return false;
            }
            else if (txtStartingrpm.Text == "")
            {
                return false;
            }
            else if (txtEndinngrpm.Text == "")
            {
                return false;
            }
            else if (txtpartyname.Text == "")
            {
                return false;
            }
            else if (txtPartyPoneno.Text == "")
            {
                return false;
            }
            else if (txtAddress.Text == "")
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/General/Welcome.aspx");
        }

    }
}
