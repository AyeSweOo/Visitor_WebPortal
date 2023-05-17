using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Visitor_WebPortal.Data;
using Visitor_WebPortal.Models;

namespace Visitor_WebPortal.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VisitorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Visitors
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Visitors.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        // GET: Visitors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // GET: Visitors/Create

        public IActionResult Create()
        {
            BindVisitType();
            return View();
        }
        public IActionResult Completed()
        {
           return View();
        }
        public void BindVisitType()
        {
            //List<VisitType> visitType = new List<VisitType>
            //         {
            //          new VisitType { VisitTypeName = "Social Visit",VisitTypeId = 1 },
            //          new VisitType { VisitTypeName = "Bussiness",VisitTypeId = 2 },
            //         };
            var visitType = from c in _context.VisitType
                             orderby c.VisitTypeName
                             select c;

           // ViewBag.industries = new SelectList(industries, "IndustryId", "IndustryName", null);
            ViewBag.VisitType = new SelectList(visitType, "VisitTypeId", "VisitTypeName", null);
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,VisitTypeId,IsForeigner,CompanyName,MobilePhone,Email,Designation,LicensePlate,NRIC,Quarantine,Symptoms,Contact_CovidCase,Acknowledge")] Visitor visitor)
        {
          
            if (ModelState.IsValid)
            {
                _context.Add(visitor);
                await _context.SaveChangesAsync();
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Completed));
                }
               
            }
            BindVisitType();
            return View(visitor);
        }

        // GET: Visitors/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }
            BindVisitType();
            return View(visitor);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,VisitTypeId,IsForeigner,CompanyName,MobilePhone,Email,Designation,LicensePlate,NRIC,Quarantine,Symptoms,Contact_CovidCase,Acknowledge")] Visitor visitor)
        {
            if (id != visitor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitorExists(visitor.Id))
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
            return View(visitor);
        }


        // GET: Visitors/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = await _context.Visitors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitor = await _context.Visitors.FindAsync(id);
            _context.Visitors.Remove(visitor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitorExists(int id)
        {
            return _context.Visitors.Any(e => e.Id == id);
        }
    }
}
