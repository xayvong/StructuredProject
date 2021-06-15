using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CKK.Logic.Models;
using CKK.Persistance.Models;

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
            FileStore store = new();
            //Store store = new();
            //Only run the Management if the login was successful. Otherwise do something else (nothing right now, but maybe something else later?)
            if(loginForm.DialogResult == DialogResult.OK)
            {
                Application.Run(new InventoryManagementForm(store));
            }
        }
    }
}
