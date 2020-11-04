using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ASP_MyBSNList.Controllers;
using ASP_MyBSNList.Controllers.Database;
using ASP_MyBSNList.Models;

namespace ASP_MyBSNList.Providers
{
    public sealed class PersonProvider
    {
        private static IEnumerable<Person> QueryPersons(Func<Person,bool> predicate)
        {
            return DbController.Context.People
                .Include(p => p.PrimaryCommunication)
                .Include(p => p.SecondaryCommunication)
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
                .Include(p => p.AgeGroup)
                .Include(p => p.City)
                .Include(p => p.Industry)
                .Include(p => p.Occupation)
                .Include(p => p.MartialStatus)
                .SingleOrDefault(predicate);
        }
        public static IEnumerable<Person> GetAll()
        {
            return DbController.Context.People
                .Include(p => p.PrimaryCommunication)
                .Include(p => p.SecondaryCommunication)
                .Include(p => p.AgeGroup)
                .Include(p => p.City)
                .Include(p => p.Industry)
                .Include(p => p.Occupation)
                .Include(p => p.MartialStatus);
        }

        public static Person GetPersonById(int id)
        {
            return QueryPerson((p) => p.Id == id);
        }

        public static IEnumerable<Person> SearchPersonsByName(string query)
        {
            return QueryPersons((p) => p.Name.Substring(0, query.Length).ToLower().Equals(query.ToLower()));
        }

        public static IEnumerable<Person> GetPersonsByList(string list)
        {
            return QueryPersons((p) => p.List.Equals(list, StringComparison.OrdinalIgnoreCase));
        }
    }
}