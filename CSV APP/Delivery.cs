using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SMSAPP
{
    public partial class Delivery : Form
    {
        public Delivery(string documentType, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            docType = documentType;
            fDate = fromDate;
            tDate = toDate;
        }

        string docType;
        DateTime fDate;
        DateTime tDate;

        private void Delivery_Load(object sender, EventArgs e)
        {
            Gateway gateway = new Gateway();
            List<DocumentInfo> documents = gateway.GetDeliveryList(fDate, tDate);

            foreach (DocumentInfo docInfo in documents)
            {
                ListViewItem items = new ListViewItem();
                items.Text = docInfo.DocumentNumber;
                items.SubItems.Add(docInfo.DocumentType);
                items.SubItems.Add(docInfo.CardCode);
                items.SubItems.Add(docInfo.CardName);
                items.SubItems.Add(docInfo.DocDate.ToString());
                items.SubItems.Add(docInfo.TotalAmount);
                items.SubItems.Add(docInfo.ContactPersonName);
                items.SubItems.Add(docInfo.ContactPersonNumber);
                items.SubItems.Add(docInfo.VehicleNumber);
                items.SubItems.Add(docInfo.DriverName);
                items.SubItems.Add(docInfo.DriverMobile);
                items.SubItems.Add(docInfo.TSOName);
                items.SubItems.Add(docInfo.TSOMobile);

                listView1.Items.Add(items);

            }

            //ListViewItem items = new ListViewItem();
            //items.Text = "123456";
            //items.SubItems.Add("Delivery");
            //items.SubItems.Add("C100001");
            //items.SubItems.Add("ABC Enterprise");
            //items.SubItems.Add("09/12/2021");
            //items.SubItems.Add("100000");
            //items.SubItems.Add("Aloukik");
            //items.SubItems.Add("01797408047");
            //items.SubItems.Add("KHA 100");
            //items.SubItems.Add("Karim");
            //items.SubItems.Add("01712345678");
            //items.SubItems.Add("Rahim");
            //items.SubItems.Add("01913248902");

            //listView1.Items.Add(items);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count==0 || listView1.SelectedItems.Count>1)
            {
                MessageBox.Show("Please select one row and then click this button");
            }

            else
            {
                DocumentInfo docInfo = new DocumentInfo();
                ListViewItem selectedItem = listView1.SelectedItems[0];
                docInfo.DocumentNumber = selectedItem.SubItems[0].Text;
                docInfo.DocumentType = selectedItem.SubItems[1].Text;
                docInfo.CardCode = selectedItem.SubItems[2].Text;
                docInfo.CardName = selectedItem.SubItems[3].Text;
                docInfo.DocDate = DateTime.Parse(selectedItem.SubItems[4].Text);
                docInfo.TotalAmount = selectedItem.SubItems[5].Text;
                docInfo.ContactPersonName = selectedItem.SubItems[6].Text;
                docInfo.ContactPersonNumber = selectedItem.SubItems[7].Text;
                docInfo.VehicleNumber = selectedItem.SubItems[8].Text;
                docInfo.DriverName = selectedItem.SubItems[9].Text;
                docInfo.DriverMobile = selectedItem.SubItems[10].Text;
                docInfo.TSOName = selectedItem.SubItems[11].Text;
                docInfo.TSOMobile = selectedItem.SubItems[12].Text;

                int amount = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(docInfo.TotalAmount)));

                string message = "স্ট্যান্ডার্ড ফিনিস অয়েল কোং এর ফ্যাক্টোরি থেকে আপনার অর্ডার কৃত পণ্য সমূহের ডেলিভারী করা হয়েছে। আপনার পন্য সমূহ বুঝে নেওয়ার জন্য অনুরোধ করা হলো। ক্রেতার নাম "+Translate(docInfo.CardName)+", ডেলিভারী চালান নং " + docInfo.DocumentNumber + ", মোট টাকা " + amount + ", ট্রাক নাম্বার "+docInfo.VehicleNumber+ ", ড্রাইভার এর নাম "+Translate(docInfo.DriverName)+ ", ড্রাইভার এর মোবাইল নং "+docInfo.DriverMobile;

                SendSMSSingle ssSingle = new SendSMSSingle(docInfo, message);
                ssSingle.Show();
            }            
        }

        public static string Translate(string word)
        {
            var toLanguage = "bn";//English
            var fromLanguage = "en";//Deutsch
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label11.Visible = true;
            pictureBox1.Visible = true;
            Gateway gateway = new Gateway();
            List<DocumentInfo> documents = gateway.GetDeliveryList(fDate, tDate);

            foreach (DocumentInfo docInfo in documents)
            {
                string message = "স্ট্যান্ডার্ড ফিনিস অয়েল কোং এর ফ্যাক্টোরি থেকে আপনার অর্ডার কৃত পণ্য সমূহের ডেলিভারী করা হয়েছে। আপনার পন্য সমূহ বুঝে নেওয়ার জন্য অনুরোধ করা হলো। ক্রেতার নাম " + Translate(docInfo.CardName) + ", ডেলিভারী চালান নং " + docInfo.DocumentNumber + ", মোট টাকা " + Math.Ceiling(decimal.Parse(docInfo.TotalAmount)) + ", ট্রাক নাম্বার " + docInfo.VehicleNumber + ", ড্রাইভার এর নাম " + Translate(docInfo.DriverName) + ", ড্রাইভার এর মোবাইল নং " + docInfo.DriverMobile;
                SendSMSToCustomer(docInfo.ContactPersonNumber, message);
                SendSMSToCustomer(docInfo.TSOMobile, message);
            }
            MessageBox.Show("SMS send to all");
            label11.Visible = false;
            pictureBox1.Visible = false;
        }

        public async void SendSMSToCustomer(string mobileNo, string sms)
        {
            string customermobileNo = mobileNo;
            string message = sms;
            //string url = "https://masking.zaman-it.com/smsapi?api_key=01720038691.qYGBUjqSF3nlitobAH&type=text&phone=88" + customermobileNo + "&senderid=8809617609850&msg=" + message;
            string url = "https://sms.zaman-it.com/api/sendsms?api_key=01720038691.qYGBUjqSF3nlitobAH&type=text&phone=88" + customermobileNo + "&senderid=8809617609850&message=" + message;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = await request.GetResponseAsync();
            string json = await new StreamReader(response.GetResponseStream()).ReadToEndAsync();

            if (json == "\r\n\r\n\r\n\r\n\r\n{\"status_code\":200}")
            {
                MessageBox.Show("SMS send successfully");
            }

            else
            {
                MessageBox.Show("SMS send failed");
            }
        }
    }
}
