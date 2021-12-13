using clone_dev_to.Models;
using Microsoft.EntityFrameworkCore;

namespace clone_dev_to.Data;

public class BloggerContext : DbContext
{
    public BloggerContext(DbContextOptions<BloggerContext> options) : base(options)
    {
    }

    public DbSet<PostModel> Posts { get; set; }
    public DbSet<TagModel> Tags { get; set; }
    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PostModel>()
            .HasMany(p => p.Tags)
            .WithMany(t => t.Posts)
            .UsingEntity(join => join.ToTable("posts_tags"));

        modelBuilder.Entity<UserModel>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.User);
        
        // seeding data: Tags
        modelBuilder.Entity<TagModel>().HasData(
            new List<TagModel>
            {
                new()
                {
                    Id = new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"),
                    Name = "javascript",
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id = new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"),
                    Name = "webdev",
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id = new Guid("d6b1de80-e44e-412e-957e-8a7e64d494f9"),
                    Name = "beginners",
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id = new Guid("daf5829d-25d3-4f36-b7f6-e6c8ba26bcd0"),
                    Name = "programming",
                    CreatedDate = DateTime.UtcNow
                },
            });

        // seeding data: Users
        modelBuilder.Entity<UserModel>()
            .HasData(new List<UserModel>
            {
                new()
                {
                    Id = new Guid("68a580be-eacd-4551-bfb1-e45efbc44062"),
                    FullName = "Hello World"
                },
                new()
                {
                    Id = new Guid("50249762-0f32-4f3d-9704-ff9e5863bc86"),
                    FullName = "Funny Dev"
                },
                new()
                {
                    Id = new Guid("0242f16c-2e5d-4839-ba0d-bb90842bd98a"),
                    FullName = "John F. Night"
                }
            });
    }
}