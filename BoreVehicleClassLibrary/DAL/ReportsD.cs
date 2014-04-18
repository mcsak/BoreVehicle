using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BoreVehicleClassLibrary.DAL
{
   public class ReportsD
    {
        DBExecution data = new DBExecution();
        public DataSet GetSiteMgmtMonthStatusDetails(Byte SearchFlag, String SearchText)
        {
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = SearchFlag;
            SqlCmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 50).Value = SearchText;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "GetSiteMgmtMonthStatusDetails";
            return data.SelectDataFromDB(SqlCmd);
        }

        public DataSet GetCurrentStockDetails(Byte Flag,byte SearchFlag, String SearchText)
        {
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = SearchFlag;
            SqlCmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 50).Value = SearchText;
            SqlCmd.Parameters.Add("@Flag", SqlDbType.TinyInt).Value = Flag;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "GetCurrentStockDetails";
            return data.SelectDataFromDB(SqlCmd);
        }

        public DataSet GetBalanceLedgerDeatils(Byte SearchFlag, String SearchText,String FromDate,String Todate)
        {
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = SearchFlag;
            SqlCmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 50).Value = SearchText;
            SqlCmd.Parameters.Add("@FromDate", SqlDbType.VarChar, 25).Value = FromDate;
            SqlCmd.Parameters.Add("@Todate", SqlDbType.VarChar, 25).Value = Todate;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "GetBalanceLedgerDeatils";
            return data.SelectDataFromDB(SqlCmd);
        }

        public DataSet GetBalanceDetails(Byte SearchFlag, String SearchText)
        {
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = SearchFlag;
            SqlCmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 50).Value = SearchText;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "GetBalanceDetails";
            return data.SelectDataFromDB(SqlCmd);
        }

        public DataSet GetBalanceTransactionsForLead(long LeadID)
        {
            SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Parameters.Add("@LeadID", SqlDbType.TinyInt).Value = LeadID;
            SqlCmd.CommandType = CommandType.StoredProcedure;
            SqlCmd.CommandText = "GetBalanceTransactionsForLead";
            return data.SelectDataFromDB(SqlCmd);
        }

    }


}
