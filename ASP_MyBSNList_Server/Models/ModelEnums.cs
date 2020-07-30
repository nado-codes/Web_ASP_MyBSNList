using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MyBSNList.Models
{
    public class Status : AppModel {}
    public class Reason : AppModel {}
    public class CommunicationType : AppModel {}
    public class Country : AppModel {}
    public class City : AppModel {}
    public class Industry : AppModel {}
    public class Occupation : AppModel {}
    public class MartialStatus : AppModel { }
    public class AgeGroup : AppModel { }

    public class Person : AppModel
    {
        [Required]
        public int infoId { get; set; }
    }
}