using System;
using System.Windows.Forms;

namespace Faktury.WinForms
{
    public partial class DeleteConfirmation : Form
    {
        
        public DeleteConfirmation(string objectToRemove)
        {
            InitializeComponent();
            label1.Text = "Ta akcja spowoduje usunięcie " + objectToRemove;
        }

        internal bool delConfirmation = false;
        private void btnOK_Click(object sender, EventArgs e)
        {
            delConfirmation = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
