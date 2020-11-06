using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazorPages.Data;
using MegaDeskRazorPages.Pages.Models;

namespace MegaDeskRazorPages.Pages.MegaDeskRazor
{
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskRazorPages.Data.MegaDeskRazorPagesContext _context;

        public DeleteModel(MegaDeskRazorPages.Data.MegaDeskRazorPagesContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MegaDesk = await _context.MegaDesk.FindAsync(id);

            if (MegaDesk != null)
            {
                _context.MegaDesk.Remove(MegaDesk);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
