using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo2.Controllers
{
    [AllowAnonymous]
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificaitonRepository());
        public IActionResult Index()
        {
            var values = nm.GetList();
            return View(values);
        }

        public IActionResult DeleteNotification(int id)
        {
            var values = nm.TGetByIdd(id);
            nm.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult NotificationDetails(int id)
        {
            var values = nm.TGetByIdd(id);
            return View(values);
        }
     

    }
}
