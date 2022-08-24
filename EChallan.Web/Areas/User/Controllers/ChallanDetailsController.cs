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
    [Area("User")]
    public class ChallanDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChallanDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/ChallanDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ChallanDetails.Include(c => c.ChallaNumberDetail).Include(c => c.Issue);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.ChallanDetails.Include(c => c.ChallaNumberDetail).Include(c => c.Issue);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: User/ChallanDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challanDetails = await _context.ChallanDetails
                .Include(c => c.ChallaNumberDetail)
                .Include(c => c.Issue)
                .FirstOrDefaultAsync(m => m.CDID == id);
            if (challanDetails == null)
            {
                return NotFound();
            }

            return View(challanDetails);
        }

        // GET: User/ChallanDetails/Create
        public IActionResult Create()
        {
            ViewData["CID"] = new SelectList(_context.ChallaNumberDetails, "CID", "ChallanNumber");
            ViewData["IID"] = new SelectList(_context.Issue, "IID", "IssueDescription");
            return View();
        }

        // POST: User/ChallanDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CDID,Price,Date,CID,IID")] ChallanDetails challanDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(challanDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CID"] = new SelectList(_context.ChallaNumberDetails, "CID", "ChallanNumber", challanDetails.CID);
            ViewData["IID"] = new SelectList(_context.Issue, "IID", "IssueDescription", challanDetails.IID);
            return View(challanDetails);
        }

        // GET: User/ChallanDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challanDetails = await _context.ChallanDetails.FindAsync(id);
            if (challanDetails == null)
            {
                return NotFound();
            }
            ViewData["CID"] = new SelectList(_context.ChallaNumberDetails, "CID", "ChallanNumber", challanDetails.CID);
            ViewData["IID"] = new SelectList(_context.Issue, "IID", "IssueDescription", challanDetails.IID);
            return View(challanDetails);
        }

        // POST: User/ChallanDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CDID,Price,Date,CID,IID")] ChallanDetails challanDetails)
        {
            if (id != challanDetails.CDID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(challanDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChallanDetailsExists(challanDetails.CDID))
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
            ViewData["CID"] = new SelectList(_context.ChallaNumberDetails, "CID", "ChallanNumber", challanDetails.CID);
            ViewData["IID"] = new SelectList(_context.Issue, "IID", "IssueDescription", challanDetails.IID);
            return View(challanDetails);
        }

        // GET: User/ChallanDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var challanDetails = await _context.ChallanDetails
                .Include(c => c.ChallaNumberDetail)
                .Include(c => c.Issue)
                .FirstOrDefaultAsync(m => m.CDID == id);
            if (challanDetails == null)
            {
                return NotFound();
            }

            return View(challanDetails);
        }

        // POST: User/ChallanDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var challanDetails = await _context.ChallanDetails.FindAsync(id);
            _context.ChallanDetails.Remove(challanDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChallanDetailsExists(int id)
        {
            return _context.ChallanDetails.Any(e => e.CDID == id);
        }
    }
}
