using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdinaryGeeksArcadeTeams.Models
{
    public class Manager
    {
        public bool Active { get; set; }

        public  int ID { get; set; }
      //  public int EmployeeNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }
        public virtual int OrganizationID { get; set; }
        public virtual List<Employee> Subordinates { get; set; }

        //public virtual List<Token> TokensToDistribute { get; set; }

        //public virtual  List<Token> EmployeeTokens { get; set; }

        
    }
}