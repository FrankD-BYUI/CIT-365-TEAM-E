using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazorPages.Pages.Models
{
    public class Desk

    {
        public const int WIDTH_MIN = 24;
        public const int WIDTH_MAX = 96;
        public const int depth_MIN = 12;
        public const int depth_MAX = 48;
        public const int DRAWER_PRICE = 50;
        public const int BASE_DESK_PRICE = 200;
        public const int BASE_SIZE_INCL = 1000;
        public const int DESKTOP_SURFACE_AREA = 1;

        

        internal object GetDateTime()
        {
            throw new NotImplementedException();
        }
    }
}
