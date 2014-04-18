using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BoreVehicleClassLibrary.DAL;
using System.Data;
using Source.UC;

namespace Source.General
{
    public partial class CommonFundManagementGrid : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        Int64 UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
            if (!IsPostBack)
            {
                ViewState["SortDir"] = "";
                ViewState["SortColIndex"] = "";
                Title = "Inward Casing";
                
                bindGrid();
            }
        }

        public void bindGrid(string Searchtxt = "", Byte flag = 0)
        {
            AdminD dMaster = new AdminD();
            if (Searchtxt == "" && flag == 0)
            {
                ds = dMaster.GetGridCommonFundDetails(Convert.ToInt64(Session["UserID"]));
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["Grid"] = ds;
                        gvCommonFund.DataSource = ds;
                        gvCommonFund.DataBind();
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

                            gvCommonFund.HeaderRow.Cells[Convert.ToInt16(ViewState["SortColIndex"].ToString())].Controls.Add(imgSort);
                        }
                    }
                    else
                    {
                        Response.Redirect("~/General/CommonFundManagement.aspx?OID=0&op=1");
                        gvCommonFund.Visible = false;

                    }
                }
            }
            else
            {
                ds = dMaster.GetGridCommonFundDetails(Convert.ToInt64(Session["UserID"]));
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["Grid"] = ds;
                        gvCommonFund.DataSource = ds;
                        gvCommonFund.DataBind();
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

                            gvCommonFund.HeaderRow.Cells[Convert.ToInt16(ViewState["SortColIndex"].ToString())].Controls.Add(imgSort);
                        }
                    }
                    else
                    {
                        ((PageMessage)(Page.Master.FindControl("PageMessage"))).InfoMessage("No matching record found.");

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
        protected void gvCommonFund_Sorting(object sender, GridViewSortEventArgs e)
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
            GridSort(gvCommonFund);
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
                gvCommonFund.HeaderRow.Cells[Convert.ToInt16(ViewState["SortColIndex"])].Controls.Add(imgSort);
            }
        }
        protected void gvCommonFund_SelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
            gvCommonFund.PageIndex = e.NewPageIndex;
            ds = (DataSet)ViewState["Grid"];
            gvCommonFund.DataSource = ds;
            gvCommonFund.DataBind();
        }

        //protected void btnTransfer_Click(object sender, EventArgs e)
        //{
        //    long OID = Convert.ToInt64(Request.Form["optionID"]);
        //    Response.Redirect("~/General/CommonFundManagement.aspx?OID=" + OID + "&op=1");
        //}
    }
}