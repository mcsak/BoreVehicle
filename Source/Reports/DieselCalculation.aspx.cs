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

namespace Source.Report
{
    public partial class DieselCalculation : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        ExpensesD dAdmin = new ExpensesD();
        ExpensesProperty pExpense = new ExpensesProperty();
        int loadcase, DiselExpenseID;
        Int64 UserID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation() == true)
            {
                pExpense.TotalNumberDiesel = Convert.ToInt64(txtDieselltr.Text.Trim());
                pExpense.TotalDrillDepth = Convert.ToInt64(txttotaldrilldept.Text.Trim());
                pExpense.DieselAverage = Convert.ToInt64(txtDieselAvg.Text.Trim());
                pExpense.TotalDepth = Convert.ToInt64(txtTotalDepth.Text);
                pExpense.TotalRPM = Convert.ToInt64(txtTotalRPM.Text);
                pExpense.DrillingAverage = Convert.ToInt64(txtDrillingAvg.Text);

                //ds = dAdmin.InsertDieselCalculation(pExpense, UserID, loadcase);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Result"].ToString() == "S")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been added successfully.");
                            btnCancel.PostBackUrl = "~/Admin/BrandGrid.aspx";
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "U")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been updated successfully.");
                        }
                        else if (ds.Tables[0].Rows[0]["Result"].ToString() == "D")
                        {
                            btnSubmit.Visible = false;
                            btnCancel.Text = "Back";
                            ((PageMessage)(Page.Master.FindControl("PageMessage"))).SuccessMessage("Your data has been deleted successfully.");
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

        public Boolean Validation()
        {
            if (txtDieselltr.Text == "")
            {
                return false;
            }
            else if (txttotaldrilldept.Text == "")
            {
                return false;
            }
            else if (txtDieselAvg.Text == "")
            {
                return false;
            }
            else if (txtTotalDepth.Text == "")
            {
                return false;
            }

            else if (txtTotalRPM.Text == "")
            {
                return false;
            }
            else if (txtDrillingAvg.Text == "")
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
    }
}