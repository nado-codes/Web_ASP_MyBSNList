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
    public class HelloWorldController : DbController
    {
        public HelloModel GetDefault()
        {
            var model = Context.Greetings.SingleOrDefault(m => m.Id == 1);

            return model;
        }
    }
}
