using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Controllers
{
    public class DefaultController : Controller
    {
        ImageCategoryManager imageCategoryManager = new ImageCategoryManager(new EfImageCategoryDal());
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        ServiceManager serviceManager = new ServiceManager(new EfServiceDal());
        PersonalManager personalManager = new PersonalManager(new EfPersonalDal());
        ContactManager contactManager = new ContactManager(new EfContactDal());

        [HttpGet]
        public IActionResult Index()
        {
            var imageCategoryList = imageCategoryManager.TGetList();
            return View(imageCategoryList);
        }

        public IActionResult Images(int id)
        {
            using Context context = new Context();
            var imageList = context.Images.Include(x => x.ImageCategory).Where(x => x.ImageCategoryID == x.ImageCategory.ImageCategoryID).ToList();
            ViewBag.İmageCategory = context.ImageCategories.Where(x => x.ImageCategoryID == id).Select(x => x.Title).FirstOrDefault();
            return View(imageList);
        }

        public IActionResult About()
        {
            var about = aboutManager.TGetList();
            return View(about);
        }

        public IActionResult Services()
        {
            var services = serviceManager.TGetList();
            return View(services);
        }
        public IActionResult Personals()
        {
            var personal = personalManager.TGetList();
            return View(personal);
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Contact contact)
        {
            contactManager.TAdd(contact);
            return RedirectToAction("Contact");
        }
    }
}
