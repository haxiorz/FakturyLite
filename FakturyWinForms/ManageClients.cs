using Faktury.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Faktury.WinForms
{
    public partial class ManageClients : Form
    {
        public ManageClients(Form1 main)
        {
            InitializeComponent();
            CreateListView();
            mainWindow = main;
        }
        Form1 mainWindow;
        List<ListViewItem> items = new List<ListViewItem>();
        private int _itemscounter;
       
        /// <summary>
        /// Populating ListView of Clients in Database
        /// </summary>
        private void CreateListView()
        {
           using (var context = new FakturyContext())
           {
               var query = context.Clients
                   .OrderBy(n => n.Id);
               var clients = query.ToList();
               foreach (var client in clients)
               {
                   items.Add(new ListViewItem(client.Id.ToString()));
                   items[_itemscounter].SubItems.Add(client.Name);
                   items[_itemscounter].SubItems.Add(client.Address);
                   items[_itemscounter].SubItems.Add(client.City);
                   items[_itemscounter].SubItems.Add(client.PostCode);
                   items[_itemscounter].SubItems.Add(client.NIP);
                   listView1.Items.Add(items[_itemscounter]);
                   _itemscounter++;
               }
           }
        }

        /// <summary>
        /// Updating ListView of Clients in Database
        /// </summary>
        internal void UpdateListView()
        {
            _itemscounter = 0;
            items.Clear();
            listView1.Items.Clear();
            CreateListView();
        }

        /// <summary>
        /// Deleting selected Client from Database
        /// </summary>
        private void DeleteObject()
        {
            try
            {
                ListViewItem selectedClient = listView1.SelectedItems[0];
                int selectedClientId = Int32.Parse(selectedClient.SubItems[0].Text);
                using (var context = new FakturyContext())
                {
                    var query = context.Clients
                        .Where(n => n.Id == selectedClientId)
                        .FirstOrDefault();

                    context.Clients.Remove(query);
                    context.SaveChanges();
                }
                UpdateListView();
            }
            catch
            {
                MessageBox.Show("Zaznacz klienta do usunięcia");
            }
        }

        /// <summary>
        /// Opening EditClient form and populating textboxes
        /// </summary>
        private void EditClient()
        {
            try
            {
                ListViewItem selectedClient = listView1.SelectedItems[0];
                int selectedClientId = Int32.Parse(selectedClient.SubItems[0].Text);
                string clientName = selectedClient.SubItems[1].Text;
                string clientAddress = selectedClient.SubItems[2].Text;
                string clientCity = selectedClient.SubItems[3].Text;
                string clientPostCode = selectedClient.SubItems[4].Text;
                string clientNip = selectedClient.SubItems[5].Text;
                EditClient editClientForm = new EditClient(this, selectedClientId, clientName, clientAddress, clientCity, clientPostCode, clientNip);
                editClientForm.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show("Zaznacz klienta do edycji", err.ToString());
            }
        }
        
        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            
            DeleteConfirmation deleteConfirmation = new DeleteConfirmation("danych klienta");
            deleteConfirmation.ShowDialog(this);
            if (deleteConfirmation.delConfirmation)
            {
                DeleteObject();
            }
            
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            AddClient addClientForm = new AddClient(this);
            addClientForm.ShowDialog(this);
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            EditClient();
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }
    }
}
