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
    public partial class Vehicle : System.Web.UI.Page
    {

        DataSet ds = new DataSet();
        MasterD dMaster = new MasterD();
        AdminProperty pAdmin = new AdminProperty();
        int loadcase, VehicleID;
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
                    Title = "Vehicle - Add";
                    HeaderTitle.InnerHtml = "Vehicle - Add";
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
                    Title = "Vehicle - Modify";
                    HeaderTitle.InnerHtml = "Vehicle - Modify";
                    btnSubmit.Text = "Modify";
                    VehicleID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetVehicleDetails(VehicleID);
                }
                else if (loadcase == 3)
                {
                    Title = "Vehicle - Delete";
                    HeaderTitle.InnerHtml = "Vehicle - Delete";
                    btnSubmit.Text = "Delete";
                    txtVehicle.Enabled = false;
                    txtName.Enabled = false;
                    txtOthers.Enabled = false;
                    VehicleID = Convert.ToInt16(Request.QueryString["OID"]);
                    GetVehicleDetails(VehicleID);
                }

            }
        }

        //Get Vehicle Details

        public void GetVehicleDetails(Int64 VehicleID)
        {
            ds = new DataSet();
            ds = dMaster.GetVehicleDetails(VehicleID);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtVehicle.Text = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                        txtName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        txtOthers.Text = ds.Tables[0].Rows[0]["Others"].ToString();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                pAdmin.VehicleNumber = txtVehicle.Text.Trim();
                pAdmin.VehicleName = txtName.Text.Trim();
                pAdmin.Others = txtOthers.Text;

                if (loadcase == 1)
                {
                    ds = dMaster.IUDVehicle(pAdmin,VehicleID, UserID, loadcase);
                }
                else
                {
                    VehicleID = Convert.ToInt16(Request.QueryString["OID"]);
                    ds = dMaster.IUDVehicle(pAdmin,VehicleID, UserID, loadcase);
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
                            //((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("This record already exists.");
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
            Response.Redirect("~/Master/VehicleGrid.aspx");
        }

        public Boolean Validation()
        {
            if (txtVehicle.Text == "")
            {
                return false;
            }
            if (txtName.Text == "")
            {
                return false;
            }
            if (txtOthers.Text == "")
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
            ds = dMaster.GetViewAllDetails(2, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvVehicleDetails.DataSource = ds.Tables[0];
                        gvVehicleDetails.DataBind();
                       // btnViewAll.Visible = true;
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