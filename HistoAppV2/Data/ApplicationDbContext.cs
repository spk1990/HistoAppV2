using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HistoAppV2.Models;
using HistoAppV2.Data;


namespace HistoAppV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
            //base.OnModelCreating(builder);

            //builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        //}
        public DbSet<HistoAppV2.Models.Orders>? Orders { get; set; }
        public DbSet<HistoAppV2.Models.HistoRoles>? HistoRoles { get; set; }
        public DbSet<HistoAppV2.Models.Contacts>? Contacts { get; set; }

        //public DbSet<HistoAppV2.Models.MultiSelectList>? MultiList { get; set; }
    }
}

//public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
//{
    //public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ApplicationUser> builder)
    //{
        //builder.Property(u => u.FirstName).HasMaxLength(256);
        //builder.Property(u => u.LastName).HasMaxLength(256);
    //}
//}
