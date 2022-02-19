using Proiect_DAW.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Models
{
    public class Proiect_DAWContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public Proiect_DAWContext(DbContextOptions options) : base(options) 
        {

        }
        public DbSet<Dotare> Dotari { get; set; }
        public DbSet<Masina> Masini { get; set; }
        public DbSet<MasinaDotare> MasinaDotari { get; set; }
        public DbSet<Piesa> Piese { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //One to One (Masina-User)
            builder.Entity<User>()
               .HasOne(m => m.Masina)
               .WithOne(u => u.User);

            //One to Many (User-Piese)
            builder.Entity<User>()
               .HasMany(p => p.Piesa)
               .WithOne(u => u.User);

            builder.Entity<Piesa>()
                .HasIndex(p => p.Serie)
                .IsUnique();

            //Many to Many (Masina-Dotare)
            builder.Entity<MasinaDotare>().HasKey(md => new { md.MasinaId, md.DotareId });

            builder.Entity<MasinaDotare>()
                .HasOne(md => md.Dotare)
                .WithMany(d => d.MasinaDotare)
                .HasForeignKey(md => md.DotareId);

            builder.Entity<MasinaDotare>()
                .HasOne(md => md.Masina)
                .WithMany(m => m.MasinaDotare)
                .HasForeignKey(md => md.MasinaId);

            //Many to Many (User-Role)
            builder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            });
        }
    }
}
