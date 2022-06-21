using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium2poprawa.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2poprawa.Models
{
    public class MainDbContext : DbContext
    {
        protected MainDbContext()
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<File> Files { get; set; }

        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organization>(e =>
            {
                e.HasKey(e => e.OrganizationID);
                e.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                e.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);

                e.HasData(
                    new Organization { OrganizationID = 1, OrganizationName = "name1", OrganizationDomain = "dom1"},
                    new Organization { OrganizationID = 2, OrganizationName = "name2", OrganizationDomain = "dom2"}
                );

            });
            modelBuilder.Entity<Team>(e =>
                        {
                            e.HasKey(e => e.TeamID);
                            e.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID);
                            e.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                            e.Property(e => e.TeamDescription).HasMaxLength(50);

                            e.HasData(
                                new Team {TeamID = 1, OrganizationID = 1, TeamName = "name1", TeamDescription = "desc1"},
                                new Team {TeamID = 2, OrganizationID = 2, TeamName = "name2", TeamDescription = "desc2"}
                            );
                        });

            modelBuilder.Entity<File>(e =>
            {
                e.HasKey(e => e.FileID);
                e.HasOne(e => e.Team).WithMany(e => e.Files).HasForeignKey(e => e.TeamID);
                e.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                e.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                e.Property(e => e.FileSize);

                e.HasData(
                    new File {FileID = 1, TeamID = 1, FileName = "name1", FileExtension = "jar", FileSize = 5},
                    new File {FileID = 2, TeamID = 2, FileName = "name2", FileExtension = "jar", FileSize = 4}
                );
            });

            modelBuilder.Entity<Member>(e => 
            {
                e.HasKey(e => e.MemberID);
                e.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID);
                e.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                e.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                e.Property(e => e.MemberNickName).HasMaxLength(20);

                e.HasData(
                    new Member {MemberID = 1, OrganizationID = 1, MemberName = "name1", MemberSurname = "sur1", MemberNickName = "nick1"},
                    new Member {MemberID = 2, OrganizationID = 2, MemberName = "name2", MemberSurname = "sur2", MemberNickName = "nick2"}
                );
            });

            modelBuilder.Entity<Membership>(e => 
            {
                e.HasKey(e => new {e.MemberID, e.TeamID});
                e.Property(e => e.MembershipDate).IsRequired();

                e.HasData(
                    new Membership {MemberID = 1, TeamID = 1, MembershipDate = DateTime.Parse("2022-06-21")},
                    new Membership {MemberID = 2, TeamID = 2, MembershipDate = DateTime.Parse("2022-06-22")}
                );
            });
        }
    }
}