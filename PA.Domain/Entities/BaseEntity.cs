using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PA.Domain;
public class BaseEntity
{
    [ScaffoldColumn(false)]
    [Key]
    [Column("id")]
    public long Id { get; set; }
}
