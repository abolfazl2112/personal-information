using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace personel
{
    class Picture
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

    class function
    {
        static public string Code = "", Name = "", UserType = "";
        static public bool aza, sazman, sabt, chap, week, date;
        public static bool IsActive = false;

        static public bool Is_In_month(string date, string month)
        {
            switch(month)
            {
                case "فروردین":  month = "01"; break;
                case "اردیبهشت": month = "02"; break;
                case "خرداد":    month = "03"; break;
                case "تیر":      month = "04"; break;
                case "مرداد":    month = "05"; break;
                case "شهریور":   month = "06"; break;
                case "مهر":      month = "07"; break;
                case "آبان":     month = "08"; break;
                case "آذر":      month = "09"; break;
                case "دی":       month = "10"; break;
                case "بهمن":     month = "11"; break;
                case "اسفند":    month = "12"; break;
                default: return false;
            }

            if (date.Substring(5, 2) == month) return true;

            return false;
        }

        static public string Get_month(int num)
        {
            switch (num)
            {
                case 1: return "فروردین";
                case 2: return "اردیبهشت";
                case 3: return "خرداد";
                case 4: return "تیر";
                case 5: return "مرداد";
                case 6: return "شهریور";
                case 7: return "مهر";
                case 8: return "آبان";
                case 9: return "آذر";
                case 10: return "دی";
                case 11: return "بهمن";
                case 12: return "اسفند";
                default: return "";
            }
        }

        public static string CheckCodeMeli(string CodeMeli)
        {
            try
            {
                char[] chArray = CodeMeli.ToCharArray();
                int[] numArray = new int[chArray.Length];
                if (chArray.Length < 10 || chArray.Length > 10)
                {
                    return ("لطفا یک عدد 10 رقمی وارد کنید");
                }
                for (int i = 0; i < chArray.Length; i++)
                {
                    numArray[i] = (int)char.GetNumericValue(chArray[i]);
                }
                int num2 = numArray[9];
                switch (CodeMeli)
                {
                    case "0000000000":
                    case "1111111111":
                    case "22222222222":
                    case "33333333333":
                    case "4444444444":
                    case "5555555555":
                    case "6666666666":
                    case "7777777777":
                    case "8888888888":
                    case "9999999999":
                        return ("کد ملی وارد شده صحیح نمی باشد");
                        break;
                }
                int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                int num4 = num3 - ((num3 / 11) * 11);
                if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))))
                {
                    return ("کد ملی صحیح می باشد");
                }
                else
                {
                    return ("کد ملی نامعتبر است");
                }
            }
            catch (Exception)
            {
                return ("لطفا یک عدد 10 رقمی وارد کنید");
            }
        }
    }
}
