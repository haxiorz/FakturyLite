using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Faktury.Biz;
using System.Globalization;
using Faktury.WinForms;
using System.Linq;

namespace Faktury.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDefaultOwner();
        }

        int productId = 1;
        private int _itemscounter = 0;
        Business business = new Business();
        List<Product> products = new List<Product>();
        List<ListViewItem> items = new List<ListViewItem>();
        Invoice invoice;
        string culture = CultureInfo.CurrentCulture.Name;
        
        /// <summary>
        /// Loading list of owners to ComboBox
        /// </summary>
        private void LoadOwnersList()
        {
            using (var context = new FakturyContext())
            {
                var query = context.Owners
                    .OrderBy(n => n.Id);

                foreach (var owner in query)
                {
                    cbOwner.Items.Add(owner.Name);
                }
            }
        }

        /// <summary>
        /// Loading clients list to ComboBox
        /// </summary>
        private void LoadClientsList()
        {
            using (var context = new FakturyContext())
            {
                var query = context.Clients
                    .OrderBy(n => n.Id);

                foreach (var client in query)
                {
                    cbClient.Items.Add(client.Name);
                }
            }
        }

        /// <summary>
        /// Populating owner textboxes with default data
        /// </summary>
        private void LoadDefaultOwner()
        {
            try
            {
                using (var context = new FakturyContext())
                {
                    var defaultOwner = context.Owners
                        .FirstOrDefault();
                    txtSellerName.Text = defaultOwner.Name;
                    txtSellerAddress.Text = defaultOwner.Address;
                    txtSellerNip.Text = defaultOwner.NIP;
                }
            }
            catch
            {
                
            }
            
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            decimal netto;
            decimal vat;
            bool nettobool = Decimal.TryParse(txtPrice.Text, NumberStyles.Any, new CultureInfo("pl-PL"), out netto);
            bool vatbool = Decimal.TryParse(cbVat.Text, NumberStyles.Any, new CultureInfo("pl-PL"), out vat);
            if (vat != 0)
            {
                AddProduct(txtProduct.Text, vat, netto, numProductCount.Value);
            }
            else
            {
                MessageBox.Show("Wybierz stawkę VAT");
            }
        }

        /// <summary>
        /// Add new product to ListView and List<T>
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="vat">Product VAT</param>
        /// <param name="nettoprice">Netto price</param>
        /// <param name="quantity">Quantity</param>
        private void AddProduct(string name, decimal vat, decimal nettoprice, decimal quantity)
        {
            if (!string.IsNullOrWhiteSpace(txtProduct.Text) && !string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                try
                {
                   
                    business.AddProduct(productId, name, vat, quantity, nettoprice, products);
                    AddProductToListView();
                    _itemscounter++;
                    productId++;
                }
                catch (Exception)
                {
                    MessageBox.Show("Wprowadziłeś niepoprawne dane!", "Błąd");
                }
            }
            else
            {
                MessageBox.Show("Wprowadź wszystkie dane!", "Błąd");
            }
        }

        /// <summary>
        /// Adding product to ListView
        /// </summary>
        private void AddProductToListView() 
        {
            items.Add(new ListViewItem(productId.ToString()));
            items[_itemscounter].SubItems.Add(products[_itemscounter].Name);
            items[_itemscounter].SubItems.Add(products[_itemscounter].Quantity.ToString() + " szt.");
            items[_itemscounter].SubItems.Add(products[_itemscounter].NettoPrice.ToString() + " zł");
            items[_itemscounter].SubItems.Add(products[_itemscounter].VAT.ToString() + "%");
            items[_itemscounter].SubItems.Add(products[_itemscounter].TotalNettoPrice.ToString() + " zł");
            items[_itemscounter].SubItems.Add(products[_itemscounter].VATValue.ToString() + " zł");
            items[_itemscounter].SubItems.Add(products[_itemscounter].TotalBruttoPrice.ToString() + " zł");
            listView1.Items.Add(items[_itemscounter]);
        }

        private void ClearProducts()
        {
            products.Clear();
            items.Clear();
            productId = 1;
            _itemscounter = 0;
            listView1.Items.Clear();
        }

        public void RefreshOwnersList()
        {
            using (var context = new FakturyContext())
            {
                var owner = context.Owners
                    .Where(n => n.Name == cbOwner.Text)
                    .FirstOrDefault();

                txtSellerName.Text = owner.Name;
                txtSellerAddress.Text = owner.Address;
                txtSellerNip.Text = owner.NIP;
            }
        }
        
        public void RefreshClientsList()
        {
            using (var context = new FakturyContext())
            {
                var client = context.Clients
                    .Where(n => n.Name == cbClient.Text)
                    .FirstOrDefault();

                txtClientName.Text = client.Name;
                txtClientAddress.Text = client.Address;
                txtClientNip.Text = client.NIP;
            }
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Regex do KeyDown
            if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^\-^\/^]"))
            {
                // Dodaj jesli jest poprawny
                e.Handled = true;
            }
        }

        private void txtSellerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsHelpers.ValidateWhitespace(sender, e);
        }

        private void txtSellerAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsHelpers.ValidateWhitespace(sender, e);
        }

        private void txtBuyerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsHelpers.ValidateWhitespace(sender, e);
        }

        private void txtBuyerAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsHelpers.ValidateWhitespace(sender, e);
        }

        private void txtProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            FormsHelpers.ValidateWhitespace(sender, e);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            FormsHelpers.ClearAllTextboxes(this);
            FormsHelpers.ClearAllMaskedTextboxes(this);
        }

        private bool CheckEmptyFields()
        {
            bool _fieldsFilled = false;
            if (!string.IsNullOrWhiteSpace(txtNumber.Text) && !string.IsNullOrWhiteSpace(txtSellerName.Text) && !string.IsNullOrWhiteSpace(txtSellerAddress.Text) && !string.IsNullOrWhiteSpace(txtSellerNip.Text))
            {
                if (!string.IsNullOrWhiteSpace(txtClientAddress.Text) && !string.IsNullOrWhiteSpace(txtClientName.Text) && !string.IsNullOrWhiteSpace(txtClientNip.Text))
                {
                    _fieldsFilled = true;
                }
            }
            return _fieldsFilled;
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            if (CheckEmptyFields() && items.Count != 0)
            {
                try
                {
                   
                    Client client = new Client(txtClientName.Text, txtClientAddress.Text, txtClientNip.Text);
                    Owner owner = new Owner(txtSellerName.Text, txtSellerAddress.Text, txtSellerNip.Text);
                    invoice = new Invoice(dtpDate.Text, txtNumber.Text, client, owner, products);
                    PDFCreator creator = new PDFCreator(invoice);
                    creator.CreatePDF();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
            else
            {
                MessageBox.Show("Wprowadź wszystkie dane.", "Błąd");
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearProducts();
        }

        private void dodajKlientaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageClients manageclientsform = new ManageClients(this);
            manageclientsform.ShowDialog(this);
        }

        private void edytujSwojeDaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageOwners manageownersform = new ManageOwners(this);
            manageownersform.ShowDialog(this);
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshClientsList();
        }

        private void cbOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshOwnersList();
        }

        private void cbClient_MouseClick(object sender, MouseEventArgs e)
        {
            cbClient.Items.Clear();
            LoadClientsList();
        }

        private void cbOwner_Click(object sender, EventArgs e)
        {
            cbOwner.Items.Clear();
            LoadOwnersList();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
           FormsHelpers.validate_textBox(sender as TextBox, e);
        }

        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView1.Columns[e.ColumnIndex].Width;
        }
    }
}
