using clone_dev_to.Models;
using Microsoft.EntityFrameworkCore;

namespace clone_dev_to.Data;

public class BloggerContext : DbContext
{
    public BloggerContext(DbContextOptions<BloggerContext> options) : base(options)
    {
    }

    public DbSet<PostModel> Posts { get; set; }
    public DbSet<PostTagModel> Tags { get; set; }
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
        modelBuilder.Entity<PostTagModel>().HasData(
            new List<PostTagModel>
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
                new()
                {
                    Id = new Guid("4cc2f0e6-0f70-4d4c-b2fd-3b3b300c8146"),
                    Name = "react",
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id = new Guid("57db3aa1-c82e-4e8f-89b4-6f176af151d9"),
                    Name = "typescript",
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id = new Guid("90092c47-ee62-4575-a7a2-dc7af0a10139"),
                    Name = "go",
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id = new Guid("f11813ff-8572-488b-9b7f-3fe4ef645fb1"),
                    Name = "docker",
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id = new Guid("67dc73c6-6a6e-411c-87ee-acb1ce62d3b9"),
                    Name = "swift",
                    CreatedDate = DateTime.UtcNow
                },
                new()
                {
                    Id = new Guid("9a5ffe6b-c39d-410e-9a03-322b27da2257"),
                    Name = "kubernetes",
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