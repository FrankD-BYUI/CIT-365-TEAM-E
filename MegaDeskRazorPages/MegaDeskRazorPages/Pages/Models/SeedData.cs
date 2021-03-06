﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MegaDeskRazorPages.Data;

namespace MegaDeskRazorPages.Pages.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskRazorPagesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MegaDeskRazorPagesContext>>()))
            {
                // Look for any movies.
                if (context.MegaDesk.Any())
                {
                    return;   // DB has been seeded
                }

                context.MegaDesk.AddRange(
                    new MegaDesk
                    {
                        CustomerName = "Luiz Manoel",
                        RushDays = "5 Days",
                        WidthDesk = 55,
                        DepthDesk = 44,
                        Drawers = 4,
                        Material = "Veneer",
                        QuoteDate = DateTime.Parse("1989-2-12"),
                    },

                    new MegaDesk
                    {
                        CustomerName = "Donal Trump",
                        RushDays = "3 Days",
                        WidthDesk = 44,
                        DepthDesk = 44,
                        Drawers = 2,
                        Material = "Laminate",
                        QuoteDate = DateTime.Parse("2020-10-17"),
                    },

                    new MegaDesk
                    {
                        CustomerName = "John Biden",
                        RushDays = "3 Days",
                        WidthDesk = 44,
                        DepthDesk = 44,
                        Drawers = 1,
                        Material = "Pine",
                        QuoteDate = DateTime.Parse("2020-10-17"),
                    },

                    new MegaDesk
                    {
                        CustomerName = "Barak Obama",
                        RushDays = "5 Days",
                        WidthDesk = 44,
                        DepthDesk = 44,
                        Drawers = 5,
                        Material = "Oak",
                        QuoteDate = DateTime.Parse("2020-10-17"),
                    },


                    new MegaDesk
                    {
                        CustomerName = "Test",
                        RushDays = "5 Days",
                        WidthDesk = 55,
                        DepthDesk = 43,
                        Drawers = 7,
                        Material = "Oak",
                        QuoteDate = DateTime.Parse("2020-10-17"),
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
