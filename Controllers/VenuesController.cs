using AAS2237A1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AAS2237A1.Controllers
{
    public class VenuesController : Controller
    {
        private Manager manager = new Manager();

        // GET: Venues
        public ActionResult Index()
        {
            var venues = manager.VenueGetAll();
            return View(venues);
        }

        // GET: Venues/Details/5
        public ActionResult Details(int? id)
        {
            var venue = manager.VenueGetById(id.GetValueOrDefault());
            if (venue == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(venue);
            }
        }

        // GET: Venues/Create
        public ActionResult Create()
        {
            // Everything that we instantiate in the models, must be passed to the view as shown below.
            var model = new VenueAddViewModel();
            return View(model);
        }

        // POST: Venues/Create
        [HttpPost]
        public ActionResult Create(VenueAddViewModel newVenue)
        {
            if (!ModelState.IsValid)
            {
                return View(newVenue);
            }
            try
            {
                var addedItem = manager.VenueAdd(newVenue);
                if (addedItem == null)
                {
                    return View(newVenue);
                }
                else
                { 
                    return RedirectToAction("Details", new {id = addedItem.VenueId});
                }
            }
            catch
            {
                return View(newVenue);
            }
        }

        // GET: Venues/Edit/5
        public ActionResult Edit(int? id)
        {
            var venue = manager.VenueGetById(id.GetValueOrDefault());
            if(venue == null)
            {
                return HttpNotFound();
            }
            else
            {
                var formVenue = manager.mapper.Map<VenueBaseViewModel, VenueEditFormViewModel>(venue);
                return View(formVenue);
            }
            
        }

        // POST: Venues/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, VenueEditViewModel theVenue)
        {
            if (!ModelState.IsValid)
            {             
                return RedirectToAction("Edit", new { id = theVenue.VenueId});
            }
            if (id.GetValueOrDefault() != theVenue.VenueId)
            {             
                return RedirectToAction("Index");
            }
            var editedItem = manager.VenueEdit(theVenue);
            if (editedItem == null)
            {
                return RedirectToAction("Edit", new { id = theVenue.VenueId });
            }
            else
            {
                return RedirectToAction("Details", new { id = theVenue.VenueId });
            }
        }

        // GET: Venues/Delete/5
        public ActionResult Delete(int? id)
        {
            var itemToDelete = manager.VenueGetById(id.GetValueOrDefault());
            if (itemToDelete == null)
            {
                // Don't leak info about the delete attempt
                // Simply redirect
                return RedirectToAction("Index");
            }
            else
                return View(itemToDelete);
        }

        // POST: Venues/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = manager.VenueDelete(id.GetValueOrDefault());         
            return RedirectToAction("Index");
        }
    }
}
