namespace Faktury.WinForms
{
    partial class ManageOwners
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.ClientId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClientName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClientAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClientCity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClientPostCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClientNIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddOwner = new System.Windows.Forms.Button();
            this.btnDeleteOwner = new System.Windows.Forms.Button();
            this.btnEditOwner = new System.Windows.Forms.Button();
            this.txtQueryString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClientId,
            this.ClientName,
            this.ClientAddress,
            this.ClientCity,
            this.ClientPostCode,
            this.ClientNIP});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(12, 37);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(714, 251);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView1_ColumnWidthChanging);
            // 
            // ClientId
            // 
            this.ClientId.Text = "Id";
            this.ClientId.Width = 34;
            // 
            // ClientName
            // 
            this.ClientName.Text = "Nazwa";
            this.ClientName.Width = 183;
            // 
            // ClientAddress
            // 
            this.ClientAddress.Text = "Adres";
            this.ClientAddress.Width = 181;
            // 
            // ClientCity
            // 
            this.ClientCity.Text = "Miejscowość";
            this.ClientCity.Width = 104;
            // 
            // ClientPostCode
            // 
            this.ClientPostCode.Text = "Kod pocztowy";
            this.ClientPostCode.Width = 97;
            // 
            // ClientNIP
            // 
            this.ClientNIP.Text = "NIP";
            this.ClientNIP.Width = 111;
            // 
            // btnAddOwner
            // 
            this.btnAddOwner.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddOwner.Location = new System.Drawing.Point(12, 294);
            this.btnAddOwner.Name = "btnAddOwner";
            this.btnAddOwner.Size = new System.Drawing.Size(100, 28);
            this.btnAddOwner.TabIndex = 2;
            this.btnAddOwner.Text = "Nowy profil";
            this.btnAddOwner.UseVisualStyleBackColor = false;
            this.btnAddOwner.Click += new System.EventHandler(this.btnAddOwner_Click);
            // 
            // btnDeleteOwner
            // 
            this.btnDeleteOwner.BackColor = System.Drawing.SystemColors.Control;
            this.btnDeleteOwner.Location = new System.Drawing.Point(626, 294);
            this.btnDeleteOwner.Name = "btnDeleteOwner";
            this.btnDeleteOwner.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteOwner.TabIndex = 4;
            this.btnDeleteOwner.Text = "Usuń ";
            this.btnDeleteOwner.UseVisualStyleBackColor = false;
            this.btnDeleteOwner.Click += new System.EventHandler(this.btnDeleteOwner_Click);
            // 
            // btnEditOwner
            // 
            this.btnEditOwner.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditOwner.Location = new System.Drawing.Point(520, 294);
            this.btnEditOwner.Name = "btnEditOwner";
            this.btnEditOwner.Size = new System.Drawing.Size(100, 28);
            this.btnEditOwner.TabIndex = 3;
            this.btnEditOwner.Text = "Edytuj";
            this.btnEditOwner.UseVisualStyleBackColor = false;
            this.btnEditOwner.Click += new System.EventHandler(this.btnEditOwner_Click);
            // 
            // txtQueryString
            // 
            this.txtQueryString.Location = new System.Drawing.Point(484, 10);
            this.txtQueryString.Name = "txtQueryString";
            this.txtQueryString.Size = new System.Drawing.Size(242, 21);
            this.txtQueryString.TabIndex = 1;
            this.txtQueryString.TextChanged += new System.EventHandler(this.txtQueryString_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wyszukaj:";
            // 
            // ManageOwners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(742, 334);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQueryString);
            this.Controls.Add(this.btnEditOwner);
            this.Controls.Add(this.btnDeleteOwner);
            this.Controls.Add(this.btnAddOwner);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ManageOwners";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zarządzaj profilami";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ClientName;
        private System.Windows.Forms.ColumnHeader ClientAddress;
        private System.Windows.Forms.ColumnHeader ClientNIP;
        private System.Windows.Forms.Button btnAddOwner;
        private System.Windows.Forms.Button btnDeleteOwner;
        private System.Windows.Forms.Button btnEditOwner;
        private System.Windows.Forms.ColumnHeader ClientId;
        private System.Windows.Forms.ColumnHeader ClientCity;
        private System.Windows.Forms.ColumnHeader ClientPostCode;
        private System.Windows.Forms.TextBox txtQueryString;
        private System.Windows.Forms.Label label1;

    }
}