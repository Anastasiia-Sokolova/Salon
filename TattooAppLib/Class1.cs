using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TattooAppLib
{
    public class authCheking
    {
        public string emptyornot(string x, string y)
        {
            string s = "";
            string a = x;
            string b = y;
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
            {
                s = "Submit all fields please";
            }
            return s;
        }

        public string createPersonalNumber(string surname, int year)
        {
            string result = "00";
            result += year;
            result += surname.Substring(0, 1);

            DateTime thisDay = DateTime.Today;
            result += thisDay.Day.ToString() + thisDay.Month.ToString() + thisDay.Year.ToString();

            return result;
        }
    };


}
