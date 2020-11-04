using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using ASP_MyBSNList.Controllers.Database;
using ASP_MyBSNList.Dtos;
using ASP_MyBSNList.Models;
using ASP_MyBSNList.Providers;
using Newtonsoft.Json.Linq;

namespace ASP_MyBSNList.Controllers.Api
{
    [RoutePrefix("api/person")]
    public class PersonController : ApiController
    {
        [HttpPost]
        public virtual int CreatePerson(PersonDto personData)
        {
            try
            {
                Person oldPerson = DbController.Context.People.SingleOrDefault(p => p.Name == personData.Name);

                //..dont add the same person twice!
                if (oldPerson != null)
                    return 0;

                //..create a new person model and pass to the db context
                /*Person newPerson = new Person
                {
                    Name = personData.Name,
                    List = personData.List,
                    MartialStatusId = Context.MartialStatuses.SingleOrDefault(m => m.Name == personData.MartialStatus)?.Id,
                    HasKids = personData.HasKids,
                    AgeGroupId = Context.AgeGroups.SingleOrDefault(m => m.Name == personData.AgeGroup)?.Id,
                    CityId = Context.Cities.SingleOrDefault(m => m.Name == personData.CurrentCity)?.Id,
                    IndustryId = Context.Industries.SingleOrDefault(m => m.Name == personData.Industry)?.Id,
                    NationalityId = Context.Countries.SingleOrDefault(m => m.Name == personData.Nationality)?.Id,
                    OccupationId = Context.Occupations.SingleOrDefault(m => m.Name == personData.Occupation)?.Id,
                    PrimaryCommunicationId = Context.CommunicationTypes.SingleOrDefault(m => m.Name == personData.Primary)?.Id,
                    SecondaryCommunicationId = Context.CommunicationTypes.SingleOrDefault(m => m.Name == personData.Secondary)?.Id,
                    LastContact = personData.LastContact,
                    DateAdded = personData.DateAdded,
                };*/

                //DbController.Context.People.Add(newPerson);
                //DbController.Context.SaveChanges();

                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public virtual Person GetPersonById(int id)
        {
            //IEnumerable<DbColumn> cols = DbController.PollSchema<Person>();

            return PersonProvider.GetPersonById(id);
        }

        [HttpGet]
        [Route("name")]
        public virtual IEnumerable<Person> GetPersonsWithName([FromUri] string q)
        {
            return PersonProvider.SearchPersonsByName(q);
        }

        [HttpGet]
        [Route("")]
        public virtual IEnumerable<Person> GetPersonsByList(string list)
        {
            return PersonProvider.GetPersonsByList(list);
        }
    }
}