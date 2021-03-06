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
            List<RouteView> views = new List<RouteView>();
            foreach (var item in data)
             {
                _dBContext = new TruckCompanyDBContext();
                var objT= _dBContext.Truckers.Single(a => a.Id == item.TruckerId);
                _dBContext = new TruckCompanyDBContext();
                 var objL = _dBContext.Locations.Single(a => a.Id == item.LocationId);
                _dBContext = new TruckCompanyDBContext();
                var objS = _dBContext.Statuses.Single(a => a.Id == item.StatusId);
                RouteView routeView = new RouteView(item.RouteNumber, objT.FirstName + " " + objT.LastName, objL.Name, objS.Name);
                views.Add(routeView);
            }

            return View(views);
        }

        // GET: RoutesController/Details/5
        public ActionResult Details(int id)
        {
            DomainEntities.AssignRoute obj = _dBContext.AssignedRoutes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _dBContext = new TruckCompanyDBContext();
            var objT = _dBContext.Truckers.Single(a => a.Id == obj.TruckerId);
            _dBContext = new TruckCompanyDBContext();
            var objL = _dBContext.Locations.Single(a => a.Id == obj.LocationId);
            _dBContext = new TruckCompanyDBContext();
            var objS = _dBContext.Statuses.Single(a => a.Id == obj.StatusId);
            return View(new RouteView(id, objT.FirstName + " " + objT.LastName, objL.Name, objS.Name));
        }

        // GET: RoutesController/Create
        public ActionResult Create()
        {
            IEnumerable<DomainEntities.Trucker> truckers = _dBContext.Truckers;
            IEnumerable<DomainEntities.Status> statuses = _dBContext.Statuses;
            IEnumerable<DomainEntities.Location> locations = _dBContext.Locations;
            RouteModel route=new RouteModel();
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
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DomainEntities.AssignRoute obj = _dBContext.AssignedRoutes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            IEnumerable<DomainEntities.Trucker> truckers = _dBContext.Truckers;
            IEnumerable<DomainEntities.Status> statuses = _dBContext.Statuses;
            IEnumerable<DomainEntities.Location> locations = _dBContext.Locations;
            CreateModel createModel = new CreateModel
            {
                Route = new RouteModel(obj),
                Truckers = truckers,
                Locations = locations,
                Statuses = statuses
            };
            return View(createModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id)
        {
           
            string val = Request.Form["TruckerId"];
            Guid tId = Guid.Parse(val);
            val = Request.Form["LocationId"];
            int lId = Int32.Parse(val);
            val = Request.Form["StatusId"];
            int sId = Int32.Parse(val);
            DomainEntities.AssignRoute routes = new DomainEntities.AssignRoute
            {
                RouteNumber=id,
                TruckerId=tId,
                LocationId=lId,
                StatusId=sId
            };
            _dBContext.AssignedRoutes.Update(routes);
            _dBContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: RoutesController/Delete/5
        public ActionResult Delete(int id)
        {
            DomainEntities.AssignRoute obj = _dBContext.AssignedRoutes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _dBContext = new TruckCompanyDBContext();
            var objT = _dBContext.Truckers.Single(a => a.Id == obj.TruckerId);
            _dBContext = new TruckCompanyDBContext();
            var objL = _dBContext.Locations.Single(a => a.Id == obj.LocationId);
            _dBContext = new TruckCompanyDBContext();
            var objS = _dBContext.Statuses.Single(a => a.Id == obj.StatusId);
            return View(new RouteView(id,objT.FirstName+" "+objT.LastName,objL.Name,objS.Name));
        }

        // POST: TruckerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int? id)
        {
            string s = Request.Form["DeleteId"];
            id = Int32.Parse(s);
            if (id == null)
                return NotFound();
            DomainEntities.AssignRoute route = _dBContext.AssignedRoutes.Find(id);
            if (route == null)
            {
                return NotFound();
            }
            _dBContext.AssignedRoutes.Remove(route);
            _dBContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
