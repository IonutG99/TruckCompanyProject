using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckCompany.Web.Models;
using TruckCompany.DataAccess;

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
            return View(data.Select(x => new TruckerModel(x))) ;
        }

        // GET: TruckerController/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DomainEntities.Trucker obj = _dBContext.Truckers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(new TruckerModel(obj));
        }

        // GET: TruckerController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: TruckerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DomainEntities.Trucker obj)
        {
            _dBContext.Truckers.Add(obj);
            _dBContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TruckerController/Edit/5
        public ActionResult Update(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DomainEntities.Trucker obj = _dBContext.Truckers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(new TruckerModel(obj));
        }

        // POST: TruckerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(DomainEntities.Trucker obj)
        {
            _dBContext.Truckers.Update(obj);
            _dBContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TruckerController/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DomainEntities.Trucker obj = _dBContext.Truckers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(new TruckerModel(obj));
        }

        // POST: TruckerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(Guid? id)
        {
            DomainEntities.Trucker obj = _dBContext.Truckers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _dBContext.Truckers.Remove(obj);
            _dBContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
