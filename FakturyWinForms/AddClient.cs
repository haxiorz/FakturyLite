using System.Windows.Forms;
using Faktury.Biz;
using System;

namespace Faktury.WinForms
{
    public partial class AddClient : Form
    {
        public AddClient(ManageClients manage)
        {
            InitializeComponent();
            manageClientsWindow = manage;
        }

        ManageClients manageClientsWindow;

        /// <summary>
        /// Adding new Client to database
        /// </summary>
        /// <param name="name">Client name</param>
        /// <param name="address">Client address</param>
        /// <param name="nip">Client NIP</param>
        private void AddClientToDatabase(string name, string address, string nip)
        {
            var client = new Client(name, address, nip);
            using (var context = new FakturyContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        private void btnAddClient_Click(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtClientName.Text) && !string.IsNullOrWhiteSpace(txtClientAddress.Text) && txtClientNIP.MaskCompleted)
            {
                try
                {
                    AddClientToDatabase(txtClientName.Text, txtClientAddress.Text, txtClientNIP.Text);
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
