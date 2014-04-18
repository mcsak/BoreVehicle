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
    public partial class Labour : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        MasterD dMaster = new MasterD();
        AdminProperty pAdmin = new AdminProperty();
        int loadcase, LabourID;
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
                    Title = "Labour - Add";
                    HeaderTitle.InnerHtml = "Labour - Add";
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
                    Title = "Labour - Modify";
                    HeaderTitle.InnerHtml = "Labour - Modify";
                    btnSubmit.Text = "Modify";
                    LabourID =Convert.ToInt16(Request.QueryString["OID"]);
                    GetLabourDetails(LabourID);
                }
                else if (loadcase == 3)
                {
                    Title = "Labour - Delete";
                    HeaderTitle.InnerHtml = "Labour - Delete";
                    btnSubmit.Text = "Delete";
                    txtLabourName.Enabled = false;
                    txtContact.Enabled = false;
                    txtAddress.Enabled = false;
                    txtOthers.Enabled = false;
                    LabourID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetLabourDetails(LabourID);
                }

            }
        }


        //Get Labour Details

        public void GetLabourDetails(Int64 LabourID)
        {
            ds = new DataSet();
            ds = dMaster.GetLabourDetails(LabourID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtLabourName.Text = ds.Tables[0].Rows[0]["LaberName"].ToString();                        
                        txtContact.Text = ds.Tables[0].Rows[0]["LaberContact"].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0]["LaberAddress"].ToString();
                        txtOthers.Text = ds.Tables[0].Rows[0]["OtherDetails"].ToString();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                pAdmin.LabourName = txtLabourName.Text.Trim();
                pAdmin.labourContact = txtContact.Text.Trim();
                pAdmin.LabourAddress = txtAddress.Text;
                pAdmin.Others = txtOthers.Text;

                if (loadcase == 1)
                {
                    ds = dMaster.IUDLabour(pAdmin, LabourID, UserID, loadcase);
                }
                else
                {
                    LabourID = Convert.ToInt16(Request.QueryString["OID"]);
                    ds = dMaster.IUDLabour(pAdmin, LabourID, UserID, loadcase);
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Master/LabourGrid.aspx");
        }
        public Boolean Validation()
        {
            if (txtLabourName.Text == "")
            {
                return false;
            }
            else if (txtContact.Text == "")
            {
                return false;
            }
            else if (txtAddress.Text == "")
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
            ds=dMaster.GetViewAllDetails(1,Convert.ToInt16(Session["SelectedVehicleID"].ToString()),txtFromDate.Text,txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvLabourDetails.DataSource = ds.Tables[0];
                        gvLabourDetails.DataBind();
                        btnViewLabours.Visible = true;
                    }
                    else
                    {
                        //btnViewLabours.Visible = false;
                    }
                }
                else
                {
                    //btnViewLabours.Visible = false;
                }
                
            }
            else
            {
               // btnViewLabours.Visible = false;
            }
            updpnlPopup.Update();
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showdetail();", true);
        }

        protected void btnViewLabours_Click(object sender, EventArgs e)
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