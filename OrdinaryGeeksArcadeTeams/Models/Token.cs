using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdinaryGeeksArcadeTeams.Models
{
    public class Token
    {
        public int ID { get; set; }
      //  public int TokenNum { get; set; }
        public virtual int EmployeeID { get; set; }

       // public virtual int OrganizationID { get; set; }
        public int AwardedByNum { get; set; }

        public bool Active { get; set; }
    }
}