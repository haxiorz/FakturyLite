using Faktury.Biz;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Faktury.WinForms
{
    public partial class EditClient : Form
    {
        public EditClient(ManageClients manage, int clientId, string name, string address, string city, string postcode, string nip)
        {
            InitializeComponent();
            manageClientsWindow = manage;
            _clientId = clientId;
            txtClientName.Text = name;
            txtClientAddress.Text = address;
            txtClientCity.Text = city;
            txtClientPostCode.Text = postcode;
            txtClientNIP.Text = nip;
        }

        ManageClients manageClientsWindow;
        private int _clientId;

        /// <summary>
        /// Editing client info in database
        /// </summary>
        /// <param name="name">Client name</param>
        /// <param name="address">Client address</param>
        /// <param name="nip">Client NIP</param>
        /// <param name="id">Client Id</param>
        private void EditClientInDatabase(string name, string address, string city, string postcode, string nip, int id)
        {
            DBManager.EditClientData(id, name, address, city, postcode, nip);
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtClientName.Text) && !string.IsNullOrWhiteSpace(txtClientAddress.Text) && !string.IsNullOrWhiteSpace(txtClientCity.Text) && txtClientNIP.MaskCompleted && txtClientPostCode.MaskCompleted)
            {
                try
                {
                    EditClientInDatabase(txtClientName.Text, txtClientAddress.Text, txtClientCity.Text, txtClientPostCode.Text, txtClientNIP.Text, _clientId);
                    this.Close();
                    manageClientsWindow.UpdateListView();
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
