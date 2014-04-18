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

namespace Source.General
{
    public partial class CommonFundManagement : System.Web.UI.Page
    {
        Int32 VehicleID;
        Int64 UserID;
        Int16 loadcase;
        AdminD dAdmin = new AdminD();
        AdminProperty prop = new AdminProperty();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
            loadcase = Convert.ToInt16(Request.QueryString["op"]);
            VehicleID = Convert.ToInt32(Request.QueryString["OID"]);

            if (!IsPostBack)
            {
                GetVehicleList();
                if (loadcase == 1)
                {
                    Title = "Fund Transfer";
                    HeaderTitle.InnerHtml = "Fund Transfer";
                    btnSubmit.Text = "Submit";
                    if (Request.QueryString["nav"] != null)
                    {
                        if (Request.QueryString["nav"].ToString() == "1")
                        {
                            btnBack.PostBackUrl = "~/Welcome.aspx";
                        }
                    }
                }
            }
        }


        public void GetVehicleList()
        {
            CasingD dCasing = new CasingD();
            DataSet ds = new DataSet();
            ds = new DataSet();
            ds = dCasing.GetVehicleList();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddlVehicle.DataTextField = "VehicleNumber";
                        ddlVehicle.DataValueField = "VehicleID";
                        ddlVehicle.DataSource = ds;
                        ddlVehicle.DataBind();
                        ddlVehicle.Items.Insert(0, new ListItem("<--Select-->", "0"));
                        ddlVehicle.Items.Insert(1, new ListItem("Common Fund", "-1"));

                        ddlCommonVehicle.DataTextField = "VehicleNumber";
                        ddlCommonVehicle.DataValueField = "VehicleID";
                        ddlCommonVehicle.DataSource = ds;
                        ddlCommonVehicle.DataBind();
                        ddlCommonVehicle.Items.Insert(0, new ListItem("<--Select-->", "0"));
                        ddlCommonVehicle.Items.Insert(1, new ListItem("Common Fund", "-1"));
                        btnSubmit.Visible = true;
                    }

                    else
                    {
                        ddlVehicle.Items.Insert(0, new ListItem("--No Data--", "-2"));
                        ddlCommonVehicle.Items.Insert(0, new ListItem("--No Data--", "-2"));
                        btnSubmit.Visible = false;
                    }
                }
                else
                {
                    ddlVehicle.Items.Insert(0, new ListItem("--No Data--", "-2"));
                    ddlCommonVehicle.Items.Insert(0, new ListItem("--No Data--", "-2"));
                    btnSubmit.Visible = false;
                }
            }
        }


        public void ViewAllDetail()
        {
            MasterD dMaster = new MasterD();
            DataSet ds = new DataSet();
            ds = dMaster.GetViewAllDetails(7, Convert.ToInt16(Session["SelectedVehicleID"].ToString()), txtFromDate.Text, txtToDate.Text);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvCommonFundDetails.DataSource = ds.Tables[0];
                        gvCommonFundDetails.DataBind();
                        btnView.Visible = true;
                    }
                    else
                    {
                        btnView.Visible = false;
                    }
                }
                else
                {
                    btnView.Visible = false;
                }

            }
            else
            {
                btnView.Visible = false;
            }

            updpnlPopup.Update();
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "showdetail();", true);
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            ViewAllDetail();
        }

        protected void ddlVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = dAdmin.GetSelectedVehicleDetails(Convert.ToInt32(ddlVehicle.SelectedValue));
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblVehicleName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        lblAvailableAmount.Text = ds.Tables[0].Rows[0]["AvailableAmount"].ToString();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                prop.FromVehicleCommon = Convert.ToInt32(ddlVehicle.SelectedValue);
                prop.TransferAmount = Convert.ToDecimal(txtTransferAmount.Text);
                prop.ToVehicleCommon = Convert.ToInt32(ddlCommonVehicle.SelectedValue);
                DataSet dSet = new DataSet();
                dSet = dAdmin.TransferFund(prop, UserID);
                if (dSet != null)
                {
                    if (dSet.Tables.Count > 0)
                    {
                        if (dSet.Tables[0].Rows.Count > 0)
                        {
                            if (dSet.Tables[0].Rows[0]["Result"].ToString() == "S")
                            {
                                PageMessageUpdate(5, "Your data has been added successfully.");
                            }
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
            if (ddlVehicle.SelectedValue == "0")
            {
                return false;
            }
            else if (txtTransferAmount.Text == "")
            {
                return false;
            }
            else if (txtTransferAmount.Text.Contains("-"))
            {
                return false;
            }
            else if (Convert.ToDecimal(txtTransferAmount.Text) >Convert.ToDecimal(lblAvailableAmount.Text))
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