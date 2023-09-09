using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_WebApp.Models;
using MVC_WebAPP_JokeSite.Areas.Identity.Data;


namespace MVC_WebAPP_JokeSite.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<ApplicationUser>()
            .HasMany(x => x.UserJokes)
            .WithOne(x => x.ApplicationUser)
            .HasForeignKey(x => x.ApplicationUserId);
    }
    public DbSet<MVC_WebApp.Models.RootModel> RootModel { get; set; }
    public DbSet<MVC_WebApp.Models.APIRootModel> APIRootModel { get; set; }
    public DbSet<MVC_WebApp.Models.JokeModel> JokeModel { get; set; }
    public DbSet<MVC_WebApp.Models.FlagsModel> FlagsModel { get; set; }
    public DbSet<MVC_WebAPP_JokeSite.Models.ErrorViewModel> ErrorViewModel { get; set; }
}
