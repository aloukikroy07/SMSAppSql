using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Resources;
using System.Globalization;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing.Printing;
using System.ComponentModel;
using Sap.Data.Hana;
using System.Threading;
using System.Data.Odbc;
using System.Net;
using System.Web;

namespace SMSAPP
{
   public class Program
    {
       public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SMSAPP());
        }

        //public static string Translate(string word)
        //{
        //    var toLanguage = "bn";//English
        //    var fromLanguage = "en";//Deutsch
        //    var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
        //    var webClient = new WebClient
        //    {
        //        Encoding = System.Text.Encoding.UTF8
        //    };
        //    var result = webClient.DownloadString(url);
        //    try
        //    {
        //        result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
        //        return result;
        //    }
        //    catch
        //    {
        //        return "Error";
        //    }
        //}

        //public void GetCSV()
        //{
        //    //Connect To Database
        //    HanaConnection connect = new HanaConnection();
        //    connect.ConnectionString = "Server=SU01:30015;UserID=DBSFO;Password=Db$F0#952";
        //    //"DRIVER=<HDBODBC32>, Server=<172.19.254.177:30015>;UserID=<SYSTEM>;Password=<PhqSap2018$>");
        //    connect.Open();

        //    //Execute Stored Procedure
        //    String strSQL = @"CALL ""SFO_PROD"".""SP_1""";
        //    HanaCommand cmd = new HanaCommand(strSQL, connect);
        //    HanaDataReader reader1 = cmd.ExecuteReader();

        //    // Export path and file.
        //    string exportPath = "C:\\Demo\\";
        //    string exportCsv;

        //    // Stream writer for CSV file.
        //    System.IO.StreamWriter csvFile = null;

        //    // Check to see if the file path exists.
        //    if (System.IO.Directory.Exists(exportPath))
        //    {

        //        try
        //        {
        //            //For seperate CSV file for seperate invoice.
        //            string newString = @"SELECT DISTINCT ""U_DocNum"" FROM ""SFO_PROD"".""@T002""";
        //            HanaCommand newCommand = new HanaCommand(newString, connect);
        //            HanaDataReader newReader = newCommand.ExecuteReader();
        //            while (newReader.Read())
        //            {
        //                exportCsv = "Invoice-" + newReader[0] + ".csv";
        //                // Stream writer for CSV file.
        //                csvFile = new System.IO.StreamWriter(@exportPath + @exportCsv);

        //                // Add the headers to the CSV file.
        //                //csvFile.WriteLine(String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\"",
        //                //    reader.GetName(0), reader.GetName(1), reader.GetName(2),
        //                //    reader.GetName(3), reader.GetName(4), reader.GetName(5), reader.GetName(6), reader.GetName(7), reader.GetName(8), reader.GetName(9), reader.GetName(10), reader.GetName(11), reader.GetName(12), reader.GetName(13), reader.GetName(14), reader.GetName(15), reader.GetName(16)));


        //                //For construct first row in csv
        //                string sqlQuery = @"SELECT DISTINCT ""U_DocNum"", ""U_DocDate"", ""U_CardCode"", ""U_DocTotal"", ""U_DiscPrcnt"", ""U_VatSum"" FROM ""SFO_PROD"".""@T002"" WHERE ""U_DocNum""='" + newReader[0] + "'";
        //                HanaCommand myCommand = new HanaCommand(sqlQuery, connect);
        //                HanaDataReader myReader = myCommand.ExecuteReader();
        //                while (myReader.Read())
        //                {
        //                    csvFile.WriteLine(String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\"",
        //                            myReader[0], myReader[1], myReader[2], myReader[3], myReader[4], myReader[5]));
        //                }
        //                myReader.Close();
        //                // Query text.
        //                // "SELECT T1.""Code"",T0.""U_ParaCode"",T0.""U_ParaName"",T0.""U_UoM"", T0.""U_Dvalue"" FROM ""@PPSP1"" T0 INNER JOIN ""@POPSP"" T1 ON T1.""Code""=T0.""Code"" WHERE T1.""Code""='" + strVal + "'"

        //                // Construct CSV file data rows.
        //                string sqlText = @"SELECT ""U_DocNum"", ""U_ItemCode"",  ""U_Quantity"", ""U_BonusQty"", ""U_Price"", ""U_TaxCode"", ""U_BatchNo"", ""U_BatchMfgDate"", ""U_BatchExpDate"", ""U_UomCode"" FROM ""SFO_PROD"".""@T002"" WHERE ""U_DocNum""='" + newReader[0] + "'";
        //                // Query text incorporated into SQL command.
        //                HanaCommand sqlSelect = new HanaCommand(sqlText, connect);
        //                HanaDataReader reader = sqlSelect.ExecuteReader();
        //                while (reader.Read())
        //                {

        //                    // Add line from reader object to new CSV file.
        //                    //csvFile.WriteLine(String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\", \"{14}\", \"{15}\", \"{16}\"",
        //                    //    reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9], reader[10], reader[11], reader[12], reader[13], reader[14], reader[15], reader[16]));
        //                    csvFile.WriteLine(String.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\"",
        //                        reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9]));

        //                }
        //                reader.Close();
        //                csvFile.Close();

        //            }
        //            newReader.Close();
        //        }
        //        catch (Exception Ex)
        //        {

        //            System.Environment.Exit(0);

        //        }
        //        finally
        //        {
        //            reader1.Close();
        //            // Close the database connection and CSV file.
        //            connect.Close();
        //            System.Environment.Exit(0);
        //        }

        //    }
        //    else
        //    {

        //        System.Environment.Exit(0);
        //    }
        //}
    }
}

