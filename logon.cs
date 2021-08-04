using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using Microsoft.Win32;

namespace personel
{
    public partial class logon : Telerik.WinControls.UI.RadForm
    {
        public int res = 0;
        public logon()
        {
            InitializeComponent();
        }
        int cont = 0;

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataTable dt=DataManagement.Search("SELECT code, username, password FROM login WHERE (username = N'"+txtuser.Text+"') AND (password = N'"+txtpass.Text+"')");
            if (dt.Rows.Count == 0)
            {
                FMessegeBox.FarsiMessegeBox.Show("اطلاعات وارد شده وجود ندارد");
                txtuser.Focus();
                return;
            }
            function.Code = dt.Rows[0]["code"].ToString();
            veroozane_list f = new veroozane_list();
            this.Hide();
            f.ShowDialog(this);
            Application.Exit();
        }


        private void buttonX2_Click(object sender, EventArgs e)
        {
            res = 0;
            this.Close();
        }

        private void textBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                txtpass.Focus();
            if (e.KeyValue == 27)
                buttonX2_Click(null, null);
        }

        private void textBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                buttonX1.Focus();
            if (e.KeyValue == 27)
                buttonX2_Click(null, null);
            if (e.KeyCode == Keys.Up)
                txtuser.Focus();
        }

        private void logon_Load(object sender, EventArgs e)
        {
            //if (!ISREG())
            //{
            //    this.Hide();
            //    new active().ShowDialog(this);
            //    Application.Exit();
            //}
            //else
            //    function.IsActive = true;
        }


        RegistryKey regKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\mnck", false);
        private bool ISREG()
        {
            if (regKey == null) return false;
            try
            {
                string regKeyReg = regKey.GetValue("mrk").ToString();
                if (regKeyReg == "RegistryByProgramer")
                {
                    return true;
                }
                else
                    return false;
            }
            catch { return false; }
        }

        private void Check_Admin_Click(object sender, EventArgs e)
        {
            //textBoxX2.Text += Persia.Calendar.ConvertToPersian(DateTime.Now).ToString("W");
        }

        private void buttonX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtpass.Focus();
            
        }

        private void buttonX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                txtpass.Focus();
            
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {
            cont = 0;
        }
    }
}
