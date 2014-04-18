using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using BoreVehicleClassLibrary.PL;

namespace BoreVehicleClassLibrary.DAL
{
    public class AdminD
    {
        DBExecution data = new DBExecution();

        //Password Encryption Technique
        public string CreatePasswordHash(string pwd, string salt)
        {
            string saltAndPwd = null;
            string hashedPwd = null;
            saltAndPwd = pwd;
            hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
            return hashedPwd;
        }

        //Check the UserID and Password
        public DataSet GetLogin(string UserName, string Password)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = UserName;
            sqlcmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = Password;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetLogin";
            return data.SelectDataFromDB(sqlcmd);
        }

        //Get Labour Details for selected Labour

        public DataSet GetLabourDetails(Int64 LabourID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@LabourID", SqlDbType.BigInt).Value = LabourID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetLabourDetails";
            return data.SelectDataFromDB(sqlcmd);

        }
        public DataSet getBitexpenses( String searchText,int flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
            sqlcmd.Parameters.Add("@searchtext", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.CommandText = "getBitexpenses";
            return data.SelectDataFromDB(sqlcmd);
        }
        public DataSet getDieselexpenses( String searchText,int flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
            sqlcmd.Parameters.Add("@searchtext", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.CommandText = "getBitexpenses";
            return data.SelectDataFromDB(sqlcmd);
        }
        public DataSet getHammerexpenses( String searchText,int flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
            sqlcmd.Parameters.Add("@searchtext", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.CommandText = "getBitexpenses";
            return data.SelectDataFromDB(sqlcmd);
        }
        public DataSet getProfile( String searchText, int flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
            sqlcmd.Parameters.Add("@searchtext", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.CommandText = "getBitexpenses";
            return data.SelectDataFromDB(sqlcmd);
        }
       
        public DataSet getManagementpayment(String searchText, int flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@flag", SqlDbType.Int).Value = flag;
            sqlcmd.Parameters.Add("@searchtext", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.CommandText = "getManagementpayment";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetGridCommonFundDetails(Int64 UserID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText="GetGridCommonFundDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetSelectedVehicleDetails(Int32 VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetSelectedVehicleDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet TransferFund(AdminProperty prop, Int64 UserID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@FromVehicleCommon", SqlDbType.Int).Value = prop.FromVehicleCommon;
            sqlcmd.Parameters.Add("@ToVehicleCommon", SqlDbType.Int).Value = prop.ToVehicleCommon;
            sqlcmd.Parameters.Add("@TransferAmount", SqlDbType.Decimal).Value = prop.TransferAmount;
            sqlcmd.Parameters.Add("@UserID", SqlDbType.Decimal).Value = UserID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "TransferFund";
            return data.SelectDataFromDB(sqlcmd);
        }


    }
}
