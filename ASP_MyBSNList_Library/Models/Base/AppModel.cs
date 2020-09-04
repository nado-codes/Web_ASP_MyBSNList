using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MyBSNList.Models.Base
{
    /// <summary>
    /// Int-based ID database model, inheriting from the UnqNameModel class
    /// </summary>
    public class AppModel : UnqNameModel
    {
        public int Id { get; set; }
    }
}