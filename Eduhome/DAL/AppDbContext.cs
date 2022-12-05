using Eduhome.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eduhome.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<SliderItem> SliderItems { get; set; }
        public DbSet<ViewCourse> ViewCourses { get; set; }
        public DbSet<SocialMediaLink> SocialMediaLinks { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<InformationItem> InformationItems { get; set; }
        public DbSet<UsefulLink> UsefulLinks { get; set; }
        public DbSet<VideoTourLink> VideoTourLinks { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
