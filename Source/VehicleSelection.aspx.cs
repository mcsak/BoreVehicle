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
    public partial class VehicleSelection : System.Web.UI.Page
    {
        MasterD MasterD_Object = new MasterD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindVehicleddl(Convert.ToInt32(Session["UserID"].ToString()));
        }

        protected void BindVehicleddl(int UserID)
        {
            //SpnUsername.InnerText = Session["UserType"].ToString();
                        
            DataSet DsVehicleMaster = new DataSet();
            DsVehicleMaster = MasterD_Object.GetVehicleMasterDataForOption(Convert.ToInt32(Session["UserID"]));
            if (DsVehicleMaster != null && DsVehicleMaster.Tables.Count > 0)
            {
                if (DsVehicleMaster.Tables[0].Rows.Count > 0)
                {
                    ddlVehicleNumberSelection.DataSource = DsVehicleMaster.Tables[0];
                    ddlVehicleNumberSelection.DataMember = "VehicleID";
                    ddlVehicleNumberSelection.DataTextField = "VehicleNumber";
                    ddlVehicleNumberSelection.DataBind();
                    ddlVehicleNumberSelection.Items.Insert(0, new ListItem("<--Select-->"));
                    ddlVehicleNumberSelection.SelectedIndex = 0;
                }

            }
        }

        protected void ddlVehicleNumberSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlVehicleNumberSelection.BackColor = System.Drawing.Color.White;
            DataSet Ds = new DataSet();
            
            Ds = MasterD_Object.GetVehicleNameForSession(Convert.ToInt32(ddlVehicleNumberSelection.SelectedValue));
            Session["SelectedVehicleNumber"] = ddlVehicleNumberSelection.SelectedValue;
            Session["SelectedVehicleID"] = Ds.Tables[0].Rows[0]["VehicleID"].ToString();
            Session["VehicleName"] = Ds.Tables[0].Rows[0]["Name"].ToString();
            Response.Redirect("~/General/Welcome.aspx");
        }
    }
}