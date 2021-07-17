namespace WinformCustomer
{
    partial class frmCustomer
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
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.phoneNoTxtBox = new System.Windows.Forms.TextBox();
            this.validateButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxBillAmt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addressTxtBox = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtgGridCustomer = new System.Windows.Forms.DataGridView();
            this.cmbDALList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUOW = new System.Windows.Forms.Button();
            this.btnETUOW = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGridCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Customer Type";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Items.AddRange(new object[] {
            "Customer",
            "LeadCustomer"});
            this.cmbCustomerType.Location = new System.Drawing.Point(142, 20);
            this.cmbCustomerType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(116, 21);
            this.cmbCustomerType.TabIndex = 11;
            this.cmbCustomerType.SelectedIndexChanged += new System.EventHandler(this.OnIndexChange);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(142, 58);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(116, 20);
            this.txtCustomerName.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Customer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "PhoneNumber";
            // 
            // phoneNoTxtBox
            // 
            this.phoneNoTxtBox.Location = new System.Drawing.Point(142, 98);
            this.phoneNoTxtBox.Name = "phoneNoTxtBox";
            this.phoneNoTxtBox.Size = new System.Drawing.Size(116, 20);
            this.phoneNoTxtBox.TabIndex = 14;
            // 
            // validateButton
            // 
            this.validateButton.Location = new System.Drawing.Point(60, 171);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(75, 23);
            this.validateButton.TabIndex = 15;
            this.validateButton.Text = "Validate";
            this.validateButton.UseVisualStyleBackColor = true;
            this.validateButton.Click += new System.EventHandler(this.validateButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Billamount";
            // 
            // txtBoxBillAmt
            // 
            this.txtBoxBillAmt.Location = new System.Drawing.Point(142, 130);
            this.txtBoxBillAmt.Name = "txtBoxBillAmt";
            this.txtBoxBillAmt.Size = new System.Drawing.Size(116, 20);
            this.txtBoxBillAmt.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(311, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Address";
            // 
            // addressTxtBox
            // 
            this.addressTxtBox.Location = new System.Drawing.Point(390, 28);
            this.addressTxtBox.Name = "addressTxtBox";
            this.addressTxtBox.Size = new System.Drawing.Size(100, 20);
            this.addressTxtBox.TabIndex = 19;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(163, 171);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtgGridCustomer
            // 
            this.dtgGridCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGridCustomer.Location = new System.Drawing.Point(34, 220);
            this.dtgGridCustomer.Name = "dtgGridCustomer";
            this.dtgGridCustomer.Size = new System.Drawing.Size(785, 235);
            this.dtgGridCustomer.TabIndex = 21;
            this.dtgGridCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGridCustomer_CellContentClick);
            // 
            // cmbDALList
            // 
            this.cmbDALList.FormattingEnabled = true;
            this.cmbDALList.Items.AddRange(new object[] {
            "ADODal",
            "EfDal"});
            this.cmbDALList.Location = new System.Drawing.Point(589, 28);
            this.cmbDALList.Name = "cmbDALList";
            this.cmbDALList.Size = new System.Drawing.Size(126, 21);
            this.cmbDALList.TabIndex = 23;
            this.cmbDALList.SelectedIndexChanged += new System.EventHandler(this.OnDalLayerChange);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(526, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "DAL Layer";
            // 
            // btnUOW
            // 
            this.btnUOW.Location = new System.Drawing.Point(390, 98);
            this.btnUOW.Name = "btnUOW";
            this.btnUOW.Size = new System.Drawing.Size(75, 23);
            this.btnUOW.TabIndex = 25;
            this.btnUOW.Text = "UOW";
            this.btnUOW.UseVisualStyleBackColor = true;
            this.btnUOW.Click += new System.EventHandler(this.btnUOW_Click);
            // 
            // btnETUOW
            // 
            this.btnETUOW.Location = new System.Drawing.Point(508, 98);
            this.btnETUOW.Name = "btnETUOW";
            this.btnETUOW.Size = new System.Drawing.Size(75, 23);
            this.btnETUOW.TabIndex = 26;
            this.btnETUOW.Text = "EF UOW";
            this.btnETUOW.UseVisualStyleBackColor = true;
            this.btnETUOW.Click += new System.EventHandler(this.btnETUOW_Click);
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(879, 563);
            this.Controls.Add(this.btnETUOW);
            this.Controls.Add(this.btnUOW);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDALList);
            this.Controls.Add(this.dtgGridCustomer);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.addressTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBoxBillAmt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.validateButton);
            this.Controls.Add(this.phoneNoTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCustomerType);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label1);
            this.Name = "frmCustomer";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGridCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox phoneNoTxtBox;
        private System.Windows.Forms.Button validateButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxBillAmt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addressTxtBox;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dtgGridCustomer;
        private System.Windows.Forms.ComboBox cmbDALList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUOW;
        private System.Windows.Forms.Button btnETUOW;
    }
}

