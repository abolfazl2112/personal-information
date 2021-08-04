using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Reflection;
using Microsoft.Win32;
using System.Threading;

namespace personel
{
    public partial class Frmbackup : Telerik.WinControls.UI.RadForm
    {
        public Frmbackup()
        {
            InitializeComponent();
        }

        private void Frmbackup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "backup file|*.bak";
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Database = Application.StartupPath.ToString() + "\\DB\\DB.mdf";
            try
            {
                btnBackup.Enabled = false;
                int ans = DataManagement.I_U_D(@"backup database [" + Database + "] to disk='" + textBox1.Text + "'");
                FMessegeBox.FarsiMessegeBox.Show("عملیات پشتیبان گیری با موفقیت انجام شد");
                btnBackup.Enabled = true;
            }
            catch(Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show("عملیات پشتیبان گیری با مشکل مواجه شده است\n"+ ex.Message);
                btnBackup.Enabled = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
