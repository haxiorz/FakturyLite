using Faktury.Biz;
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
    public partial class AddOwner : Form
    {
        public AddOwner(ManageOwners manage)
        {
            InitializeComponent();
            manageOwnersWindow = manage;
        }

        ManageOwners manageOwnersWindow;

        /// <summary>
        /// Adding new owner to database
        /// </summary>
        /// <param name="name">Owner name</param>
        /// <param name="address">Owner address</param>
        /// <param name="nip">Owner NIP</param>
        private void AddOwnerToDatabase(string name, string address, string nip)
        {
            var owner = new Owner(name, address, nip);
            using (var context = new FakturyContext())
            {
                context.Owners.Add(owner);
                context.SaveChanges();
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOwnerName.Text) && !string.IsNullOrWhiteSpace(txtOwnerAddress.Text) && txtOwnerNIP.Mask.Length == 13)
            {
                try
                {
                    AddOwnerToDatabase(txtOwnerName.Text, txtOwnerAddress.Text, txtOwnerNIP.Text);
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
