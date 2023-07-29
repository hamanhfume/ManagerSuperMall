namespace SuperMallManagerMVC
{
    partial class AddUpdateBillForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateBillForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSaveStaffBillDetail = new System.Windows.Forms.Button();
            this.textBoxSearchStaffBill = new System.Windows.Forms.TextBox();
            this.dataGridViewInfomationCustomerAddBillForm = new System.Windows.Forms.DataGridView();
            this.buttonSearchCustomerBill = new System.Windows.Forms.Button();
            this.textBoxSearchCustomerBill = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonUpdateItemInItemDetailsInBill = new System.Windows.Forms.Button();
            this.dataGridViewInfomationItemAddBillForm = new System.Windows.Forms.DataGridView();
            this.buttonSearchItemBill = new System.Windows.Forms.Button();
            this.textBoxSearchItemBill = new System.Windows.Forms.TextBox();
            this.numericUpDownQuantityBill = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelStaffBillAdd = new System.Windows.Forms.Label();
            this.labelCreateTimeBill = new System.Windows.Forms.Label();
            this.labelTotalAmountBill = new System.Windows.Forms.Label();
            this.labelTotalDiscount = new System.Windows.Forms.Label();
            this.labelTotalItems = new System.Windows.Forms.Label();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.dataGridViewItemsDetailsInBill = new System.Windows.Forms.DataGridView();
            this.buttonSaveBill = new System.Windows.Forms.Button();
            this.buttonPaymentBill = new System.Windows.Forms.Button();
            this.buttonRemoveBill = new System.Windows.Forms.Button();
            this.buttonCancelBillDetail = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfomationCustomerAddBillForm)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfomationItemAddBillForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantityBill)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemsDetailsInBill)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSaveStaffBillDetail);
            this.groupBox1.Controls.Add(this.textBoxSearchStaffBill);
            this.groupBox1.Controls.Add(this.dataGridViewInfomationCustomerAddBillForm);
            this.groupBox1.Controls.Add(this.buttonSearchCustomerBill);
            this.groupBox1.Controls.Add(this.textBoxSearchCustomerBill);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(612, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Infomation";
            // 
            // buttonSaveStaffBillDetail
            // 
            this.buttonSaveStaffBillDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveStaffBillDetail.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveStaffBillDetail.Image")));
            this.buttonSaveStaffBillDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaveStaffBillDetail.Location = new System.Drawing.Point(433, 48);
            this.buttonSaveStaffBillDetail.Name = "buttonSaveStaffBillDetail";
            this.buttonSaveStaffBillDetail.Size = new System.Drawing.Size(149, 28);
            this.buttonSaveStaffBillDetail.TabIndex = 5;
            this.buttonSaveStaffBillDetail.Text = "Save Staff";
            this.buttonSaveStaffBillDetail.UseVisualStyleBackColor = true;
            this.buttonSaveStaffBillDetail.Click += new System.EventHandler(this.SaveStaffClickEventHandler);
            // 
            // textBoxSearchStaffBill
            // 
            this.textBoxSearchStaffBill.Location = new System.Drawing.Point(156, 51);
            this.textBoxSearchStaffBill.Name = "textBoxSearchStaffBill";
            this.textBoxSearchStaffBill.Size = new System.Drawing.Size(233, 22);
            this.textBoxSearchStaffBill.TabIndex = 2;
            // 
            // dataGridViewInfomationCustomerAddBillForm
            // 
            this.dataGridViewInfomationCustomerAddBillForm.AllowUserToAddRows = false;
            this.dataGridViewInfomationCustomerAddBillForm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInfomationCustomerAddBillForm.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInfomationCustomerAddBillForm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewInfomationCustomerAddBillForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfomationCustomerAddBillForm.Location = new System.Drawing.Point(7, 85);
            this.dataGridViewInfomationCustomerAddBillForm.Name = "dataGridViewInfomationCustomerAddBillForm";
            this.dataGridViewInfomationCustomerAddBillForm.Size = new System.Drawing.Size(598, 150);
            this.dataGridViewInfomationCustomerAddBillForm.TabIndex = 4;
            this.dataGridViewInfomationCustomerAddBillForm.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectCustomerAddBillCentCilckHandler);
            // 
            // buttonSearchCustomerBill
            // 
            this.buttonSearchCustomerBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchCustomerBill.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearchCustomerBill.Image")));
            this.buttonSearchCustomerBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchCustomerBill.Location = new System.Drawing.Point(457, 15);
            this.buttonSearchCustomerBill.Name = "buttonSearchCustomerBill";
            this.buttonSearchCustomerBill.Size = new System.Drawing.Size(104, 28);
            this.buttonSearchCustomerBill.TabIndex = 3;
            this.buttonSearchCustomerBill.Text = "Search";
            this.buttonSearchCustomerBill.UseVisualStyleBackColor = true;
            this.buttonSearchCustomerBill.Click += new System.EventHandler(this.btnSearchCustomerBillEventHandler);
            // 
            // textBoxSearchCustomerBill
            // 
            this.textBoxSearchCustomerBill.Location = new System.Drawing.Point(156, 18);
            this.textBoxSearchCustomerBill.Name = "textBoxSearchCustomerBill";
            this.textBoxSearchCustomerBill.Size = new System.Drawing.Size(233, 22);
            this.textBoxSearchCustomerBill.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name Staff:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name Customer:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonUpdateItemInItemDetailsInBill);
            this.groupBox2.Controls.Add(this.dataGridViewInfomationItemAddBillForm);
            this.groupBox2.Controls.Add(this.buttonSearchItemBill);
            this.groupBox2.Controls.Add(this.textBoxSearchItemBill);
            this.groupBox2.Controls.Add(this.numericUpDownQuantityBill);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(635, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(612, 242);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Item Information";
            // 
            // buttonUpdateItemInItemDetailsInBill
            // 
            this.buttonUpdateItemInItemDetailsInBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdateItemInItemDetailsInBill.Image = ((System.Drawing.Image)(resources.GetObject("buttonUpdateItemInItemDetailsInBill.Image")));
            this.buttonUpdateItemInItemDetailsInBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdateItemInItemDetailsInBill.Location = new System.Drawing.Point(425, 48);
            this.buttonUpdateItemInItemDetailsInBill.Name = "buttonUpdateItemInItemDetailsInBill";
            this.buttonUpdateItemInItemDetailsInBill.Size = new System.Drawing.Size(149, 28);
            this.buttonUpdateItemInItemDetailsInBill.TabIndex = 7;
            this.buttonUpdateItemInItemDetailsInBill.Text = "Update Quantity";
            this.buttonUpdateItemInItemDetailsInBill.UseVisualStyleBackColor = true;
            this.buttonUpdateItemInItemDetailsInBill.Click += new System.EventHandler(this.UpdateQuantityClickEventHandler);
            // 
            // dataGridViewInfomationItemAddBillForm
            // 
            this.dataGridViewInfomationItemAddBillForm.AllowUserToAddRows = false;
            this.dataGridViewInfomationItemAddBillForm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInfomationItemAddBillForm.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInfomationItemAddBillForm.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewInfomationItemAddBillForm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfomationItemAddBillForm.Location = new System.Drawing.Point(7, 86);
            this.dataGridViewInfomationItemAddBillForm.Name = "dataGridViewInfomationItemAddBillForm";
            this.dataGridViewInfomationItemAddBillForm.ReadOnly = true;
            this.dataGridViewInfomationItemAddBillForm.Size = new System.Drawing.Size(598, 150);
            this.dataGridViewInfomationItemAddBillForm.TabIndex = 5;
            this.dataGridViewInfomationItemAddBillForm.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectItemsAddBillCentCilckHandler);
            // 
            // buttonSearchItemBill
            // 
            this.buttonSearchItemBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearchItemBill.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearchItemBill.Image")));
            this.buttonSearchItemBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchItemBill.Location = new System.Drawing.Point(446, 15);
            this.buttonSearchItemBill.Name = "buttonSearchItemBill";
            this.buttonSearchItemBill.Size = new System.Drawing.Size(104, 28);
            this.buttonSearchItemBill.TabIndex = 6;
            this.buttonSearchItemBill.Text = "Search";
            this.buttonSearchItemBill.UseVisualStyleBackColor = true;
            this.buttonSearchItemBill.Click += new System.EventHandler(this.btnSearchItemsClickEventHandler);
            // 
            // textBoxSearchItemBill
            // 
            this.textBoxSearchItemBill.Location = new System.Drawing.Point(156, 18);
            this.textBoxSearchItemBill.Name = "textBoxSearchItemBill";
            this.textBoxSearchItemBill.Size = new System.Drawing.Size(233, 22);
            this.textBoxSearchItemBill.TabIndex = 4;
            // 
            // numericUpDownQuantityBill
            // 
            this.numericUpDownQuantityBill.Location = new System.Drawing.Point(156, 51);
            this.numericUpDownQuantityBill.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDownQuantityBill.Name = "numericUpDownQuantityBill";
            this.numericUpDownQuantityBill.Size = new System.Drawing.Size(233, 22);
            this.numericUpDownQuantityBill.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name Item:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelStaffBillAdd);
            this.groupBox3.Controls.Add(this.labelCreateTimeBill);
            this.groupBox3.Controls.Add(this.labelTotalAmountBill);
            this.groupBox3.Controls.Add(this.labelTotalDiscount);
            this.groupBox3.Controls.Add(this.labelTotalItems);
            this.groupBox3.Controls.Add(this.labelCustomerName);
            this.groupBox3.Controls.Add(this.dataGridViewItemsDetailsInBill);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(14, 263);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1233, 375);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Item Details In Bill";
            // 
            // labelStaffBillAdd
            // 
            this.labelStaffBillAdd.AutoSize = true;
            this.labelStaffBillAdd.Location = new System.Drawing.Point(13, 352);
            this.labelStaffBillAdd.Name = "labelStaffBillAdd";
            this.labelStaffBillAdd.Size = new System.Drawing.Size(40, 16);
            this.labelStaffBillAdd.TabIndex = 6;
            this.labelStaffBillAdd.Text = "Staff:";
            // 
            // labelCreateTimeBill
            // 
            this.labelCreateTimeBill.AutoSize = true;
            this.labelCreateTimeBill.Location = new System.Drawing.Point(961, 334);
            this.labelCreateTimeBill.Name = "labelCreateTimeBill";
            this.labelCreateTimeBill.Size = new System.Drawing.Size(114, 16);
            this.labelCreateTimeBill.TabIndex = 5;
            this.labelCreateTimeBill.Text = "Create Time Bill:";
            // 
            // labelTotalAmountBill
            // 
            this.labelTotalAmountBill.AutoSize = true;
            this.labelTotalAmountBill.Location = new System.Drawing.Point(705, 334);
            this.labelTotalAmountBill.Name = "labelTotalAmountBill";
            this.labelTotalAmountBill.Size = new System.Drawing.Size(120, 16);
            this.labelTotalAmountBill.TabIndex = 4;
            this.labelTotalAmountBill.Text = "Total Amount Bill:";
            // 
            // labelTotalDiscount
            // 
            this.labelTotalDiscount.AutoSize = true;
            this.labelTotalDiscount.Location = new System.Drawing.Point(463, 334);
            this.labelTotalDiscount.Name = "labelTotalDiscount";
            this.labelTotalDiscount.Size = new System.Drawing.Size(131, 16);
            this.labelTotalDiscount.TabIndex = 3;
            this.labelTotalDiscount.Text = "Total Discounts Bill:";
            // 
            // labelTotalItems
            // 
            this.labelTotalItems.AutoSize = true;
            this.labelTotalItems.Location = new System.Drawing.Point(247, 334);
            this.labelTotalItems.Name = "labelTotalItems";
            this.labelTotalItems.Size = new System.Drawing.Size(109, 16);
            this.labelTotalItems.TabIndex = 2;
            this.labelTotalItems.Text = "Total Items Bill: ";
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Location = new System.Drawing.Point(13, 316);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(71, 16);
            this.labelCustomerName.TabIndex = 1;
            this.labelCustomerName.Text = "Customer:";
            // 
            // dataGridViewItemsDetailsInBill
            // 
            this.dataGridViewItemsDetailsInBill.AllowUserToAddRows = false;
            this.dataGridViewItemsDetailsInBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewItemsDetailsInBill.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewItemsDetailsInBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewItemsDetailsInBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemsDetailsInBill.Location = new System.Drawing.Point(7, 21);
            this.dataGridViewItemsDetailsInBill.Name = "dataGridViewItemsDetailsInBill";
            this.dataGridViewItemsDetailsInBill.ReadOnly = true;
            this.dataGridViewItemsDetailsInBill.Size = new System.Drawing.Size(1219, 282);
            this.dataGridViewItemsDetailsInBill.TabIndex = 0;
            this.dataGridViewItemsDetailsInBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdateItemDetailInBillCellCilckEventHandler);
            this.dataGridViewItemsDetailsInBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DeleteItemDetailInBillEventHandler);
            // 
            // buttonSaveBill
            // 
            this.buttonSaveBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveBill.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveBill.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveBill.Image")));
            this.buttonSaveBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSaveBill.Location = new System.Drawing.Point(282, 653);
            this.buttonSaveBill.Name = "buttonSaveBill";
            this.buttonSaveBill.Size = new System.Drawing.Size(110, 30);
            this.buttonSaveBill.TabIndex = 7;
            this.buttonSaveBill.Text = "Save";
            this.buttonSaveBill.UseVisualStyleBackColor = true;
            this.buttonSaveBill.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // buttonPaymentBill
            // 
            this.buttonPaymentBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPaymentBill.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPaymentBill.Image = ((System.Drawing.Image)(resources.GetObject("buttonPaymentBill.Image")));
            this.buttonPaymentBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPaymentBill.Location = new System.Drawing.Point(486, 653);
            this.buttonPaymentBill.Name = "buttonPaymentBill";
            this.buttonPaymentBill.Size = new System.Drawing.Size(110, 30);
            this.buttonPaymentBill.TabIndex = 8;
            this.buttonPaymentBill.Text = "Payment";
            this.buttonPaymentBill.UseVisualStyleBackColor = true;
            this.buttonPaymentBill.Click += new System.EventHandler(this.btnPaymentClickEventHandler);
            // 
            // buttonRemoveBill
            // 
            this.buttonRemoveBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRemoveBill.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveBill.Image = ((System.Drawing.Image)(resources.GetObject("buttonRemoveBill.Image")));
            this.buttonRemoveBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRemoveBill.Location = new System.Drawing.Point(868, 653);
            this.buttonRemoveBill.Name = "buttonRemoveBill";
            this.buttonRemoveBill.Size = new System.Drawing.Size(110, 30);
            this.buttonRemoveBill.TabIndex = 9;
            this.buttonRemoveBill.Text = "Remove";
            this.buttonRemoveBill.UseVisualStyleBackColor = true;
            this.buttonRemoveBill.Click += new System.EventHandler(this.btnRemoveClickEventHandler);
            // 
            // buttonCancelBillDetail
            // 
            this.buttonCancelBillDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelBillDetail.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelBillDetail.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelBillDetail.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelBillDetail.Image")));
            this.buttonCancelBillDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelBillDetail.Location = new System.Drawing.Point(681, 653);
            this.buttonCancelBillDetail.Name = "buttonCancelBillDetail";
            this.buttonCancelBillDetail.Size = new System.Drawing.Size(110, 30);
            this.buttonCancelBillDetail.TabIndex = 10;
            this.buttonCancelBillDetail.Text = "Cancel";
            this.buttonCancelBillDetail.UseVisualStyleBackColor = true;
            this.buttonCancelBillDetail.Click += new System.EventHandler(this.btnCancelAddBillEventClickHandler);
            // 
            // AddUpdateBillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1261, 698);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancelBillDetail);
            this.Controls.Add(this.buttonRemoveBill);
            this.Controls.Add(this.buttonPaymentBill);
            this.Controls.Add(this.buttonSaveBill);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateBillForm";
            this.Text = "Add Bill Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfomationCustomerAddBillForm)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfomationItemAddBillForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantityBill)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemsDetailsInBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewInfomationCustomerAddBillForm;
        private System.Windows.Forms.Button buttonSearchCustomerBill;
        private System.Windows.Forms.TextBox textBoxSearchCustomerBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearchItemBill;
        private System.Windows.Forms.TextBox textBoxSearchItemBill;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantityBill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSearchStaffBill;
        private System.Windows.Forms.DataGridView dataGridViewInfomationItemAddBillForm;
        private System.Windows.Forms.DataGridView dataGridViewItemsDetailsInBill;
        private System.Windows.Forms.Label labelCreateTimeBill;
        private System.Windows.Forms.Label labelTotalAmountBill;
        private System.Windows.Forms.Label labelTotalDiscount;
        private System.Windows.Forms.Label labelTotalItems;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.Button buttonSaveBill;
        private System.Windows.Forms.Button buttonPaymentBill;
        private System.Windows.Forms.Button buttonRemoveBill;
        private System.Windows.Forms.Button buttonUpdateItemInItemDetailsInBill;
        private System.Windows.Forms.Button buttonSaveStaffBillDetail;
        private System.Windows.Forms.Button buttonCancelBillDetail;
        private System.Windows.Forms.Label labelStaffBillAdd;
    }
}