using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using Stimulsoft.Report;
namespace personel
{
    class network
    {

        public static bool CheckConection()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }
    }

    class DataManagement
    {
        public static SqlConnection SCO = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\DB\\DB.mdf;Integrated Security=True;User Instance=True");
        public static SqlCommand SCM = new SqlCommand();
        public static SqlDataAdapter SDA = new SqlDataAdapter();
        public static SqlCommandBuilder SCB = new SqlCommandBuilder();
        public static DataTable DT = new DataTable();
        //****************************************************************************************************
        //public static int API3000 = 10;
        //public static int API5000 = 21;
        //public static servisesms.Send ws = new servisesms.Send();
        //public static int API = 10;
        public static DevComponents.DotNetBar.Controls.TextBoxX mobiles = null;
        public static string sms = "";
        public static string shomare = "50001333222717";
        public static string Username = "9155335725";
        public static string Password = "5725";
        public static string lang = "فارسی";
        public static string smsCounter = "1";
        public static bool IsFast = true;


        //MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
        public static DataTable Search(string CTS)
        {
            try
            {

                if (SCO.State != ConnectionState.Open) SCO.Open();

            }
            catch
            {
                FMessegeBox.FarsiMessegeBox.Show("مشکل در باز کردن پایگاه داده","خطا");
                return null;
            }

            try
            {
                DT = new DataTable();
                SCM = new SqlCommand(CTS, SCO);
                SDA = new SqlDataAdapter(SCM);
                SCB = new SqlCommandBuilder(SDA);
                SDA.Fill(DT);
            }
            catch(Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show("مشکل در خواندن اطلاعات پایگاه داده\n" + ex.Message, "خطا");
            }
            return (DT);
        }

        public static int I_U_D(string SQL)
        {
            try
            {
                if (SCO.State != ConnectionState.Open) SCO.Open();
            }
            catch(Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show("مشکل در باز کردن پایگاه داده\n" + ex.Message, "خطا");
            }
            int result = 0;
            try
            {

                SCM.CommandText = SQL;
                result = SCM.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                FMessegeBox.FarsiMessegeBox.Show("مشکل در بروزرسانی اطلاعات پایگاه داده\n" + ex.Message, "خطا");
            }
            return (result);
        }
    }
    class Data
    {
        public static string saveFile(StiReport sti, string Subject, string Name, string txtDate)
        {
            if (!System.IO.Directory.Exists(Application.StartupPath + "\\نامه های اداری" + "\\" + Subject))
                System.IO.Directory.CreateDirectory(Application.StartupPath + "\\نامه های اداری" + "\\" + Subject);

            string fname = Application.StartupPath + "\\نامه های اداری" + "\\" + Subject + "\\" + Name + " " + txtDate.Replace('/','-');;
            for (int i = 0; System.IO.File.Exists(Application.StartupPath + "\\نامه های اداری" + "\\" + Subject + "\\" + Name + "#" + txtDate.Replace('/','-')); i++)
                fname = Application.StartupPath + "\\نامه های اداری" + "\\" + Subject + "\\" + Name + " " + txtDate.Replace('/','-') + "-" + i;

            sti.ExportDocument(StiExportFormat.Pdf, fname + ".pdf");
            return fname + ".docx";
        }

        public static string Pdate()
        {
            string st = "";
            PersianCalendar pc = new PersianCalendar();
            int day, m, y;
            string year = pc.GetYear(DateTime.Now).ToString();
            y = int.Parse(year.Substring(2,2));
            m = pc.GetMonth(DateTime.Now);
            day = pc.GetDayOfMonth(DateTime.Now);
            st = y.ToString() + ((m < 10) ? "0" + m.ToString() : m.ToString()) + ((day < 10) ? "0" + day.ToString() : day.ToString());
            return st;
        }

        public static string English()
        {
            string S;
            DateTime Mdate = DateTime.Now;
            S = Mdate.Day.ToString() + " / " + Mdate.Month.ToString() + " / " + Mdate.Year.ToString() + " : " + Mdate.DayOfWeek;
            return (S);
        }
    }
    class Languge_Keybord
    {
        public static void Persian()
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("fa-ir"));
        }
        public static void English()
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
        }
    }

    class Pictures
    {
        public static string Location = "";
        public static int Pic(Form form)
        {
            OpenFileDialog ODI = new OpenFileDialog();
            ODI.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            ODI.Filter = "Picture As jpg|*.jpg|Picture As jpeg|*.jpeg*|Picture As bmp|*.bmp|Picture As gif|*.gif|Picture As wmf|*.wmf|Picture As png|*.png";
            if (ODI.ShowDialog(form) == DialogResult.OK)
                Location = ODI.FileName.ToString();
            return (0);
        }
    }
}
