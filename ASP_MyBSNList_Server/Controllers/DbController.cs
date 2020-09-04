using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_MyBSNList.Models;

namespace ASP_MyBSNList.Controllers
{
    public class DbController
    {
        private static ApplicationDbContext _context;

        public static ApplicationDbContext Context
        {
            get => (_context != null) ? _context : _context = new ApplicationDbContext();
        }

    }
}