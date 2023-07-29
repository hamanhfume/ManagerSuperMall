namespace SuperMallManagerMVC
{
    partial class PaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            this.buttonCompletedPayment = new System.Windows.Forms.Button();
            this.buttonCompletedCancels = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNameCustomerPayment = new System.Windows.Forms.TextBox();
            this.textBoxNameStaffPayment = new System.Windows.Forms.TextBox();
            this.textBoxTimeCreateBillPayment = new System.Windows.Forms.TextBox();
            this.textBoxTotalItemPayment = new System.Windows.Forms.TextBox();
            this.textBoxTotaDiscountPayment = new System.Windows.Forms.TextBox();
            this.textBoxTotaAmountPayment = new System.Windows.Forms.TextBox();
            this.comboBoxPaymentsType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxBillId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCompletedPayment
            // 
            this.buttonCompletedPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCompletedPayment.Image = ((System.Drawing.Image)(resources.GetObject("buttonCompletedPayment.Image")));
            this.buttonCompletedPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCompletedPayment.Location = new System.Drawing.Point(63, 469);
            this.buttonCompletedPayment.Name = "buttonCompletedPayment";
            this.buttonCompletedPayment.Size = new System.Drawing.Size(135, 37);
            this.buttonCompletedPayment.TabIndex = 0;
            this.buttonCompletedPayment.Text = "Completed";
            this.buttonCompletedPayment.UseVisualStyleBackColor = true;
            this.buttonCompletedPayment.Click += new System.EventHandler(this.btnCompletedPaymentEventHandler);
            // 
            // buttonCompletedCancels
            // 
            this.buttonCompletedCancels.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCompletedCancels.Image = ((System.Drawing.Image)(resources.GetObject("buttonCompletedCancels.Image")));
            this.buttonCompletedCancels.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCompletedCancels.Location = new System.Drawing.Point(244, 469);
            this.buttonCompletedCancels.Name = "buttonCompletedCancels";
            this.buttonCompletedCancels.Size = new System.Drawing.Size(135, 37);
            this.buttonCompletedCancels.TabIndex = 1;
            this.buttonCompletedCancels.Text = "Cancel";
            this.buttonCompletedCancels.UseVisualStyleBackColor = true;
            this.buttonCompletedCancels.Click += new System.EventHandler(this.btnCancelPaymentClickEventHandle);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name Customer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name Staff:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time Create Bill:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Total Items:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Total Discounts:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 349);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Total Amount:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 398);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Payments Type:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(137, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 19);
            this.label8.TabIndex = 9;
            this.label8.Text = "Payment Infomation:";
            // 
            // textBoxNameCustomerPayment
            // 
            this.textBoxNameCustomerPayment.Location = new System.Drawing.Point(155, 107);
            this.textBoxNameCustomerPayment.Name = "textBoxNameCustomerPayment";
            this.textBoxNameCustomerPayment.Size = new System.Drawing.Size(254, 22);
            this.textBoxNameCustomerPayment.TabIndex = 2;
            // 
            // textBoxNameStaffPayment
            // 
            this.textBoxNameStaffPayment.Location = new System.Drawing.Point(155, 155);
            this.textBoxNameStaffPayment.Name = "textBoxNameStaffPayment";
            this.textBoxNameStaffPayment.Size = new System.Drawing.Size(254, 22);
            this.textBoxNameStaffPayment.TabIndex = 3;
            // 
            // textBoxTimeCreateBillPayment
            // 
            this.textBoxTimeCreateBillPayment.Location = new System.Drawing.Point(155, 203);
            this.textBoxTimeCreateBillPayment.Name = "textBoxTimeCreateBillPayment";
            this.textBoxTimeCreateBillPayment.Size = new System.Drawing.Size(254, 22);
            this.textBoxTimeCreateBillPayment.TabIndex = 4;
            // 
            // textBoxTotalItemPayment
            // 
            this.textBoxTotalItemPayment.Location = new System.Drawing.Point(155, 251);
            this.textBoxTotalItemPayment.Name = "textBoxTotalItemPayment";
            this.textBoxTotalItemPayment.Size = new System.Drawing.Size(254, 22);
            this.textBoxTotalItemPayment.TabIndex = 5;
            // 
            // textBoxTotaDiscountPayment
            // 
            this.textBoxTotaDiscountPayment.Location = new System.Drawing.Point(155, 299);
            this.textBoxTotaDiscountPayment.Name = "textBoxTotaDiscountPayment";
            this.textBoxTotaDiscountPayment.Size = new System.Drawing.Size(254, 22);
            this.textBoxTotaDiscountPayment.TabIndex = 6;
            // 
            // textBoxTotaAmountPayment
            // 
            this.textBoxTotaAmountPayment.Location = new System.Drawing.Point(155, 347);
            this.textBoxTotaAmountPayment.Name = "textBoxTotaAmountPayment";
            this.textBoxTotaAmountPayment.Size = new System.Drawing.Size(254, 22);
            this.textBoxTotaAmountPayment.TabIndex = 7;
            // 
            // comboBoxPaymentsType
            // 
            this.comboBoxPaymentsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPaymentsType.FormattingEnabled = true;
            this.comboBoxPaymentsType.Items.AddRange(new object[] {
            "Payment in cash",
            "Payment by bank transfer",
            "Payment by swiping card"});
            this.comboBoxPaymentsType.Location = new System.Drawing.Point(155, 395);
            this.comboBoxPaymentsType.Name = "comboBoxPaymentsType";
            this.comboBoxPaymentsType.Size = new System.Drawing.Size(254, 24);
            this.comboBoxPaymentsType.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Id Bill-Detail:";
            // 
            // textBoxBillId
            // 
            this.textBoxBillId.Location = new System.Drawing.Point(155, 60);
            this.textBoxBillId.Name = "textBoxBillId";
            this.textBoxBillId.Size = new System.Drawing.Size(254, 22);
            this.textBoxBillId.TabIndex = 1;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(442, 539);
            this.Controls.Add(this.textBoxBillId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxPaymentsType);
            this.Controls.Add(this.textBoxTotaAmountPayment);
            this.Controls.Add(this.textBoxTotaDiscountPayment);
            this.Controls.Add(this.textBoxTotalItemPayment);
            this.Controls.Add(this.textBoxTimeCreateBillPayment);
            this.Controls.Add(this.textBoxNameStaffPayment);
            this.Controls.Add(this.textBoxNameCustomerPayment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCompletedCancels);
            this.Controls.Add(this.buttonCompletedPayment);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentForm";
            this.Text = "Payment Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCompletedPayment;
        private System.Windows.Forms.Button buttonCompletedCancels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNameCustomerPayment;
        private System.Windows.Forms.TextBox textBoxNameStaffPayment;
        private System.Windows.Forms.TextBox textBoxTimeCreateBillPayment;
        private System.Windows.Forms.TextBox textBoxTotalItemPayment;
        private System.Windows.Forms.TextBox textBoxTotaDiscountPayment;
        private System.Windows.Forms.TextBox textBoxTotaAmountPayment;
        private System.Windows.Forms.ComboBox comboBoxPaymentsType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxBillId;
    }
}