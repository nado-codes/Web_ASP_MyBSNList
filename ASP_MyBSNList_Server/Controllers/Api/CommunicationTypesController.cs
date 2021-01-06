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
    [RoutePrefix("api/communicationTypes")]
    public class CommunicationTypesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<CommunicationType> GetCommunicationTypes()
        {
            var dbCommunicationTypes = DbController.Context.CommunicationTypes.ToList();

            return dbCommunicationTypes;
        }
    }
}
