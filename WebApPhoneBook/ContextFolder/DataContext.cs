using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApPhoneBook.Entitys;

namespace WebApPhoneBook.ContextFolder
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<PhoneBook> PhoneBooks { get; set; }
    }
}
