using clone_dev_to.DTO;
using clone_dev_to.Models;

namespace clone_dev_to.Services.Interfaces;

public interface IPostTagService
{
    List<PostTagDto> GetAll();
}