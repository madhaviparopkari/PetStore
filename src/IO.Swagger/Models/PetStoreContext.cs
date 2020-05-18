using Microsoft.EntityFrameworkCore;

namespace IO.Swagger.Models
{
    public class PetStoreContext : DbContext
    {
        public PetStoreContext(DbContextOptions<PetStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pet { get; set; }
    }
}