using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using _2_Book_Library.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet Books { get; set; }

    public ApplicationDbContext()
        : base("DefaultConnection", throwIfV1Schema: false)
    {
    }

    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }
}