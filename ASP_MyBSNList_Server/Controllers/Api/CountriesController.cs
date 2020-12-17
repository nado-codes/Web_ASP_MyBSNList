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
    [RoutePrefix("api/countries")]
    public class CountriesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Country> GetCountries()
        {
            var dbCountries = DbController.Context.Countries.ToList();

            return dbCountries;
        }
    }
}
