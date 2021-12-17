using System;
using System.Collections.Generic;
using clone_dev_to.Controllers;
using clone_dev_to.DTO;
using clone_dev_to.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace clone_dev_to_test.Controllers;

public class PostTagControllerTest
{
    [Fact]
    public void GetAll_GetEmptyDataFromDB_Return200AndEmptyListInResponseBody()
    {
        var mockService = new Mock<IPostTagService>();
        mockService.Setup(p => p.GetAll()).Returns(new List<PostTagDto>());

        var ctrl = new PostTagController(mockService.Object);
        var result = ctrl.GetAll();
        var ok = result as OkObjectResult;

        Assert.NotNull(ok);
        Assert.Equal(200, ok.StatusCode);
        var respBody = ok.Value as ResponseSuccess<List<PostTagDto>>;
        Assert.NotNull(respBody);
        Assert.Empty(respBody.Data);

        mockService.Verify(v => v.GetAll(), Times.Once);
    }
    
    [Fact]
    public void GetAll_GetPostDataSuccess_Return200WithData()
    {
        var mockService = new Mock<IPostTagService>();
        mockService.Setup(p => p.GetAll()).Returns(SetupData());

        var ctrl = new PostTagController(mockService.Object);
        var result = ctrl.GetAll();
        var ok = result as OkObjectResult;

        Assert.NotNull(ok);
        Assert.Equal(200, ok.StatusCode);
        var respBody = ok.Value as ResponseSuccess<List<PostTagDto>>;
        Assert.NotNull(respBody);
        Assert.Equal(2,respBody.Data.Count);
        var resp1 = respBody.Data[0];
        Assert.Equal("b3d9e7a8-3c31-4aed-9984-c65c14ef0795", resp1.Id.ToString());
        Assert.Equal("javascript", resp1.Name);
        var resp2 = respBody.Data[1];
        Assert.Equal("b3ce1341-d10c-429f-954b-854f55aef90b", resp2.Id.ToString());
        Assert.Equal("webdev", resp2.Name);

        mockService.Verify(v => v.GetAll(), Times.Once);
    }

    private List<PostTagDto> SetupData()
    {
        return new List<PostTagDto>
        {
            new()
            {
                Id = new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"),
                Name = "javascript",
            },
            new()
            {
                Id = new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"),
                Name = "webdev",
            },
        };
    }
}