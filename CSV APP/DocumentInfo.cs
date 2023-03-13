using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSAPP
{
    public class DocumentInfo
    {
        public string DocumentNumber { get; set; }
        public string DocumentType { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public DateTime DocDate { get; set; }
        public string TotalAmount { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverMobile { get; set; }
        public string VehicleNumber { get; set; }
        public string TSOName { get; set; }
        public string TSOMobile { get; set; }
    }
}
