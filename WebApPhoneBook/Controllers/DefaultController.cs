using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using PhoneBook;

namespace WebApPhoneBook.Controllers
{
    public class DefaultController : Controller
    {
        private List<PhoneBook.PhoneBook> books;

        public DefaultController()
        {
            PhoneBookContext db = new PhoneBookContext();
            var dbBooks = db.PhoneBooks;
            books = dbBooks.ToList();
        }

        public IActionResult Index()
        {
            return View(books);
        }

        public IActionResult Record(int id)
        {
            id--;
            if (id < 0 || id > books.Count - 1)
            {
                return View();
            }
            return View(books[id]);
        }
    }
}
