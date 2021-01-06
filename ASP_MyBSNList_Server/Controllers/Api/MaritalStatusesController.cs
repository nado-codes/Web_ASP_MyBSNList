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
    [RoutePrefix("api/maritalstatuses")]
    public class MaritalStatusesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<MartialStatus> GetMaritalStatuses()
        {
            var dbMaritalStatuses = DbController.Context.MartialStatuses.ToList();

            return dbMaritalStatuses;
        }
    }
}
