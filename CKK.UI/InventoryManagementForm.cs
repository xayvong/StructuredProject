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
    public partial class InventoryManagementForm : Form
    {
        private IStore Store;

        public InventoryManagementForm(IStore store)
        {
            Store = store;
            InitializeComponent();
            RefreshList();
        }

        private void RefreshList()
        {
            InventoryList.Items.Clear();
            foreach (var item in Store.GetStoreItems())
            {
                InventoryList.Items.Add(item);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchResultsForm searchForm = new SearchResultsForm(Store,SearchTextBox.Text);
            if (!searchForm.IsDisposed)
            {
                searchForm.ShowDialog();
                RefreshList();
                SearchTextBox.Text = "";
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NewItemForm newItemForm = new();
            var result = newItemForm.ShowDialog();

            //Only if the user hits the Create button will it add it to the store. 
            if(result == DialogResult.OK)
            {
                Store.AddStoreItem(newItemForm.Item, newItemForm.Item.Quantity);
                RefreshList();
            }

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var selected = (Product)InventoryList.SelectedItem;
            var selectedIndex = InventoryList.SelectedIndex;
            if (selected != null)
            {
                ItemEditorForm editor = new(selected);
                editor.ShowDialog();
                RefreshList();
                InventoryList.SelectedIndex = selectedIndex;
                if (Store is ISavable store)
                {
                    store.Save();
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var selected = (Product)InventoryList.SelectedItem;
            if(selected != null)
            {
                var result = MessageBox.Show(this, "Are you sure you want to delete this item?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if(result == DialogResult.Yes)
                {
                    Store.DeleteStoreItem(selected.Id);
                }
            }
            RefreshList();
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(SearchTextBox.Focused)
            {
                if(e.KeyCode == Keys.Enter)
                {
                    SearchButton_Click(sender, e);
                }
            }
        }

        
    }
}
