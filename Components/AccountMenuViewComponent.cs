using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Tuskla.Components
{
    public class AccountMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
