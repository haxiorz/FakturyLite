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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adres:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "NIP:";
            // 
            // txtOwnerName
            // 
            this.txtOwnerName.Location = new System.Drawing.Point(63, 13);
            this.txtOwnerName.Name = "txtOwnerName";
            this.txtOwnerName.Size = new System.Drawing.Size(288, 20);
            this.txtOwnerName.TabIndex = 1;
            // 
            // txtOwnerAddress
            // 
            this.txtOwnerAddress.Location = new System.Drawing.Point(63, 44);
            this.txtOwnerAddress.Name = "txtOwnerAddress";
            this.txtOwnerAddress.Size = new System.Drawing.Size(288, 20);
            this.txtOwnerAddress.TabIndex = 2;
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(139, 111);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(105, 39);
            this.btnAddClient.TabIndex = 4;
            this.btnAddClient.Text = "Dodaj profil";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // txtOwnerNIP
            // 
            this.txtOwnerNIP.Location = new System.Drawing.Point(63, 71);
            this.txtOwnerNIP.Mask = "000-000-00-00";
            this.txtOwnerNIP.Name = "txtOwnerNIP";
            this.txtOwnerNIP.Size = new System.Drawing.Size(288, 20);
            this.txtOwnerNIP.TabIndex = 3;
            // 
            // AddOwner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 173);
            this.Controls.Add(this.txtOwnerNIP);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.txtOwnerAddress);
            this.Controls.Add(this.txtOwnerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddOwner";
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
    }
}