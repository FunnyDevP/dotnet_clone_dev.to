using System.ComponentModel.DataAnnotations.Schema;

namespace clone_dev_to.Models;

[Table("tags")]
public class PostTagModel
{
    public Guid Id { get; set; }

    [Column("name",TypeName = "varchar(30)")]
    public string Name { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    public ICollection<PostModel> Posts { get; set; }
}
