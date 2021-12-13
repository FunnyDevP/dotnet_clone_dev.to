using clone_dev_to.DTO;
using clone_dev_to.Models;
using clone_dev_to.Repositories;
using clone_dev_to.Services.Interfaces;

namespace clone_dev_to.Services;

public class PostService : IPostService
{
    private readonly IRepository<PostModel> _repository;

    public PostService(IRepository<PostModel> repository)
    {
        _repository = repository;
    }

    public List<PostDto> GetAll()
    {
        var postData = _repository.GetAll();
        if (postData.Count == 0)
        {
            return new List<PostDto>();
        }

        return postData.Select(p => new PostDto
        {
            UserId = p.UserId,
            FullName = p.User.FullName,
            PublicationDate = p.PublicationDate.ToLocalTime(),
            BlogId = p.Id,
            BlogTitle = p.Title,
            BlogDetail = p.Detail,
            BlogTags = p.Tags.Select(t => new Tag {Id = t.Id, Name = t.Name}).ToList()
        }).ToList();
    }
}