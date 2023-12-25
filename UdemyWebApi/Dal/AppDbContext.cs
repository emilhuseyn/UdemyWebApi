using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UdemyWebApi.Entities;

namespace UdemyWebApi.Dal
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne(s=>s.Parent)
                .WithMany(m=>m.Children)
                .HasForeignKey(e=>e.CategoryId); 
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<Course> Courses{ get; set; }
        public DbSet<StudentsCourses> StudentsCourses{ get; set; }
    }
}
