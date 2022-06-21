using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2poprawa.Models.DTO
{
    public class SomeTeams
    {
        public string TeamName {get; set;}
        public string TeamDescription { get; set; }
        public string OrganizationName {get; set;}
        public IEnumerable<SomeMembers> Members { get; set; }
        
    }
}