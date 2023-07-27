using System.ComponentModel.DataAnnotations.Schema;

namespace GetActive_API.Models;

public class Post
{
    public Guid id { get; set; }
    public string title { get; set; } = String.Empty;
    public string description { get; set; } = String.Empty;
    public Guid workoutid { get; set; }
    public Workout Workout { get; set; }
}

public class NewPost
{
    public string Title { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public Guid WorkoutId { get; set; }
}