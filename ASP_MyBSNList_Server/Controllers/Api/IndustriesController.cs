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
    [RoutePrefix("api/industries")]
    public class IndustriesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Industry> GetIndustries()
        {
            var dbIndustries = DbController.Context.Industries.ToList();

            return dbIndustries;
        }
    }
}
