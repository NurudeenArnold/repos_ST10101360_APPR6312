using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Areas.Identity.Data;
using WebApplication2.Models;

namespace WebApplication2.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    public DbSet<WebApplication2.Models.MonetaryDonations>? MonetaryDonations { get; set; }
    public DbSet<WebApplication2.Models.GoodsDonations>? GoodsDonations { get; set; }
    public DbSet<WebApplication2.Models.Categories>? Categories { get; set; }
    public DbSet<WebApplication2.Models.Disasters>? Disasters { get; set; }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    void IEntityTypeConfiguration<ApplicationUser>.Configure(EntityTypeBuilder<ApplicationUser> builder)
    {

    }
}

