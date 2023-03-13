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
    public partial class Invoice : Form
    {
        public Invoice(string documentType, DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            docType = documentType;
            fDate = fromDate;
            tDate = toDate;
        }

        string docType;
        DateTime fDate;
        DateTime tDate;
        private void Invoice_Load(object sender, EventArgs e)
        {

        }
    }
}
