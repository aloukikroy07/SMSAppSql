using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSAPP
{
    class Gateway
    {
        public List<DocumentInfo> GetDeliveryList(DateTime fDate, DateTime tDate)
        {
            string fromDate = fDate.ToString("yyyy-MM-dd");
            string toDate = tDate.ToString("yyyy-MM-dd");
            List<DocumentInfo> documents = new List<DocumentInfo>();
            //Connect To Database
            HanaConnection connect = new HanaConnection();
            connect.ConnectionString = "Server=SU01:30015;UserID=DBSFO;Password=Db$F0#952";
            //"DRIVER=<HDBODBC32>, Server=<172.19.254.177:30015>;UserID=<SYSTEM>;Password=<PhqSap2018$>");
            connect.Open();

            //Execute Stored Procedure
            String strSQL = @"select T0.""DocNum"", T0.""CardCode"", T0.""CardName"", T0.""DocDate"", 'Delivery' as ""DocType"", T0.""DocTotal"", T0.""U_vhclNumber"", T0.""U_drvrName"", T0.""U_drvMobNum"", 
            (SELECT T11.""Name"" from ""SFO_PROD"".""OCPR"" T11 where T11.""CardCode"" = T0.""CardCode"" and T11.""Name""=(select distinct T12.""CntctPrsn"" from ""SFO_PROD"".""OCRD"" T12 where T12.""CardCode""=T0.""CardCode"")) AS ""ContactPersonName"",
            (SELECT T11.""Cellolar"" from ""SFO_PROD"".""OCPR"" T11 where T11.""CardCode"" = T0.""CardCode"" and T11.""Name""=(select distinct T12.""CntctPrsn"" from ""SFO_PROD"".""OCRD"" T12 where T12.""CardCode""=T0.""CardCode"")) AS ""ContactPersonMob"",
            (SELECT T11.""SlpName"" from ""SFO_PROD"".""OSLP"" T11 where T11.""SlpCode""=T0.""SlpCode"") ""TSOName"",
            (SELECT T11.""Mobil"" from ""SFO_PROD"".""OSLP"" T11 where T11.""SlpCode""=T0.""SlpCode"") ""TSOMobile""
            from ""SFO_PROD"".""ODLN"" T0 WHERE T0.""DocDate"" BETWEEN '" + fromDate + "' and '" + toDate + "'";
            HanaCommand cmd = new HanaCommand(strSQL, connect);
            HanaDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DocumentInfo documentInfo = new DocumentInfo();

                documentInfo.DocumentNumber = reader["DocNum"].ToString();
                documentInfo.CardCode = reader["CardCode"].ToString();
                documentInfo.CardName = reader["CardName"].ToString();
                documentInfo.DocDate = (DateTime)reader["DocDate"];
                documentInfo.DocumentType = reader["DocType"].ToString();
                documentInfo.TotalAmount = reader["DocTotal"].ToString();
                documentInfo.ContactPersonName = reader["ContactPersonName"].ToString();
                documentInfo.ContactPersonNumber = reader["ContactPersonMob"].ToString();
                documentInfo.VehicleNumber = reader["U_vhclNumber"].ToString();
                documentInfo.DriverName = reader["U_drvrName"].ToString();
                documentInfo.DriverMobile = reader["U_drvMobNum"].ToString();
                documentInfo.TSOName = reader["TSOName"].ToString();
                documentInfo.TSOMobile = reader["TSOMobile"].ToString();

                documents.Add(documentInfo);
            }

            connect.Close();
            reader.Close();

            return documents;
        }

        public List<DocumentInfo> GetInvoiceList()
        {
            List<DocumentInfo> documents = new List<DocumentInfo>();
            //Connect To Database
            HanaConnection connect = new HanaConnection();
            connect.ConnectionString = "Server=SU01:30015;UserID=DBSFO;Password=Db$F0#952";
            //"DRIVER=<HDBODBC32>, Server=<172.19.254.177:30015>;UserID=<SYSTEM>;Password=<PhqSap2018$>");
            connect.Open();

            //Execute Stored Procedure
            String strSQL = @"CALL ""SFO_PROD"".""SP_1""";
            HanaCommand cmd = new HanaCommand(strSQL, connect);
            HanaDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DocumentInfo documentInfo = new DocumentInfo();

                documents.Add(documentInfo);
            }

            connect.Close();
            reader.Close();

            return documents;
        }

        public List<DocumentInfo> GetOutgoingPaymentList()
        {
            List<DocumentInfo> documents = new List<DocumentInfo>();
            //Connect To Database
            HanaConnection connect = new HanaConnection();
            connect.ConnectionString = "Server=SU01:30015;UserID=DBSFO;Password=Db$F0#952";
            //"DRIVER=<HDBODBC32>, Server=<172.19.254.177:30015>;UserID=<SYSTEM>;Password=<PhqSap2018$>");
            connect.Open();

            //Execute Stored Procedure
            String strSQL = @"CALL ""SFO_PROD"".""SP_1""";
            HanaCommand cmd = new HanaCommand(strSQL, connect);
            HanaDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                DocumentInfo documentInfo = new DocumentInfo();

                documents.Add(documentInfo);
            }

            connect.Close();
            reader.Close();

            return documents;
        }
    }
}
