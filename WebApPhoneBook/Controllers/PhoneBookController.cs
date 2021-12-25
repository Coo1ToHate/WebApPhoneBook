using Microsoft.AspNetCore.Mvc;
using WebApPhoneBook.ContextFolder;
using WebApPhoneBook.Entitys;

namespace WebApPhoneBook.Controllers
{
    public class PhoneBookController : Controller
    {
        public IActionResult AllView()
        {
            ViewBag.PhoneBook = new DataContext().PhoneBooks;
            ViewBag.Title = "Телефонная книжка";
            return View();
        }

        public IActionResult Record(int? id)
        {
            if (id == null)
            {
                return Redirect("~/");
            }

            ViewBag.Title = $"Телефонная книжка - Запись №{id}";

            PhoneBook record = new DataContext().PhoneBooks.Find(id);
            if (record == null)
            {
                return Redirect("~/");
            }

            return View(record);
        }

        [HttpGet]
        public IActionResult Util(int? id)
        {
            if (id == null)
            {
                ViewBag.Title = "Добавить запись";
                return View();
            }

            PhoneBook record = new DataContext().PhoneBooks.Find(id);
            if (record == null)
            {
                return Redirect("~/");
            }

            ViewBag.Title = $"Телефонная книжка - Редактор записи №{id}";

            return View(record);
        }

        [HttpPost]
        public IActionResult AddRecord(string recordLastName, string recordFirstName, string recordMiddleName, string recordNumberPhone, string recordAddress, string recordDesc)
        {
            using (var db = new DataContext())
            {
                db.PhoneBooks.Add(
                    new PhoneBook()
                    {
                        LastName = recordLastName,
                        FirstName = recordFirstName,
                        MiddleName = recordMiddleName,
                        NumberPhone = recordNumberPhone,
                        Address = recordAddress,
                        Desc = recordDesc
                    });
                db.SaveChanges();
            }
            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult EditRecord(string recordLastName, string recordFirstName, string recordMiddleName, string recordNumberPhone, string recordAddress, string recordDesc, string recordId)
        {
            using (var db = new DataContext())
            {
                var tmp = db.PhoneBooks.Find(int.Parse(recordId));
                tmp.LastName = recordLastName;
                tmp.FirstName = recordFirstName;
                tmp.MiddleName = recordMiddleName;
                tmp.NumberPhone = recordNumberPhone;
                tmp.Address = recordAddress;
                tmp.Desc = recordDesc;
                db.SaveChanges();
            }

            return Redirect($"/PhoneBook/record?id={recordId}");
        }

        public IActionResult Del(int? id)
        {
            if (id == null)
            {
                return Redirect("~/");
            }

            PhoneBook record = new DataContext().PhoneBooks.Find(id);
            if (record == null)
            {
                return Redirect("~/");
            }

            ViewBag.Title = "Удаление записи";

            return View(record);
        }

        [HttpPost]
        public IActionResult Del(int id)
        {
            using (var db = new DataContext())
            {
                var tmp = db.PhoneBooks.Find(id);
                db.PhoneBooks.Remove(tmp);
                db.SaveChanges();
            }
            return Redirect("~/");
        }
    }
}
