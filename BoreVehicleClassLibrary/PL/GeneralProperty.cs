using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoreVehicleClassLibrary.PL
{
    public class GeneralProperty
    {
        public string PointNo { get; set; }
        public string DrillerName { get; set; }
        //public string DrillerDept { get; set; }
        //public string CasingDept { get; set; }
        public int Welding { get; set; }
        public int Cap { get; set; }
        public int HolesPipe { get; set; }
        public decimal StartingRPM { get; set; }
        public decimal EndingRPM { get; set; }
        public int Collar { get; set; }
        public string BitSiteMgmg { get; set; }
        public string HammerSiteMgmt { get; set; }

        public Int64 DrillingDepthRate { get; set; }
        public Int64 CasingDepthRate { get; set; }
        public Int64 WeldingRate { get; set; }
        public Int64 HolePipeRate { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal AmountPaid { get; set; }
        public string PartyVehicleNumber { get; set; }
        public string BillNumber { get; set; }

        public string PartyName { get; set; }
        public string PartyPhoneNumber { get; set; }
        public string PartyAddress { get; set; }
        public string Remarks { get; set; }

        public string Date { get; set; }
        public Int64 Quantity { get; set; }
        public Int64 VehicleID { get; set; }
        public Int64 VehicleNo { get; set; }
        public Int64 VendorName { get; set; }
        public string PersonName { get; set; }
        public decimal BillAmount { get; set; }


        public decimal BillingDrillingRate { get; set; }
        public decimal BillingCasingRate { get; set; }
        public decimal BillingWeldingRate { get; set; }
        public decimal BillingHolesPipeRate { get; set; }
        public decimal BillingCollarRate { get; set; }

        public decimal BillingDrillingTotal { get; set; }
        public decimal BillingCasingTotal { get; set; }
        public decimal BillingWeldingTotal { get; set; }
        public decimal BillingHolesPipeTotal { get; set; }
        public decimal BillingCollarTotal { get; set; }
        public Int64 LeadID { get; set; }



    }
}
