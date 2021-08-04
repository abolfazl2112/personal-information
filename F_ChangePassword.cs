using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace personel
{
    public partial class F_ChangePassword : Telerik.WinControls.UI.RadForm
    {
        public F_ChangePassword()
        {
            InitializeComponent();
        }

        private void F_ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassNew.Text == txtPassReNew.Text)
                {
                    int result = DataManagement.I_U_D("UPDATE login SET username = N'" + txtUserNew.Text + "', password = N'" + txtPassNew.Text + "' WHERE(username = N'" + txtUserNow.Text + "') AND (password = N'" + txtPassNow.Text + "')");
                    if (result > 0)
                        FMessegeBox.FarsiMessegeBox.Show("اطلاعات با موفقیت ثبت شد");
                    else
                        FMessegeBox.FarsiMessegeBox.Show("کاربری با این مشخصات وجود ندارد");
                }
                else
                    FMessegeBox.FarsiMessegeBox.Show("پسورد جدید با تکرار آن برابر نیست");
            }
            catch (Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show(ex.Message);
            }
        }
    }
}
