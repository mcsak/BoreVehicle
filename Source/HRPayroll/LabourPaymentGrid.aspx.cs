using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using BoreVehicleClassLibrary.DAL;

namespace Source.HRPayroll
{
    public partial class LabourPaymentGrid : System.Web.UI.Page
    {
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["SortDir"] = "";
                ViewState["SortColIndex"] = "";
                Title = "Outward Casing";
                imgSearch.ImageUrl = "~/Images/searchicongrid.png";
                bindGrid();
            }
        }
        public void bindGrid(string Searchtxt = "", int flag = 0)
        {


            AdminD adminbus = new AdminD();
            if (Searchtxt == "" && flag == 0)
            {
                ds = adminbus.getProfile(Searchtxt, flag);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["Grid"] = ds;
                        gvLabourPayment.DataSource = ds;
                        gvLabourPayment.DataBind();
                        if (ViewState["SortColIndex"].ToString() != "")
                        {
                            HtmlImage imgSort = new HtmlImage();
                            imgSort.Align = "AppsMiddle";
                            imgSort.Style.Add("margin-top", "5px");
                            imgSort.Style.Add("margin-left", "3px");
                            if (ViewState["SortDir"].ToString() == "DESC")
                            {
                                imgSort.Src = "~/Images/sort_desc.gif";
                            }
                            else
                            {
                                imgSort.Src = "~/Images/sort_asc.gif";
                            }

                            gvLabourPayment.HeaderRow.Cells[Convert.ToInt16(ViewState["SortColIndex"].ToString())].Controls.Add(imgSort);
                        }
                    }
                    else
                    {
                        Response.Redirect("~/HRPayrolll/LabourPayment.aspxOID=0&op=1");
                        gvLabourPayment.Visible = false;

                    }
                }
            }
            else
            {
                ds = adminbus.getProfile(Searchtxt, flag);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["Grid"] = ds;
                        gvLabourPayment.DataSource = ds;
                        gvLabourPayment.DataBind();
                        if (ViewState["SortColIndex"].ToString() != "")
                        {
                            HtmlImage imgSort = new HtmlImage();
                            imgSort.Align = "AppsMiddle";
                            imgSort.Style.Add("margin-top", "5px");
                            imgSort.Style.Add("margin-left", "3px");
                            if (ViewState["SortDir"].ToString() == "DESC")
                            {
                                imgSort.Src = "~/Images/sort_desc.gif";
                            }
                            else
                            {
                                imgSort.Src = "~/Images/sort_asc.gif";
                            }
                            
                            gvLabourPayment.HeaderRow.Cells[Convert.ToInt16(ViewState["SortColIndex"].ToString())].Controls.Add(imgSort);
                        }
                    }
                    else
                    {
                        // ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("No matching record found.");

                    }
                }

            }



        }



        private void GridSort(GridView gv)
        {
            DataView dv = new DataView();
            DataTable dt;
            ds = (DataSet)ViewState["Grid"];
            dv = new DataView(ds.Tables[0]);
            dv.Sort = ViewState["SortExp"] + " " + ViewState["SortDir"];
            gv.DataSource = dv;
            dt = dv.ToTable();
            DataSet ds1 = new DataSet();
            ds1.Tables.Add(dt.Copy());
            ViewState["Grid"] = ds1;
            gv.DataBind();
        }
        protected void gvLabourPayment_Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] arrSort = e.SortExpression.ToString().Split('|');
            ViewState["SortExp"] = arrSort[0];
            if ((ViewState["SortColIndex"].ToString() != arrSort[1]) || (ViewState["SortColIndex"].ToString() == ""))
            {
                ViewState["SortDir"] = "ASC";
            }
            else
            {
                if (ViewState["SortDir"].ToString() == "ASC")
                {
                    ViewState["SortDir"] = "DESC";
                }
                else
                {
                    ViewState["SortDir"] = "ASC";
                }
            }
            ViewState["SortColIndex"] = arrSort[1];
            GridSort(gvLabourPayment);
            if (ViewState["SortColIndex"].ToString() != "")
            {
                HtmlImage imgSort = new HtmlImage();
                imgSort.Align = "AppsMiddle";
                if (ViewState["SortDir"].ToString() == "DESC")
                {
                    imgSort.Src = "~/Images/sort_desc.gif";
                }
                else
                {
                    imgSort.Src = "~/Images/sort_asc.gif";
                }
                gvLabourPayment.HeaderRow.Cells[Convert.ToInt16(ViewState["SortColIndex"])].Controls.Add(imgSort);
            }
        }
        protected void gvLabourPayment_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            gvLabourPayment.PageIndex = e.NewPageIndex;
            ds = (DataSet)ViewState["Grid"];
            gvLabourPayment.DataSource = ds;
            gvLabourPayment.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/HRPayrolll/LabourPayment.aspx?OID=0&op=1");

        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            long OID = Convert.ToInt64(Request.Form["optionID"]);
            Response.Redirect("~/HRPayrolll/LabourPayment.aspx?OID=" + OID + "&op=2");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            long OID = Convert.ToInt64(Request.Form["optionID"]);
            Response.Redirect("~/HRPayrolll/LabourPayment.aspx?OID=" + OID + "&op=3");

        }
        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (imgSearch.CommandArgument == "S")
            {
                if (ddlsearchby.SelectedIndex == 0)
                {
                    // ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("select a search by.");
                }

                if (txtsearch.Text == "")
                {
                    //((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("Enter the search text.");
                }
                bindGrid(txtsearch.Text.Trim(), ddlsearchby.SelectedIndex);
                imgSearch.ImageUrl = "~/Images/cancelsearch.png";
                imgSearch.ToolTip = "Close";
                imgSearch.CommandArgument = "C";
                txtsearch.Enabled = false;
            }
            else
            {
                ViewState["SearchText"] = null;

                bindGrid();
                imgSearch.ImageUrl = "~/Images/searchicongrid.png";
                imgSearch.ToolTip = "Go";
                imgSearch.CommandArgument = "S";
                txtsearch.Text = "";
                ((System.Web.UI.HtmlControls.HtmlContainerControl)(Page.Master.FindControl("PageMessage").FindControl("infomsg"))).Style.Add("visibility", "hidden");
                txtsearch.Enabled = true;
            }

        }
    }
}