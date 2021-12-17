using System;
using System.Collections.Generic;
using clone_dev_to.Controllers;
using clone_dev_to.DTO;
using clone_dev_to.Models;
using clone_dev_to.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        var ctrl = new PostController(mockService.Object);
        var result = ctrl.GetAll();
        var ok = result as OkObjectResult;

        Assert.NotNull(ok);
        Assert.Equal(200, ok.StatusCode);
        var respBody = ok.Value as ResponseSuccess<List<PostDto>>;
        Assert.NotNull(respBody);
        Assert.Empty(respBody.Data);

        mockService.Verify(v => v.GetAll(), Times.Once);
    }

    [Fact]
    public void GetAll_GetPostDataSuccess_Return200WithData()
    {
        var mockService = new Mock<IPostService>();
        mockService.Setup(p => p.GetAll()).Returns(SetupPostData());

        var ctrl = new PostController(mockService.Object);
        var result = ctrl.GetAll();
        var ok = result as OkObjectResult;

        Assert.NotNull(ok);
        Assert.Equal(200, ok.StatusCode);
        var respBody = ok.Value as ResponseSuccess<List<PostDto>>;
        Assert.NotNull(respBody);
        Assert.Single(respBody.Data);
        var postData1 = respBody.Data[0];

        Assert.Equal("efbb274d-2031-4f1b-b265-fd37177f7c52", postData1.UserId.ToString());
        Assert.Equal("Hello World", postData1.FullName);
        var expectedPubDate = new DateTime(2021, 12, 14, 11, 0, 0, 0);
        Assert.Equal(expectedPubDate, postData1.PublicationDate);
        Assert.Equal("a55d6644-549a-4d65-87e4-a2830a710568", postData1.BlogId.ToString());
        Assert.Equal("test_title", postData1.BlogTitle);
        Assert.Equal("test_detail", postData1.BlogDetail);
        Assert.Single(postData1.BlogTags);
        Assert.Equal("db206b1d-21d1-423b-9362-8624b3330451", postData1.BlogTags[0].Id.ToString());
        Assert.Equal("tag1", postData1.BlogTags[0].Name);
    }

    private List<PostDto> SetupPostData()
    {
        return new List<PostDto>
        {
            new()
            {
                UserId = new Guid("efbb274d-2031-4f1b-b265-fd37177f7c52"),
                FullName = "Hello World",
                PublicationDate = new DateTime(2021, 12, 14, 11, 0, 0, 0),
                BlogId = new Guid("a55d6644-549a-4d65-87e4-a2830a710568"),
                BlogTitle = "test_title",
                BlogDetail = "test_detail",
                BlogTags = new List<Tag>
                {
                    new()
                    {
                        Id = new Guid("db206b1d-21d1-423b-9362-8624b3330451"),
                        Name = "tag1"
                    }
                }
            }
        };
    }
}