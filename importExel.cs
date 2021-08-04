using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;

namespace personel
{
    public partial class importExel : Office2007Form
    {

        public importExel()
        {
            InitializeComponent();
        }

        private void importExel_Load(object sender, EventArgs e)
        {
            if (!function.IsActive)
            {
                btnUpdate.Enabled = false;
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            if (txtSheet.Text == "")
            {
                FMessegeBox.FarsiMessegeBox.Show("نام شیت فایل اکسل را وارد کنید");
                return;
            }
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "فایل اکسل(*.xls)|*.xls";
                open.Title = "انتخاب فایل اکسل";
                if (open.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        string path = open.FileName;
                        System.Data.OleDb.OleDbConnection MyConnection;
                        System.Data.DataSet DtSet;
                        System.Data.OleDb.OleDbDataAdapter MyCommand;
                        MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + path + "';Extended Properties=Excel 8.0;");
                        MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + txtSheet.Text + "$]", MyConnection);
                        MyCommand.TableMappings.Add("Table", "Names");
                        DtSet = new System.Data.DataSet();
                        MyCommand.Fill(DtSet);
                        dataGridViewX1.DataSource = DtSet.Tables[0];
                        MyConnection.Close();

                        for (int i = 0; i < dataGridViewX1.Columns.Count; i++)
                        {
                            txtExel.Items.Add(dataGridViewX1.Columns[i].HeaderText);
                        }

                        groupPanel1.Enabled = groupPanel2.Enabled = groupPanel3.Enabled = true;
                    }
                    catch(Exception ex)
                    {
                        FMessegeBox.FarsiMessegeBox.Show("مشکل در خواندن فایل اکسل\n" + ex.Message);
                        return;
                    }
                }
            }
            catch(Exception ex) 
            {
                FMessegeBox.FarsiMessegeBox.Show("مشکل در باز کردن فایل اکسل\n" + ex.Message);
            }
        }

        bool flag = false, flagName = false, flagFamily = false, flagfather = false, flagMob = false, flagTell = false, flagShSh = false, flagAddress = false, flagBasiji = false, flagType = false;
        string SelectedName = "";
        private void btnSabt_Click(object sender, EventArgs e)
        {
            if (txtExel.Text == "" || txtItemPaygah.Text == "") return;
            dataGridViewX1.Columns[txtExel.SelectedIndex].HeaderText = txtItemPaygah.Text;
            dataGridViewX1.Columns[txtExel.SelectedIndex].Name = SelectedName;
            
            if(txtItemPaygah.SelectedIndex == 0)
                flag = true;
            if (txtItemPaygah.SelectedIndex == 1)
                flagName = true;
            if (txtItemPaygah.SelectedIndex == 2)
                flagFamily = true;
            if (txtItemPaygah.SelectedIndex == 3)
                flagfather = true;
            if (txtItemPaygah.SelectedIndex == 4)
                flagShSh = true;
            if (txtItemPaygah.SelectedIndex == 5)
                flagMob = true;
            if (txtItemPaygah.SelectedIndex == 6)
                flagTell = true;
            if (txtItemPaygah.SelectedIndex == 7)
                flagAddress = true;
            if (txtItemPaygah.SelectedIndex == 8)
                flagBasiji = true;
            if (txtItemPaygah.SelectedIndex == 9)
                flagType = true;

   
        }

        private void txtItemPaygah_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (txtItemPaygah.SelectedIndex)
            {
                case 0:
                    SelectedName = "codemeli";
                    break;
                case 1:
                    SelectedName = "name";
                    break;
                case 2:
                    SelectedName = "family";
                    break;
                case 3:
                    SelectedName = "fathername";
                    break;
                case 4:
                    SelectedName = "shsh";
                    break;
                case 5:
                    SelectedName = "mob";
                    break;
                case 6:
                    SelectedName = "tell";
                    break;
                case 7:
                    SelectedName = "address";
                    break;
                case 8:
                    SelectedName = "shbasiji";
                    break;
                case 9:
                    SelectedName = "typeozviat";
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!flag) return;

            string sql = "INSERT INTO person (codemeli{0}{1}{2}{3}{4}{5}{6}{7}{8})VALUES({9}{10}{11}{12}{13}{14}{15}{16}{17}{18})";
            try
            {
                int count = 0;
                int ans = 0;
                for (int i = 0; i < dataGridViewX1.RowCount; i++)
                {
                    string Sql = string.Format(sql, (flagName ? ",name" : ""), (flagFamily ? ",family" : ""), (flagfather ? ",fathername" : ""), (flagShSh ? ",shsh" : ""), (flagMob ? ",mob" : ""), (flagTell ? ",tell" : ""), (flagAddress ? ",address" : ""), (flagBasiji ? ",shbasiji" : ""), (flagType ? ",typeozviat" : ""),
                        "N'" + dataGridViewX1.Rows[i].Cells["codemeli"].Value.ToString() + "'", (flagName ? ",N'" + dataGridViewX1.Rows[i].Cells["name"].Value.ToString() + "'" : ""), (flagFamily ? ",N'" + dataGridViewX1.Rows[i].Cells["family"].Value.ToString() + "'" : ""), (flagfather ? ",N'" + dataGridViewX1.Rows[i].Cells["fathername"].Value.ToString() + "'" : ""),
                        (flagShSh ? ",N'" + dataGridViewX1.Rows[i].Cells["shsh"].Value.ToString() + "'" : ""), (flagMob ? ",N'" + dataGridViewX1.Rows[i].Cells["mob"].Value.ToString() + "'" : ""), (flagTell ? ",N'" + dataGridViewX1.Rows[i].Cells["tell"].Value.ToString() + "'" : ""), (flagAddress ? ",N'" + dataGridViewX1.Rows[i].Cells["address"].Value.ToString() + "'" : ""),
                        (flagBasiji ? ",N'" + dataGridViewX1.Rows[i].Cells["shbasiji"].Value.ToString() + "'" : ""), (flagType ? ",N'" + dataGridViewX1.Rows[i].Cells["typeozviat"].Value.ToString() + "'" : ""));

                    if (dataGridViewX1.Rows[i].Cells["codemeli"].Value.ToString() != "")
                    {
                        ans = DataManagement.I_U_D(Sql);
                        if (ans > 0)
                            count++;
                        else
                        {
                            FMessegeBox.FarsiMessegeBox.Show("خطا در ثبت اطلاعات\n" + ans);
                            break;
                        }
                    }
                    
                }
                if (ans > 0)
                    lblAns.Text = "تعداد " + count.ToString() + " ثبت شد";
            }
            catch(Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show("خطا در ثبت اطلاعات\n" + ex.Message, "خطا", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error);
            }
        }

        private void btnUpdate_EnabledChanged(object sender, EventArgs e)
        {
            if (!function.IsActive)
            {
                btnUpdate.Enabled = false;
            }
        }
    }
}
