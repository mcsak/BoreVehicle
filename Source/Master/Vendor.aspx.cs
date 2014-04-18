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

namespace Source.Master
{
    public partial class Vendor : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        MasterD dMaster = new MasterD();
        AdminProperty pAdmin = new AdminProperty();
        int loadcase, VendorID;
        Int64 UserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadcase = 1;// Convert.ToInt16(Request.QueryString["op"]);
            btnBack.PostBackUrl = "~/General/Welcome.aspx";
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Now.Month.ToString() +"-"+DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                if (loadcase == 1)
                {
                    Title = "Vendor - Add";
                    HeaderTitle.InnerHtml = "Vendor - Add";
                    btnSubmit.Text = "Submit";
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
                    Title = "Vendor - Modify";
                    HeaderTitle.InnerHtml = "Vendor - Modify";
                    btnSubmit.Text = "Modify";
                    VendorID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetVendorDetails(VendorID);
                }
                else if (loadcase == 3)
                {
                    Title = "Vendor - Delete";
                    HeaderTitle.InnerHtml = "Vendor - Delete";
                    btnSubmit.Text = "Delete";
                    txtVendor.Enabled = false;
                    VendorID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetVendorDetails(VendorID);
                }

            }
        }

        //Get Vendor Details

        public void GetVendorDetails(Int64 VendorID)
        {
            ds = new DataSet();
            ds = dMaster.GetVendorDetails(VendorID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtVendor.Text = ds.Tables[0].Rows[0]["VendorName"].ToString();
                        txtContact.Text = ds.Tables[0].Rows[0]["VendorContact"].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0]["VendorAddress"].ToString();
                        txtOthers.Text = ds.Tables[0].Rows[0]["OtherDetails"].ToString();

                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                pAdmin.VendorName = txtVendor.Text.Trim();
                pAdmin.VendorContact = txtContact.Text.Trim();
                pAdmin.VendorAddress = txtAddress.Text;
                pAdmin.Others = txtOthers.Text;
                if (loadcase == 1)
                {
                    ds = dMaster.IUDVendor(pAdmin,VendorID, UserID, loadcase);
                }
                else
                {
                    VendorID = Convert.ToInt16(Request.QueryString["OID"]);
                    ds = dMaster.IUDVendor(pAdmin,VendorID, UserID, loadcase);
                }
                if (ds != null)
                {
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
                                //((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been updated successfully.");
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
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Master/VendorGrid.aspx");
        }

        public Boolean Validation()
        {
            if (txtVendor.Text == "")
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
            ds = dMaster.GetViewAllDetails(3, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvVehicleDetails.DataSource = ds.Tables[0];
                        gvVehicleDetails.DataBind();
                        //btnViewAll.Visible = true;
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
    }
}