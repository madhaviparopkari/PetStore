using System.Collections.Generic;
using System;
using IO.Swagger.DBModels;
using System.Linq;

namespace IO.Swagger.DAL
{

public partial class CategoryDal
    {
        private readonly PetstoreDBContext _context;

        public CategoryDal(PetstoreDBContext context)
        {
            _context = context;
        }

        public DBModels.Category getCategoryByName(string name)
        {
            DBModels.Category category = _context.Category.Single(c => c.Name == name);
             
            return category;
    
        }

        public void saveCategory(DBModels.Category category) 
        {
            _context.Category.Add(category);
            _context.SaveChanges();
        }
   }
}