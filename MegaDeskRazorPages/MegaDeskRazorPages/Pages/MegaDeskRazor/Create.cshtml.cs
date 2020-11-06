using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskRazorPages.Data;
using MegaDeskRazorPages.Pages.Models;

namespace MegaDeskRazorPages.Pages.MegaDeskRazor
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskRazorPages.Data.MegaDeskRazorPagesContext _context;

        public CreateModel(MegaDeskRazorPages.Data.MegaDeskRazorPagesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MegaDesk MegaDesk { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MegaDesk.Add(MegaDesk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}