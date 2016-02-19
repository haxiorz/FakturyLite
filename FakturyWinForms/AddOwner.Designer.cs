namespace Faktury.WinForms
{
    partial class AddOwner
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
            this.txtOwnerName = new System.Windows.Forms.TextBox();
            this.txtOwnerAddress = new System.Windows.Forms.TextBox();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.txtOwnerNIP = new System.Windows.Forms.MaskedTextBox();
            this.txtOwnerCity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOwnerPostCode = new System.Windows.Forms.MaskedTextBox();
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
            // txtOwnerName
            // 
            this.txtOwnerName.Location = new System.Drawing.Point(105, 15);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(304, 21);
            this.txtOwnerName.TabIndex = 1;
            // 
            // txtOwnerAddress
            // 
            this.txtOwnerAddress.Location = new System.Drawing.Point(105, 45);
            this.txtOwnerAddress.Name = "txtOwnerAddress";
            this.txtOwnerAddress.Size = new System.Drawing.Size(304, 21);
            this.txtOwnerAddress.TabIndex = 2;
            // 
            // btnAddClient
            // 
            this.btnAddClient.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddClient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAddClient.Location = new System.Drawing.Point(0, 181);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(428, 39);
            this.btnAddClient.TabIndex = 6;
            this.btnAddClient.Text = "Dodaj profil";
            this.btnAddClient.UseVisualStyleBackColor = false;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // txtOwnerNIP
            // 
            this.txtOwnerNIP.Location = new System.Drawing.Point(105, 135);
            this.txtOwnerNIP.Mask = "000-000-00-00";
            this.txtOwnerNIP.Name = "txtOwnerNIP";
            this.txtOwnerNIP.Size = new System.Drawing.Size(304, 21);
            this.txtOwnerNIP.TabIndex = 5;
            // 
            // txtOwnerCity
            // 
            this.txtOwnerCity.Location = new System.Drawing.Point(105, 75);
            this.txtOwnerCity.Name = "txtOwnerCity";
            this.txtOwnerCity.Size = new System.Drawing.Size(304, 21);
            this.txtOwnerCity.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Miejscowość:";
            // 
            // txtOwnerPostCode
            // 
            this.txtOwnerPostCode.Location = new System.Drawing.Point(105, 105);
            this.txtOwnerPostCode.Mask = "00-000";
            this.txtOwnerPostCode.Name = "txtOwnerPostCode";
            this.txtOwnerPostCode.Size = new System.Drawing.Size(304, 21);
            this.txtOwnerPostCode.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kod pocztowy:";
            // 
            // AddOwner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(428, 220);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOwnerPostCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOwnerCity);
            this.Controls.Add(this.txtOwnerNIP);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.txtOwnerAddress);
            this.Controls.Add(this.txtOwnerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddOwner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodaj profil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOwnerName;
        private System.Windows.Forms.TextBox txtOwnerAddress;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.MaskedTextBox txtOwnerNIP;
        private System.Windows.Forms.TextBox txtOwnerCity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtOwnerPostCode;
        private System.Windows.Forms.Label label5;
    }
}