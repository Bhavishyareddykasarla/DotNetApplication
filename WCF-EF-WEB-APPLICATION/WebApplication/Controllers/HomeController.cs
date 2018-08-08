using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{    
    public class HomeController : Controller
    {
        SoftwareServiceReference.Service1Client api = new SoftwareServiceReference.Service1Client();
        public ActionResult Index()
        {
            List<Software> lstRecord = new List<Software>();

            var lst = api.GetSoftwares();

            foreach (var item in lst)
            {
                Software software = new Software();
                software.Id = item.Id;
                software.Rank = item.Rank;
                software.Name = item.Name;
                software.Version = item.Version;
                software.Licencetype = item.LicenceType;
                lstRecord.Add(software);

            }


            return View(lstRecord);
        }

        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(Software mdl)
        {

            Software sofware = new Software();
            sofware.Name = mdl.Name;
            sofware.Version = mdl.Version;
            sofware.Rank = mdl.Rank;
            sofware.Licencetype = mdl.Licencetype;
            api.AddSoftware(sofware.Name, sofware.Version, sofware.Licencetype, sofware.Rank); ;
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Delete(int id)
        {
            int retval = api.DeleteSoftwareById(id);
            if (retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public ActionResult Details(int id)
        {
            var item = api.GetSoftwareById(id);
            Software software = new Software();
            software.Id = item.Id;
            software.Rank = item.Rank;
            software.Name = item.Name;
            software.Version = item.Version;
            software.Licencetype = item.LicenceType;
            return View(software);

        }

        public ActionResult Edit(int id)
        {
            var item = api.GetSoftwareById(id);
            Software software = new Software();
            software.Id = item.Id;
            software.Rank = item.Rank;
            software.Name = item.Name;
            software.Version = item.Version;
            software.Licencetype = item.LicenceType;
            return View(software);

        }
        [HttpPost]
        public ActionResult Edit(Software item)
        {
            Software software = new Software();
            software.Id = item.Id;
            software.Rank = item.Rank;
            software.Name = item.Name;
            software.Version = item.Version;
            software.Licencetype = item.Licencetype;


            int Retval = api.UpdateSoftware(software.Id, software.Name, software.Version, software.Licencetype, software.Rank);
            if (Retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}