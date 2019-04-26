using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadJournal
{
    public class Dv  // удобно работать с месяцами
    {
        private int month;
        private int year;
        private int result;

        public Dv(int mn, int yr)
        {
            month = mn;
            year = yr;
            result = year * 12 + month;
        }
        public int DvResult()
        {
            return result;
        }
        public string DvStr()
        {
            return month.ToString("00") + "." + year.ToString("0000");
        }
    }
}
