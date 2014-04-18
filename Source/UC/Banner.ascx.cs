using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BoreVehicleClassLibrary.DAL;

namespace Source.UC
{
    public partial class Banner : System.Web.UI.UserControl
    {
        MasterD MasterD_Object;
        protected void Page_Load(object sender, EventArgs e)
        {
            MasterD_Object = new MasterD();
            if (!IsPostBack)
                BindVehicleddl(Convert.ToInt32(Session["UserID"].ToString()));

        }

        protected void BindVehicleddl(int UserID)
        {
            SpnUsername.InnerText = Session["UserType"].ToString();
            DataSet DsVehicleMaster = new DataSet();
            DsVehicleMaster = MasterD_Object.GetVehicleMasterDataForOption(Convert.ToInt32(Session["UserID"]));
            if (DsVehicleMaster != null && DsVehicleMaster.Tables.Count > 0)
            {
                if (DsVehicleMaster.Tables[0].Rows.Count > 0)
                {
                    ddlVehicleNumber.DataSource = DsVehicleMaster.Tables[0];
                    ddlVehicleNumber.DataMember = "VehicleID";
                    ddlVehicleNumber.DataTextField = "VehicleNumber";
                    ddlVehicleNumber.DataBind();
                    ddlVehicleNumber.Items.Insert(0, new ListItem("<--Select-->", "-1"));
                }
                //
                String Str;
                Str = Session["SelectedVehicleID"].ToString();
                
                if (Session["SelectedVehicleID"] != null && Convert.ToInt32(Session["SelectedVehicleID"].ToString()) != 0 && Convert.ToInt32(Session["SelectedVehicleID"].ToString()) != -1)
                {
                    ddlVehicleNumber.SelectedValue = Session["SelectedVehicleNumber"].ToString();
                    ddlVehicleNumber.Enabled = false;
                    //ddlVehicleNumber.SelectedValue = Session["SelectedVehicleID"].ToString();
                }
            }
        }
        

        protected void ddlVehicleNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlVehicleNumber.BackColor = System.Drawing.Color.White;
            DataSet Ds = new DataSet();
            Ds = MasterD_Object.GetVehicleNameForSession(Convert.ToInt32(ddlVehicleNumber.SelectedValue));
            Session["SelectedVehicleNumber"] = ddlVehicleNumber.SelectedValue;
            Session["SelectedVehicleID"] = Ds.Tables[0].Rows[0]["VehicleID"].ToString();
            Session["VehicleName"] = Ds.Tables[0].Rows[0]["Name"].ToString();
            ddlVehicleNumber.Enabled = false;
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            HttpRuntime.Close();
            Response.Redirect("~/Default.aspx");
        }
    }
}