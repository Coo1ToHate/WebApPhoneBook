using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApPhoneBook.ContextFolder;
using WebApPhoneBook.Entitys;

namespace WebApPhoneBook.IdentityApp
{
    public class DataInitalizer
    {
        public static async Task Initalize(DataContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if(context.PhoneBooks.Any()) return;

            var data = new List<PhoneBook>()
            {
                new PhoneBook(){ LastName = "Фамилия_1", FirstName = "Имя_1", MiddleName = "Отчество_1", NumberPhone = "8-999-999-99-99", Address = "Адрес_1", Desc = "Описание_1"},
                new PhoneBook(){ LastName = "Фамилия_2", FirstName = "Имя_2", MiddleName = "Отчество_2", NumberPhone = "8-999-999-99-99", Address = "Адрес_2", Desc = "Описание_2"}
            };

            
            foreach (var r in data)
            {
                await context.PhoneBooks.AddAsync(r);
            }
        }
    }
}
