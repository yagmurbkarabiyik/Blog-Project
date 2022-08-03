using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo2.ViewComponents.Writer
{
    public class WriterSidebarPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public WriterSidebarPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = value.NameSurname;
            ViewBag.image = value.ImageUrl;
            return View(value);
        }
    }
}
