using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CKK.Logic.Models;

namespace CKK.UI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
            Store store = new Store();
            
            store.AddStoreItem(new Product(), 1);
            store.AddStoreItem(new Product(), 2);
            store.AddStoreItem(new Product(), 3);
            if(loginForm.DialogResult == DialogResult.OK)
            {
                Application.Run(new InventoryManagementForm(store));
            }
        }
    }
}