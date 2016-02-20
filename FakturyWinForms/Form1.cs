using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Faktury.Biz;
using System.Globalization;
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
        List<Product> products = new List<Product>();
        List<ListViewItem> items = new List<ListViewItem>();
        Invoice invoice;
        
        /// <summary>
        /// Loading list of owners to ComboBox
        /// </summary>
        private void LoadOwnersList()
        {
            var owners = DBManager.DataForOwnersListView();

            foreach (var owner in owners)
            {
                cbOwner.Items.Add(owner.Name);
            }
            
        }

        /// <summary>
        /// Loading clients list to ComboBox
        /// </summary>
        private void LoadClientsList()
        {
            var clients = DBManager.DataForClientsListView();
            foreach (var client in clients)
            {
                cbClient.Items.Add(client.Name);
            }
            
        }

        /// <summary>
        /// Populating owner textboxes with default data
        /// </summary>
        private void LoadDefaultOwner()
        {
            try
            {
                var defaultOwner = DBManager.SelectDefaultOwner();
                txtSellerName.Text = defaultOwner.Name;
                txtSellerAddress.Text = defaultOwner.Address;
                txtSellerCity.Text = defaultOwner.City;
                txtSellerPostCode.Text = defaultOwner.PostCode;
                txtSellerNip.Text = defaultOwner.NIP;
                
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
                    DBManager manager = new DBManager();
                    manager.AddProduct(productId, name, vat, quantity, nettoprice, radioButton1.Checked, products);
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
            items[_itemscounter].SubItems.Add(products[_itemscounter].NettoPrice.ToString("C"));
            items[_itemscounter].SubItems.Add(products[_itemscounter].VAT.ToString() + "%");
            items[_itemscounter].SubItems.Add(products[_itemscounter].TotalNettoPrice.ToString("C"));
            items[_itemscounter].SubItems.Add(products[_itemscounter].VATValue.ToString("C"));
            items[_itemscounter].SubItems.Add(products[_itemscounter].TotalBruttoPrice.ToString("C"));
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
            var owner = DBManager.OwnerByName(cbOwner.Text);
            txtSellerName.Text = owner.Name;
            txtSellerAddress.Text = owner.Address;
            txtSellerCity.Text = owner.City;
            txtSellerPostCode.Text = owner.PostCode;
            txtSellerNip.Text = owner.NIP;
            
        }
        
        public void RefreshClientsList()
        {
            var client = DBManager.ClientByName(cbClient.Text);
            txtClientName.Text = client.Name;
            txtClientAddress.Text = client.Address;
            txtClientCity.Text = client.City;
            txtClientPostCode.Text = client.PostCode;
            txtClientNip.Text = client.NIP;
            
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

        private void txtSellerCity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtClientCity_KeyPress(object sender, KeyPressEventArgs e)
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
            int _fieldsCounter = 0;
            List<string> textboxes = new List<string>();
            textboxes.Add(txtNumber.Text);
            textboxes.Add(txtSellerName.Text);
            textboxes.Add(txtSellerAddress.Text);
            textboxes.Add(txtSellerCity.Text);
            textboxes.Add(txtClientName.Text);
            textboxes.Add(txtClientAddress.Text);
            textboxes.Add(txtClientCity.Text);
            List<MaskedTextBox> maskedtextboxes = new List<MaskedTextBox>();
            maskedtextboxes.Add(txtSellerPostCode);
            maskedtextboxes.Add(txtSellerNip);
            maskedtextboxes.Add(txtClientPostCode);
            maskedtextboxes.Add(txtClientNip);
            bool _fieldsFilled = false;
            foreach (string text in textboxes)
            {
                if (!string.IsNullOrWhiteSpace(text))
                {
                    _fieldsCounter++;
                }
            }
            foreach (MaskedTextBox textbox in maskedtextboxes)
            {
                if (textbox.MaskCompleted)
                {
                    _fieldsCounter++;
                }
            }
            if (_fieldsCounter == 11)
            {
                _fieldsFilled = true;
            }
            return _fieldsFilled;
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            if (CheckEmptyFields() && items.Count != 0)
            {
                try
                {
                   
                    Client client = new Client(txtClientName.Text, txtClientAddress.Text, txtClientCity.Text, txtClientPostCode.Text, txtClientNip.Text);
                    Owner owner = new Owner(txtSellerName.Text, txtSellerAddress.Text, txtSellerCity.Text, txtSellerPostCode.Text, txtSellerNip.Text);
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
            ManageOwners manageownersform = new ManageOwners();
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

        private void zapisaneFakturyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileSelector profileSelector = new ProfileSelector();
            profileSelector.ShowDialog(this);
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                Client client = new Client(txtClientName.Text, txtClientAddress.Text, txtClientCity.Text, txtClientPostCode.Text, txtClientNip.Text);
                Owner owner = new Owner(txtSellerName.Text, txtSellerAddress.Text, txtSellerCity.Text, txtSellerPostCode.Text, txtSellerNip.Text);
                invoice = new Invoice(dtpDate.Text, txtNumber.Text, client, owner, products);
                DBManager.SaveInvoice(invoice);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

    }
}
