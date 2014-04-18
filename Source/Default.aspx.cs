using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BoreVehicleClassLibrary.DAL;

namespace Source
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            SessionClear();
        }
        protected void btnlog_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            AdminD d_admin = new AdminD();
            string password = txtpassword.Text.Trim();
            if (txtemail.Text != null && txtpassword.Text != null)
            {
                string saltGenSize = password.Substring(password.Length - 4);
                string hashedPasswordAndSalt = d_admin.CreatePasswordHash(txtpassword.Text.Trim(), saltGenSize);
                ds = d_admin.GetLogin(txtemail.Text.ToLower().Trim(), hashedPasswordAndSalt);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            if (ds.Tables[0].Rows[0]["Result"].ToString() == "Success")
                            {
                                Session["UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                                Session["UserType"] = ds.Tables[0].Rows[0]["UserType"].ToString();
                                Session["SelectedVehicleID"] = ds.Tables[0].Rows[0]["VehicleID"].ToString();
                                Session["VehicleName"] = "-1";
                                if (Convert.ToInt32(ds.Tables[0].Rows[0]["VehicleID"].ToString()) == -1)
                                    Response.Redirect("~/VehicleSelection.aspx");
                                else
                                    Response.Redirect("~/General/Welcome.aspx");

                            }
                            else if (ds.Tables[0].Rows[0]["Result"].ToString() == "NotExists")
                            {
                                lblmessage.Text = "User name or Password does not match.";
                            }
                            else
                                lblmessage.Text = "Sorry, please try sometime later.";

                        }
                    }
                    else
                    {
                        lblmessage.Text = "User does not exist.";
                    }
                }

            }

        }

        protected void SessionClear()
        {
            Session["SelectedVehicleID"] = null;
            Session["UserID"] = null;
            Session["UserType"] = null;

            
        }
    }
}