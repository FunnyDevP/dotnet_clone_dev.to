namespace clone_dev_to.DTO;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class PostDto
{
    public Guid UserId { get; set; }
    public string FullName { get; set; }
    public DateTime PublicationDate { get; set; }
    public Guid BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogDetail { get; set; }
    public List<Tag> BlogTags { get; set; }
}
