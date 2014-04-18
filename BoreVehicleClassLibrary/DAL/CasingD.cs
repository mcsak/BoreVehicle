using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BoreVehicleClassLibrary.PL;

namespace BoreVehicleClassLibrary.DAL
{
    public class CasingD
    {
        DBExecution data = new DBExecution();
        public DataSet GetOutwardCasing(Int64 UserID, Int64 VehicleID, String searchText, byte flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.BigInt).Value = VehicleID;
            sqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = flag;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetOutwardCasing";
            return data.SelectDataFromDB(sqlcmd);
        }
        public DataSet getInward(Int64 UserID, Int64 VehicleID, String searchText, byte flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.BigInt).Value = VehicleID;
            sqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = flag;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "getInward";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet getVendorList()
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "getVendorList";
            return data.SelectDataFromDB(sqlcmd);
        }
        //public DataSet getBitexpenseID(int VendorID )
        //{
        //    SqlCommand sqlcmd = new SqlCommand();
        //    sqlcmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = VendorID;
        //    sqlcmd.CommandType = CommandType.StoredProcedure;
        //    sqlcmd.CommandText = "getBitexpenseID";
        //    return data.SelectDataFromDB(sqlcmd);
        //}
        public DataSet GetBitReplacement(Int64 BitID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@bitID", SqlDbType.Int).Value = BitID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetBitReplacement";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetHammerReplacement(Int64 HammerID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@HammerID", SqlDbType.Int).Value = HammerID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetHammerReplacement";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetVehicleList()
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetVehicleList";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetCasingInwardDetails(Int64 CasingInwardID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@CasingInwardID", SqlDbType.BigInt).Value = CasingInwardID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetCasingInwardDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDInwardCasing(GeneralProperty prop, Int64 CasingInwardID, Int64 UserID, int Action,int VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@CasingInwardID", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@CasingInwardID", SqlDbType.BigInt).Value = CasingInwardID;
            }
            sqlcmd.Parameters.Add("@CasingDate", SqlDbType.DateTime).Value = DateTime.ParseExact(prop.Date, "dd/MM/yyyy", null);
            sqlcmd.Parameters.Add("@CasingQuantity", SqlDbType.Int).Value = prop.Quantity;
            sqlcmd.Parameters.Add("@BillNumber", SqlDbType.VarChar, 25).Value = prop.BillNumber;
            sqlcmd.Parameters.Add("@BillAmount", SqlDbType.Decimal).Value = prop.BillAmount;
            sqlcmd.Parameters.Add("@VehicleNo", SqlDbType.VarChar,25).Value = prop.PartyVehicleNumber;
            sqlcmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = prop.VendorName;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = prop.Remarks;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@Action", SqlDbType.Int).Value = Action;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDInwardCasing";
            return data.SelectDataFromDB(sqlcmd);

        }

        public DataSet GetCasingOutwardDetails(Int64 OutwardCasingID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@CasingOutwardID", SqlDbType.BigInt).Value = OutwardCasingID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetCasingOutwardDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDOutwardCasing(GeneralProperty prop, Int64 OutwardCasingID, Int64 UserID, int Action,int VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@CasingOutwardID", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@CasingOutwardID", SqlDbType.BigInt).Value = OutwardCasingID;
            }
            sqlcmd.Parameters.Add("@CasingDate", SqlDbType.DateTime).Value = DateTime.ParseExact(prop.Date, "dd/MM/yyyy", null);
            sqlcmd.Parameters.Add("@CasingQuantity", SqlDbType.Int).Value = prop.Quantity;
            sqlcmd.Parameters.Add("@PersonName", SqlDbType.VarChar, 100).Value = prop.PersonName;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = prop.VehicleID;
            //sqlcmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = prop.VendorName;
            sqlcmd.Parameters.Add("@BillAmount", SqlDbType.Decimal).Value = prop.BillAmount;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar, 500).Value = prop.Remarks;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@Action", SqlDbType.Int).Value = Action;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDOutwardCasing";
            return data.SelectDataFromDB(sqlcmd);

        }
        public DataSet InserBitReplacement(ExpensesProperty EP)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@BitID", SqlDbType.BigInt).Value = EP.BitNo;
            sqlcmd.Parameters.Add("@Total", SqlDbType.Decimal).Value = EP.TotalAmount;
            sqlcmd.Parameters.Add("@VehicleNo", SqlDbType.BigInt).Value = EP.VehicleNumber;
            sqlcmd.Parameters.Add("@PaidAmount", SqlDbType.Decimal).Value = EP.PaidAmount;
            sqlcmd.Parameters.Add("@Balance", SqlDbType.Decimal).Value = EP.Balance;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar).Value = EP.Remarks;
            sqlcmd.Parameters.Add("@VendorID", SqlDbType.BigInt).Value = EP.VendorID;
            sqlcmd.Parameters.Add("@Replacement", SqlDbType.VarChar).Value = EP.AmountDetails;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "InserBitReplacement";
            return data.SelectDataFromDB(sqlcmd);
        }
    }
}
