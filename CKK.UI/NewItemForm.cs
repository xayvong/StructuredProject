using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKK.UI
{
    public partial class NewItemForm : Form
    {
        public InventoryItem Item { get; private set; }
        public NewItemForm()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var prod = new Product();
            prod.SetName(NameTextBox.Text);
            prod.SetPrice(PriceTextBox.Value);
            Item = new StoreItem(prod, (int)QuantityTextBox.Value);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
