using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using orakle_api.Entities;




namespace orakle_api.Data
{
    public class DataContext : IdentityDbContext<Owner, IdentityRole<Guid>, Guid>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DataContext()
        {
        }

        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Artefact> Artefacts { get; set; }
    }
}
