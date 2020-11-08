using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MegaDeskRazorPages.Pages.Models;

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

        [Required]
        [Range(24, 96, ErrorMessage = "Width must be between 24 and 96.")]
        [Display(Name = "Width")]
        public int WidthDesk { get; set; }

        [Required]
        [Range(12, 48, ErrorMessage = "Depth must be between 12 and 48.")]
        [Display(Name = "Depth")]
        public int DepthDesk { get; set; }

        [Display(Name = "Size")]
        public int SizeDesk
        {
            get {return WidthDesk * DepthDesk; }
        }

        [Required]
        public int Drawers { get; set; }

        [Required]
        public string Material { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        [StringLength(30, ErrorMessage = "Name input has too many characters.")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Rush Days")]
        public string RushDays { get; set; }

        private DateTime _date;

        [Required]
        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]
        public DateTime QuoteDate {get {
         return _date;
        }
        set {
         _date = DateTime.Now;
        }
        }
[Display(Name = "Total Cost")]

        public int Calc_Total_Cost()
        {
            int sizeCost, basePrice, numDrawers, matCost, shippingCos;
            DeskQuote MyDeskQuote = new DeskQuote();
            sizeCost = MyDeskQuote.getSizeCost(size);
            basePrice = Desk.BASE_DESK_PRICE;
            numDrawers = MyDeskQuote.getDrawersCost(Drawers);
            Console.WriteLine(sizeCost);
            matCost = MyDeskQuote.getCostMaterial(Material);
            shippingCos = MyDeskQuote.getRushCost(size, RushDays);
            return sizeCost + basePrice + numDrawers + matCost + shippingCos;
        }

        public int TotalCost
        {
            get => Calc_Total_Cost();
            set
            {
                Calc_Total_Cost();
            }
        }


    }
}