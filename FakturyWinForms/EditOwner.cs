﻿using Faktury.Biz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faktury.WinForms
{
    public partial class EditOwner : Form
    {
        public EditOwner(ManageOwners manage, int clientId, string name, string address, string nip)
        {
            InitializeComponent();
            manageOwnersWindow = manage;
            _clientId = clientId;
            txtOwnerName.Text = name;
            txtOwnerAddress.Text = address;
            txtOwnerNIP.Text = nip;
        }

        ManageOwners manageOwnersWindow;
        private int _clientId;

        /// <summary>
        /// Editing owner info in database
        /// </summary>
        /// <param name="name">Owner name</param>
        /// <param name="address">Owner address</param>
        /// <param name="nip">Owner NIP</param>
        /// <param name="id">Owner Id</param>
        public void EditOwnerInDatabase(string name, string address, string nip, int id)
        {
            using (var context = new FakturyContext())
            {
                var owner = context.Owners
                    .Where(n => n.Id == id)
                    .FirstOrDefault();
                owner.Name = name;
                owner.Address = address;
                owner.NIP = nip;
                context.SaveChanges();
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOwnerName.Text) && !string.IsNullOrWhiteSpace(txtOwnerAddress.Text) && txtOwnerNIP.Mask.Length == 13)
            {
                try
                {
                    EditOwnerInDatabase(txtOwnerName.Text, txtOwnerAddress.Text, txtOwnerNIP.Text, _clientId);
                    this.Close();
                    manageOwnersWindow.UpdateListView();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne dane");
            }
        }
    }
}
