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
    [RoutePrefix("api/ageGroups")]
    public class AgeGroupsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<AgeGroup> GetAgeGroups()
        {
            var dbAgeGroups = DbController.Context.AgeGroups.ToList();

            return dbAgeGroups;
        }
    }
}
