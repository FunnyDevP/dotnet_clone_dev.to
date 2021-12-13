using System.ComponentModel.DataAnnotations.Schema;

namespace clone_dev_to.Models;

[Table("users")]
public class UserModel
{
    public Guid Id { get; set; }
    [Column("full_name",TypeName = "varchar(100)")]
    public string FullName { get; set; }
    
    public ICollection<PostModel> Posts { get; set; }
}