using clone_dev_to.DTO;
using clone_dev_to.Models;
using clone_dev_to.Repositories;
using clone_dev_to.Services.Interfaces;

namespace clone_dev_to.Services;

public class PostTagService : IPostTagService
{
    private readonly IRepository<PostTagModel> _repository;

    public PostTagService(IRepository<PostTagModel> repository)
    {
        _repository = repository;
    }

    public List<PostTagDto> GetAll()
    {
        var postTagData = _repository.GetAll();
        var modelToDto = postTagData.Select((pt) => new PostTagDto
        {
            Id = pt.Id,
            Name = pt.Name
        }).ToList();
        return postTagData.Count == 0 ? new List<PostTagDto>() : modelToDto;
    }
}