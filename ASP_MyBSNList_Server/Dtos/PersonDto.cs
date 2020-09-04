using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ASP_MyBSNList.Models;
using Newtonsoft.Json;

namespace ASP_MyBSNList.Dtos
{
    public class PersonDto
    {
        /*
            \"Met On\": \"\",\r\n  
            \"Added\": \"\",\r\n  
         */

        [Required]
        public string Name { get; set; }

        public string List { get; set; }

        //[Required] public byte PrimaryCommunicationId { get; set; }
        public string Primary /*Communication*/ { get; set; } //CommunicationType

        //[Required] public byte SecondaryCommunicationId { get; set; }
        public string Secondary /*Communication*/ { get; set; } //CommunicationType

        //[Required] public byte NationalityId { get; set; }
        public string Nationality { get; set; } //Country

        [JsonProperty("Current City")]
        //[Required] public byte CityId { get; set; }
        public string CurrentCity { get; set; } //City

        //[Required] public byte OccupationId { get; set; }
        public string Occupation { get; set; } //Occupation

        //[Required] public byte IndustryId { get; set; }
        public string Industry { get; set; } //Industry

        [JsonProperty("Marital Status")]
        //[Required] public byte MartialStatusId { get; set; }
        public string MartialStatus { get; set; } //MartialStatus

        [JsonProperty("Age Group")]
        //[Required] public byte AgeGroupId { get; set; }
        public string AgeGroup { get; set; } //AgeGroup

        [Required] public bool HasKids { get; set; }
        [Required] public string Remarks { get; set; }

        [Required] public DateTime DateAdded { get; set; }
        [Required] public DateTime LastContact { get; set; }

        
    }
}