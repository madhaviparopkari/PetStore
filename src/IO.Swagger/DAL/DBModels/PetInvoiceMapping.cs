using System;
using System.Collections.Generic;

namespace IO.Swagger.DBModels
{
    public partial class PetInvoiceMapping
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
