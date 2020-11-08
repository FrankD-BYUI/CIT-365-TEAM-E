using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace MegaDeskRazorPages.Pages.Models
{
    public class DeskQuote
    {
        private int drawersCost;
        private int materialCost;
        private int rushCost;
        private int myOverage;
        private int sizeCost;
        private string[,] priceRush = new string[3, 3];
        public string customerName;
        public string rushDays;
        public Desk desk;
        public string quoteDate;
        public int totalCost;
        public enum DesktopMaterial
        {
            Select,
            Oak = 200,
            Laminate = 100,
            Pine = 50,
            Rosewood = 300,
            Veneer = 125
        }

        public DeskQuote()
        {

        }

        public void setSizeOverage(int mySize)
        {
            if (mySize > 1000)
                this.myOverage = mySize - 1000;
            else
                this.myOverage = 0;
        }

        public int getSizeOverage()
        {
            return this.myOverage;
        }

        public int getSizeCost(int mySize)
        {
            if (mySize > 1000)
                this.sizeCost = this.myOverage * Desk.DESKTOP_SURFACE_AREA;
            else
                this.sizeCost = 0;
            return this.sizeCost;
        }

        public int getDrawersCost(int myNumberOfDrawers)
        {
            this.drawersCost = myNumberOfDrawers * Desk.DRAWER_PRICE;
            return this.drawersCost;
        }

        public int getCostMaterial(string myMaterial)
        {
            this.materialCost = (int)Enum.Parse(typeof(DesktopMaterial), myMaterial);
            return this.materialCost;
        }

        public int getRushCost(int sizeDesk, string rushDays)
        {
            switch (rushDays)
            {
                case "3 Days":
                    if (sizeDesk < 1000)
                        this.rushCost = 60;
                    if (sizeDesk >= 1000 && sizeDesk <= 2000)
                        this.rushCost = 70;
                    if (sizeDesk > 2000)
                        this.rushCost = 80;
                    break;

                case "5 Days":
                    if (sizeDesk < 1000)
                        this.rushCost = 40;
                    if (sizeDesk >= 1000 && sizeDesk <= 2000)
                        this.rushCost = 50;
                    if (sizeDesk > 2000)
                        this.rushCost = 60;
                    break;

                case "7 Days":
                    if (sizeDesk < 1000)
                        this.rushCost = 30;
                    if (sizeDesk >= 1000 && sizeDesk <= 2000)
                        this.rushCost = 35;
                    if (sizeDesk > 2000)
                        this.rushCost = 40;
                    break;
                default:
                    this.rushCost = 0;
                    break;
            }
            return this.rushCost;
        }

        internal string getSizeCost(string v)
        {
            throw new NotImplementedException();
        }

        public void setcustomerName(string custName)
        {
            customerName = custName;
        }

        public string getcustomerName()
        {
            return customerName;
        }

        public void setRush(string rush)
        {
            this.rushDays = rush;
        }

        public void setQuoteDate()
        {
            this.quoteDate = (string)desk.GetDateTime();
        }

        public int getTotalCost()
        {
            this.totalCost = this.sizeCost + Desk.BASE_DESK_PRICE + this.drawersCost + this.materialCost + this.rushCost;
            return this.totalCost;
        }

        public string getQuoteDate()
        {
            return quoteDate;
        }

    }
}
