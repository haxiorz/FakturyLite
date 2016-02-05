﻿namespace Faktury.WinForms
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
            this.ClientNIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddOwner = new System.Windows.Forms.Button();
            this.btnDeleteOwner = new System.Windows.Forms.Button();
            this.btnEditOwner = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClientId,
            this.ClientName,
            this.ClientAddress,
            this.ClientNIP});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(613, 219);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ClientId
            // 
            this.ClientId.Text = "Id";
            this.ClientId.Width = 34;
            // 
            // ClientName
            // 
            this.ClientName.Text = "Nazwa";
            this.ClientName.Width = 198;
            // 
            // ClientAddress
            // 
            this.ClientAddress.Text = "Adres";
            this.ClientAddress.Width = 265;
            // 
            // ClientNIP
            // 
            this.ClientNIP.Text = "NIP";
            this.ClientNIP.Width = 111;
            // 
            // btnAddOwner
            // 
            this.btnAddOwner.Location = new System.Drawing.Point(12, 237);
            this.btnAddOwner.Name = "btnAddOwner";
            this.btnAddOwner.Size = new System.Drawing.Size(86, 28);
            this.btnAddOwner.TabIndex = 1;
            this.btnAddOwner.Text = "Nowy profil";
            this.btnAddOwner.UseVisualStyleBackColor = true;
            this.btnAddOwner.Click += new System.EventHandler(this.btnAddOwner_Click);
            // 
            // btnDeleteOwner
            // 
            this.btnDeleteOwner.Location = new System.Drawing.Point(539, 237);
            this.btnDeleteOwner.Name = "btnDeleteOwner";
            this.btnDeleteOwner.Size = new System.Drawing.Size(86, 28);
            this.btnDeleteOwner.TabIndex = 2;
            this.btnDeleteOwner.Text = "Usuń ";
            this.btnDeleteOwner.UseVisualStyleBackColor = true;
            this.btnDeleteOwner.Click += new System.EventHandler(this.btnDeleteOwner_Click);
            // 
            // btnEditOwner
            // 
            this.btnEditOwner.Location = new System.Drawing.Point(447, 237);
            this.btnEditOwner.Name = "btnEditOwner";
            this.btnEditOwner.Size = new System.Drawing.Size(86, 28);
            this.btnEditOwner.TabIndex = 3;
            this.btnEditOwner.Text = "Edytuj";
            this.btnEditOwner.UseVisualStyleBackColor = true;
            this.btnEditOwner.Click += new System.EventHandler(this.btnEditOwner_Click);
            // 
            // ManageOwners
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 342);
            this.Controls.Add(this.btnEditOwner);
            this.Controls.Add(this.btnDeleteOwner);
            this.Controls.Add(this.btnAddOwner);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ManageOwners";
            this.Text = "Zarządzaj profilami";
            this.ResumeLayout(false);

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

    }
}