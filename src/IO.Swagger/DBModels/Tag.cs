using System;
using System.Collections.Generic;

namespace IO.Swagger.DBModels
{
    public partial class Tag
    {
        public Tag()
        {
            PetTagMapping = new HashSet<PetTagMapping>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PetTagMapping> PetTagMapping { get; set; }
    }
}
