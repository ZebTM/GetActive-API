using System.ComponentModel.DataAnnotations.Schema;

namespace GetActive_API.Models;

public class Workout
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("title")]
    public string Title { get; set; } = String.Empty;
}

public class WorkoutViewModel
{   
    public Guid Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public IEnumerable<Exercise> Exercises { get; set; } = new List<Exercise>();
}

public class NewWorkout
{
    public string Title { get; set; }
    public IEnumerable<NewExercise> Exercises { get; set; }
}