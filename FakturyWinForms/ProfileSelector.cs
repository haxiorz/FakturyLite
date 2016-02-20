using System;
using System.Linq;
using System.Windows.Forms;
using Faktury.Biz;

namespace Faktury.WinForms
{
    public partial class ProfileSelector : Form
    {
        public ProfileSelector()
        {
            InitializeComponent();
        }
        int id;
        
        private void LoadOwnersList()
        {
            var owners = DBManager.DataForOwnersListView();

            foreach (var owner in owners)
            {
                cbOwner.Items.Add(owner.Name);
            }

        }

        private void cbOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new FakturyContext())
            {
                var owner = context.Owners
                    .Where(n => n.Name == cbOwner.Text)
                    .First();
                id = owner.Id;
            }
            label2.Text = id.ToString();
        }

        private void cbOwner_MouseClick(object sender, MouseEventArgs e)
        {
            cbOwner.Items.Clear();
            LoadOwnersList();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            InvoiceList invoiceList = new InvoiceList(id);
            invoiceList.ShowDialog();
        }
    }
}
