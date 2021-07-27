using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CKK.Logic.Models;
using CKK.Logic.Interfaces;

namespace CKK.UI
{
    public partial class ItemEditorForm : Form
    {
        private InventoryItem Item;
        public ItemEditorForm(InventoryItem item)
        {
            Item = item;
            InitializeComponent();
            SetValues();           
        }

        private void SetValues()
        {
            if (Item != null)
            {
                IdTextBox.Text = Item.Product.ProductId.ToString();
                NameTextBox.Text = Item.Product.Name;
                PriceTextBox.Value = Item.Product.Price;
                QuantityTextBox.Value = Item.Quantity;
            }
        }

        private void ItemEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult != DialogResult.OK)
            {
                var result = MessageBox.Show(this,"Are you sure you want to leave without saving?","Are you sure?",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
                if(result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            } else
            {
                Item.Product.Name =(NameTextBox.Text);
                Item.Product.Price = (PriceTextBox.Value);
                Item.Product.Quantity = ((int)QuantityTextBox.Value);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
