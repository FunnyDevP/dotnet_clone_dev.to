using clone_dev_to.Data;
using clone_dev_to.Models;

namespace clone_dev_to.Repositories;

public class PostTagRepository: IRepository<PostTagModel>
{
    private readonly BloggerContext _bloggerContext;

    public PostTagRepository(BloggerContext bloggerContext)
    {
        _bloggerContext = bloggerContext;
    }
    public List<PostTagModel> GetAll()
    {
        return _bloggerContext.Tags.ToList();
    }
}