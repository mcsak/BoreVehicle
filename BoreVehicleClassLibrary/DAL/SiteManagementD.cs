using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoreVehicleClassLibrary.DAL;
using BoreVehicleClassLibrary.PL;

namespace BoreVehicleClassLibrary.DAL
{
    public class SiteManagementD
    {
        DBExecution data = new DBExecution();

        public DataSet GetSiteManagementDetails(Int64 SiteMgmtID,int VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@LeadID", SqlDbType.BigInt).Value = SiteMgmtID;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetSiteManagementDetails";
            return data.SelectDataFromDB(sqlcmd);
        }



        public DataSet IUDSiteManagement(GeneralProperty prop,Int64 SiteMgmtID,Int64 UserID,int Action)
        {
            SqlCommand sqlcmd=new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@LeadID", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@LeadID", SqlDbType.BigInt).Value = SiteMgmtID;
            }
            /*Site management input calculation values*/
            sqlcmd.Parameters.Add("@PointNo",SqlDbType.VarChar,25).Value=prop.PointNo;
            sqlcmd.Parameters.Add("@DrillerName", SqlDbType.VarChar, 200).Value = prop.DrillerName;
            sqlcmd.Parameters.Add("@DrillingDepth", SqlDbType.Decimal).Value = prop.DrillingDepthRate;
            sqlcmd.Parameters.Add("@CasingDepth", SqlDbType.Decimal).Value = prop.CasingDepthRate;
            sqlcmd.Parameters.Add("@Welding", SqlDbType.Int).Value = prop.Welding;
            sqlcmd.Parameters.Add("@Cap", SqlDbType.Int).Value = prop.Cap;
            sqlcmd.Parameters.Add("@HolesPipe", SqlDbType.Int).Value = prop.HolesPipe;
            sqlcmd.Parameters.Add("@StartingRPM", SqlDbType.Decimal).Value = prop.StartingRPM;
            sqlcmd.Parameters.Add("@EndingRPM", SqlDbType.Decimal).Value = prop.EndingRPM;
            sqlcmd.Parameters.Add("@Collar", SqlDbType.Int).Value = prop.Collar;
            sqlcmd.Parameters.Add("@Bit", SqlDbType.VarChar, 50).Value = prop.BitSiteMgmg;
            sqlcmd.Parameters.Add("@Hammer", SqlDbType.VarChar, 50).Value = prop.HammerSiteMgmt;
            /*Sitemangement party details*/
            sqlcmd.Parameters.Add("@PartyName", SqlDbType.VarChar, 200).Value = prop.PartyName;
            sqlcmd.Parameters.Add("@PartyPhoneNumber", SqlDbType.VarChar, 250).Value = prop.PartyPhoneNumber;
            sqlcmd.Parameters.Add("@PartyAddress", SqlDbType.VarChar, 500).Value = prop.PartyAddress;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = prop.Remarks;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = prop.VehicleID;
            sqlcmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            sqlcmd.Parameters.Add("@Action", SqlDbType.TinyInt).Value = Action;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDSiteManagement";
            return data.SelectDataFromDB(sqlcmd);            
        }
        public DataSet GetSiteMangementLeads(Int64 UserID,Int64 VehicleID, String searchText, byte flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.BigInt).Value = VehicleID;
            sqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = flag;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetSiteMangementLeads";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet getPointNumberList(int VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "getPointNumberList";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetLeadDetail(Int64 LeadID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@LeadID", SqlDbType.BigInt).Value = LeadID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetLeadDetail";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet InsertBillingDetails(GeneralProperty prop,Int64 UserID,int VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@DrillingDepthRate", SqlDbType.Decimal).Value = prop.BillingDrillingRate;
            sqlcmd.Parameters.Add("@CasingDepthRate", SqlDbType.Decimal).Value = prop.BillingCasingRate;
            sqlcmd.Parameters.Add("@WeldingRate", SqlDbType.Decimal).Value = prop.BillingWeldingRate;
            sqlcmd.Parameters.Add("@HolesPipeRate", SqlDbType.Decimal).Value = prop.BillingHolesPipeRate;
            sqlcmd.Parameters.Add("@CollarRate", SqlDbType.Decimal).Value = prop.BillingCollarRate;
            sqlcmd.Parameters.Add("@DrillingDepthTotal", SqlDbType.Decimal).Value = prop.BillingDrillingTotal;
            sqlcmd.Parameters.Add("@CasingDepthTotal", SqlDbType.Decimal).Value = prop.BillingCasingTotal;
            sqlcmd.Parameters.Add("@WeldingTotal", SqlDbType.Decimal).Value = prop.BillingWeldingTotal;
            sqlcmd.Parameters.Add("@HolesPipeTotal", SqlDbType.Decimal).Value = prop.BillingHolesPipeTotal;
            sqlcmd.Parameters.Add("@CollarTotal", SqlDbType.Decimal).Value = prop.BillingCollarTotal;
            
            sqlcmd.Parameters.Add("@GrandTotal", SqlDbType.Decimal).Value = prop.GrandTotal;
            sqlcmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal).Value = prop.AmountPaid;
            sqlcmd.Parameters.Add("@LeadID", SqlDbType.BigInt).Value = prop.LeadID;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = prop.Remarks;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "InsertBillingDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public Boolean InsertMonthStatus(int NoOfLiteres,string Remarks,Int64 UserID, int VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@NoOfLiteres", SqlDbType.Int, 500).Value = NoOfLiteres;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = Remarks;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "InsertMonthStatus";
            return data.InsertUpdateDeleteToDB(sqlcmd);
        }

    }
}
