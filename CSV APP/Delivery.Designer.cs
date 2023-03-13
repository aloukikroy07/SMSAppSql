
namespace SMSAPP
{
    partial class Delivery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Delivery));
            this.listView1 = new System.Windows.Forms.ListView();
            this.DocumentNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DocumentType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CardCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CardName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DocDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactPersonName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContactPersonNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VehicleNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DriverName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DriverMobile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TSOName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TSOMobile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DocumentNumber,
            this.DocumentType,
            this.CardCode,
            this.CardName,
            this.DocDate,
            this.TotalAmount,
            this.ContactPersonName,
            this.ContactPersonNumber,
            this.VehicleNumber,
            this.DriverName,
            this.DriverMobile,
            this.TSOName,
            this.TSOMobile});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 426);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // DocumentNumber
            // 
            this.DocumentNumber.Text = "DocumentNumber";
            this.DocumentNumber.Width = 156;
            // 
            // DocumentType
            // 
            this.DocumentType.Text = "DocumentType";
            this.DocumentType.Width = 123;
            // 
            // CardCode
            // 
            this.CardCode.Text = "CardCode";
            this.CardCode.Width = 140;
            // 
            // CardName
            // 
            this.CardName.Text = "CardName";
            this.CardName.Width = 167;
            // 
            // DocDate
            // 
            this.DocDate.Text = "DocDate";
            this.DocDate.Width = 140;
            // 
            // TotalAmount
            // 
            this.TotalAmount.Text = "TotalAmount";
            this.TotalAmount.Width = 149;
            // 
            // ContactPersonName
            // 
            this.ContactPersonName.Text = "ContactPersonName";
            this.ContactPersonName.Width = 162;
            // 
            // ContactPersonNumber
            // 
            this.ContactPersonNumber.Text = "ContactPersonNumber";
            this.ContactPersonNumber.Width = 181;
            // 
            // VehicleNumber
            // 
            this.VehicleNumber.Text = "VehicleNumber";
            // 
            // DriverName
            // 
            this.DriverName.Text = "DriverName";
            // 
            // DriverMobile
            // 
            this.DriverMobile.Text = "DriverMobile";
            // 
            // TSOName
            // 
            this.TSOName.Text = "TSOName";
            // 
            // TSOMobile
            // 
            this.TSOMobile.Text = "TSOMobile";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Send SMS To Selected BP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(427, 445);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 41);
            this.button2.TabIndex = 2;
            this.button2.Text = "Send SMS To All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(363, 525);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(245, 20);
            this.label11.TabIndex = 14;
            this.label11.Text = "Please wait and don\'t do anything";
            this.label11.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(192, 495);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 79);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Delivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 586);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "Delivery";
            this.Text = "Delivery";
            this.Load += new System.EventHandler(this.Delivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader DocumentNumber;
        private System.Windows.Forms.ColumnHeader DocumentType;
        private System.Windows.Forms.ColumnHeader CardCode;
        private System.Windows.Forms.ColumnHeader CardName;
        private System.Windows.Forms.ColumnHeader DocDate;
        private System.Windows.Forms.ColumnHeader TotalAmount;
        private System.Windows.Forms.ColumnHeader ContactPersonName;
        private System.Windows.Forms.ColumnHeader ContactPersonNumber;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader VehicleNumber;
        private System.Windows.Forms.ColumnHeader DriverName;
        private System.Windows.Forms.ColumnHeader DriverMobile;
        private System.Windows.Forms.ColumnHeader TSOName;
        private System.Windows.Forms.ColumnHeader TSOMobile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}