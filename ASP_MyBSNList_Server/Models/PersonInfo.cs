using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MyBSNList.Models
{
    public class PersonInfo
    {
        [Required] public int Id { get; set; }
        [Required] public int PersonId { get; set; }

        [Required] public byte PrimaryCommunicationId { get; set; }
        public CommunicationType PrimaryCommunication { get; set; }

        [Required] public byte SecondaryCommunicationId { get; set; }
        public CommunicationType SecondaryCommunication { get; set; }

        [Required] public byte NationalityId { get; set; }
        public Country Nationality { get; set; }

        [Required] public byte CityId { get; set; }
        public City City { get; set; }

        [Required] public byte OccupationId { get; set; }
        public Occupation Occupation { get; set; }

        [Required] public byte IndustryId { get; set; }
        public Industry Industry { get; set; }

        [Required] public byte MartialStatusId { get; set; }
        public MartialStatus MartialStatus { get; set; }

        [Required] public byte AgeGroupId { get; set; }
        public AgeGroup AgeGroup { get; set; }

        [Required] public bool HasKids { get; set; }
        [Required] public string Remarks { get; set; }

        [Required] public DateTime DateAdded { get; set; }
        [Required] public DateTime LastContact { get; set; }
    }
}