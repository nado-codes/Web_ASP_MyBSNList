using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MyBSNList.Models
{
    /// <summary>
    /// A sample model only. Used for database testing.
    /// </summary>
    public class HelloModel
    {
        public byte Id { get; set; }

        [Required] 
        public string Name { get; set; }
    }
}