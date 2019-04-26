using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadJournal
{
    public class Receipt  // Получение номеров
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Journal Journal { get; set; }
        public Client Client { get; set; }
        public bool Check { get; set; }  // номер получен (со стороны клиента)
    }
}
