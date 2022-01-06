using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApPhoneBook.ContextFolder;
using WebApPhoneBook.Entitys;

namespace WebApPhoneBook.Controllers
{
    public class PhoneBookController : Controller
    {

        private readonly DataContext _context;

        public PhoneBookController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.PhoneBook = _context.PhoneBooks;
            return View();
        }

        public async Task<IActionResult> Record(int? id)
        {
            if (id == null)
            {
                return Redirect("~/");
            }

            PhoneBook record = await _context.PhoneBooks.FindAsync(id);
            if (record == null)
            {
                return Redirect("~/");
            }

            return View(record);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add(int? id)
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddRecord(string recordLastName, string recordFirstName, string recordMiddleName, string recordNumberPhone, string recordAddress, string recordDesc)
        {
            _context.Add(new PhoneBook()
            {
                LastName = recordLastName,
                FirstName = recordFirstName,
                MiddleName = recordMiddleName,
                NumberPhone = recordNumberPhone,
                Address = recordAddress,
                Desc = recordDesc
            });
            await _context.SaveChangesAsync();
            return Redirect("~/");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int? id)
        {
            PhoneBook record = _context.PhoneBooks.Find(id);
            if (record == null)
            {
                return Redirect("~/");
            }

            return View(record);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditRecord(string recordLastName, string recordFirstName, string recordMiddleName, string recordNumberPhone, string recordAddress, string recordDesc, string recordId)
        {
            var tmp = _context.PhoneBooks.FirstOrDefault(r => r.Id == int.Parse(recordId));
            tmp.LastName = recordLastName;
            tmp.FirstName = recordFirstName;
            tmp.MiddleName = recordMiddleName;
            tmp.NumberPhone = recordNumberPhone;
            tmp.Address = recordAddress;
            tmp.Desc = recordDesc;
            _context.Update(tmp);
            await _context.SaveChangesAsync();

            return Redirect($"/PhoneBook/record?id={recordId}");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Del(int? id)
        {
            if (id == null)
            {
                return Redirect("~/");
            }

            PhoneBook record = _context.PhoneBooks.Find(id);
            if (record == null)
            {
                return Redirect("~/");
            }

            return View(record);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Del(int id)
        {
            PhoneBook recorDel = new PhoneBook() { Id = id };
            _context.Entry(recorDel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();

            return Redirect("~/");
        }
    }
}
