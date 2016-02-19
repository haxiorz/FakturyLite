using Faktury.Biz;
using System;
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
        private void AddOwnerToDatabase(string name, string address, string city, string postcode, string nip)
        {
            var owner = new Owner(name, address, city, postcode, nip);
            DBManager.AddOwner(owner);
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOwnerName.Text) && !string.IsNullOrWhiteSpace(txtOwnerAddress.Text) && !string.IsNullOrWhiteSpace(txtOwnerCity.Text) && txtOwnerNIP.MaskCompleted && txtOwnerPostCode.MaskCompleted)
            {
                try
                {
                    AddOwnerToDatabase(txtOwnerName.Text, txtOwnerAddress.Text, txtOwnerCity.Text, txtOwnerPostCode.Text, txtOwnerNIP.Text);
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
