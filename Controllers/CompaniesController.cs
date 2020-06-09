using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyManagerTool.Data;
using CompanyManagerTool.Models;
using CompanyManagerTool.ViewModel;

namespace CompanyManagerTool.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly CompanyContext _context;

        public CompaniesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyDb.ToListAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.CompanyDb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            DropDownVM dropDownVM = new DropDownVM();
            dropDownVM.VmvtDropDownList = _context.VmvtDb.ToList();
            return View(dropDownVM);
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DropDownVM company)
        {

            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            DropDownVM dropDownVM = new DropDownVM();
            dropDownVM.VmvtDropDownList = _context.VmvtDb.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.CompanyDb.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            // need to assign company object values to dropDownVM 
            // So that the past values are visible in the boxes
            dropDownVM.Id = company.Id;
            dropDownVM.CompanyCode = company.CompanyCode;
            dropDownVM.CompanyName = company.CompanyName;
            dropDownVM.Email = company.Email;
            dropDownVM.WrongEmail = company.WrongEmail;
            dropDownVM.ContactNumber = company.ContactNumber;
            dropDownVM.County = company.County;
            dropDownVM.VMVT = company.VMVT;
            dropDownVM.Activities = company.Activities;
            dropDownVM.AdditionalInfo = company.AdditionalInfo;

            return View(dropDownVM);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DropDownVM company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }
        //-----------------------------------------------------------------------------
        //Commented out Delete function code redirects to a separate confirmation page"
        //-----------------------------------------------------------------------------
            

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            /*
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.CompanyDb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
            */

            var imone = await _context.CompanyDb.FindAsync(id);
            _context.CompanyDb.Remove(imone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        /*
        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.CompanyDb.FindAsync(id);
            _context.CompanyDb.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        */

        private bool CompanyExists(int id)
        {
            return _context.CompanyDb.Any(e => e.Id == id);
        }
    }
}
