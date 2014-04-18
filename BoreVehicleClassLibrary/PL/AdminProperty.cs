using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoreVehicleClassLibrary.PL
{
    public class AdminProperty
    {
        public string labourContact { get; set; }
        public string LabourAddress { get; set; }
        public string VehicleName { get; set;    }
        public string VendorName { get; set; }
        public string VendorContact { get; set; }
        public string VendorAddress { get; set; }
        public Int64 LabourID { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public Int64 VehicleID { get; set; }
        public decimal ManagerSalary { get; set; }

        public string Others{get;set;}
        public string VehicleNumber { get; set; }

        public Int64 ManagerUserID { get; set; }
        public string ManagerName { get; set; }
        public string LabourName { get; set; }


        public string Date { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }

        public decimal TransferAmount { get; set; }
        public Int32 FromVehicleCommon{get;set;}
        public Int32 ToVehicleCommon { get; set; }
    }

    public class ExpensesProperty
    {
        public Int64 VehicleNumber { get; set; }
        public string Date { get; set; }
        public decimal RPM { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string Particulars { get; set; }
        public string AmountDetails { get; set; }
        public Int64 BitNo { get; set; }
        public Int64 HammerNo { get; set; }
        //public Int64 FirstQuantity { get; set; }
        //public Int64 SecondQuantity { get; set; }
        //public Int64 ThirdQuantity { get; set; }
        //public Int64 FourthQuantity { get; set; }
        //public Int64 FifthQuantity { get; set; }
        //public Int64 FirstRate { get; set; }
        //public Int64 SecondRate { get; set; }
        //public Int64 ThirdRate { get; set; }
        //public Int64 FourthRate { get; set; }
        //public Int64 FifthRate { get; set; }
        //public Int64 FirstTotal { get; set; }
        //public Int64 SecondTotal { get; set; }
        //public Int64 ThirdTotal { get; set; }
        //public Int64 FourthTotal { get; set; }
        //public Int64 FifthTotal { get; set; }
       // public Int64 GrandTotal { get; set; }
        //public string Replacable { get; set; }
        public string VendorName { get; set; }
        public string Details { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public Int16 VendorID { get; set; }

        public string Spares { get; set; }


        public decimal BillAmount { get; set; }
        public decimal Balance { get; set; }
        public Int64 BitQuantity { get; set; }
        public decimal BitExpenses { get; set; }

        public Int64 HammerQuantity { get; set; }
        public decimal HammerExpenses { get; set; }
        public decimal DieselAmount { get; set; }
        public decimal DieselQuantity { get; set; }
        public decimal DieselExpenses { get; set; }
        public decimal NoOfLitre { get; set; }
        public decimal Feet { get; set; }
        public decimal DieselAvg { get; set; }


        public Int64 TotalNumberDiesel { get; set; }
        public Int64 TotalDrillDepth { get; set; }
        public Int64 DieselAverage { get; set; }
        public Int64 TotalDepth { get; set; }
        public Int64 TotalRPM{ get; set; }
        public Int64 DrillingAverage { get; set; }

    }
}
