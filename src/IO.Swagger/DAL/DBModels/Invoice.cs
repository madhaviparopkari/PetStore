using System;
using System.Collections.Generic;

namespace IO.Swagger.DBModels
{
    public partial class Invoice
    {
        public Invoice()
        {
            Pet = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int StatusId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ShippingAddress { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual InvoiceStatus Status { get; set; }
        public virtual ICollection<Pet> Pet { get; set; }
    }
}
