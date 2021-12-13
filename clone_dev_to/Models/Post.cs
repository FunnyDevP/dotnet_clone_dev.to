using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace clone_dev_to.Models;

[Table("posts")]
public class PostModel
{
    public Guid Id { get; set; }

    [Column("title", TypeName = "varchar(100)")]
    [Required]
    public string Title { get; set; }

    [Column("detail",TypeName = "text")]
    [Required]
    public string Detail { get; set; }

    [Column("publication_date")]
    public DateTime PublicationDate { get; set; }

    // Many to Many: Post and Tags
    public ICollection<TagModel> Tags { get; set; }
    
    // One to Many: User and Post
    [Column("user_id")]
    public Guid UserId { get; set; }
    public UserModel User { get; set; }
}
