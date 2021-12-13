using clone_dev_to.Models;
using Microsoft.EntityFrameworkCore;
namespace clone_dev_to.Data;

public class PostContext:DbContext
{
    public PostContext(DbContextOptions<PostContext> options) : base(options)
    {
        
    }
    
    public DbSet<PostModel> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TagModel>().HasData(
            new List<TagModel>
            {
                new()
                {
                    Id = new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"),
                    Name = "javascript",
                    CreatedDate = DateTime.UtcNow.Date
                },
                new()
                {
                    Id = new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"),
                    Name = "webdev",
                    CreatedDate = DateTime.UtcNow.Date
                },
                new()
                {
                    Id = new Guid("d6b1de80-e44e-412e-957e-8a7e64d494f9"),
                    Name = "beginners",
                    CreatedDate = DateTime.UtcNow.Date
                },
                new()
                {
                    Id = new Guid("daf5829d-25d3-4f36-b7f6-e6c8ba26bcd0"),
                    Name = "programming",
                    CreatedDate = DateTime.UtcNow.Date
                },
            });
        modelBuilder.Entity<PostModel>()
            .HasMany(p => p.Tags)
            .WithMany(t => t.Posts)
            .UsingEntity(join => join.ToTable("posts_tags"));
    }
}
