using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2poprawa.Models;
using kolokwium2poprawa.Models.DTO;

namespace kolokwium2poprawa.Service
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;
        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddMember(Member member)
        {
            var addmember = new Member
            {
                OrganizationID = member.OrganizationID,
                MemberName = member.MemberName,
                MemberSurname = member.MemberSurname,
                MemberNickName = member.MemberNickName
            };
            _dbContext.Add(addmember);
             await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<object>> GetTeam(int TeamID)
        {
            return  _dbContext.Teams
            .Where(e => e.TeamID == TeamID)
            .Select(e => new SomeTeams
            {
                TeamName = e.TeamName,
                TeamDescription = e.TeamDescription,
                OrganizationName = e.Organization.OrganizationName,
                Members = e.Memberships
                    .Select(e => new SomeMembers
                    {
                        MemberName = e.Member.MemberName,
                        MemberSurname = e.Member.MemberSurname,
                        MemberNickName = e.Member.MemberNickName
                    }).OrderBy(e => e.MembershipDate)
                    .ToList() 
            }).ToList();
        }
    }
}
