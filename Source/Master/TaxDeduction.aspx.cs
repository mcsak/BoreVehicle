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
    public partial class TaxDeduction : System.Web.UI.Page
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

                if (loadcase == 1)
                {
                    Title = "Tax Deduction";
                    HeaderTitle.InnerHtml = "Tax Deduction";
                    btnSubmit.Text = "Submit";
                    if (Request.QueryString["nav"] != null)
                    {
                        if (Request.QueryString["nav"].ToString() == "1")
                        {
                            btnBack.PostBackUrl = "~/Welcome.aspx";
                        }
                    }
                    bindTaxDeduction();
                }
            }
        }


        public void bindTaxDeduction()
        {
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
                            txttaxDeduction.Text = "0";
                        }
                        else
                        {
                            txttaxDeduction.Text = ds.Tables[0].Rows[0]["Value"].ToString();
                        }
                        
                       
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txttaxDeduction.Text == "")
            {
                PageMessageUpdate(6, "Enter the tax deduction.");
            }
            else
            {
                if (loadcase == 1)
                {
                    ds = dMaster.UpdateTaxDeduction(txttaxDeduction.Text.Trim(), UserID, loadcase);
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
    }
}