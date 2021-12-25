using Microsoft.EntityFrameworkCore;
using WebApPhoneBook.Entitys;

namespace WebApPhoneBook.ContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<PhoneBook> PhoneBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MSSQLLocalPhoneBook;Trusted_Connection=True;");
        }
    }
}
