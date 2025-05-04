using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using EmployeeFilesApp.Models;

namespace EmployeeFilesApp.Controllers
{
    public class FileRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FileRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FileRecords
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.FileRecords.Include(f => f.Department).Include(f => f.Employee);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: FileRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileRecord = await _context.FileRecords
                .Include(f => f.Department)
                .Include(f => f.Employee)
                .FirstOrDefaultAsync(m => m.FileId == id);
            if (fileRecord == null)
            {
                return NotFound();
            }

            return View(fileRecord);
        }

        // GET: FileRecords/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            return View();
        }

        // POST: FileRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FileId,FileName,FileType,FileSizeMB,EmployeeId,DepartmentId")] FileRecord fileRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", fileRecord.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", fileRecord.EmployeeId);
            return View(fileRecord);
        }

        // GET: FileRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileRecord = await _context.FileRecords.FindAsync(id);
            if (fileRecord == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", fileRecord.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", fileRecord.EmployeeId);
            return View(fileRecord);
        }

        // POST: FileRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FileId,FileName,FileType,FileSizeMB,EmployeeId,DepartmentId")] FileRecord fileRecord)
        {
            if (id != fileRecord.FileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileRecordExists(fileRecord.FileId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", fileRecord.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", fileRecord.EmployeeId);
            return View(fileRecord);
        }

        // GET: FileRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileRecord = await _context.FileRecords
                .Include(f => f.Department)
                .Include(f => f.Employee)
                .FirstOrDefaultAsync(m => m.FileId == id);
            if (fileRecord == null)
            {
                return NotFound();
            }

            return View(fileRecord);
        }

        // POST: FileRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fileRecord = await _context.FileRecords.FindAsync(id);
            if (fileRecord != null)
            {
                _context.FileRecords.Remove(fileRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileRecordExists(int id)
        {
            return _context.FileRecords.Any(e => e.FileId == id);
        }
    }
}
