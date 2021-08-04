using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace personel
{
    public partial class frmRestor : DevComponents.DotNetBar.Office2007Form
    {
        public frmRestor()
        {
            InitializeComponent();
        }

        private void btnRestor_Click(object sender, EventArgs e)
        {
            string Database = Application.StartupPath.ToString() + "\\DB\\DB.mdf";
            SqlConnection sq = new SqlConnection("data source=.\\SQLEXPRESS;attachdbfilename="+Database+";integrated security=true;user instance=true");
            try
            {

                SqlCommand cmd = new SqlCommand("alter database [" + Database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE ;USE [master]; restore database [" + Database + "] from disk ='" + textBox1.Text + "'WITH REPLACE;ALTER DATABASE [" + Database + "] SET MULTI_USER", sq);
                
                sq.Open();
                cmd.ExecuteNonQuery();
                sq.Close();
                FMessegeBox.FarsiMessegeBox.Show("عملیات  با موفقیت انجام شدُ");
                btnRestor.Enabled = true;
            }
            catch(Exception ex)
            {
                
                FMessegeBox.FarsiMessegeBox.Show("عملیات با مشکل مواجه شده است\n" + ex.Message);
                btnRestor.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "backup file|*.bak";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;

            }
        }

        private void frmRestor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
