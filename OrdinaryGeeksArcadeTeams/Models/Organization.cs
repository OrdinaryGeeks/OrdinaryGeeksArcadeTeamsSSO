using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdinaryGeeksArcadeTeams.Models
{
    public class Organization
    {
        public int ID { get;set;}
      //  public int OrganizationNum { get; set; }

        public string Name { get; set; }

        public string AdminPassword { get; set; }
       // public virtual List<Employee> Employees { get; set; }
        
     //   public virtual List<Token> OrganizationTokens { get; set; }
        public virtual List<Manager> Managers { get; set; }
        public bool Active { get; set; }

    }
}