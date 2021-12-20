using Microsoft.EntityFrameworkCore;

namespace PhoneBook
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<PhoneBook> PhoneBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MSSQLLocalPhoneBook;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneBook>().HasData(
                new PhoneBook[]
                {
                    new PhoneBook(1, "Иванов", "Петр", "Сергеевич", "8-999-999-99-99", "г. Москва, ул. Ленина, д. 256, кв. 5", "Лучший друг"),
                    new PhoneBook(2, "Петрова", "Мария", "Ивановна", "8-888-888-88-88", "г. Сочи, ул. Мичурина, д. 26, кв. 55", "Бабушка"),
                    new PhoneBook(3, "Сидоров", "Андрей", "Павлович", "8-777-777-77-77", "г. Новосибирск, ул. Ватутина, д. 50, кв. 33", "Познакомились в Анапе"),
                    new PhoneBook(4, "Смирнов", "Аркадий", "Владимирович", "8-666-666-66-66", "г. Томск, ул. Сибирская, д. 91, кв. 12", "Брат")
                });
        }
    }
}
