using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASP_MyBSNList.Dtos;
using ASP_MyBSNList.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASP_MyBSNList.Controllers.Api
{
    [RoutePrefix("api/list")]
    public class ListController : ApiController
    {
        public enum List {A, B, C}


        private readonly PersonController _personController;

        public ListController()
        {
            _personController = new PersonController();
        }

        [HttpPost]
        [Route("")]
        public virtual void PostDefault(JArray data)
        {
            PersonDto[] personsData = ParsePersonsData(data);

            //personsData[0].

            int count = 0;

            foreach(PersonDto person in personsData)
                count += _personController.CreatePerson(person);
        }

        private PersonDto[] ParsePersonsData(JArray dataArray)
        {
            PersonDto[] personsData = new PersonDto[dataArray.Count];

            for (int i = 0; i < dataArray.Count; i++)
            {
                JToken row = dataArray[i];
                PersonDto person = JsonConvert.DeserializeObject<PersonDto>(row.ToString());
                personsData[i] = person;
            }

            return personsData;
        }
    }
}
