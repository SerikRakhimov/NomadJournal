using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadJournal
{
    public class Client
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Fio { get; set; }
        public string Email { get; set; }
        public int Period { get; set; }
        public int StartMn { get; set; }
        public int StartYr { get; set; }
        public int StartDv { get; set; }
        public int FinishDv { get; set; }
        public int Sum { get; set; }
        public bool Work { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
