using System.Collections.Generic;
using System;
using IO.Swagger.DBModels;

namespace IO.Swagger.DAL
{

public partial class PetDal
    {
        private readonly PetstoreDBContext _context;

        public PetDal(PetstoreDBContext context)
        {
            _context = context;
        }

        public DBModels.Pet getPetById(int id)
        {
            DBModels.Pet pet = null; 
            return pet;
    
        }

        public void savePet(DBModels.Pet pet) 
        {
            _context.Pet.Add(pet);
            _context.SaveChanges();
        }
   }
}