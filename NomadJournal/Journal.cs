using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadJournal
{
    public class Journal
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Dv { get; set; }
        public string Theme { get; set; }
        public bool Send { get; set; }  // признак отправки
        public string SendCompany { get; set; }  // компания - доставщик
    }
}
