using clone_dev_to.DTO;

namespace clone_dev_to.Services.Interfaces;

public interface IPostService
{
    List<PostDto> GetAll();
}