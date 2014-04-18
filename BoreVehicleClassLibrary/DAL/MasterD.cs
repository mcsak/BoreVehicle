using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoreVehicleClassLibrary.PL;

namespace BoreVehicleClassLibrary.DAL
{
    public class MasterD
    {
        DBExecution data = new DBExecution();
        public DataSet GetLabourDetails(Int64 LabourID)
              
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@LabourID", SqlDbType.BigInt).Value = LabourID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetLabourDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDLabour(AdminProperty prop, Int64 LabourID, Int64 UserID, int Action)
        {
            SqlCommand sqlcmd = new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@LabourID", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@LabourID", SqlDbType.BigInt).Value = LabourID;
            }

           
            sqlcmd.Parameters.Add("@LabourName", SqlDbType.VarChar,100).Value = prop.LabourName;
            sqlcmd.Parameters.Add("@Contact", SqlDbType.VarChar,100).Value = prop.labourContact;
            sqlcmd.Parameters.Add("@Address", SqlDbType.VarChar,500).Value = prop.LabourAddress;
            sqlcmd.Parameters.Add("@Others", SqlDbType.VarChar,250).Value = prop.Others;
            sqlcmd.Parameters.Add("@Action", SqlDbType.Int).Value = Action;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDLabour";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetVehicleDetails(Int64 VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetVehicleDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDVehicle(AdminProperty prop, Int64 VehicleID, Int64 UserID, int Action)
        {
            SqlCommand sqlcmd = new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            }

            sqlcmd.Parameters.Add("@VehicleNumber", SqlDbType.VarChar, 25).Value = prop.VehicleNumber;
            sqlcmd.Parameters.Add("@Name", SqlDbType.VarChar, 25).Value = prop.VehicleName;
            sqlcmd.Parameters.Add("@Others", SqlDbType.VarChar, 250).Value = prop.Others;
            sqlcmd.Parameters.Add("@Action", SqlDbType.Int).Value = Action;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDVehicle";
            return data.SelectDataFromDB(sqlcmd);
        }


        public DataSet GetVendorDetails(Int64 VendorID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@VendorID", SqlDbType.Int).Value = VendorID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetVendorDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDVendor(AdminProperty prop, Int64 VendorID, Int64 UserID, int Action)
        {
            SqlCommand sqlcmd = new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@VendorID", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@VendorID", SqlDbType.BigInt).Value = VendorID;
            }

            sqlcmd.Parameters.Add("@VendorName", SqlDbType.VarChar, 100).Value = prop.VendorName;
            sqlcmd.Parameters.Add("@Contact", SqlDbType.VarChar, 100).Value = prop.VendorContact;
            sqlcmd.Parameters.Add("@Address", SqlDbType.VarChar, 500).Value = prop.VendorAddress;
            sqlcmd.Parameters.Add("@Others", SqlDbType.VarChar,250).Value = prop.Others;
            sqlcmd.Parameters.Add("@Action", SqlDbType.BigInt).Value = Action;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDVendor";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetVehicleMasterDataForOption(int UserID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = UserID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetVehicleMasterDataForOption";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetVehicleNameForSession(int VehicleID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.BigInt).Value = VehicleID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetVehicleNameForSession";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetVendors(String searchText, byte flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
              sqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = flag;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetVendors";
            return data.SelectDataFromDB(sqlcmd);
        }
        public DataSet GetVehicle(String searchText, byte flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = flag;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetVehicle";
            return data.SelectDataFromDB(sqlcmd);
        }
        public DataSet GetLabours(String searchText, byte flag)
        {
            SqlCommand sqlcmd = new SqlCommand();
            
            sqlcmd.Parameters.Add("@SearchText", SqlDbType.VarChar, 100).Value = searchText;
            sqlcmd.Parameters.Add("@SearchFlag", SqlDbType.TinyInt).Value = flag;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetLabours";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetViewAllDetails(int flag,int VehicleID,string FromDate,string Todate)
        {
            SqlCommand sqlcmd = new SqlCommand();
            FromDate = FromDate.Trim();
            Todate = Todate.Trim();
            String[] Arra = FromDate.Contains('-') ? FromDate.Split('-') : FromDate.Split('/');
            FromDate = Arra[1] + Arra[0];
            Arra = null;
            Arra = Todate.Contains('-') ? Todate.Split('-') : Todate.Split('/');
            Todate = Arra[1] + Arra[0];
            //=new string[3];
            if (FromDate.Contains(""))
                Arra = FromDate.Split('/');
            sqlcmd.Parameters.Add("@Flag", SqlDbType.Int).Value = flag;
            sqlcmd.Parameters.Add("@VehicleID", SqlDbType.Int).Value = VehicleID;
            sqlcmd.Parameters.Add("@FromDate", SqlDbType.VarChar, 25).Value = FromDate;
            sqlcmd.Parameters.Add("@Todate", SqlDbType.VarChar, 25).Value = Todate;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetViewAllDetails";
            return data.SelectDataFromDB(sqlcmd);
        }


        public DataSet UpdateTaxDeduction(string taxdeduction,Int64 UserID,int Action)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@SettingID", SqlDbType.Int).Value = 1;// 1 For Tax deduction
            sqlcmd.Parameters.Add("@TaxDeduction", SqlDbType.VarChar,200).Value = taxdeduction;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "UpdateTaxDeduction";
            return data.SelectDataFromDB(sqlcmd);
        }


        public DataSet GetTaxDeduction()
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetTaxDeduction";
            return data.SelectDataFromDB(sqlcmd);
        }
    }
}
