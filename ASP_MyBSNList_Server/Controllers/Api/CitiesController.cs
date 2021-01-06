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
    [RoutePrefix("api/cities")]
    public class CitiesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<City> GetCities()
        {
            var dbCities = DbController.Context.Cities.ToList();

            return dbCities;
        }
    }
}
