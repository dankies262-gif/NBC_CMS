using Microsoft.EntityFrameworkCore;
using NBC_CMS.Models;
using System.Security.Claims;

namespace NBC_CMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<ClaimCorrection> ClaimCorrections { get; set; }

        public DbSet<ClaimStatus> ClaimStatuses { get; set; }


    }
}