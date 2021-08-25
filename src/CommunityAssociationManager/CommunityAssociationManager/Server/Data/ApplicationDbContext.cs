using CommunityAssociationManager.Server.Models;
using CommunityAssociationManager.Shared.Models;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using OurProperty = CommunityAssociationManager.Shared.Models.Property;

namespace CommunityAssociationManager.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunityMember> CommunityMembers { get; set; }
        public DbSet<CommunityProperty> CommunityProperties { get; set; }
        public DbSet<OurProperty> Properties { get; set; }
        public DbSet<TaxRecurrance> TaxRecurrances { get; set; }
        public DbSet<RecurringTax> RecurringTaxes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Community>()
                .HasOne(c => c.Manager)
                .WithMany(m => m.ManagedCommunities)
                .HasForeignKey(c => c.ManagerId);
            builder.Entity<Community>()
                .HasOne(c => c.Cashier)
                .WithMany(m => m.CashierCommunities)
                .HasForeignKey(c => c.CashierId);

            builder.Entity<Community>().HasKey(c => c.Id);
            builder.Entity<CommunityProperty>().HasKey(c => c.Id);
            builder.Entity<CommunityMember>().HasKey(c => c.Id);
            builder.Entity<OurProperty>().HasKey(c => c.Id);
            builder.Entity<TaxRecurrance>().HasKey(c => c.Id);
            builder.Entity<RecurringTax>().HasKey(c => c.Id);
            builder.Entity<RecurringTax>().HasKey(c => c.Id);

            base.OnModelCreating(builder);
        }
    }
}
