using System;
using System.Collections.Generic;
using clone_dev_to.Models;
using clone_dev_to.Repositories;
using clone_dev_to.Services;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace clone_dev_to_test.Services;

public class PostServiceTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public PostServiceTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void GetAll_PostDataOnDbIsEmpty_ReturnEmptyListOfPostDto()
    {
        var mockPostRepo = new Mock<IRepository<PostModel>>();
        mockPostRepo.Setup(r => r.GetAll()).Returns(new List<PostModel>());

        var service = new PostService(mockPostRepo.Object);
        var resultGetAll = service.GetAll();

        Assert.Empty(resultGetAll);
        mockPostRepo.Verify(v => v.GetAll(), Times.Once);
    }

    [Fact]
    public void GetAll_GetPostDataSuccess_ReturnPostDto()
    {
        var mockPostRepo = new Mock<IRepository<PostModel>>();
        mockPostRepo.Setup(r => r.GetAll()).Returns(SetupPostData());

        var service = new PostService(mockPostRepo.Object);
        var resultGetAll = service.GetAll();

        Assert.Equal(2, resultGetAll.Count);

        var postData1 = resultGetAll[0];

        Assert.Equal("0242f16c-2e5d-4839-ba0d-bb90842bd98a", postData1.UserId.ToString());
        Assert.Equal("John F. Night", postData1.FullName);
        Assert.Equal(new DateTime(2021, 12, 13, 7, 0, 0), postData1.PublicationDate);
        Assert.Equal("f3e8cd3e-6951-46e3-a191-4648fa993a1a", postData1.BlogId.ToString());
        Assert.Equal("test_title_01", postData1.BlogTitle);
        Assert.Equal("test_detail_01", postData1.BlogDetail);
        Assert.Equal(2, postData1.BlogTags.Count);
        Assert.Equal("b3ce1341-d10c-429f-954b-854f55aef90b", postData1.BlogTags[0].Id.ToString());
        Assert.Equal("webdev", postData1.BlogTags[0].Name);
        Assert.Equal("b3d9e7a8-3c31-4aed-9984-c65c14ef0795", postData1.BlogTags[1].Id.ToString());
        Assert.Equal("javascript", postData1.BlogTags[1].Name);

        var postData2 = resultGetAll[1];
        Assert.Equal("50249762-0f32-4f3d-9704-ff9e5863bc86", postData2.UserId.ToString());
        Assert.Equal("Funny Dev", postData2.FullName);
        Assert.Equal(new DateTime(2021, 12, 13, 8, 0, 0), postData2.PublicationDate);
        Assert.Equal("e771a9c5-0f33-481c-bc83-62d929f4ae7f", postData2.BlogId.ToString());
        Assert.Equal("test_title_02", postData2.BlogTitle);
        Assert.Equal("test_detail_02", postData2.BlogDetail);
        Assert.Equal(3, postData2.BlogTags.Count);
        Assert.Equal("b3d9e7a8-3c31-4aed-9984-c65c14ef0795", postData2.BlogTags[0].Id.ToString());
        Assert.Equal("javascript", postData2.BlogTags[0].Name);
        Assert.Equal("d6b1de80-e44e-412e-957e-8a7e64d494f9", postData2.BlogTags[1].Id.ToString());
        Assert.Equal("beginners", postData2.BlogTags[1].Name);
        Assert.Equal("daf5829d-25d3-4f36-b7f6-e6c8ba26bcd0", postData2.BlogTags[2].Id.ToString());
        Assert.Equal("programming", postData2.BlogTags[2].Name);
    }

    private List<PostModel> SetupPostData()
    {
        return new List<PostModel>
        {
            new()
            {
                Id = new Guid("f3e8cd3e-6951-46e3-a191-4648fa993a1a"),
                Title = "test_title_01",
                Detail = "test_detail_01",
                PublicationDate = new DateTime(2021, 12, 13, 7, 0, 0).ToUniversalTime(),
                Tags = new List<PostTagModel>
                {
                    new()
                    {
                        Id = new Guid("b3ce1341-d10c-429f-954b-854f55aef90b"),
                        Name = "webdev"
                    },
                    new()
                    {
                        Id = new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"),
                        Name = "javascript"
                    },
                },
                UserId = new Guid("0242f16c-2e5d-4839-ba0d-bb90842bd98a"),
                User = new UserModel {Id = new Guid("0242f16c-2e5d-4839-ba0d-bb90842bd98a"), FullName = "John F. Night"}
            },
            new()
            {
                Id = new Guid("e771a9c5-0f33-481c-bc83-62d929f4ae7f"),
                Title = "test_title_02",
                Detail = "test_detail_02",
                PublicationDate = new DateTime(2021, 12, 13, 8, 0, 0).ToUniversalTime(),
                Tags = new List<PostTagModel>
                {
                    new()
                    {
                        Id = new Guid("b3d9e7a8-3c31-4aed-9984-c65c14ef0795"),
                        Name = "javascript"
                    },
                    new()
                    {
                        Id = new Guid("d6b1de80-e44e-412e-957e-8a7e64d494f9"),
                        Name = "beginners"
                    },
                    new()
                    {
                        Id = new Guid("daf5829d-25d3-4f36-b7f6-e6c8ba26bcd0"),
                        Name = "programming"
                    }
                },
                UserId = new Guid("50249762-0f32-4f3d-9704-ff9e5863bc86"),
                User = new UserModel {Id = new Guid("50249762-0f32-4f3d-9704-ff9e5863bc86"), FullName = "Funny Dev"}
            }
        };
    }
}