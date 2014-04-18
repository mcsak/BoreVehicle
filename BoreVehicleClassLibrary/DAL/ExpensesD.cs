using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoreVehicleClassLibrary.DAL;
using BoreVehicleClassLibrary.PL;

namespace BoreVehicleClassLibrary.DAL
{
    public class ExpensesD
    {
        DBExecution data = new DBExecution();
        public DataSet GetBitExpenseDetails(Int64 BitExpenseID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@BitExpenseID", SqlDbType.BigInt).Value = BitExpenseID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetBitExpenseDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDBitExpenses(ExpensesProperty prop, Int64 BitExpenseID, Int64 UserID, int Action, int VehicleID,DataTable dtBitSizedata)
        {
            data.SQLBulkDataCopy("BitSizesTransTempData", dtBitSizedata);

            SqlCommand sqlcmd = new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@BitExpensesID", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@BitExpensesID", SqlDbType.BigInt).Value = BitExpenseID;
            }
            sqlcmd.Parameters.Add("@ExpenseDate", SqlDbType.DateTime).Value = DateTime.ParseExact(prop.Date, "dd/MM/yyyy", null);
            sqlcmd.Parameters.Add("@BitNumber", SqlDbType.VarChar, 10).Value = DBNull.Value;
            //sqlcmd.Parameters.Add("@Replaceable", SqlDbType.VarChar, 100).Value = prop.Replacable;
            sqlcmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = prop.VendorID;
           // sqlcmd.Parameters.Add("@AmouuntDetails", SqlDbType.VarChar,500).Value = prop.AmountDetails;
            //sqlcmd.Parameters.Add("@GrandTotal", SqlDbType.Int).Value = prop.GrandTotal;
            sqlcmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = prop.TotalAmount;
            sqlcmd.Parameters.Add("@PaidAmount", SqlDbType.Decimal).Value = prop.PaidAmount;
            sqlcmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal).Value = prop.RemainingAmount;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = prop.Remarks;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.Parameters.Add("@Action", SqlDbType.Int).Value = Action;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDBitExpenses";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetVehicleNumber(Int64 UserID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetVehicleNumber";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetDiselExpenseDetails(Int64 DiselExpenseID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@DiselExpenseID", SqlDbType.BigInt).Value = DiselExpenseID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetDiselExpenseDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDDieselExpenses(ExpensesProperty prop, Int64 DiselExpenseID,Int64 UserID,int Action,int VehicleID)
        {
            SqlCommand sqlcmd=new SqlCommand();
            if(Action==1)
            {
                sqlcmd.Parameters.Add("@DiselExpenseID",SqlDbType.BigInt).Value=DBNull.Value;

            }
            else{
                sqlcmd.Parameters.Add("@DiselExpenseID",SqlDbType.BigInt).Value=DiselExpenseID;
            }
            sqlcmd.Parameters.Add("@ExpenseDate", SqlDbType.DateTime).Value = DateTime.ParseExact(prop.Date, "dd/MM/yyyy", null);
            sqlcmd.Parameters.Add("@RPM", SqlDbType.Decimal).Value = prop.RPM;
            sqlcmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = prop.Amount;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = prop.Remarks;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@NoOfLitre", SqlDbType.Decimal).Value = prop.NoOfLitre;
            sqlcmd.Parameters.Add("@Feet", SqlDbType.Decimal).Value = prop.Feet;
            sqlcmd.Parameters.Add("@DieselAvg", SqlDbType.Decimal).Value = prop.DieselAvg;
            sqlcmd.Parameters.Add("@Action", SqlDbType.Int).Value = Action;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDDieselExpenses";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetHammerExpenseDetails(Int64 HammerExpenseID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@HammerExpenseID", SqlDbType.BigInt).Value = HammerExpenseID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetHammerExpenseDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDHammerExpenses(ExpensesProperty prop, Int64 HammerExpenseID, Int64 UserID, int Action,DataTable DtHammerSize,int VehicleID)
        {
            data.SQLBulkDataCopy("HammerSizeTransTempData", DtHammerSize);
            SqlCommand sqlcmd = new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@HammerExpenseID", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@HammerExpenseID", SqlDbType.BigInt).Value = HammerExpenseID;
            }
            sqlcmd.Parameters.Add("@ExpenseDate", SqlDbType.VarChar, 50).Value = prop.Date;
            //sqlcmd.Parameters.Add("@HammerNumber", SqlDbType.VarChar, 10).Value = DBNull.Value;
            //sqlcmd.Parameters.Add("@Replaceable", SqlDbType.VarChar, 100).Value = prop.Replacable;
            sqlcmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = prop.VendorID;
            //sqlcmd.Parameters.Add("@HammerSize6Quantity", SqlDbType.Int).Value = prop.FirstQuantity;
            //sqlcmd.Parameters.Add("@HammerSize6p5Quantity", SqlDbType.Int).Value = prop.SecondQuantity;
            //sqlcmd.Parameters.Add("@HammerSize7Quantity", SqlDbType.Int).Value = prop.ThirdQuantity;
            //sqlcmd.Parameters.Add("@HammerSize7p5Quantity", SqlDbType.Int).Value = prop.FourthQuantity;
            //sqlcmd.Parameters.Add("@HammerSize8Quantity", SqlDbType.Int).Value = prop.FifthQuantity;
            sqlcmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = prop.TotalAmount;
            sqlcmd.Parameters.Add("@PaidAmount", SqlDbType.Decimal).Value = prop.PaidAmount;
            sqlcmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal).Value = prop.RemainingAmount;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = prop.Remarks;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@Action", SqlDbType.Int).Value = Action;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDHammerExpenses";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet InsertSpareSet(long HammerExpensesID,string Spares, long Amount,long UserID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@HammerExpensesID", SqlDbType.BigInt).Value = HammerExpensesID;
            sqlcmd.Parameters.Add("@Spares", SqlDbType.VarChar,100).Value = Spares;
            sqlcmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = Convert.ToDecimal(Amount);
            sqlcmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "InsertSpareSet";
            return data.SelectDataFromDB(sqlcmd);
        }


        public DataSet GetDailyExpenseDetail(Int64 DailyExpenseID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@DailyExpenseID", SqlDbType.BigInt).Value = DailyExpenseID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetDailyExpenseDetail";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDDailyExpenses(ExpensesProperty prop,Int64 DailyExpenseID, Int64 UserID,int Action,int VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@DailyExpenseID", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@DailyExpenseID", SqlDbType.BigInt).Value = DailyExpenseID;
            }
            sqlcmd.Parameters.Add("@DailyExpenseDate", SqlDbType.VarChar,50).Value = prop.Date;
            sqlcmd.Parameters.Add("@BillAmount", SqlDbType.Decimal).Value = prop.BillAmount;
            sqlcmd.Parameters.Add("@BalanceAmount", SqlDbType.Decimal).Value = prop.Balance;
            sqlcmd.Parameters.Add("@BitQuantity", SqlDbType.Int).Value = prop.BitQuantity;
            sqlcmd.Parameters.Add("@BitExpenses", SqlDbType.Decimal).Value = prop.BitExpenses;
            sqlcmd.Parameters.Add("@HammerQuantity", SqlDbType.Int).Value = prop.HammerQuantity;
            sqlcmd.Parameters.Add("@HammerExpenses", SqlDbType.Decimal).Value = prop.HammerExpenses;
            sqlcmd.Parameters.Add("@DieselQuantity", SqlDbType.Decimal).Value = prop.DieselQuantity;
            sqlcmd.Parameters.Add("@DieselAmount", SqlDbType.Decimal).Value = prop.DieselExpenses;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar,500).Value = prop.Remarks;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.Parameters.Add("@Action", SqlDbType.Int).Value = Action;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDDailyExpenses";
            return data.SelectDataFromDB(sqlcmd);
        }
        public DataSet GetBitExpenses(Int64 UserID, Int64 VehicleID, String searchText, byte flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.BigInt).Value = VehicleID;
            sqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = flag;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetBitExpenses";
            return data.SelectDataFromDB(sqlcmd);
        }
        public DataSet GetHammerExpenses(Int64 UserID, Int64 VehicleID, String searchText, byte flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.BigInt).Value = VehicleID;
            sqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = flag;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetHammerExpenses";
            return data.SelectDataFromDB(sqlcmd);
        }
        public DataSet GetDieselExpenses(Int64 UserID, Int64 VehicleID, String searchText, byte flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.BigInt).Value = VehicleID;
            sqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = flag;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetDieselExpenses";
            return data.SelectDataFromDB(sqlcmd);
        }
        public DataSet getEndingRPM(int VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@vehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "getEndingRPM";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataTable GetBitMasterForDropDown()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Value");
            dt.Rows.Add(1, 5);
            dt.Rows.Add(2, 5.5);
            dt.Rows.Add(3, 6);
            dt.Rows.Add(4, 6.5);
            dt.Rows.Add(5, 7);
            dt.Rows.Add(6, 7.5);
            dt.Rows.Add(7, 8);
            dt.Rows.Add(8, 8.5);
            dt.Rows.Add(9, 9);
            dt.Rows.Add(10, 9.5);
            dt.Rows.Add(11, 10);
            dt.Rows.Add(12, 10.5);
            dt.Rows.Add(13, 11);
            dt.Rows.Add(14, 11.5);
            dt.Rows.Add(15, 12);
            return dt;
        }

        public DataSet GetBitExpensesIDForDDL(int VendorID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@FlagType", SqlDbType.TinyInt).Value = 1;
            sqlcmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = VendorID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetDDLDataForHammerAndBit";
            return data.SelectDataFromDB(sqlcmd);            
        }

        public DataSet GetHammerExpensesIDForDDL(int VendorID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@FlagType", SqlDbType.TinyInt).Value = 2;
            sqlcmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = VendorID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetDDLDataForHammerAndBit";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDOtherExpenses(ExpensesProperty prop, Int64 OtherExpensesID, Int64 UserID, int Action,int VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@OtherExpensesID", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@OtherExpensesID", SqlDbType.BigInt).Value = OtherExpensesID;
            }
            sqlcmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.ParseExact(prop.Date, "dd/MM/yyyy", null);
            sqlcmd.Parameters.Add("@Particulars", SqlDbType.VarChar, 500).Value = prop.Particulars;
            sqlcmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = prop.Amount;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@Action", SqlDbType.Int).Value = Action;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDOtherExpenses";
            return data.SelectDataFromDB(sqlcmd);

        }
    }
}
