using Microsoft.Practices.ServiceLocation;
using OrgPort.Domain.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrgPort.Controllers
{
    public class NewsController : AuthorizedController
    {

        public NewsController(IServiceLocator serviceLocator):base (serviceLocator)
        {

        }

        //
        // GET: /News/

        public ActionResult Index()
        {
            return View();
        }

        // GET: /News/List
        public ActionResult List()
        {
            var newsList = Using<GetNewsItemList>().Execute(20, 0);

            return View(newsList);
        }

        //
        // GET: /News/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /News/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /News/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /News/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /News/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /News/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /News/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
