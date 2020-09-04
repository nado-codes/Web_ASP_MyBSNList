using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_MyBSNList.Models
{
    /// <summary>
    /// Database model with a forced-unique name whose length cannot exceed 255 characters
    /// </summary>
    public class UnqNameModel
    {
        [Required]
        [Index("Name_Index", IsUnique = true)]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}