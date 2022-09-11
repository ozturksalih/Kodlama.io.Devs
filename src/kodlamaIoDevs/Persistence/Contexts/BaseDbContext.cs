using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext :DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(p =>
            {
                p.ToTable("ProgrammingLanguages").HasKey(p => p.Id);
                p.Property(p=>p.Id).HasColumnName("Id");
                p.Property(p=>p.Name).HasColumnName("Name");
                p.HasMany(p => p.Frameworks);
            });

            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Python") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            modelBuilder.Entity<Framework>(f => 
            {
                f.ToTable("Frameworks").HasKey(f => f.Id);
                f.Property(f=>f.Id).HasColumnName("Id");
                f.Property(f => f.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                f.Property(f=> f.Name).HasColumnName("Name");                
                f.HasOne(f => f.ProgrammingLanguage);
            });

            Framework[] frameworkEntitySeeds = 
            {
                new (1, 1, ".net"),
                new (2,1, "c#"),
                new (3,2,"piton"),
                new (4,1,"vv")

            };
            modelBuilder.Entity<Framework>().HasData(frameworkEntitySeeds);
        }

    }
}
