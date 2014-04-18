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

namespace Source.HRPayroll
{
    public partial class LabourPayment : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        HRManagement dHRmgmt = new HRManagement();
        AdminProperty pAdmin = new AdminProperty();
        int loadcase, LabourPaymentID;
        Int64 UserID;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadcase = 1;// Convert.ToInt16(Request.QueryString["op"]);
            btnBack.PostBackUrl = "~/General/Welcome.aspx";
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            if (!IsPostBack)
            {
               // ViewAllDetail();
                GetLabourName();
                //txtFromDate.Text = DateTime.Now.Month.ToString() +"-"+DateTime.Now.Year.ToString();
                txtFromDate.Text = DateTime.Now.Month.ToString() +"-"+DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                //txtToDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                if (loadcase == 1)
                {
                    Title = "Labour Payment - Add";
                    HeaderTitle.InnerHtml = "Labour Payment  - Add";
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
                    Title = "Labour Payment  - Modify";
                    HeaderTitle.InnerHtml = "Labour Payment  - Modify";
                    btnSubmit.Text = "Modify";
                    LabourPaymentID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetLabourPaymentDetails(LabourPaymentID);
                }
                else if (loadcase == 3)
                {
                    Title = "Labour Payment  - Delete";
                    HeaderTitle.InnerHtml = "Labour Payment  - Delete";
                    btnSubmit.Text = "Delete";
                    txtLabourName.Enabled = false;
                    txtDate.Enabled = false;
                    txtAmount.Enabled = false;
                    LabourPaymentID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetLabourPaymentDetails(LabourPaymentID);
                }

            }
        }

        //Get Labour Payment Details

        public void GetLabourPaymentDetails(Int64 LabourPaymentID)
        {
            ds = new DataSet();
            ds = dHRmgmt.GetLabourPaymentDetails(LabourPaymentID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtLabourName.Text = ds.Tables[0].Rows[0]["LabourName"].ToString();
                        txtDate.Text = ds.Tables[0].Rows[0]["Date"].ToString();
                        txtAmount.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    }
                }
            }
        }


        public void GetLabourName()
        {
            ds = dHRmgmt.GetLabourName();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlLabourName.DataTextField = "LaberName";
                        ddlLabourName.DataValueField = "LaberID";
                        ddlLabourName.DataSource = ds;
                        ddlLabourName.DataBind();
                        ddlLabourName.Items.Insert(0, new ListItem("<--Select-->", "0"));
                    }
                    else
                    {
                        ddlLabourName.Items.Insert(0, new ListItem("--No Data--", "0"));
                    }
                }
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                pAdmin.LabourID = Convert.ToInt64(ddlLabourName.SelectedValue);

                pAdmin.Date = txtDate.Text.Trim();
                pAdmin.Amount = txtAmount.Text.Trim();
                pAdmin.Remarks = txtRemarks.Text;

                if (loadcase == 1)
                {
                    ds = dHRmgmt.IUDLabourPayment(pAdmin, LabourPaymentID, UserID, loadcase);
                }
                else
                {
                    LabourPaymentID = Convert.ToInt16(Request.QueryString["OID"]);
                    ds = dHRmgmt.IUDLabourPayment(pAdmin, LabourPaymentID, UserID, loadcase);
                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Result"].ToString() == "S")
                        {
                            btnSubmit.Visible = false;
                            btnBack.Text = "Back";
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been added successfully.");
                            //btnBack.PostBackUrl = "~/Admin/BrandGrid.aspx";
                            btnBack.PostBackUrl = "~/General/Welcome.aspx";
                            PageMessageUpdate(5, "Your data has been saved successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "U")
                        {
                            btnSubmit.Visible = false;
                            btnBack.Text = "Back";
                            btnBack.PostBackUrl = "~/General/Welcome.aspx";
                           // ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been updated successfully.");
                            PageMessageUpdate(5, "Your data has been updated successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "D")
                        {
                            btnSubmit.Visible = false;
                            btnBack.Text = "Back";
                            btnBack.PostBackUrl = "~/General/Welcome.aspx";
                           // ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been deleted successfully.");
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
            Response.Redirect("~/HRPayroll/LabourPaymentGrid.aspx");
        }

        public Boolean Validation()
        {
            //if (txtLabourName.Text == "")
            //{
            //    return false;
            //}
            if (ddlLabourName.SelectedValue == "0")
            {
                return false;
            }
            else if (txtDate.Text == "")
            {
                return false;
            }
            else if (txtAmount.Text == "")
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
            ds = dMaster.GetViewAllDetails(4, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvLabourDetails.DataSource = ds.Tables[0];
                        gvLabourDetails.DataBind();
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