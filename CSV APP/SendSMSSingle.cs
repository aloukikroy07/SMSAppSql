using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSAPP
{
    public partial class SendSMSSingle : Form
    {
        public SendSMSSingle(DocumentInfo docInfo, string message)
        {
            InitializeComponent();

            documentInfo = docInfo;
            textMessage = message;
        }

        DocumentInfo documentInfo;
        string textMessage;

        private void SendSMSSingle_Load(object sender, EventArgs e)
        {
            textBox1.Text = documentInfo.DocumentNumber;
            textBox4.Text = documentInfo.CardName;
            textBox2.Text = documentInfo.ContactPersonName;
            textBox3.Text = documentInfo.ContactPersonNumber;
            richTextBox1.Text = textMessage;
            textBox8.Text = documentInfo.VehicleNumber;
            textBox5.Text = documentInfo.DriverName;
            textBox7.Text = documentInfo.DriverMobile;
            textBox6.Text = documentInfo.TSOName;
            textBox9.Text = documentInfo.TSOMobile;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            label11.Visible = true;
            SendSMSToCustomer(textBox3.Text, richTextBox1.Text, "CUSTOMER");
            SendSMSToCustomer(textBox9.Text, richTextBox1.Text, "TSO");
            pictureBox1.Visible = false;
            label11.Visible = false;
        }

        public async void SendSMSToCustomer(string mobileNo, string sms, string person)
        {
            string customermobileNo = mobileNo;
            string message = sms;
            //string url = "https://masking.zaman-it.com/smsapi?api_key=01720038691.qYGBUjqSF3nlitobAH&type=text&phone=88" + customermobileNo + "&senderid=8809617609850&msg=" + message;
            string url = "https://sms.zaman-it.com/api/sendsms?api_key=01720038691.qYGBUjqSF3nlitobAH&type=text&phone=88"+customermobileNo+"&senderid=8809617609850&message="+message;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = await request.GetResponseAsync();
            string json = await new StreamReader(response.GetResponseStream()).ReadToEndAsync();

            if (json == "\r\n\r\n\r\n\r\n\r\n{\"status_code\":200}")
            {
                MessageBox.Show("SMS send successfully");
            }

            else {
                MessageBox.Show("SMS send failed");
            }
        }
    }
}
