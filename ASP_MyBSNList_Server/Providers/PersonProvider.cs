using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ASP_MyBSNList.Controllers;
using ASP_MyBSNList.Controllers.Database;
using ASP_MyBSNList.Models;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace ASP_MyBSNList.Providers
{
    public sealed class PersonProvider
    {
        #region UtilityMethods
        private static IEnumerable<Person> QueryPersons(Func<Person,bool> predicate)
        {
            return DbController.Context.People
                .Include(p => p.PrimaryCommunication)
                .Include(p => p.SecondaryCommunication)
                .Include(p => p.Nationality)
                .Include(p => p.AgeGroup)
                .Include(p => p.City)
                .Include(p => p.Industry)
                .Include(p => p.Occupation)
                .Include(p => p.MartialStatus)
                .AsEnumerable().Where(predicate);
        }
        private static Person QueryPerson(Func<Person, bool> predicate)
        {
            return DbController.Context.People
                .Include(p => p.PrimaryCommunication)
                .Include(p => p.SecondaryCommunication)
                .Include(p => p.Nationality)
                .Include(p => p.AgeGroup)
                .Include(p => p.City)
                .Include(p => p.Industry)
                .Include(p => p.Occupation)
                .Include(p => p.MartialStatus)
                .SingleOrDefault(predicate);
        }

        private static bool ExistsWithName(string name)
        {
            return (DbController.Context.People.SingleOrDefault(p => p.Name == name) != null);
        }
        #endregion

        public static IEnumerable<Person> GetAll()
        {
            return DbController.Context.People
                .Include(p => p.PrimaryCommunication)
                .Include(p => p.SecondaryCommunication)
                .Include(p => p.Nationality)
                .Include(p => p.AgeGroup)
                .Include(p => p.City)
                .Include(p => p.Industry)
                .Include(p => p.Occupation)
                .Include(p => p.MartialStatus);
        }

        //GET
        public static Person GetPersonById(int id)
        {
            return QueryPerson((p) => p.Id == id);
        }
        public static IEnumerable<Person> GetPersonsByList(string list)
        {
            return QueryPersons((p) => p.List.Equals(list, StringComparison.OrdinalIgnoreCase));
        }

        public static IEnumerable<Person> SearchPersonsByName(string query)
        {
            return QueryPersons((p) => p.Name.Substring(0, query.Length).ToLower().Equals(query.ToLower()));
        }

        //POST
        public static Person AddPerson(Person person)
        {
            if(ExistsWithName(person.Name))
            {
                var response = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent("ALREADY_EXIST")
                };

                throw new HttpResponseException(response);
            }

            Person newPerson = DbController.Context.People.Add(person);
            DbController.Context.SaveChanges();

            return newPerson;
        }

        //PUT
        public static long UpdatePerson(Person person)
        {
            try
            {
                Person oldPerson = DbController.Context.People.SingleOrDefault(p => p.Id == person.Id);
                oldPerson.Copy(person);

                DbController.Context.SaveChanges();

                return 1;
            }
            catch(Exception e)
            {

            }

            return 0;
        }

        //DELETE
        public static long DeletePerson(Person person)
        {
            try
            {
                Person oldPerson = DbController.Context.People.SingleOrDefault(p => p.Id == person.Id);
                DbController.Context.People.Remove(oldPerson);
                DbController.Context.SaveChanges();

                return 1;
            }
            catch { }

            return 0;
        }
    }
}