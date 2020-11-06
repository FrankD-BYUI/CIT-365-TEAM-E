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
    public class IndexModel : PageModel
    {
        private readonly MegaDeskRazorPages.Data.MegaDeskRazorPagesContext _context;

        public IndexModel(MegaDeskRazorPages.Data.MegaDeskRazorPagesContext context)
        {
            _context = context;
        }

        public IList<MegaDesk> MegaDesk { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

      
        public async Task OnGetAsync()
        {
            var movies = from m in _context.MegaDesk
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.CustomerName.Contains(SearchString));
            }

            MegaDesk = await movies.ToListAsync();
        }
    }
}
