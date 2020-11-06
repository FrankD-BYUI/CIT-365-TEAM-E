using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazorPages.Data;
using MegaDeskRazorPages.Pages.Models;

namespace MegaDeskRazorPages.Pages.MegaDeskRazor
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskRazorPages.Data.MegaDeskRazorPagesContext _context;

        public EditModel(MegaDeskRazorPages.Data.MegaDeskRazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MegaDesk MegaDesk { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MegaDesk = await _context.MegaDesk.FirstOrDefaultAsync(m => m.ID == id);

            if (MegaDesk == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MegaDesk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MegaDeskExists(MegaDesk.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MegaDeskExists(int id)
        {
            return _context.MegaDesk.Any(e => e.ID == id);
        }
    }
}
