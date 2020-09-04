using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MyBSNList.Models
{
    /// <summary>
    /// Byte-based ID database model, inheriting from the UnqNameModel class
    /// </summary>
    public class EnumModel : UnqNameModel
    {
        public byte Id { get; set; }
    }
}