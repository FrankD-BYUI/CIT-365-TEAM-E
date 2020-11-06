using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazorPages.Pages.Models;

namespace MegaDeskRazorPages.Data
{
    public class MegaDeskRazorPagesContext : DbContext
    {
        public MegaDeskRazorPagesContext (DbContextOptions<MegaDeskRazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskRazorPages.Pages.Models.MegaDesk> MegaDesk { get; set; }
    }
}
