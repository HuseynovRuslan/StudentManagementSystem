using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
        
        }

       public  DbSet<Student> Students { get; set; }
       public DbSet<Group> Groups { get; set; }
         public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsRequired();

                entity.Property(e=>e.Age)
                .HasMaxLength(3)
                .IsRequired();
            });
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);

        }
    }
}
