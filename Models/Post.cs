using System.ComponentModel.DataAnnotations.Schema;

namespace GetActive_API.Models;

public class Post
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("title")]
    public string Title { get; set; } = String.Empty;
    [Column("description")]

    public string Description { get; set; } = String.Empty;
    [Column("workoutid")]
    public Guid WorkoutId { get; set; }
}

public class NewPost
{
    [Column("title")]
    public string Title { get; set; } = String.Empty;
    [Column("description")]

    public string Description { get; set; } = String.Empty;
    [Column("workoutid")]
    public Guid WorkoutId { get; set; }
}