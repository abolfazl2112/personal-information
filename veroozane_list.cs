using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using Stimulsoft.Report;
using System.IO;

namespace personel
{
    public partial class veroozane_list : Telerik.WinControls.UI.RadForm
    {
        Telerik.WinControls.UI.BestFitColumnMode StyleHeaderCells = Telerik.WinControls.UI.BestFitColumnMode.HeaderCells;

        string SqlAll = "SELECT daraje AS [شرایط فرد],codemeli AS [کد ملی], name AS نام, family AS [نام خانوادگی], fathername AS [نام پدر], shsh AS [ش.شناسنامه], tavalod AS [تاریخ تولد], esalat AS اصالت, sokoonat AS سکونت, " +
                        " taahol AS تاهل, olad AS اولاد, madrak AS مدرک, reshte AS رشته, sarbazi AS سربازی, shoghl AS [شغل قبلی], Sbime AS [سابقه بیمه], ShBime AS [شماره بیمه], tell AS [تلفن ثابت], "+
                        " mobile AS موبایل ,address AS آدرس,name1 AS [نام و نام خانوادگی آشنا 1], nesbat1 AS [نسبت 1], tell1 AS [تلفن 1], mob1 AS [موبایل 1], name2 AS [نام و نام خانوادگی 2], nesbat2 AS [نسبت 2], tell2 AS [تلفن 2],  mob2 AS [موبایل 2] ,"+
                        " shakhs AS [نام شخص ثبت نام کننده], date AS [تاریخ ثبت], nazar AS [نظر شخص ثبت نام کننده], tozih AS توضیحات, vaziat AS وضعیت FROM person ";

        public veroozane_list()
        {
            InitializeComponent();
        }

        private void vshir_list_Load(object sender, EventArgs e)
        {
            btnLeft.Text = Persia.Calendar.ConvertToPersian(DateTime.Now).ToString("W");
            ShowAllData();
        }

        public static void setRowNumber(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        private void ShowAllData()
        {
            dgvAll.DataSource = DataManagement.Search(SqlAll);
            for (int i = 0; i < dgvAll.RowCount; i++)
                dgvAll.Columns[i].AutoSizeMode = StyleHeaderCells;


            dgvSabtenam.DataSource = DataManagement.Search(SqlAll + " where (vaziat = N'در صف انتظار')");
            for (int i = 0; i < dgvSabtenam.RowCount; i++)
                dgvSabtenam.Columns[i].AutoSizeMode = StyleHeaderCells;

            dgvEstekhdam.DataSource = DataManagement.Search(SqlAll + " where (vaziat = N'استخدام')");
            for (int i = 0; i < dgvEstekhdam.RowCount; i++)
                dgvEstekhdam.Columns[i].AutoSizeMode = StyleHeaderCells;

            dgvTark.DataSource = DataManagement.Search(SqlAll + " where (vaziat = N'ترک کار')");
            for (int i = 0; i < dgvTark.RowCount; i++)
                dgvTark.Columns[i].AutoSizeMode = StyleHeaderCells;

            dgvEnserafi.DataSource = DataManagement.Search(SqlAll + " where (vaziat = N'انصرافی')");
            for (int i = 0; i < dgvEnserafi.RowCount; i++)
                dgvEnserafi.Columns[i].AutoSizeMode = StyleHeaderCells;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            new F_AddEditPerson("new",null).ShowDialog(this);
            vshir_list_Load(null, null);
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                if (expkoleaza.Expanded && dgvAll.RowCount > 0)
                {
                    sql = "DELETE FROM person WHERE (codemeli = N'" + dgvAll.CurrentRow.Cells["کد ملی"].Value.ToString() + "')";

                }
                if (tabSabtenam.IsSelected && dgvSabtenam.RowCount > 0)
                {
                    sql = "DELETE FROM person WHERE (codemeli = N'" + dgvSabtenam.CurrentRow.Cells["کد ملی"].Value.ToString() + "')";

                }
                else if (tabEstekhdam.IsSelected && dgvEstekhdam.RowCount > 0)
                {
                    sql = "DELETE FROM person WHERE (codemeli = N'" + dgvEstekhdam.CurrentRow.Cells["کد ملی"].Value.ToString() + "')";

                }
                else if (dgvTark.RowCount > 0)
                {
                    sql = "DELETE FROM person WHERE (codemeli = N'" + dgvTark.CurrentRow.Cells["کد ملی"].Value.ToString() + "')";

                }
                else
                    return;

                if (FMessegeBox.FarsiMessegeBox.Show("آیا برای حذف مطمئن هستید؟", "سوال", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question) == DialogResult.Yes)
                {
                    int ans = DataManagement.I_U_D(sql);
                        vshir_list_Load(null, null);
                        FMessegeBox.FarsiMessegeBox.Show("حذف شد");
                }
            }
            catch(Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show("مشکل در ذخیره اطلاعات\n" + ex.Message, "اخطار", FMessegeBox.FMessegeBoxButtons.Ok, FMessegeBox.FMessegeBoxIcons.Error);

            }
        }

        private void btn1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                this.Close();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            vshir_list_Load(null, null);
            //try
            //{
            //    if (superTabControl1.SelectedTabIndex == 0 && dataGridFaal.RowCount == 0)
            //        return;
            //    if (superTabControl1.SelectedTabIndex == 1 && dataGridAdi.RowCount == 0)
            //        return;
            //    if (superTabControl1.SelectedTabIndex == 2 && dataGridRaked.RowCount == 0)
            //        return;
            //    con.Disconnect();
            //    con.connection();
            //    StiReport sti = new StiReport();
            //    sti.Load("ReportAza.mrt");
            //    sti.RegData("DataSource3", con.show_data("select * from person"));
            //    sti.Dictionary.DataSources.Items[0].DataTable = dt;
            //    con.Disconnect();
            //    sti.Show();
            //}
            //catch (Exception ex)
            //{
            //    FMessegeBox.FarsiMessegeBox.Show("خطا\n" + ex.Message);
            //}
        }

        //private void SearchPerson()
        //{
        //    try
        //    {
        //        con.Disconnect();
        //        con.connection();
        //        if (expkoleaza.Expanded)
        //            dgvAll.DataSource = DataManagement.Search(SqlAll + " WHERE (codemeli LIKE N'" + txtSearchMeli.Text + "%') AND (name LIKE N'" + txtSearchName.Text + "%') AND (family LIKE N'" + txtSearchFamily.Text + "%') AND (typeozviat = N'فعال')");
        //        else if (tabSelected == "tabFaal")
        //            dgvSabtenam.DataSource = DataManagement.Search(SqlAll + " FROM person WHERE (codemeli LIKE N'" + txtSearchMeli.Text + "%') AND (name LIKE N'" + txtSearchName.Text + "%') AND (family LIKE N'" + txtSearchFamily.Text + "%') AND (typeozviat = N'فعال')");
        //        else if (tabSelected == "tabAdi")
        //            dgvEstekhdam.DataSource = DataManagement.Search(SqlAll + " WHERE (codemeli LIKE N'" + txtSearchMeli.Text + "%') AND (name LIKE N'" + txtSearchName.Text + "%') AND (family LIKE N'" + txtSearchFamily.Text + "%') AND (typeozviat = N'عادی')");
        //        else
        //            dataGridRaked.DataSource = DataManagement.Search(SqlAll + " WHERE (codemeli LIKE N'" + txtSearchMeli.Text + "%') AND (name LIKE N'" + txtSearchName.Text + "%') AND (family LIKE N'" + txtSearchFamily.Text + "%') AND (typeozviat = N'راکد')");
        //    }
        //    catch { }
        //    con.Disconnect();

        //}


        private void btnSabteName_Click(object sender, EventArgs e)
        {
            if (txtOnvan.Text == "" || txtAddName.Text == "") return;
            try
            {
                string codeM = "";
                if (tabSabtenam.IsSelected)
                    codeM = dgvSabtenam.CurrentRow.Cells["کد ملی"].Value.ToString();
                else if (tabEstekhdam.IsSelected)
                    codeM = dgvEstekhdam.CurrentRow.Cells["کد ملی"].Value.ToString();
                else
                    codeM = dgvTark.CurrentRow.Cells["کد ملی"].Value.ToString();

                string[] Names = txtAddName.Text.Split('\\','.');
                string FileNewName = Names[Names.Length - 2] + "." + Names[Names.Length - 1];

                if (!System.IO.Directory.Exists(Application.StartupPath + "\\files"))
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\files");

                FileNewName = Application.StartupPath + "\\files\\" + FileNewName;
                if (System.IO.File.Exists(FileNewName))
                {
                    if (FMessegeBox.FarsiMessegeBox.Show("آیا فایل جایگزین شود؟", "سوال", FMessegeBox.FMessegeBoxButtons.YesNo, FMessegeBox.FMessegeBoxIcons.Question) == DialogResult.Yes)
                    {
                        System.IO.File.Delete(FileNewName);
                        System.IO.File.Copy(txtAddName.Text, FileNewName);
                    }
                }
                else
                {
                    System.IO.File.Copy(txtAddName.Text, FileNewName);
                }
                string sql = "INSERT INTO scan (codeMeli, onvan, imag) VALUES (N'" + codeM + "', N'" + txtOnvan.Text + "', N'" + FileNewName + "')";
                
                int ans = DataManagement.I_U_D(sql);
                if (ans > 0)
                {
                    txtAddName.Text = txtOnvan.Text = "";
                    dgvFiles.DataSource = DataManagement.Search("SELECT codeMeli'کدملی',onvan'عنوان فایل',imag'فایل' FROM scan WHERE (codeMeli = N'" + dgvAll.CurrentRow.Cells["کد ملی"].Value.ToString() + "' )");
                    FMessegeBox.FarsiMessegeBox.Show("اطلاعات با موفقیت ثبت شد");
                }
                else
                    FMessegeBox.FarsiMessegeBox.Show("مشکل در ثبت اطلاعات\n" + ans);



            }
            catch(Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show("خطا در ثبت اطلاعات\n" + ex.Message);
            }
        }

        private void لیستنامههایشخصToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewX1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFiles.CurrentRow.Cells[2].Value.ToString() == "")
                    return;
                System.Diagnostics.Process.Start(dgvFiles.CurrentRow.Cells[2].Value.ToString());
            }
            catch (Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show(ex.Message);
            }
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            if (dgvFiles.RowCount == 0)
                return;
            try
            {
                string sql = "DELETE FROM scan WHERE(codeMeli = N'" + dgvFiles.CurrentRow.Cells["کدملی"].Value.ToString() +
                    "') AND (onvan = N'" + dgvFiles.CurrentRow.Cells[1].Value.ToString() +
                    "') AND (imag = N'" + dgvFiles.CurrentRow.Cells[2].Value.ToString() + "')";

                int result = DataManagement.I_U_D(sql);

                if (result>0)
                    FMessegeBox.FarsiMessegeBox.Show("حذف با موفقیت انجام شد");
                else
                    FMessegeBox.FarsiMessegeBox.Show("مشکل در بروزرسانی اطلاعات\n" + sql);
            }
            catch (Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show("خطا در بروزرسانی اطلاعات\n" + ex.Message);
            }
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
            expkoleaza.Expanded = !expkoleaza.Expanded;
        }

        private void dataGridAll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                expkoleaza.Expanded = false;
        }

        private void expandablePanel3_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            if (expandablePanel3.Expanded)
                expandablePanel3.BringToFront();
        }

        private void expkoleaza_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
        {
            btnVEstekhdam.Enabled = btnVTark.Enabled = groupPersons.Visible = !expkoleaza.Expanded;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void buttonX2_Click_1(object sender, EventArgs e)
        {
            new about().ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            F_ChangePassword f_change = new F_ChangePassword();
            f_change.ShowDialog(this);
        }

        private void superTabControl1_SelectedTabChanged(object sender, SuperTabStripSelectedTabChangedEventArgs e)
        {
            if (tabSabtenam.IsSelected)
            {
                btnVEstekhdam.Enabled =  true;
                btnVTark.Enabled = false;
                //dgvSabtenam.DataSource = DataManagement.Search(SqlAll + "where (vaziat = N'در صف انتظار')");
            }
            else if (tabEstekhdam.IsSelected)
            {
                btnVEstekhdam.Enabled = false;
                btnVTark.Enabled = true;

                //dgvEstekhdam.DataSource = DataManagement.Search(SqlAll + "where (vaziat = N'استخدام')");
            }
            else if (tabTarkekar.IsSelected)
            {
                btnVEstekhdam.Enabled = true;
                btnVTark.Enabled = false;
                //dgvEstekhdam.DataSource = DataManagement.Search(SqlAll + "where (vaziat = N'ترک کار')");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (expkoleaza.Expanded && dgvAll.RowCount > 0)
                new F_AddEditPerson("edit", dgvAll.CurrentRow).ShowDialog(this);
            else if (tabSabtenam.IsSelected && dgvSabtenam.RowCount > 0)
                new F_AddEditPerson("edit", dgvSabtenam.CurrentRow).ShowDialog(this);
            else if (tabEstekhdam.IsSelected && dgvEstekhdam.RowCount > 0)
                new F_AddEditPerson("edit", dgvEstekhdam.CurrentRow).ShowDialog(this);
            else
                new F_AddEditPerson("edit", dgvTark.CurrentRow).ShowDialog(this);

            vshir_list_Load(null, null);
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            try
            {
                if (expkoleaza.Expanded && dgvAll.RowCount > 0)
                {
                    expandablePanel3.Expanded = true;
                    dgvFiles.DataSource = DataManagement.Search("SELECT codeMeli'کدملی',onvan'عنوان فایل',imag'فایل' FROM scan WHERE (codeMeli = N'" + dgvAll.CurrentRow.Cells["کد ملی"].Value.ToString() + "' )");
                }
                else if (tabSabtenam.IsSelected && dgvSabtenam.RowCount > 0)
                {
                    expandablePanel3.Expanded = true;
                    dgvFiles.DataSource = DataManagement.Search("SELECT codeMeli'کدملی',onvan'عنوان فایل',imag'فایل' FROM scan WHERE (codeMeli = N'" + dgvSabtenam.CurrentRow.Cells["کد ملی"].Value.ToString() + "' )");
                }
                else if (tabEstekhdam.IsSelected && dgvEstekhdam.RowCount > 0)
                {
                    expandablePanel3.Expanded = true;
                    dgvFiles.DataSource = DataManagement.Search("SELECT codeMeli'کدملی',onvan'عنوان فایل',imag'فایل' FROM scan WHERE (codeMeli = N'" + dgvEstekhdam.CurrentRow.Cells["کد ملی"].Value.ToString() + "' )");
                }
                else if(dgvTark.RowCount > 0)
                {
                    expandablePanel3.Expanded = true;
                    dgvFiles.DataSource = DataManagement.Search("SELECT codeMeli'کدملی',onvan'عنوان فایل',imag'فایل' FROM scan WHERE (codeMeli = N'" + dgvTark.CurrentRow.Cells["کد ملی"].Value.ToString() + "' )");
                }
            }
            catch (Exception) { }
        }

        private void btnVEstekhdam_Click(object sender, EventArgs e)
        {
            try
            {
                string codemeli = "";
                if (tabSabtenam.IsSelected && dgvSabtenam.RowCount > 0)
                {
                    codemeli = dgvSabtenam.CurrentRow.Cells["کد ملی"].Value.ToString();
                }
                else if(dgvTark.RowCount > 0)
                    codemeli = dgvTark.CurrentRow.Cells["کد ملی"].Value.ToString();


                if (FMessegeBox.FarsiMessegeBox.Show("آیا برای انتقال انجام شود؟","سوال",FMessegeBox.FMessegeBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataManagement.I_U_D("UPDATE person SET vaziat = N'استخدام' WHERE (codemeli = N'" + codemeli + "')");
                    vshir_list_Load(null, null);
                }

            }
            catch (Exception ex) { FMessegeBox.FarsiMessegeBox.Show(ex.Message); }
        }

        private void btnVTark_Click(object sender, EventArgs e)
        {
            try
            {
                string codemeli = "";
                if (tabSabtenam.IsSelected && dgvSabtenam.RowCount > 0)
                {
                    codemeli = dgvSabtenam.CurrentRow.Cells["کد ملی"].Value.ToString();
                }
                else if(dgvEstekhdam.RowCount > 0)
                    codemeli = dgvEstekhdam.CurrentRow.Cells["کد ملی"].Value.ToString();
                if (FMessegeBox.FarsiMessegeBox.Show("آیا برای انتقال انجام شود؟","سوال",FMessegeBox.FMessegeBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataManagement.I_U_D("UPDATE person SET vaziat = N'ترک کار' WHERE (codemeli = N'" + codemeli + "')");
                    vshir_list_Load(null, null);
                }
            }
            catch (Exception ex) { FMessegeBox.FarsiMessegeBox.Show(ex.Message); }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            try
            {
                DataManagement.I_U_D("UPDATE person SET DateTark = N'" + txtDateTark.Text + "',ElateTark = N'" + txtElateTark.Text + "',TedadeRooz=N'" + txtTedadeRooz.Text + "', tozih=N'" + txtTozihat.Text +
                    "' WHERE (codemeli = N'" + dgvTark.CurrentRow.Cells["کد ملی"].Value.ToString() + "')");
                vshir_list_Load(null, null);
            }
            catch (Exception ex) { FMessegeBox.FarsiMessegeBox.Show(ex.Message); }
        }

        private void dgvEstekhdam_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                DataTable dt = DataManagement.Search("select DateShoroo,tozih from person where codemeli = N'" + e.Row.Cells["کد ملی"].Value.ToString() + "'");
                txtDateShoroo.Text = dt.Rows[0][0].ToString();
                txtTozih.Text = dt.Rows[0][1].ToString();

            }
            catch { }
        }

        private void dgvTark_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                DataTable dt = DataManagement.Search("select DateTark,ElateTark,TedadeRooz,tozih from person where codemeli = N'" + e.Row.Cells["کد ملی"].Value.ToString() + "'");
                txtDateTark.Text = dt.Rows[0][0].ToString();
                txtElateTark.Text = dt.Rows[0][1].ToString();
                txtTedadeRooz.Text = dt.Rows[0][2].ToString();
                txtTozihat.Text = dt.Rows[0][3].ToString();

            }
            catch { }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            try
            {
                DataManagement.I_U_D("UPDATE person SET DateShoroo = N'" + txtDateShoroo.Text + "',tozih = N'" + txtTozih.Text + "' WHERE (codemeli = N'" + dgvEstekhdam.CurrentRow.Cells["کد ملی"].Value.ToString() + "')");
                vshir_list_Load(null, null);
            }
            catch (Exception ex) { FMessegeBox.FarsiMessegeBox.Show(ex.Message); }
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                txtAddName.Text = ofd.FileName;
            }
        }

        private void btnSharayet_Click(object sender, EventArgs e)
        {
            try
            {
                DataManagement.I_U_D("UPDATE person SET daraje = N'" + txtSharayet.Text + "' WHERE (codemeli = N'" + dgvSabtenam.CurrentRow.Cells["کد ملی"].Value.ToString() + "')");
                vshir_list_Load(null, null);
            }
            catch (Exception ex) { FMessegeBox.FarsiMessegeBox.Show(ex.Message); }
        }

        private void btnEnserafi_Click(object sender, EventArgs e)
        {
            try
            {
                if (FMessegeBox.FarsiMessegeBox.Show("آیا برای انتقال انجام شود؟","سوال",FMessegeBox.FMessegeBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataManagement.I_U_D("UPDATE person SET vaziat = N'انصرافی' WHERE (codemeli = N'" + dgvSabtenam.CurrentRow.Cells["کد ملی"].Value.ToString() + "')");
                    vshir_list_Load(null, null);
                }
            }
            catch (Exception ex) { FMessegeBox.FarsiMessegeBox.Show(ex.Message); }
        }

        private void btnEntezar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FMessegeBox.FarsiMessegeBox.Show("آیا برای انتقال انجام شود؟","سوال",FMessegeBox.FMessegeBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataManagement.I_U_D("UPDATE person SET vaziat = N'در صف انتظار' WHERE (codemeli = N'" + dgvEnserafi.CurrentRow.Cells["کد ملی"].Value.ToString() + "')");
                    vshir_list_Load(null, null);
                }
            }
            catch (Exception ex) { FMessegeBox.FarsiMessegeBox.Show(ex.Message); }
        }

        private void dgvFiles_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (File.Exists(e.Row.Cells[2].Value.ToString()))
            {
                System.Diagnostics.Process.Start(e.Row.Cells[2].Value.ToString());
            }
            else
                FMessegeBox.FarsiMessegeBox.Show("فایل وجود ندارد");
        }

        private void btnCancelName_Click(object sender, EventArgs e)
        {
            txtOnvan.Text = txtAddName.Text = "";
            expandablePanel3.Expanded = false;
        }
    }
}
