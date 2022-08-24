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
    public class PaymentMethodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentMethodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/PaymentMethods
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PaymentMethod.Include(p => p.ChallanDetails);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: User/PaymentMethods
        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.PaymentMethod.Include(p => p.ChallanDetails);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: User/PaymentMethods
        public async Task<IActionResult> Index2()
        {
            var applicationDbContext = _context.PaymentMethod.Include(p => p.ChallanDetails);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: User/PaymentMethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _context.PaymentMethod
                .Include(p => p.ChallanDetails)
                .FirstOrDefaultAsync(m => m.PaymentMethodId == id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return View(paymentMethod);
        }

        // GET: User/PaymentMethods/Create
        public IActionResult Create()
        {
            ViewData["Price"] = new SelectList(_context.ChallanDetails, "CDID", "Price");
            return View();
        }

        // POST: User/PaymentMethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentMethodId,PaymentMethodName,MethodEnabled,Price")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index2));
            }
            ViewData["Price"] = new SelectList(_context.ChallanDetails, "CDID", "Price", paymentMethod.Price);
            return View(paymentMethod);
        }

        // GET: User/PaymentMethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _context.PaymentMethod.FindAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            ViewData["Price"] = new SelectList(_context.ChallanDetails, "CDID", "Price", paymentMethod.Price);
            return View(paymentMethod);
        }

        // POST: User/PaymentMethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentMethodId,PaymentMethodName,MethodEnabled,Price")] PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.PaymentMethodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentMethodExists(paymentMethod.PaymentMethodId))
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
            ViewData["Price"] = new SelectList(_context.ChallanDetails, "CDID", "CDID", paymentMethod.Price);
            return View(paymentMethod);
        }

        // GET: User/PaymentMethods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _context.PaymentMethod
                .Include(p => p.ChallanDetails)
                .FirstOrDefaultAsync(m => m.PaymentMethodId == id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return View(paymentMethod);
        }

        // POST: User/PaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentMethod = await _context.PaymentMethod.FindAsync(id);
            _context.PaymentMethod.Remove(paymentMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentMethodExists(int id)
        {
            return _context.PaymentMethod.Any(e => e.PaymentMethodId == id);
        }
    }
}
