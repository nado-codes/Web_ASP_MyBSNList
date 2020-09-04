using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using ASP_MyBSNList.Dtos;
using ASP_MyBSNList.Models;
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
                ApplicationDbContext dbContext = DbController.Context;

                Person oldPerson = dbContext.People.SingleOrDefault(p => p.Name == personData.Name);

                //..dont add the same person twice!
                if (oldPerson != null)
                    return 0;

                //..create a new person model and pass to the db context
                Person newPerson = new Person
                {
                    Name = personData.Name,
                    List = personData.List,
                    MartialStatusId = dbContext.MartialStatuses.SingleOrDefault(m => m.Name == personData.MartialStatus)?.Id,
                    HasKids = personData.HasKids,
                    AgeGroupId = dbContext.AgeGroups.SingleOrDefault(m => m.Name == personData.AgeGroup)?.Id,
                    CityId = dbContext.Cities.SingleOrDefault(m => m.Name == personData.CurrentCity)?.Id,
                    IndustryId = dbContext.Industries.SingleOrDefault(m => m.Name == personData.Industry)?.Id,
                    NationalityId = dbContext.Countries.SingleOrDefault(m => m.Name == personData.Nationality)?.Id,
                    OccupationId = dbContext.Occupations.SingleOrDefault(m => m.Name == personData.Occupation)?.Id,
                    PrimaryCommunicationId = dbContext.CommunicationTypes.SingleOrDefault(m => m.Name == personData.Primary)?.Id,
                    SecondaryCommunicationId = dbContext.CommunicationTypes.SingleOrDefault(m => m.Name == personData.Secondary)?.Id,
                    LastContact = personData.LastContact,
                    DateAdded = personData.DateAdded,
                };

                dbContext.People.Add(newPerson);
                dbContext.SaveChanges();

                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}