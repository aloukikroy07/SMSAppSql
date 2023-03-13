using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMSAPP
{
    public partial class Outgoing_Payments : Form
    {
        public Outgoing_Payments(string documentType, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            docType = documentType;
            fDate = fromDate;
            tDate = toDate;
        }

        string docType;
        DateTime fDate;
        DateTime tDate;
        private void Outgoing_Payments_Load(object sender, EventArgs e)
        {

        }
    }
}
