namespace SuperMallManagerMVC
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonLoginForm = new System.Windows.Forms.Button();
            this.buttonCancelForm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserName:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 188);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(259, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(311, 26);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(259, 184);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(311, 26);
            this.textBox2.TabIndex = 3;
            // 
            // buttonLoginForm
            // 
            this.buttonLoginForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoginForm.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoginForm.Image")));
            this.buttonLoginForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLoginForm.Location = new System.Drawing.Point(222, 271);
            this.buttonLoginForm.Name = "buttonLoginForm";
            this.buttonLoginForm.Size = new System.Drawing.Size(135, 36);
            this.buttonLoginForm.TabIndex = 4;
            this.buttonLoginForm.Text = "Login";
            this.buttonLoginForm.UseVisualStyleBackColor = true;
            this.buttonLoginForm.Click += new System.EventHandler(this.buttonLoginForm_Click);
            // 
            // buttonCancelForm
            // 
            this.buttonCancelForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelForm.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancelForm.Image")));
            this.buttonCancelForm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelForm.Location = new System.Drawing.Point(450, 271);
            this.buttonCancelForm.Name = "buttonCancelForm";
            this.buttonCancelForm.Size = new System.Drawing.Size(135, 36);
            this.buttonCancelForm.TabIndex = 5;
            this.buttonCancelForm.Text = "Cancel";
            this.buttonCancelForm.UseVisualStyleBackColor = true;
            this.buttonCancelForm.Click += new System.EventHandler(this.buttonCancelForm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(357, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "Login";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(799, 411);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancelForm);
            this.Controls.Add(this.buttonLoginForm);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonLoginForm;
        private System.Windows.Forms.Button buttonCancelForm;
        private System.Windows.Forms.Label label3;
    }
}