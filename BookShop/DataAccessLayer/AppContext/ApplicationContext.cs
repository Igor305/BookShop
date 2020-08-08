using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.AppContext
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<PrintingEdition> PrintingEditions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // => optionsBuilder.UseSqlite("Data Source=blogging.db");
        }

    }


}
