using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo2.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        Context c = new Context();
        private readonly UserManager<AppUser> _userManager;

        public MessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> InBox()
        {
            var enteredUsers = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = mm.GetInboxListByWriter(enteredUsers.Id);
            return View(values);
           
        }
        public async Task<IActionResult> SendBox()
        {
            var enteredUsers = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = mm.GetSendBoxListByWriter(enteredUsers.Id);
            return View(values);

        }
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message2 p)
        {
            Context c = new Context(); 
            //var userName = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterId).FirstOrDefault();
            var enteredUsers = await _userManager.FindByNameAsync(User.Identity.Name);
            p.SenderId = enteredUsers.Id;
            p.ReceiverId = 3;
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(p);
            return RedirectToAction("InBox");
        }
    }
}
