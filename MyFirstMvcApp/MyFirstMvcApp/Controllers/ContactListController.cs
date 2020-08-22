using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstMvcApp.Data;
using MyFirstMvcApp.Models;

namespace MyFirstMvcApp.Controllers

{
    public class ContactListController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly MyFirstMvcAppDbContext _context;

        public ContactListController(MyFirstMvcAppDbContext context)
        {
            _context = context;
        }

        // GET: ContactList
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactListEntry.ToListAsync());
        }

        // GET: ContactList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactListEntry = await _context.ContactListEntry
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactListEntry == null)
            {
                return NotFound();
            }

            return View(contactListEntry);
        }

        // GET: ContactList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ContactType,Name,DateOFBirth,TelephoneNumber,Email")] ContactListEntry contactListEntry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactListEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactListEntry);
        }

        // GET: ContactList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactListEntry = await _context.ContactListEntry.FindAsync(id);
            if (contactListEntry == null)
            {
                return NotFound();
            }
            return View(contactListEntry);
        }

        // POST: ContactList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ContactType,Name,DateOFBirth,TelephoneNumber,Email")] ContactListEntry contactListEntry)
        {
            if (id != contactListEntry.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactListEntry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactListEntryExists(contactListEntry.ID))
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
            return View(contactListEntry);
        }

        // GET: ContactList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactListEntry = await _context.ContactListEntry
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contactListEntry == null)
            {
                return NotFound();
            }

            return View(contactListEntry);
        }

        // POST: ContactList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactListEntry = await _context.ContactListEntry.FindAsync(id);
            _context.ContactListEntry.Remove(contactListEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactListEntryExists(int id)
        {
            return _context.ContactListEntry.Any(e => e.ID == id);
        }
    }
}
