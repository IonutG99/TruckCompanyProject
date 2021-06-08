using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckCompany.DataAccess;
using TruckCompany.Web.Models;

namespace TruckCompany.Web.Controllers
{
    public class RoutesController : Controller
    {
        private static TruckCompanyDBContext _dBContext;

        public RoutesController(TruckCompanyDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        // GET: RoutesController
        public ActionResult Index()
        {
            IEnumerable<DomainEntities.AssignRoute> data = _dBContext.AssignedRoutes;

            List<int> routeN = new List<int>();
            List<string> truckerN = new List<string>();
            List<string> locationN = new List<string>();
            List<string> statusN = new List<string>();
            foreach (var item in data)
             {
                 routeN.Add(item.RouteNumber);
                _dBContext = new TruckCompanyDBContext();
                var objT= _dBContext.Truckers.Single(a => a.Id == item.TruckerId);
                truckerN.Add(objT.FirstName+" "+objT.LastName);
                _dBContext = new TruckCompanyDBContext();
                 var objL = _dBContext.Locations.Single(a => a.Id == item.LocationId);
                locationN.Add(objL.Name);
                _dBContext = new TruckCompanyDBContext();
                var objS = _dBContext.Statuses.Single(a => a.Id == item.StatusId);
                statusN.Add(objS.Name);
            }
            RoutesRecords routesRecords = new RoutesRecords()
            {
                RouteNumbers = routeN,
                TruckerFirstName = truckerN,
                LocationName = locationN,
                StatusName = statusN
            };
            return View(routesRecords);
        }

        // GET: RoutesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoutesController/Create
        public ActionResult Create()
        {
            IEnumerable<DomainEntities.Trucker> truckers = _dBContext.Truckers;
            IEnumerable<DomainEntities.Status> statuses = _dBContext.Statuses;
            IEnumerable<DomainEntities.Location> locations = _dBContext.Locations;
            RoutesModel route=new RoutesModel();
            CreateModel createModel = new CreateModel
            {
                Route = route,
                Truckers = truckers,
                Locations = locations,
                Statuses = statuses
            };
            return View(createModel);
        }

        // POST: RoutesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DomainEntities.AssignRoute routes)
        {
            string val=Request.Form["TruckerId"];
            Guid tId = Guid.Parse(val);
            val = Request.Form["LocationId"];
            int lId = Int32.Parse(val);
            val = Request.Form["StatusId"];
            int sId = Int32.Parse(val);
            routes.TruckerId = tId;
            routes.LocationId = lId;
            routes.StatusId = sId;
           _dBContext.AssignedRoutes.Add(routes);
            //_dBContext.AssignedRoutes.AddAsync(routes);
            _dBContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: RoutesController/Edit/5
        public ActionResult Update(int routeNumber)
        {
            DomainEntities.AssignRoute obj = _dBContext.AssignedRoutes.Find(routeNumber);
            if (obj == null)
            {
                return NotFound();
            }
            IEnumerable<DomainEntities.Trucker> truckers = _dBContext.Truckers;
            IEnumerable<DomainEntities.Status> statuses = _dBContext.Statuses;
            IEnumerable<DomainEntities.Location> locations = _dBContext.Locations;
            CreateModel createModel = new CreateModel
            {
                Route = new RoutesModel(obj),
                Truckers = truckers,
                Locations = locations,
                Statuses=statuses
            };
            return View(createModel);
        }

        // POST: RoutesController/Edit/5
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

        // GET: RoutesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoutesController/Delete/5
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
