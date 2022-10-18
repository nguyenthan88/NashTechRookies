using System.ComponentModel.DataAnnotations;

public class TaskRequestModel
{
    public Guid Id { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    public string Title { get; set; } = null!;

    public bool? IsCompleted { get; set; }
}
