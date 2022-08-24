using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EChallan.Web.Data;
using EChallan.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace EChallan.Web.Areas.User.Controllers
{
    [Authorize]
    [Authorize(Roles = "AppAdmin")]
    [Area("User")]
    public class ChallaNumberDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChallaNumberDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/ChallaNumberDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChallaNumberDetails.ToListAsync());
        }

        // GET: User/ChallaNumberDetails -- for user
        public async Task<IActionResult> Index1()
        {
            return View(await _context.ChallaNumberDetails.ToListAsync());
        }

        // GET: User/ChallaNumberDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challaNumberDetail = await _context.ChallaNumberDetails
                .FirstOrDefaultAsync(m => m.CID == id);
            if (challaNumberDetail == null)
            {
                return NotFound();
            }

            return View(challaNumberDetail);
        }

        [Authorize(Roles = "Appuser")]
        // GET: User/ChallaNumberDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/ChallaNumberDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CID,ChallanNumber,VehicalNumber")] ChallaNumberDetail challaNumberDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(challaNumberDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(challaNumberDetail);
        }

        // GET: User/ChallaNumberDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challaNumberDetail = await _context.ChallaNumberDetails.FindAsync(id);
            if (challaNumberDetail == null)
            {
                return NotFound();
            }
            return View(challaNumberDetail);
        }

        // POST: User/ChallaNumberDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CID,ChallanNumber,VehicalNumber")] ChallaNumberDetail challaNumberDetail)
        {
            if (id != challaNumberDetail.CID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(challaNumberDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChallaNumberDetailExists(challaNumberDetail.CID))
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
            return View(challaNumberDetail);
        }

        // GET: User/ChallaNumberDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challaNumberDetail = await _context.ChallaNumberDetails
                .FirstOrDefaultAsync(m => m.CID == id);
            if (challaNumberDetail == null)
            {
                return NotFound();
            }

            return View(challaNumberDetail);
        }

        // POST: User/ChallaNumberDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var challaNumberDetail = await _context.ChallaNumberDetails.FindAsync(id);
            _context.ChallaNumberDetails.Remove(challaNumberDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChallaNumberDetailExists(int id)
        {
            return _context.ChallaNumberDetails.Any(e => e.CID == id);
        }
    }
}
