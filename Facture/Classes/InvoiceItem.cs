using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Facture.Classes
{
    public class InvoiceItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof (Item))]
        public int ItemId { get; set; }

        public int Quantity { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Item Item { get; set; }

        public override string ToString()
        {
            return $"InvoiceID: {Id} Quantity: {Quantity}";
        }

        public decimal Total
        {
            get
            {
                return Item.Price * Quantity;
            }
        }

    }
}
