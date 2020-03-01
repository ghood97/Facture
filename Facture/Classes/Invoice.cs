using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Facture.Classes
{
    public class Invoice
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string BillTo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<InvoiceItem> InvoiceItems { get; set; }

        public override string ToString()
        {
            return $"{BillTo} - {Address} - {City}, {State} - {Phone}";
        }
    }
}
