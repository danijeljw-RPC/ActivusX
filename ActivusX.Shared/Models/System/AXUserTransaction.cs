using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ActivusX.Shared.Models.System;

[Table("ax_user_transactions")]
public class AXUserTransaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("timestamp")]
    public DateTime Timestamp { get; set; } = DateTime.Now;

    [Column("user_name")]
    [MaxLength(100)]
    public string EmailAddress { get; set; } = null!;

    [Column("screen")]
    [MaxLength(50)]
    public string ActivityScreen { get; set; } = null!;
    
    [Column("query")]
    public string Activity { get; set;} = null!;
}