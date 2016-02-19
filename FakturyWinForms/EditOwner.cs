using Faktury.Biz;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Faktury.WinForms
{
    public partial class EditOwner : Form
    {
        public EditOwner(ManageOwners manage, int clientId, string name, string address, string city, string postcode, string nip)
        {
            InitializeComponent();
            manageOwnersWindow = manage;
            _clientId = clientId;
            txtOwnerName.Text = name;
            txtOwnerAddress.Text = address;
            txtOwnerNIP.Text = nip;
            txtOwnerCity.Text = city;
            txtOwnerPostCode.Text = postcode;
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
        public void EditOwnerInDatabase(string name, string address, string city, string postcode, string nip, int id)
        {
            DBManager.EditOwnerData(id, name, address, city, postcode, nip);
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtOwnerName.Text) && !string.IsNullOrWhiteSpace(txtOwnerAddress.Text) && !string.IsNullOrWhiteSpace(txtOwnerCity.Text) && txtOwnerNIP.MaskCompleted && txtOwnerPostCode.MaskCompleted)
            {
                try
                {
                    EditOwnerInDatabase(txtOwnerName.Text, txtOwnerAddress.Text, txtOwnerCity.Text, txtOwnerPostCode.Text, txtOwnerNIP.Text, _clientId);
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
