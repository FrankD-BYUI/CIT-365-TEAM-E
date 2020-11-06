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
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskRazorPages.Data.MegaDeskRazorPagesContext _context;

        public DetailsModel(MegaDeskRazorPages.Data.MegaDeskRazorPagesContext context)
        {
            _context = context;
        }

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
    }
}
