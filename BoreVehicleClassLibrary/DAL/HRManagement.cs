using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoreVehicleClassLibrary.PL;

namespace BoreVehicleClassLibrary.DAL
{
    public class HRManagement
    {
        DBExecution data = new DBExecution();

        public DataSet GetLabourPaymentDetails(Int64 LabourPaymentID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@LabourPaymentID", SqlDbType.BigInt).Value = LabourPaymentID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetLabourPaymentDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDLabourPayment(AdminProperty prop,Int64 LabourPaymentID,Int64 UserID,int Action)
        {
            SqlCommand sqlcmd = new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@LabourPaymentID", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@LabourPaymentID", SqlDbType.BigInt).Value = LabourPaymentID;
            }
            sqlcmd.Parameters.Add("@LabourID", SqlDbType.BigInt).Value = prop.LabourID;
            sqlcmd.Parameters.Add("@DateofPayment", SqlDbType.DateTime).Value = prop.Date;
            sqlcmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = prop.Amount;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar,500).Value = prop.Remarks;
            sqlcmd.Parameters.Add("@Action", SqlDbType.Int).Value = Action;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDLabourPayment";
            return data.SelectDataFromDB(sqlcmd);
        }


        public DataSet GetManagerPaymentDetails(Int64 ManagerPaymentID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@ManagerPaymentID", SqlDbType.BigInt).Value = ManagerPaymentID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetManagerPaymentDetails";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet IUDManagerPayment(AdminProperty prop, Int64 ManagerPaymentID, Int64 UserID, int Action)
        {
            SqlCommand sqlcmd = new SqlCommand();
            if (Action == 1)
            {
                sqlcmd.Parameters.Add("@ManagerPaymentID", SqlDbType.BigInt).Value = DBNull.Value;
            }
            else
            {
                sqlcmd.Parameters.Add("@ManagerPaymentID", SqlDbType.BigInt).Value = ManagerPaymentID;
            }
            sqlcmd.Parameters.Add("@ManagerUserID", SqlDbType.BigInt).Value = prop.ManagerUserID;
            sqlcmd.Parameters.Add("@DateofPayment", SqlDbType.DateTime).Value = DateTime.ParseExact(prop.Date,"dd/MM/yyyy",null);
            if (prop.Amount == "")
            {
                sqlcmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = 0.00;
            }
            else
            {
                sqlcmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = Convert.ToDecimal(prop.Amount);
            }

            
            sqlcmd.Parameters.Add("@Salary", SqlDbType.Decimal).Value = prop.ManagerSalary;
            sqlcmd.Parameters.Add("@Remarks", SqlDbType.VarChar,500).Value = prop.Remarks;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.Parameters.Add("@Action", SqlDbType.Int).Value = Action;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "IUDManagerPayment";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetLabourName()
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetLabourName";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet GetManagerName()
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "GetManagerName";
            return data.SelectDataFromDB(sqlcmd);
        }

        public DataSet CloseManagerUserAccount(Int64 ManagerUserID,Int64 UserID)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Parameters.Add("@ManagerUserID", SqlDbType.BigInt).Value = ManagerUserID;
            sqlcmd.Parameters.Add("@CreateBy", SqlDbType.BigInt).Value = UserID;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "CloseManagerUserAccount";
            return data.SelectDataFromDB(sqlcmd);
        }



    }
}
