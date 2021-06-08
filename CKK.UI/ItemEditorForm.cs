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
            DialogResult = DialogResult.None;
            InitializeComponent();
            SetValues();           
        }

        private void SetValues()
        {
            if (Item != null)
            {
                IdTextBox.Text = Item.GetProduct().GetId().ToString();
                NameTextBox.Text = Item.GetProduct().GetName();
                PriceTextBox.Value = Item.GetProduct().GetPrice();
                QuantityTextBox.Value = Item.GetQuantity();
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
                Item.GetProduct().SetName(NameTextBox.Text);
                Item.GetProduct().SetPrice(PriceTextBox.Value);
                Item.SetQuantity((int)QuantityTextBox.Value);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
