using CKK.Logic.Interfaces;
using CKK.Persistance.Interfaces;
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
    public partial class SearchResultsForm : Form
    {
        private readonly IStore Store;
        private readonly string Search;
        public SearchResultsForm(IStore store, string search)
        {
            Store = store;
            Search = search;
            InitializeComponent();
            PopulateSearchBox();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var selected = (InventoryItem)SearchResultsListBox.SelectedItem;
            var selectedIndex = SearchResultsListBox.SelectedIndex;
            if (selected != null)
            {
                ItemEditorForm editor = new(selected);
                editor.ShowDialog();
                if (Store is ISavable store)
                {
                    store.Save();
                }
                SearchResultsListBox.Items.RemoveAt(selectedIndex);
                SearchResultsListBox.Items.Insert(selectedIndex, selected);

            }
        }

        private void PopulateSearchBox()
        {
            var results = Store.GetProductsByName(Search);
            if(results.Count <= 0)
            {
                MessageBox.Show("There are no items that match your search");
                Close();
            }else
            {
                foreach(var item in results)
                {
                    SearchResultsListBox.Items.Add(item);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var selected = (InventoryItem)SearchResultsListBox.SelectedItem;
            var selectedIndex = SearchResultsListBox.SelectedIndex;
            if (selected != null)
            {
                var result = MessageBox.Show(this, "Are you sure you want to delete this item?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    Store.DeleteStoreItem(selected.GetProduct().GetId());
                    SearchResultsListBox.Items.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
