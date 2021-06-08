﻿using CKK.Logic.Interfaces;
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
        IStore Store;

        public InventoryManagementForm(IStore store)
        {
            Store = store;
            InitializeComponent();
            RefreshList();
        }

        private void RefreshList()
        {
            InventoryList.Items.Clear();
            foreach(var item in Store.GetStoreItems())
            {
                InventoryList.Items.Add(item);
                
            }
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NewItemForm newItemForm = new();
            var result = newItemForm.ShowDialog();

            //Only if the user hits the Create button will it add it to the store. 
            if(result == DialogResult.OK)
            {
                Store.AddStoreItem(newItemForm.Item.GetProduct(), newItemForm.Item.GetQuantity());
                RefreshList();
            }

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var selected = (InventoryItem)InventoryList.SelectedItem;
            if (selected != null)
            {
                ItemEditorForm editor = new(selected);
                editor.ShowDialog();
                RefreshList();
            }
            
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var selected = (InventoryItem)InventoryList.SelectedItem;
            if(selected != null)
            {
                var result = MessageBox.Show(this, "Are you sure you want to delete this item?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if(result == DialogResult.Yes)
                {
                    Store.DeleteStoreItem(selected.GetProduct().GetId());
                }
            }
            RefreshList();
        }
    }
}
