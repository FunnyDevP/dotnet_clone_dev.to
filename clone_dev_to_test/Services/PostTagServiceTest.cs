using System;
using System.Collections.Generic;
using clone_dev_to.Models;
using clone_dev_to.Repositories;
using clone_dev_to.Services;
using Moq;
using Xunit;

namespace clone_dev_to_test.Services;

public class PostTagServiceTest
{
    [Fact]
    public void GetAll_PostDataTagOnDbIsEmpty_ReturnEmptyListOfPostTagDto()
    {
        var mockPostRepo = new Mock<IRepository<PostTagModel>>();
        mockPostRepo.Setup(r => r.GetAll()).Returns(new List<PostTagModel>());

        var service = new PostTagService(mockPostRepo.Object);
        var resultGetAll = service.GetAll();

        Assert.Empty(resultGetAll);
        mockPostRepo.Verify(v => v.GetAll(), Times.Once);
    }

    [Fact]
    public void GetAll_GetPostTagDataSuccess_ReturnPostDto()
    {
        var mockPostRepo = new Mock<IRepository<PostTagModel>>();
        mockPostRepo.Setup(r => r.GetAll()).Returns(SetupPostTagData());

        var service = new PostTagService(mockPostRepo.Object);
        var resultGetAll = service.GetAll();

        Assert.NotEmpty(resultGetAll);
        Assert.Equal(2, resultGetAll.Count);
        var tag1 = resultGetAll[0];
        Assert.Equal("b3d9e7a8-3c31-4aed-9984-c65c14ef0795", tag1.Id.ToString());
        Assert.Equal("javascript", tag1.Name);
        var tag2 = resultGetAll[1];
        Assert.Equal("b3ce1341-d10c-429f-954b-854f55aef90b", tag2.Id.ToString());
        Assert.Equal("webdev", tag2.Name);

        mockPostRepo.Verify(v => v.GetAll(), Times.Once);
    }

    private List<PostTagModel> SetupPostTagData()
    {
        return new List<PostTagModel>
        {
            new()
            {
                Id = new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"),
                Name = "javascript",
                CreatedDate = DateTime.UtcNow
            },
            new()
            {
                Id = new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"),
                Name = "webdev",
                CreatedDate = DateTime.UtcNow
            },
        };
    }
}