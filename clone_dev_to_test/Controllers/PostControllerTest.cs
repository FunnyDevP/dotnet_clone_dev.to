using System.Collections.Generic;
using clone_dev_to.DTO;
using clone_dev_to.Services.Interfaces;
using Moq;
using Xunit;

namespace clone_dev_to_test.Controllers;

public class PostControllerTest
{
    [Fact]
    public void GetAll_GetEmptyDataFromDB_Return200AndEmptyListInResponseBody()
    {
        var mockService = new Mock<IPostService>();
        mockService.Setup(p => p.GetAll()).Returns(new List<PostDto>());
        mockService.Verify(v => v.GetAll(),Times.Once);
        
        var ctrl = new PostController()

    }
}