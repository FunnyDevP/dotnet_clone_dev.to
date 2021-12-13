using clone_dev_to.Data;
using clone_dev_to.Models;
using Microsoft.EntityFrameworkCore;

namespace clone_dev_to.Repositories;

public class PostRepository : IRepository<PostModel>
{
    private readonly BloggerContext _bloggerContext;

    public PostRepository(BloggerContext bloggerContext)
    {
        _bloggerContext = bloggerContext;
    }

    public List<PostModel> GetAll()
    {
        return _bloggerContext.Posts
            .Include(p => p.Tags)
            .Include(p => p.User)
            .OrderByDescending(p => p.PublicationDate)
            .ToList();
    }
}