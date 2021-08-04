using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;

namespace personel
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void about_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Close();
        }

        private void about_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void about_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
