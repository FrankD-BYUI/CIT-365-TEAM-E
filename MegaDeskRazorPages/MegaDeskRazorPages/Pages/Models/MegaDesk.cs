using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskRazorPages.Pages.Models
{
    public class MegaDesk
    {
       
        private int myOverage;
        public int size;

        public void setSizeOverage(int mySize)
        {
            if (mySize > 1000)
                this.myOverage = mySize - 1000;
            else
                this.myOverage = 0;
        }

        public int ID { get; set; }

        [Display(Name = "Width")]
        public int WidthDesk { get; set; }

        [Display(Name = "Depth")]
        public int DepthDesk { get; set; }

        [Display(Name = "Size")]
        public int SizeDesk
        {
            get => size; set { size = WidthDesk * DepthDesk; }
        }

        public int Drawers { get; set; }

        public string Material { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Rush Days")]
        public string RushDays { get; set; }

        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }

        [Display(Name = "Total Cost")]
        public int TotalCost { get; set; }

    }
}