using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckCompany.Web.Models;

namespace TruckCompany.Web.Controllers
{
    public class TruckerController : Controller 
    {
        private readonly TruckCompanyDBContext _dBContext;
        public TruckerController(TruckCompanyDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        // GET: TruckerController
        public ActionResult Index()
        {
            IEnumerable<DomainEntities.Trucker> data = _dBContext.Truckers;
            return View(data.Select(x => new Trucker
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName=x.LastName,
                PhoneNumber=x.PhoneNumber
            }
            )) ;
        }

        // GET: TruckerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TruckerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TruckerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TruckerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TruckerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TruckerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TruckerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
