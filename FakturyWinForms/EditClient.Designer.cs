namespace Faktury.WinForms
{
    partial class EditClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.txtClientAddress = new System.Windows.Forms.TextBox();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.txtClientNIP = new System.Windows.Forms.MaskedTextBox();
            this.txtClientCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClientPostCode = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adres:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "NIP:";
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(105, 15);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(304, 21);
            this.txtClientName.TabIndex = 1;
            // 
            // txtClientAddress
            // 
            this.txtClientAddress.Location = new System.Drawing.Point(105, 45);
            this.txtClientAddress.Name = "txtClientAddress";
            this.txtClientAddress.Size = new System.Drawing.Size(304, 21);
            this.txtClientAddress.TabIndex = 2;
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddClient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddClient.Location = new System.Drawing.Point(0, 173);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(428, 39);
            this.btnAddClient.TabIndex = 4;
            this.btnAddClient.Text = "Edytuj dane";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // txtClientNIP
            // 
            this.txtClientNIP.Location = new System.Drawing.Point(105, 135);
            this.txtClientNIP.Mask = "000-000-00-00";
            this.txtClientNIP.Name = "txtClientNIP";
            this.txtClientNIP.Size = new System.Drawing.Size(304, 21);
            this.txtClientNIP.TabIndex = 3;
            // 
            // txtClientCity
            // 
            this.txtClientCity.Location = new System.Drawing.Point(105, 75);
            this.txtClientCity.Name = "txtClientCity";
            this.txtClientCity.Size = new System.Drawing.Size(304, 21);
            this.txtClientCity.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Miejscowość:";
            // 
            // txtClientPostCode
            // 
            this.txtClientPostCode.Location = new System.Drawing.Point(105, 105);
            this.txtClientPostCode.Mask = "00-000";
            this.txtClientPostCode.Name = "txtClientPostCode";
            this.txtClientPostCode.Size = new System.Drawing.Size(304, 21);
            this.txtClientPostCode.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kod pocztowy:";
            // 
            // EditClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(428, 212);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtClientPostCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClientCity);
            this.Controls.Add(this.txtClientNIP);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.txtClientAddress);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edytuj klienta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.TextBox txtClientAddress;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.MaskedTextBox txtClientNIP;
        private System.Windows.Forms.TextBox txtClientCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtClientPostCode;
        private System.Windows.Forms.Label label5;
    }
}