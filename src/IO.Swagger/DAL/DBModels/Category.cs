using System;
using System.Collections.Generic;

namespace IO.Swagger.DBModels
{
    public partial class Category
    {
        public Category()
        {
            Pet = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Pet> Pet { get; set; }
    }
}
