using System;
using System.Collections.Generic;

namespace IO.Swagger.DBModels
{
    public partial class Pet
    {
        public Pet()
        {
            PetTagMapping = new HashSet<PetTagMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int? CategoryId { get; set; }
        public int? InvoiceId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual ICollection<PetTagMapping> PetTagMapping { get; set; }
    }
}
