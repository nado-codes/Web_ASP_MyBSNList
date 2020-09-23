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
            List<Person> persons = new List<Person>();
            List<Person> dbPersons = Context.People.OrderBy(p => p.Id).ToList();
            int loopCount = 0;
            Random rand = new Random();

            /*while (persons.Count < maxNumberOfPersons && loopCount < Context.People.Count())
            {
                int index = rand.Next(1, dbPersons.Count() - 1);
                Person person = dbPersons.FirstOrDefault(p => p.Id == index);

                if (person == null)
                    continue;

                if(!persons.Contains(person))
                    persons.Add(person);

                loopCount++;
            }*/

            for (int i = 0; i < maxNumberOfPersons; i++)
            {
                int index = rand.Next(dbPersons.FirstOrDefault().Id, dbPersons.LastOrDefault().Id);
                Person person = dbPersons.SingleOrDefault(p => p.Id == index);

                while (persons.Contains(person) || person == null)
                {
                    index = rand.Next(dbPersons.FirstOrDefault().Id, dbPersons.LastOrDefault().Id);
                    person = dbPersons.SingleOrDefault(p => p.Id == index);
                }

                person.Name = person.Name.GetHashCode() + "";

                persons.Add(person);
            }

            return persons;
        }
    }
}
