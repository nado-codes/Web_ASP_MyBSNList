using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASP_MyBSNList.Controllers.Database;
using ASP_MyBSNList.Models;

namespace ASP_MyBSNList.Controllers.Api
{
    [RoutePrefix("api/reasons")]
    public class ReasonsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Reason> GetReasons()
        {
            var dbReasons = DbController.Context.Reasons.ToList();

            return dbReasons;
        }
    }
}
