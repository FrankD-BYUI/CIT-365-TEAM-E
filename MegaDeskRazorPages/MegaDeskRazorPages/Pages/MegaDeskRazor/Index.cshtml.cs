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

        public IList<MegaDesk> MegaDesks { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentSort { get; set; }


        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<MegaDesk> megaDeskIQ = from s in _context.MegaDesk
                                            select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                megaDeskIQ = megaDeskIQ.Where(s => s.CustomerName.Contains(SearchString));
            }
            
            switch (sortOrder)
            {
                case "name_desc":
                    megaDeskIQ = megaDeskIQ.OrderByDescending(s => s.CustomerName);
                    break;
                case "Date":
                    megaDeskIQ = megaDeskIQ.OrderBy(s => s.QuoteDate);
                    break;
                case "date_desc":
                    megaDeskIQ = megaDeskIQ.OrderByDescending(s => s.QuoteDate);
                    break;
                default:
                    megaDeskIQ = megaDeskIQ.OrderBy(s => s.CustomerName);
                    break;
            }

            MegaDesks = await megaDeskIQ.AsNoTracking().ToListAsync();
        }
    }
}
