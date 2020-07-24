using ASP_MyBSNList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ASP_MyBSNList.Controllers
{
    public class HelloWorldController : ApiController
    {
        private ApplicationDbContext _context;

        public HelloWorldController()
        {
            _context = new ApplicationDbContext();
        }

        public HelloModel GetDefault()
        {
            var model = _context.Greetings.SingleOrDefault(m => m.Id == 1);

            return model;
        }
    }
}
