using System.ComponentModel.DataAnnotations.Schema;

namespace GetActive_API.Models;

public class Exercise
{
    [Column("id")]
    public Guid Id { get; set; }
    [Column("workoutid")]
    public Guid WorkoutId { get; set; } 
    [Column("title")]
    public string Title { get; set; } = String.Empty;
    [Column("sets")]
    public int Sets { get; set; } = 0;
    [Column("reps")]
    public int Reps { get; set; } = 0;
}

public class ExerciseModel
{
    public Guid WorkoutId { get; set; } 
    public string Title { get; set; } = String.Empty;
    public int Sets { get; set; } = 0;
    public int Reps { get; set; } = 0;
}

public class NewExercise
{
    public string Title { get; set; } = String.Empty;
    public int Sets { get; set; } = 0;
    public int Reps { get; set; } = 0;
}