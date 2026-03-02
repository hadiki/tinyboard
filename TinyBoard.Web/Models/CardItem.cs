using System.ComponentModel.DataAnnotations;

namespace TinyBoard.Web.Models;

public class CardItem
{
    public  Guid Id { get; set; }
    
    [Required, StringLength(100)]
    public string Title { get; set; } = string.Empty;
    
    [StringLength(2000)]
    public string? Notes { get; set; }

    public CardStatus Status { get; set; } = CardStatus.ToDo;
    
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;
}