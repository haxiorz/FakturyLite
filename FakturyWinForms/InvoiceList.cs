using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Faktury.Biz;

namespace Faktury.WinForms
{
    public partial class InvoiceList : Form
    {
        public InvoiceList(int id)
        {
            InitializeComponent();
            this.id = id;
            CreateListView();
            
        }

        private int id;
        private int _itemscounter;
        List<ListViewItem> items = new List<ListViewItem>();

        private void CreateListView()
        {
            var invoices = DBManager.DataForInvoiceListView(id);
            listView1.Items.Clear();
            foreach (var invoice in invoices)
            {
                items.Add(new ListViewItem(invoice.Id.ToString()));
                items[_itemscounter].SubItems.Add(invoice.NumberOfInvoice);
                items[_itemscounter].SubItems.Add(invoice.Date);
                items[_itemscounter].SubItems.Add(DBManager.ClientById(invoice.ClientId));
                listView1.Items.Add(items[_itemscounter]);
                _itemscounter++;
            }

        }

        private void DeleteObject()
        {
            try
            {
                ListViewItem selectedClient = listView1.SelectedItems[0];
                int selectedInvoiceId = Int32.Parse(selectedClient.SubItems[0].Text);
                DBManager.DeleteInvoice(selectedInvoiceId);
                UpdateListView();
            }
            catch
            {
                MessageBox.Show("Zaznacz klienta do usunięcia");
            }
        }

        internal void UpdateListView()
        {
            _itemscounter = 0;
            items.Clear();
            listView1.Items.Clear();
            CreateListView();
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            DeleteObject();
        }
    }
}
