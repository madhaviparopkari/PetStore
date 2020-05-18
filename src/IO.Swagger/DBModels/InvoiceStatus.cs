using System;
using System.Collections.Generic;

namespace IO.Swagger.DBModels
{
    public partial class InvoiceStatus
    {
        public InvoiceStatus()
        {
            Invoice = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
