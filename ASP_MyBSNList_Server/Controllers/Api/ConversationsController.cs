using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using ASP_MyBSNList.Models;

namespace ASP_MyBSNList.Controllers.Api
{
    [RoutePrefix("api/conversations")]
    public class ConversationsController : DbController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Person> GetRandomPersons(int maxNumberOfPersons = 5)
        {
            var rand = new Random();

            var persons = new List<Person>();
            var dbPersons = Context.People.OrderBy(p => p.Id).ToList();

            for (var i = 0; i < Math.Min(maxNumberOfPersons, dbPersons.Count); i++)
            {
                var index = rand.Next(0, dbPersons.Count-1);
                var person = dbPersons[index];

                if (person == null) throw new ApplicationException("Found null person in table or false index");

                while (persons.Contains(person))
                {
                    index = rand.Next(dbPersons.FirstOrDefault()?.Id ?? 0, dbPersons.LastOrDefault()?.Id ?? 1);
                    person = dbPersons.SingleOrDefault(p => p.Id == index);
                }

                persons.Add(person);
            }

            return persons;
        }
    }
}
