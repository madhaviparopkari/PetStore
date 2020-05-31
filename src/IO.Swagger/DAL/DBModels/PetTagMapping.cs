using System;
using System.Collections.Generic;

namespace IO.Swagger.DBModels
{
    public partial class PetTagMapping
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int TagId { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
