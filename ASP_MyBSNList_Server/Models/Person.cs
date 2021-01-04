using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using ASP_MyBSNList.Models.Base;
using Newtonsoft.Json;

namespace ASP_MyBSNList.Models
{
    /// <summary>
    /// Specifies a database record for a person and all known information about them
    /// </summary>
    public class Person : AppModel
    {
        public string SafeName => GetHashCode() + "";

        [Required] public string List { get; set; }

        public byte? Gender { get; set; }

        public byte? PrimaryCommunicationId { get; set; }
        public CommunicationType PrimaryCommunication { get; set; }

        public byte? SecondaryCommunicationId { get; set; }
        public CommunicationType SecondaryCommunication { get; set; }

        public byte? NationalityId { get; set; }
        public Country Nationality { get; set; }

        public byte? CityId { get; set; }
        public City City { get; set; }

        public byte? OccupationId { get; set; }
        public Occupation Occupation { get; set; }

        public byte? IndustryId { get; set; }
        public Industry Industry { get; set; }

        public byte? MartialStatusId { get; set; }
        public MartialStatus MartialStatus { get; set; }

        public byte? AgeGroupId { get; set; }
        public AgeGroup AgeGroup { get; set; }

        public bool? HasKids { get; set; }
        public string Remarks { get; set; }

        public DateTime? DateAdded { get; set; }
        public DateTime? LastContact { get; set; }

        public void Copy(Person person)
        {
            List = person.List;
            Gender = person.Gender;

            PrimaryCommunicationId = person.PrimaryCommunication?.Id;
            //PrimaryCommunication = person.PrimaryCommunication;

            SecondaryCommunicationId = person.SecondaryCommunication?.Id;
            //SecondaryCommunication = person.SecondaryCommunication;

            NationalityId = person.Nationality?.Id;
            //Nationality = person.Nationality;

            CityId = person.City?.Id;
            //City = person.City;

            OccupationId = person.Occupation?.Id;
            //Occupation = person.Occupation;

            IndustryId = person.Industry?.Id;
            //Industry = person.Industry;

            MartialStatusId = person.MartialStatus?.Id;
            //MartialStatus = person.MartialStatus;

            AgeGroupId = person.AgeGroup?.Id;
            //AgeGroup = person.AgeGroup;

            HasKids = person.HasKids;
            Remarks = person.Remarks;

            LastContact = person.LastContact;
            DateAdded = DateTime.Now;
        }
    }
}