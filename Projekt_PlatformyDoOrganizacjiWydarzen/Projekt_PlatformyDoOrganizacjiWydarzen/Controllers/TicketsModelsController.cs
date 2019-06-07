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
using Syncfusion.HtmlConverter;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Syncfusion.Pdf;
using System.IO;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Syncfusion.Pdf.Grid;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Syncfusion.Pdf.Barcode;

namespace Projekt_PlatformyDoOrganizacjiWydarzen.Controllers
{
    public class TicketsModelsController : Controller
    {
        private readonly TicketsContext _context;

        public TicketsModelsController(TicketsContext context)
        {
            _context = context;
        }

        // GET: TicketsModels
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var tickets = from t in _context.TicketsModel
                          select t;
            if (!HttpContext.User.IsInRole("Admin"))
            {
                tickets = tickets.Where(t => t.user_mail.Contains(HttpContext.User.Identity.Name.ToString()));
            }
            return View(await tickets.ToListAsync());
        }
        
        [HttpPost]
        public  ActionResult SendEmail(int id,string topic,string message)
        {
            string organizer="Message from event: organizer";
            var users = _context.TicketsModel.Where(u => u.event_id.Equals(id));
            
            message = organizer + Environment.NewLine + message; 
                try
                { 
                foreach(var user in users) { 
                        var mimeMessage = new MimeMessage();
                        mimeMessage.From.Add(new MailboxAddress("PentoKieubasy", "projektplatforma@wp.pl"));
                        mimeMessage.To.Add(new MailboxAddress(user.user_mail));
                        mimeMessage.Subject = topic;
                       mimeMessage.Body = new TextPart("html")
                        {
                            Text = message
                        };
                        using (var client = new SmtpClient())
                        {
                            client.Connect("smtp.wp.pl", 465, true);
                            client.Authenticate("projektplatforma@wp.pl", "projektplatforma");


                            client.Send(mimeMessage);

                            client.Disconnect(true);
                        }
                }
            }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Wystąpił błąd przy wysyłaniu e-mail: {ex.Message}";
                }
            
           return RedirectToAction("Details","EventsModels",new { id = id });
        }
        // GET: TicketsModels/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketsModel = await _context.TicketsModel
                .FirstOrDefaultAsync(m => m.id == id);
            ViewBag.details_NIP = ticketsModel.NIP;
            if (ticketsModel.getUser() != HttpContext.User.Identity.Name.ToString() && !HttpContext.User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Index));
            }
            if (ticketsModel == null)
            {
                return NotFound();
            }

            return View(ticketsModel);
        }
       
        // GET: TicketsModels/Create
        [Authorize]
        public IActionResult Create(TicketsModel ticketsModel)
        {
            ViewBag.type = ticketsModel.event_type;
            ticketsModel.user_mail = HttpContext.User.Identity.Name.ToString();
            if(TicketsModel.CheckPresonTickets(_context, ticketsModel)) return View(ticketsModel);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(int tmp, [Bind("id, event_id, name, place, hour, user_mail, user_name, user_surname, event_type, NIP, tickets_per_person")] TicketsModel ticketsModel)
        {
            ViewBag.type = ticketsModel.event_type;
            ticketsModel.user_mail = HttpContext.User.Identity.Name.ToString();
            if (ModelState.IsValid)
            {
                _context.Add(ticketsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("AddTickets", "EventsModels", new { id = ticketsModel.event_id });
            }
            return View(ticketsModel);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketsModel = await _context.TicketsModel
                .FirstOrDefaultAsync(m => m.id == id);
            if (ticketsModel.getUser() != HttpContext.User.Identity.Name.ToString() && !HttpContext.User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(Index));
            }
            if (ticketsModel == null)
            {
                return NotFound();
            }

            return View(ticketsModel);
        }


        public async Task<IActionResult> TicketToPdf(int? id)

        // public IActionResult DetailsToPdf(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var ticketsModelx = await _context.TicketsModel
                .FirstOrDefaultAsync(m => m.id == id);
            ViewBag.details_NIP = ticketsModelx.NIP;
            if (ticketsModelx.getUser() != HttpContext.User.Identity.Name.ToString())
            {
                return RedirectToAction(nameof(Index));
            }
            if (ticketsModelx == null)
            {
                return NotFound();
            }
            /*
           // return View(ticketsModel);
            //View(ticketsModel);
            
            HtmlToPdfConverter convert = new HtmlToPdfConverter();

            WebKitConverterSettings settings = new WebKitConverterSettings();
            settings.WebKitPath = Path.Combine("QtBinariesWindows");
            convert.ConverterSettings = settings;
            Syncfusion.Pdf.PdfDocument document= convert.Convert("https://localhost:44366/EventsModels/TicketToPdf/30");
            PdfPage page = document.Pages.Add();
            MemoryStream ms = new MemoryStream();

            document.Save(ms);
            document.Close(true);

            ms.Position = 0;

            FileStreamResult fileStreamResult = new FileStreamResult(ms, "application/pdf");
            fileStreamResult.FileDownloadName = "test.pdf";

            return fileStreamResult;
            */


            //Create a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            //Add values to list
            List<Object> data = new List<Object>();
            Object row1 = new { x = "email", y = ticketsModelx.getUser() };
            Object row2 = new { x = "imie", y = ticketsModelx.user_name.ToString() };
            Object row3 = new { x = "nazwisko", y = ticketsModelx.user_surname };
            Object row4 = new { x = "Data i godzina", y = ticketsModelx.hour };
            Object row5 = new { x = "Nazwa wydarzenia", y = ticketsModelx.name };
            Object row6 = new { x = "Miejsce wydarzenia", y = ticketsModelx.place };
            data.Add(row6);
            data.Add(row5);
            data.Add(row4);
            data.Add(row2);
            data.Add(row3);
            data.Add(row1);
            //Add list to IEnumerable
            IEnumerable<Object> dataTable = data;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(20, 20));

            
            PdfQRBarcode barcode = new PdfQRBarcode();

            //PdfPage page = doc.Pages.Add();
            //Setting location of the barcode 
            barcode.ErrorCorrectionLevel = PdfErrorCorrectionLevel.High;


            barcode.XDimension = 3;


            barcode.Location = new Syncfusion.Drawing.PointF(200, 200);

            //Setting size of the barcode

            barcode.Size = new Syncfusion.Drawing.SizeF(200, 100);

            barcode.Text = "https://localhost:44366/AP/Werify/"+ticketsModelx.event_id+"/"+ticketsModelx.id;

            //Printing barcode on to the Pdf. 

            barcode.Draw(page);

            //Save and close the Document

            //doc.Save("CODABAR.pdf");

            //doc.Close(true);



            //Save the PDF document to stream
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);
            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";
            //Define the file name.
            string fileName = "Output.pdf";
            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return File(stream, contentType, fileName);
        }


        // POST: TicketsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketsModel = await _context.TicketsModel.FindAsync(id);
            _context.TicketsModel.Remove(ticketsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("DeleteTickets", "EventsModels", new { id = ticketsModel.event_id });
        }

        private bool TicketsModelExists(int id)
        {
            return _context.TicketsModel.Any(e => e.id == id);
        }

        public IActionResult DeletedEvent(int eventid)
        {
            _context.TicketsModel.Where(p => p.event_id == eventid)
                .ToList().ForEach(p => _context.TicketsModel.Remove(p));
            _context.SaveChanges();
            return RedirectToAction("Index", "EventsModels");
        }
    }
}
