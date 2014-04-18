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
    public partial class ManagerPayment : System.Web.UI.Page
    {
          DataSet ds = new DataSet();
        HRManagement dHRmgmt = new HRManagement();
        AdminProperty pAdmin = new AdminProperty();
        int loadcase, ManagerPaymentID;
        Int64 UserID;
        protected void Page_Load(object sender, EventArgs e)
        {

            loadcase = 1;// Convert.ToInt16(Request.QueryString["op"]);
            btnBack.PostBackUrl = "~/General/Welcome.aspx";
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            
            if (!IsPostBack)
            {
                GetManagerName();
                txtFromDate.Text = DateTime.Now.Month.ToString() +"-"+DateTime.Now.Year.ToString();
                txtToDate.Text = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                if (loadcase == 1)
                {
                    Title = "Manager Payment - Add";
                    HeaderTitle.InnerHtml = "Manager Payment  - Add";
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
                    Title = "Manager Payment  - Modify";
                    HeaderTitle.InnerHtml = "Manager Payment  - Modify";
                    btnSubmit.Text = "Modify";
                    ManagerPaymentID = Convert.ToInt16(Request.QueryString["RID"]);
                    GetManagerPaymentDetails(ManagerPaymentID);
                }
                else if (loadcase == 3)
                {
                    Title = "Manager Payment  - Delete";
                    HeaderTitle.InnerHtml = "Manager Payment  - Delete";
                    btnSubmit.Text = "Delete";
                    txtManagerName.Enabled = false;
                    txtDate.Enabled = false;
                    txtAdvanceAmount.Enabled = false;
                    txtRemarks.Enabled = false;
                    ManagerPaymentID = Convert.ToInt16(Request.QueryString["RID"]);
                    GetManagerPaymentDetails(ManagerPaymentID);
                }

            }
        }


        //Get Vehicle Details

        public void GetManagerPaymentDetails(Int64 ManagerPaymentID)
        {
            ds = new DataSet();
            ds = dHRmgmt.GetManagerPaymentDetails(ManagerPaymentID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtManagerName.Text = ds.Tables[0].Rows[0]["ManagerName"].ToString();
                        txtDate.Text = ds.Tables[0].Rows[0]["Date"].ToString();
                        txtAdvanceAmount.Text = ds.Tables[0].Rows[0]["AdvanceAmount"].ToString();
                        txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    }
                }
            }
        }


        public void GetManagerName()
        {
            ds = dHRmgmt.GetManagerName();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlUserName.DataTextField = "ManagerName";
                        ddlUserName.DataValueField = "ManagerID";
                        ddlUserName.DataSource = ds;
                        ddlUserName.DataBind();
                        ddlUserName.Items.Insert(0, new ListItem("<--Select-->", "0"));
                    }
                    else
                    {
                        ddlUserName.Items.Insert(0, new ListItem("--No Data--", "0"));
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (Validation() == true)
            {
                //pAdmin.ManagerName = txtManagerName.Text.Trim();
                pAdmin.ManagerUserID = Convert.ToInt64(ddlUserName.SelectedValue);
                pAdmin.Date = txtDate.Text.Trim();
                pAdmin.Amount = txtAdvanceAmount.Text.Trim();
                if (txtSalary.Text == "")
                {
                    pAdmin.ManagerSalary = 0;
                }
                else
                {
                    pAdmin.ManagerSalary = Convert.ToDecimal(txtSalary.Text.Trim());
                }
                
                pAdmin.Remarks = txtRemarks.Text;

                if (loadcase == 1)
                {
                    ds = dHRmgmt.IUDManagerPayment(pAdmin,ManagerPaymentID, UserID, loadcase);
                }
                else
                {
                    ManagerPaymentID = Convert.ToInt16(Request.QueryString["RID"]);
                    ds = dHRmgmt.IUDManagerPayment(pAdmin,ManagerPaymentID, UserID, loadcase);
                }
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
                           // ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been updated successfully.");
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
            Response.Redirect("~/HRPayroll/ManagerPaymentGrid.aspx");
        }

        public Boolean Validation()
        {
            //if (txtManagerName.Text == "")
            //{
            //    return false;
            //}
            if (ddlUserName.SelectedValue == "0")
            {
                return false;
            }
            else if (txtDate.Text == "")
            {
                return false;
            }
            //else if (txtAdvanceAmount.Text == "")
            //{
            //    return false;
            //}
            else if (txtRemarks.Text == "")
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
            ds = dMaster.GetViewAllDetails(5, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvManagerDetails.DataSource = ds.Tables[0];
                        gvManagerDetails.DataBind();
                        btnViewAll.Visible = true;
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

        protected void btnCloseAccount_Click(object sender, EventArgs e)
        {
            DataSet dSet = new DataSet();
            dSet = dHRmgmt.CloseManagerUserAccount(Convert.ToInt64(ddlUserName.SelectedValue),Convert.ToInt64(HttpContext.Current.Session["UserID"]));
            if (dSet != null)
            {
                if (dSet.Tables.Count > 0)
                {
                    if (dSet.Tables[0].Rows.Count > 0)
                    {
                        if (dSet.Tables[0].Rows[0]["Result"].ToString() == "S")
                        {
                            btnSubmit.Visible = false;
                            btnBack.Text = "Back";
                            btnBack.PostBackUrl = "~/General/Welcome.aspx";
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been added successfully.");
                            //btnBack.PostBackUrl = "~/Admin/BrandGrid.aspx";
                            PageMessageUpdate(5, "Your data has been added successfully.");
                        }
                    }
                }
            }
        }

    }
}