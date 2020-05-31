using System.Collections.Generic;
using System;

namespace IO.Swagger.DBModels
{
    public partial class Pet
    {
        public Pet()
        {
            PetTagMapping = new HashSet<PetTagMapping>();
            //Validate();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int? CategoryId { get; set; }
        public int? InvoiceId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual ICollection<PetTagMapping> PetTagMapping { get; set; }

        public void Validate()
        {
            if(this.Id < 0) 
            {
                throw new ArgumentException("Invalid pet ID or ID can't be negative.");
            }
            if(string.IsNullOrEmpty(this.Name))
            {
                throw new ArgumentException("Pet name can not be null or empty.");
            }
           
           if(!Enum.TryParse(this.Status.ToLower(), out PetStatus petStatus))
           {
                 throw new ArgumentException("Invalid pet status. Status should be one of Available, Sold or Pending.");
           }
            

            if(this.CategoryId < 0) 
            {
                throw new ArgumentException("Category ID can't be negative.");
            }
            
            if(this.InvoiceId < 0) 
            {
                throw new ArgumentException("Invoice ID can't be negative.");
            }
        } 
    }
}
