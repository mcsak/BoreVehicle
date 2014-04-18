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

namespace Source.Casing
{
    public partial class InwardCasing : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        CasingD dCasing = new CasingD();
        GeneralProperty pCasing = new GeneralProperty();
        int loadcase, InwardCasingID, VehicleID;
        Int64 UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadcase = 1;// Convert.ToInt16(Request.QueryString["op"]);
            btnCancel.PostBackUrl = "~/General/Welcome.aspx";
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            VehicleID = Convert.ToInt16(HttpContext.Current.Session["SelectedVehicleID"].ToString());
            if (!IsPostBack)
            {
                //ViewAllDetail();
                getVendorList();
                txtFromDate.Text = DateTime.Now.Month.ToString() +"-"+DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                if (loadcase == 1)
                {
                    Title = "Inward Casing - Add";
                    HeaderTitle.InnerHtml = "Inward Casing  - Add";
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
                    Title = "Inward Casing  - Modify";
                    HeaderTitle.InnerHtml = "Inward Casing  - Modify";
                    btnSubmit.Text = "Modify";
                    InwardCasingID =  Convert.ToInt16(Request.QueryString["OID"]);
                    GetCasingInwardDetails(InwardCasingID);
                }
                else if (loadcase == 3)
                {
                    Title = "Inward Casing  - Delete";
                    HeaderTitle.InnerHtml = "Inward Casing  - Delete";
                    btnSubmit.Text = "Delete";
                    txtDate.Enabled = false;
                    txtQuantity.Enabled = false;
                    txtBillAmount.Enabled = false;
                    txtVehicleNo.Enabled = false;
                    ddlVendorname.Enabled = false;
                    //txtPersonName.Enabled = false;
                    txtRemarks.Enabled = false;
                    InwardCasingID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetCasingInwardDetails(InwardCasingID);
                }

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
                        ddlVendorname.DataTextField = "vendorName";
                        ddlVendorname.DataValueField = "VendorID";
                        ddlVendorname.DataSource = ds;
                        ddlVendorname.DataBind();
                        ddlVendorname.Items.Insert(0, new ListItem("<--Select-->", "0"));
                    }

                    else
                    {
                        ddlVendorname.Items.Insert(0, new ListItem("--No Data--", "0"));
                    }
                }
            }
        }

        

        public void GetCasingInwardDetails(Int64 InwardCasingID)
        {
            ds = new DataSet();
            ds = dCasing.GetCasingInwardDetails(InwardCasingID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtDate.Text = ds.Tables[0].Rows[0]["CasingDate"].ToString();
                        txtQuantity.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
                        txtBillAmount.Text = ds.Tables[0].Rows[0]["BillAmount"].ToString();
                        txtVehicleNo.Text = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                        ddlVendorname.SelectedValue = ds.Tables[0].Rows[0]["VendorID"].ToString();                     
                        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                pCasing.Date = txtDate.Text.Trim();
                pCasing.Quantity = Convert.ToInt64(txtQuantity.Text.Trim());
                pCasing.BillNumber = txtBillNo.Text.Trim();
                pCasing.BillAmount =Convert.ToDecimal(txtBillAmount.Text);
                pCasing.PartyVehicleNumber = txtVehicleNo.Text.Trim();
                pCasing.VendorName =Convert.ToInt64(ddlVendorname.SelectedValue);
                //pCasing.PersonName = txtPersonName.Text.Trim();
                pCasing.Remarks = txtRemarks.Text.Trim();


                if (loadcase == 1)
                {
                    ds = dCasing.IUDInwardCasing(pCasing, InwardCasingID, UserID, loadcase, VehicleID);
                }
                else
                {
                    InwardCasingID =  Convert.ToInt16(Request.QueryString["OID"]);
                    ds = dCasing.IUDInwardCasing(pCasing, InwardCasingID, UserID, loadcase, VehicleID);
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
                          //  ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been updated successfully.");
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
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("This record already exists.");
                            PageMessageUpdate(6, "This record already exists.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "ND")
                        {
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("Delete the model related to this brand before delete this record..");
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
            else if (txtQuantity.Text == "")
            {
                return false;
            }
            else if (txtVehicleNo.Text == "")
            {
                return false;
            }
            if (ddlVendorname.SelectedValue == "0")
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

        }

        public void ViewAllDetail()
        {
            MasterD dMaster=new MasterD();
            ds = dMaster.GetViewAllDetails(6, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvCasingInwardDetails.DataSource = ds.Tables[0];
                        gvCasingInwardDetails.DataBind();
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
    }
}