using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.WinControls.UI.Localization;

namespace personel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); 
            RadGridLocalizationProvider.CurrentProvider = new PersianRadGridLocalizationProvider();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new logon());
            }
            catch(Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show(ex.Message,"خطا - با پشتیبانی تماس بگیرید");
            }
        }
    }
}
