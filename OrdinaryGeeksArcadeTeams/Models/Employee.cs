using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdinaryGeeksArcadeTeams.Models
{
    public class Employee
    {
        public int ID { get; set; }

       // public int EmployeeNumber { get; set; }

     //   public virtual int OrganizationID { get; set; }

        public bool Active { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual int ManagerID { get; set; }
        public virtual List<Token> EmployeeTokens {get;set;}


    }
}