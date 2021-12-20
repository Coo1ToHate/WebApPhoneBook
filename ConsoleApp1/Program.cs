using System;
using System.Collections.Generic;
using PhoneBook;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBookContext db = new PhoneBookContext();
            /*
            PhoneBook.PhoneBook book1 = new PhoneBook.PhoneBook("lname1", "fname1", "mname1", "+7999999999", "address1", "qweads");
            PhoneBook.PhoneBook book2 = new PhoneBook.PhoneBook("lname2", "fname2", "mname2", "+7999999999", "address2", "Asdaqwexz");

            var storagePhone = new List<PhoneBook.PhoneBook>() { book1, book2 };

            foreach (var item in storagePhone)
            {
                db.PhoneBooks.Add(item);
            }

            db.SaveChanges();*/
            /*
            PhoneBook.PhoneBook book = new PhoneBook.PhoneBook("lname3", "fname3", "mname3", "+7999999999", "address3", "dsgfdhdfhdfh");
            db.PhoneBooks.Add(book);
            db.SaveChanges();
            */
            var books = db.PhoneBooks;
            foreach (var b in books)
            {
                Console.WriteLine($"{b.Id} - {b.LastName} {b.FirstName} {b.MiddleName} - {b.NumberPhone} - {b.Address} - {b.Desc}");
            }
        }
    }
}
