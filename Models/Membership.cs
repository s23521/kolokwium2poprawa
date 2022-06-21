using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2poprawa.Models.DTO;

namespace kolokwium2poprawa.Models
{
    public class Membership
    {
        public int MemberID { get; set; }
        public int TeamID { get; set; }
        public DateTime MembershipDate { get; set; }    
        public virtual Member Member {get; set;}
        public virtual Team Team {get; set;}
    }
}