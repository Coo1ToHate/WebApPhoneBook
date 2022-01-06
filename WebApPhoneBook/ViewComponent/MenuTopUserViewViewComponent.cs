using Microsoft.AspNetCore.Mvc;

namespace WebApPhoneBook.ViewComponent
{
    public class MenuTopUserViewViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
