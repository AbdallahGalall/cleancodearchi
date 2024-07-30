using cleancodearchi.domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;

namespace cleancodearchi.infrastructure
{
    public class Appdbcontext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=cleandbarchi;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        //}

        public Appdbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<model> tasks { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<model>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.task_desc).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<model>(entity =>
            {
                entity.Property(e => e.status).HasDefaultValue(false);
            });

                modelBuilder.Entity<model>().HasData(
                new model { id = 1, status = false, task_desc = "playing football" },
                new model { id = 2, status = false, task_desc = "playing pingbong",  },
                new model { id = 3, status = false, task_desc = "watching football" }
                );

        }


    }
}
