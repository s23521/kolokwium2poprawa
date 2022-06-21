using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2poprawa.Models;

namespace kolokwium2poprawa.Service
{
    public interface IDbService
    {
        Task<IEnumerable<object>> GetTeam(int TeamID);
        Task AddMember(Member member);
    }
}