using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace personel
{
    public partial class F_AddEditPerson : Telerik.WinControls.UI.RadForm
    {
        string type = "new";
        Telerik.WinControls.UI.GridViewRowInfo DGVR;
        string codeOld= "";

        public F_AddEditPerson(string NewEditType, Telerik.WinControls.UI.GridViewRowInfo dgvr)
        {
            InitializeComponent();
            type = NewEditType;
            DGVR = dgvr;
        }

        private void F_AddEditPerson_Load(object sender, EventArgs e)
        {
            if (type == "edit")
            {
                txtmeli.Text = codeOld = DGVR.Cells["کد ملی"].Value.ToString();
                txtName.Text = DGVR.Cells[2].Value.ToString();
                txtfamily.Text = DGVR.Cells[3].Value.ToString();
                txtFather.Text = DGVR.Cells[4].Value.ToString();
                txtShshen.Text = DGVR.Cells[5].Value.ToString();
                txtTavalod.Text = DGVR.Cells[6].Value.ToString();
                txtesalat.Text = DGVR.Cells[7].Value.ToString();
                txtSokoonat.Text = DGVR.Cells[8].Value.ToString();
                txtTaahol.Text = DGVR.Cells[9].Value.ToString();
                txtOlad.Text = DGVR.Cells[10].Value.ToString();
                txtMadrak.Text = DGVR.Cells[11].Value.ToString();
                txtReshte.Text = DGVR.Cells[12].Value.ToString();
                txtSarbazi.Text = DGVR.Cells[13].Value.ToString();
                txtShoghl.Text = DGVR.Cells[14].Value.ToString();
                txtSabeghe.Text = DGVR.Cells[15].Value.ToString();
                txtBime.Text = DGVR.Cells[16].Value.ToString();
                txtTell.Text = DGVR.Cells[17].Value.ToString();
                txtMobile.Text = DGVR.Cells[18].Value.ToString();
                txtAddress.Text = DGVR.Cells[19].Value.ToString();
                txtName1.Text = DGVR.Cells[20].Value.ToString();
                txtNesbat1.Text = DGVR.Cells[21].Value.ToString();
                txtTell1.Text = DGVR.Cells[22].Value.ToString();
                txtMobile1.Text = DGVR.Cells[23].Value.ToString();
                txtName2.Text = DGVR.Cells[24].Value.ToString();
                txtNesbat2.Text = DGVR.Cells[25].Value.ToString();
                txtTell2.Text = DGVR.Cells[26].Value.ToString();
                txtMobile2.Text = DGVR.Cells[27].Value.ToString();
                txtShakhs.Text = DGVR.Cells[28].Value.ToString();
                txtDate.Text = DGVR.Cells[29].Value.ToString();
                txtEzharat.Text = DGVR.Cells[30].Value.ToString();
                txtTozih.Text = DGVR.Cells[31].Value.ToString();
                txtVaziat.Text = DGVR.Cells[32].Value.ToString();

                lblVaziat.Visible = true;
                txtVaziat.Visible = true;
            }
        }

        private void btnSabt_Click(object sender, EventArgs e)
        {
            string sql = "";
            try
            {
                if (type == "new")
                    sql = "INSERT INTO person(codemeli, name, family, fathername, shsh, tavalod, esalat, sokoonat, taahol, olad, madrak, reshte, sarbazi, shoghl, Sbime, ShBime, tell,mobile, address,name1, nesbat1, tell1, mob1, name2, nesbat2, tell2, mob2, shakhs, date, nazar, tozih, vaziat) " +
                         "VALUES(N'" + txtmeli.Text + "', N'" + txtName.Text + "', N'" + txtfamily.Text + "', N'" + txtFather.Text + "', N'" + txtShshen.Text + "', N'" + txtTavalod.Text + "', N'" + txtesalat.Text + "', N'" + txtSokoonat.Text + "', N'" + txtTaahol.Text + "', N'" + txtOlad.Text +
                         "', N'" + txtMadrak.Text + "', N'" + txtReshte.Text + "', N'" + txtSarbazi.Text + "', N'" + txtShoghl.Text + "', N'" + txtSabeghe.Text + "', N'" + txtBime.Text + "', N'" + txtTell.Text + "', N'" + txtMobile.Text + "', N'" + txtAddress.Text + "', N'" + txtName1.Text +
                         "', N'" + txtNesbat1.Text + "', N'" + txtTell1.Text + "', N'" + txtMobile1.Text + "', N'" + txtName2.Text + "', N'" + txtNesbat2.Text + "', N'" + txtTell2.Text + "', N'" + txtMobile2.Text +
                         "', N'" + txtShakhs.Text + "', N'" + txtDate.Text + "', N'" + txtEzharat.Text + "', N'" + txtTozih.Text + "', N'" + txtVaziat.Text + "')";
                else
                    sql = "UPDATE person SET codemeli = N'" + txtmeli.Text + "', name = N'" + txtName.Text + "', family = N'" + txtfamily.Text + "', fathername = N'" + txtFather.Text + "', shsh = N'" + txtShshen.Text + "', tavalod = N'" + txtTavalod.Text + "', esalat = N'" + txtesalat.Text + "', sokoonat = N'" + txtSokoonat.Text + "', taahol = N'" + txtTaahol.Text +
                        "', olad = N'" + txtOlad.Text + "', " + "madrak = N'" + txtMadrak.Text + "',reshte = N'" + txtReshte.Text + "', sarbazi = N'" + txtSarbazi.Text + "', shoghl = N'" + txtShoghl.Text + "', Sbime = N'" + txtSabeghe.Text + "', ShBime = N'" + txtBime.Text + "', tell = N'" + txtTell.Text + "',mobile = N'" + txtMobile.Text + "',address = N'" + txtAddress.Text +
                        "', shakhs = N'" + txtShakhs.Text + "', date = N'" + txtDate.Text + "', nazar = N'" + txtEzharat.Text + "', tozih = N'" + txtTozih.Text + "', vaziat = N'" + txtVaziat.Text + "',name1 = N'" + txtName1.Text + "', nesbat1 = N'" + txtNesbat1.Text + "', tell1 = N'" + txtTell1.Text + "', mob1 = N'" + txtMobile1.Text + "', name2 = N'" + txtName2.Text +
                        "', nesbat2 = N'" + txtNesbat2.Text + "', tell2 = N'" + txtTell2.Text + "', mob2 = N'" + txtMobile2.Text + "'  WHERE (codemeli = N'" + codeOld + "')";

                DataManagement.I_U_D(sql);
                FMessegeBox.FarsiMessegeBox.Show("اطلاعات فرد با موفقیت ثبت شد");

            }
            catch (Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show("خطا\n" + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtmeli_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtmeli.Text != "")
                {
                    string result = function.CheckCodeMeli(txtmeli.Text);
                    if (result == "کد ملی صحیح می باشد")
                    {
                        DataTable dt = DataManagement.Search("select codemeli from person where codemeli = N'" + txtmeli.Text + "'");
                        if (type == "new")
                            if (dt.Rows.Count > 0)
                            {
                                if (FMessegeBox.FarsiMessegeBox.Show("کد ملی وارد شده تکراری است\n آیا میخواهید اطلاعات فرد مورد نظر را مشاهده کنید؟", "سوال", FMessegeBox.FMessegeBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    type = "edit";
                                    txtmeli.Text = codeOld = dt.Rows[0][0].ToString();
                                    txtName.Text = dt.Rows[0][1].ToString();
                                    txtfamily.Text = dt.Rows[0][2].ToString();
                                    txtFather.Text = dt.Rows[0][3].ToString();
                                    txtShshen.Text = dt.Rows[0][4].ToString();
                                    txtTavalod.Text = dt.Rows[0][5].ToString();
                                    txtesalat.Text = dt.Rows[0][6].ToString();
                                    txtSokoonat.Text = dt.Rows[0][7].ToString();
                                    txtTaahol.Text = dt.Rows[0][8].ToString();
                                    txtOlad.Text = dt.Rows[0][9].ToString();
                                    txtMadrak.Text = dt.Rows[0][10].ToString();
                                    txtReshte.Text = dt.Rows[0][11].ToString();
                                    txtSarbazi.Text = dt.Rows[0][12].ToString();
                                    txtShoghl.Text = dt.Rows[0][13].ToString();
                                    txtSabeghe.Text = dt.Rows[0][14].ToString();
                                    txtBime.Text = dt.Rows[0][15].ToString();
                                    txtTell.Text = dt.Rows[0][16].ToString();
                                    txtName1.Text = dt.Rows[0][17].ToString();
                                    txtNesbat1.Text = dt.Rows[0][18].ToString();
                                    txtTell1.Text = dt.Rows[0][19].ToString();
                                    txtMobile1.Text = dt.Rows[0][20].ToString();
                                    txtMobile.Text = dt.Rows[0][21].ToString();
                                    txtName2.Text = dt.Rows[0][22].ToString();
                                    txtNesbat2.Text = dt.Rows[0][23].ToString();
                                    txtTell2.Text = dt.Rows[0][24].ToString();
                                    txtMobile2.Text = dt.Rows[0][25].ToString();
                                    txtAddress.Text = dt.Rows[0][26].ToString();
                                    txtShakhs.Text = dt.Rows[0][27].ToString();
                                    txtDate.Text = dt.Rows[0][28].ToString();
                                    txtEzharat.Text = dt.Rows[0][29].ToString();
                                    txtTozih.Text = dt.Rows[0][30].ToString();
                                    txtVaziat.Text = dt.Rows[0][31].ToString();
                                }
                            }
                    }
                    else
                        FMessegeBox.FarsiMessegeBox.Show(result);
                }
            }
            catch (Exception ex) { FMessegeBox.FarsiMessegeBox.Show(ex.Message); }
        }

        private void txtTaahol_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtMadrak_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtOlad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtSarbazi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtBime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                txtBime.Text = "";
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtTell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                txtTell.Text = "";
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                txtMobile.Text = "";
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtTell1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                txtTell1.Text = "";
            if (e.KeyChar >= '0' && e.KeyChar <= '9'|| e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtMobile1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                txtMobile1.Text = "";
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtTell2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                txtTell2.Text = "";
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtMobile2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                txtMobile2.Text = "";
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtmeli_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                txtmeli.Text = "";
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtShshen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                txtShshen.Text = "";
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }



    }
}
