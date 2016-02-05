using Faktury.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Faktury.WinForms
{
    public partial class ManageOwners : Form
    {
        public ManageOwners(Form1 main)
        {
            InitializeComponent();
            CreateListView();
            mainWindow = main;
        }

        Form1 mainWindow;
        List<ListViewItem> items = new List<ListViewItem>();
        private int _itemscounter;

        /// <summary>
        /// Populating ListView of Owners in Database
        /// </summary>
        private void CreateListView()
        {
            using (var context = new FakturyContext())
            {
                var query = context.Owners
                    .OrderBy(n => n.Id);
                var owners = query.ToList();
                foreach (var owner in owners)
                {
                    items.Add(new ListViewItem(owner.Id.ToString()));
                    items[_itemscounter].SubItems.Add(owner.Name);
                    items[_itemscounter].SubItems.Add(owner.Address);
                    items[_itemscounter].SubItems.Add(owner.NIP);
                    listView1.Items.Add(items[_itemscounter]);
                    _itemscounter++;
                }
            }
        }

        /// <summary>
        /// Updating ListView of Owners in Database
        /// </summary>
        internal void UpdateListView()
        {
            _itemscounter = 0;
            items.Clear();
            listView1.Items.Clear();
            CreateListView();
        }

        /// <summary>
        /// Deleting selected Owner from Database
        /// </summary>
        private void DeleteOwner()
        {
            try
            {
                ListViewItem selectedClient = listView1.SelectedItems[0];
                int selectedOwnerId = Int32.Parse(selectedClient.SubItems[0].Text);
                using (var context = new FakturyContext())
                {
                    var query = context.Owners
                        .Where(n => n.Id == selectedOwnerId)
                        .FirstOrDefault();

                    context.Owners.Remove(query);
                    context.SaveChanges();
                }
                UpdateListView();
            }
            catch (Exception err)
            {
                MessageBox.Show("Zaznacz klienta do usunięcia", err.ToString());
            }
        }

        /// <summary>
        /// Opening EditOwner form and populating textboxes
        /// </summary>
        private void EditOwner()
        {
            try
            {
                ListViewItem selectedClient = listView1.SelectedItems[0];
                int selectedClientId = Int32.Parse(selectedClient.SubItems[0].Text);
                string ownerName = selectedClient.SubItems[1].Text;
                string ownerAddress = selectedClient.SubItems[2].Text;
                string ownerNip = selectedClient.SubItems[3].Text;
                EditOwner editClientForm = new EditOwner(this, selectedClientId, ownerName, ownerAddress, ownerNip);
                editClientForm.Show();
            }
            catch (Exception err)
            {
                MessageBox.Show("Zaznacz profil do edycji", err.ToString());
            }
        }

        private void btnAddOwner_Click(object sender, EventArgs e)
        {
            AddOwner addOwnerForm = new AddOwner(this);
            addOwnerForm.Show();
        }

        private void btnEditOwner_Click(object sender, EventArgs e)
        {
            EditOwner();
        }

        private void btnDeleteOwner_Click(object sender, EventArgs e)
        {
            DeleteOwner();
        }
    }
}
