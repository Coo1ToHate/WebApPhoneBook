using Microsoft.AspNetCore.Mvc;

namespace WebApPhoneBook.ViewComponent
{
    public class MenuTopViewViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
