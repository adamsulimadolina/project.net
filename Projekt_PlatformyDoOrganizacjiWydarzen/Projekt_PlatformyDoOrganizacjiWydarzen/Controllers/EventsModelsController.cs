using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_PlatformyDoOrganizacjiWydarzen.Models;
using Projekt_PlatformyDoOrganizacjiWydarzen.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Fonts;


namespace Projekt_PlatformyDoOrganizacjiWydarzen.Controllers
{
    public class EventsModelsController : Controller
    {
        private readonly EventsContext _context;
        

        public EventsModelsController(EventsContext context)
        {
            _context = context;
        }

        // GET: EventsModels
        public async Task<IActionResult> Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.userID = HttpContext.User.Identity.Name.ToString();
            }
            if (HttpContext.User.IsInRole("Admin"))
            {
                ViewBag.access = true;
            }
            return View(await _context.EventsModel.ToListAsync());
        }
        [HttpGet]
        public async Task<JsonResult> GetEvents()
        {
            return Json(await _context.EventsModel.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string placeString, string nameString, DateTime startdata, DateTime enddata)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.userID = HttpContext.User.Identity.Name.ToString();
            }
            if (HttpContext.User.IsInRole("Admin"))
            {
                ViewBag.access = true;
            }
            var events = from e in _context.EventsModel
                         select e;
            if (!String.IsNullOrEmpty(placeString))
            {
                events = events.Where(s => s.place.Contains(placeString));
            }
            if (!String.IsNullOrEmpty(nameString))
            {
                events = events.Where(s => s.name.Contains(nameString));
            }
            if (startdata.ToString("dd/MM/yyyy") != "01.01.2019" || enddata.ToString("dd/MM/yyyy") != "01.01.2019")
            {
                events = _context.EventsModel
                    .Where(e => e.hour >= startdata)
                    .Where(e => e.hour <= enddata);
            }
            return View(await events.ToListAsync());
        }

        // GET: EventsModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.userID = HttpContext.User.Identity.Name.ToString();
            }
            if (HttpContext.User.IsInRole("Admin"))
            {
                ViewBag.access = true;
            }
            if (id == null)
            {
                return NotFound();
            }

            var eventsModel = await _context.EventsModel
                .FirstOrDefaultAsync(m => m.id == id);
            ViewBag.detailsID = eventsModel.getUser();
            
            if (eventsModel == null)
            {
                return NotFound();
            }

            return View(eventsModel);
        }
       
        // GET: EventsModels/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,event_type,date,place,name,hour,tickets,tickets_per_person,organisator")] EventsModel eventsModel)
        {
            var userID = HttpContext.User.Identity.Name;
            eventsModel.organizer = userID;
            if (ModelState.IsValid)
            {
                _context.Add(eventsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventsModel);
        }

        // GET: EventsModels/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var eventsModel = await _context.EventsModel.FindAsync(id);
            if (eventsModel.getUser() != HttpContext.User.Identity.Name.ToString() && !HttpContext.User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Index));
            }
            if (eventsModel == null)
            {
                return NotFound();
            }
            return View(eventsModel);
        }

        // POST: EventsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,event_type,date,place,name,hour,tickets,tickets_per_person,organizer")] EventsModel eventsModel)
        {
            if (id != eventsModel.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsModelExists(eventsModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eventsModel);
        }

        // GET: EventsModels/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var eventsModel = await _context.EventsModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (eventsModel.getUser() != HttpContext.User.Identity.Name.ToString() && !HttpContext.User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Index));
            }
            if (eventsModel == null)
            {
                return NotFound();
            }

            return View(eventsModel);
        }
       

        // POST: EventsModels/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventsModel = await _context.EventsModel.FindAsync(id);
            _context.EventsModel.Remove(eventsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("DeletedEvent", "TicketsModels", new { eventid = id });
        }

        private bool EventsModelExists(int id)
        {
            return _context.EventsModel.Any(e => e.id == id);
        }

        [Authorize]
        public async Task<IActionResult> Join(int id)
        {
            var events = await _context.EventsModel.FindAsync(id);
            return RedirectToAction("Create", "TicketsModels",
               new
               {
                   event_id = events.id,
                   name = events.name,
                   place = events.place,
                   hour = events.hour,
                   event_type = events.event_type,
                   tickets_per_person = events.tickets_per_person
               });
        }

        public async Task<IActionResult> DeleteTickets(int id)
        {
            var eventsModel = await _context.EventsModel.FindAsync(id);
            eventsModel.tickets++;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsModelExists(eventsModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "TicketsModels");
            }
            return View(eventsModel);
        }

        public async Task<IActionResult> AddTickets(int id)
        {
            var eventsModel = await _context.EventsModel.FindAsync(id);
            eventsModel.tickets--;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsModelExists(eventsModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "TicketsModels");
            }
            return View(eventsModel);
        }
    }
}
/*
        [HttpGet]
        public FileStreamResult CreatePdf()
        {
            var data = new PdfDate
            {
               
                EventsModel xd = new List<EventsModel>
        {
         

        }
            };
            var path = _pdfService.CreatePdf(data);

            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/pdf");
        }


    }
}*/