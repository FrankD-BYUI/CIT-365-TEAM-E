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
       

        public static int drawersCost;
        public static int materialCost;
        public static int sizeCost;
        public static int myOverage;
        public static string rushDays;
        public static string rushCost;
        public static string[,] priceRush = new string[3, 3];



        public static int DRAWER_PRICE = 50;
        public const int BASE_DESK_PRICE = 200;
        public const int BASE_SIZE_INCL = 1000;
        public const int DESKTOP_SURFACE_AREA = 1;
        public enum DesktopMaterial
        {
            Select,
            Oak = 200,
            Laminate = 100,
            Pine = 50,
            Rosewood = 300,
            Veneer = 125
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


        private int _size;
        [Display(Name = "Size")]
        public int SizeDesk { 
            get {
                return _size;
            }
            set {
                _size = DepthDesk * WidthDesk;
            }
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
        public DateTime QuoteDate
        {
            get
            {
                return _date;
            }
            set
            {
                _date = DateTime.Now;

            }
        }

        private int _total;
        [Display(Name = "Total Cost")]
        public int TotalCost
        {
            get
            {
                return MegaDesk.BASE_DESK_PRICE + GetDrawersCost(Drawers) + getCostMaterial(Material) + getSizeCost(SizeDesk);
            }
        }
        public int GetDrawersCost(int drawers)
        {
            MegaDesk.drawersCost = drawers * MegaDesk.DRAWER_PRICE;
            return MegaDesk.drawersCost;
        }
        public int getCostMaterial(string myMaterial)
        {
            MegaDesk.materialCost = (int)Enum.Parse(typeof(DesktopMaterial), myMaterial);
            return MegaDesk.materialCost;
        }
        public void setSizeOverage(int mySize)
        {
            if (mySize > 1000)
                MegaDesk.myOverage = mySize - 1000;
            else
                MegaDesk.myOverage = 0;
        }

        public int getSizeOverage()
        {
            return MegaDesk.myOverage;
        }
        public int getSizeCost(int mySize)
        {
            if (mySize > 1000)
                MegaDesk.sizeCost = MegaDesk.myOverage * Desk.DESKTOP_SURFACE_AREA;
            else
                MegaDesk.sizeCost = 0;
            return MegaDesk.sizeCost;
        }
        
    }
    
}