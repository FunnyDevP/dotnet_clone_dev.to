using System.Collections.Generic;
using clone_dev_to.Controllers;
using clone_dev_to.DTO;
using clone_dev_to.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace clone_dev_to_test.Controllers;

public class PostTagController
{
    public void GetAll_GetEmptyDataFromDB_Return200AndEmptyListInResponseBody()
    {
        var mockService = new Mock<IPostTagService>();
        mockService.Setup(p => p.GetAll()).Returns(new List<PostTagDto>());

        var ctrl = new PostTagController(mockService.Object);
        var result = ctrl.GetAll();
        var ok = result as OkObjectResult;

        Assert.NotNull(ok);
        Assert.Equal(200, ok.StatusCode);
        var respBody = ok.Value as ResponseSuccess<List<PostDto>>;
        Assert.NotNull(respBody);
        Assert.Empty(respBody.Data);

        mockService.Verify(v => v.GetAll(), Times.Once);
    }
}