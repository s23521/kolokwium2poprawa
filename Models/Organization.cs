using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2poprawa.Models.DTO;

namespace kolokwium2poprawa.Models
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDomain { get; set; }
        public virtual ICollection<Member> Members {get; set;}
        public virtual ICollection<Team> Teams {get; set;} 
    }
}