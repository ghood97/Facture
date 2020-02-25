using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Facture.Classes
{
    class InvoiceItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Item item { get; set; }
        public int Quantity { get; set; }
    }
}
