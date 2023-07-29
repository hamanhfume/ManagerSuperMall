namespace SuperMallManagerMVC
{
    partial class AddUpdateDiscountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUpdateDiscountForm));
            this.buttonAddNewDiscount = new System.Windows.Forms.Button();
            this.buttonCancelDiscount = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxIdDiscount = new System.Windows.Forms.TextBox();
            this.textBoxNameDiscount = new System.Windows.Forms.TextBox();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTypeDiscount = new System.Windows.Forms.ComboBox();
            this.numericUpDownPercentdiscount = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownValueDiscount = new System.Windows.Forms.NumericUpDown();
            this.labelAddNewDiscount = new System.Windows.Forms.Label();
            this.labelStatusAddNewDiscount = new System.Windows.Forms.Label();
            this.labelStatusAutoIdAddNewDiscount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercentdiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValueDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddNewDiscount
            // 
            this.buttonAddNewDiscount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddNewDiscount.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddNewDiscount.Image")));
            this.buttonAddNewDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddNewDiscount.Location = new System.Drawing.Point(108, 415);
            this.buttonAddNewDiscount.Name = "buttonAddNewDiscount";
            this.buttonAddNewDiscount.Size = new System.Drawing.Size(169, 37);
            this.buttonAddNewDiscount.TabIndex = 8;
            this.buttonAddNewDiscount.Text = "Add New Discounts";
            this.buttonAddNewDiscount.UseVisualStyleBackColor = true;
            this.buttonAddNewDiscount.Click += new System.EventHandler(this.AddNewDiscountClickEventHandler);
            // 
            // buttonCancelDiscount
            // 
            this.buttonCancelDiscount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelDiscount.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelDiscount.Image")));
            this.buttonCancelDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelDiscount.Location = new System.Drawing.Point(328, 415);
            this.buttonCancelDiscount.Name = "buttonCancelDiscount";
            this.buttonCancelDiscount.Size = new System.Drawing.Size(169, 37);
            this.buttonCancelDiscount.TabIndex = 9;
            this.buttonCancelDiscount.Text = "Cancel";
            this.buttonCancelDiscount.UseVisualStyleBackColor = true;
            this.buttonCancelDiscount.Click += new System.EventHandler(this.CancelClickDiscountAddUpdateFomEventHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id Discount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name Discount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time Start:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Time End:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Type Discount:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(80, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Percent Discount:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(80, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Value Discount:";
            // 
            // textBoxIdDiscount
            // 
            this.textBoxIdDiscount.Location = new System.Drawing.Point(248, 73);
            this.textBoxIdDiscount.Name = "textBoxIdDiscount";
            this.textBoxIdDiscount.Size = new System.Drawing.Size(275, 22);
            this.textBoxIdDiscount.TabIndex = 1;
            // 
            // textBoxNameDiscount
            // 
            this.textBoxNameDiscount.Location = new System.Drawing.Point(248, 121);
            this.textBoxNameDiscount.Name = "textBoxNameDiscount";
            this.textBoxNameDiscount.Size = new System.Drawing.Size(275, 22);
            this.textBoxNameDiscount.TabIndex = 2;
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(248, 169);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(275, 22);
            this.dateTimePickerStartTime.TabIndex = 3;
            // 
            // dateTimePickerEndTime
            // 
            this.dateTimePickerEndTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndTime.Location = new System.Drawing.Point(248, 212);
            this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
            this.dateTimePickerEndTime.Size = new System.Drawing.Size(275, 22);
            this.dateTimePickerEndTime.TabIndex = 4;
            // 
            // comboBoxTypeDiscount
            // 
            this.comboBoxTypeDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeDiscount.FormattingEnabled = true;
            this.comboBoxTypeDiscount.Items.AddRange(new object[] {
            "Does not apply Discount ",
            "Discount Direct Value",
            "Discount Percent Price Item",
            "Discount by Percent and Value"});
            this.comboBoxTypeDiscount.Location = new System.Drawing.Point(248, 258);
            this.comboBoxTypeDiscount.Name = "comboBoxTypeDiscount";
            this.comboBoxTypeDiscount.Size = new System.Drawing.Size(275, 24);
            this.comboBoxTypeDiscount.TabIndex = 5;
            this.comboBoxTypeDiscount.SelectedIndexChanged += new System.EventHandler(this.TypeDiscountIndexChangeEventHandler);
            // 
            // numericUpDownPercentdiscount
            // 
            this.numericUpDownPercentdiscount.Location = new System.Drawing.Point(248, 308);
            this.numericUpDownPercentdiscount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.numericUpDownPercentdiscount.Name = "numericUpDownPercentdiscount";
            this.numericUpDownPercentdiscount.Size = new System.Drawing.Size(275, 22);
            this.numericUpDownPercentdiscount.TabIndex = 6;
            // 
            // numericUpDownValueDiscount
            // 
            this.numericUpDownValueDiscount.Location = new System.Drawing.Point(248, 361);
            this.numericUpDownValueDiscount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.numericUpDownValueDiscount.Name = "numericUpDownValueDiscount";
            this.numericUpDownValueDiscount.Size = new System.Drawing.Size(275, 22);
            this.numericUpDownValueDiscount.TabIndex = 7;
            // 
            // labelAddNewDiscount
            // 
            this.labelAddNewDiscount.AutoSize = true;
            this.labelAddNewDiscount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddNewDiscount.Location = new System.Drawing.Point(180, 27);
            this.labelAddNewDiscount.Name = "labelAddNewDiscount";
            this.labelAddNewDiscount.Size = new System.Drawing.Size(242, 19);
            this.labelAddNewDiscount.TabIndex = 16;
            this.labelAddNewDiscount.Text = "Add New Discount Infomation:";
            // 
            // labelStatusAddNewDiscount
            // 
            this.labelStatusAddNewDiscount.AutoSize = true;
            this.labelStatusAddNewDiscount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusAddNewDiscount.ForeColor = System.Drawing.Color.Red;
            this.labelStatusAddNewDiscount.Location = new System.Drawing.Point(7, 6);
            this.labelStatusAddNewDiscount.Name = "labelStatusAddNewDiscount";
            this.labelStatusAddNewDiscount.Size = new System.Drawing.Size(0, 16);
            this.labelStatusAddNewDiscount.TabIndex = 17;
            // 
            // labelStatusAutoIdAddNewDiscount
            // 
            this.labelStatusAutoIdAddNewDiscount.AutoSize = true;
            this.labelStatusAutoIdAddNewDiscount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusAutoIdAddNewDiscount.ForeColor = System.Drawing.Color.Red;
            this.labelStatusAutoIdAddNewDiscount.Location = new System.Drawing.Point(248, 53);
            this.labelStatusAutoIdAddNewDiscount.Name = "labelStatusAutoIdAddNewDiscount";
            this.labelStatusAutoIdAddNewDiscount.Size = new System.Drawing.Size(0, 16);
            this.labelStatusAutoIdAddNewDiscount.TabIndex = 18;
            // 
            // AddUpdateDiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(602, 487);
            this.Controls.Add(this.labelStatusAutoIdAddNewDiscount);
            this.Controls.Add(this.labelStatusAddNewDiscount);
            this.Controls.Add(this.labelAddNewDiscount);
            this.Controls.Add(this.numericUpDownValueDiscount);
            this.Controls.Add(this.numericUpDownPercentdiscount);
            this.Controls.Add(this.comboBoxTypeDiscount);
            this.Controls.Add(this.dateTimePickerEndTime);
            this.Controls.Add(this.dateTimePickerStartTime);
            this.Controls.Add(this.textBoxNameDiscount);
            this.Controls.Add(this.textBoxIdDiscount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelDiscount);
            this.Controls.Add(this.buttonAddNewDiscount);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateDiscountForm";
            this.Text = "Add Discount Form";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPercentdiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValueDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddNewDiscount;
        private System.Windows.Forms.Button buttonCancelDiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxIdDiscount;
        private System.Windows.Forms.TextBox textBoxNameDiscount;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
        private System.Windows.Forms.ComboBox comboBoxTypeDiscount;
        private System.Windows.Forms.NumericUpDown numericUpDownPercentdiscount;
        private System.Windows.Forms.NumericUpDown numericUpDownValueDiscount;
        private System.Windows.Forms.Label labelAddNewDiscount;
        private System.Windows.Forms.Label labelStatusAddNewDiscount;
        private System.Windows.Forms.Label labelStatusAutoIdAddNewDiscount;
    }
}