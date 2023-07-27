using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GetActive_API.Models;

public class Exercise
{
    public Guid id { get; set; }
    public string title { get; set; } = String.Empty;
    public int sets { get; set; } = 0;
    public int reps { get; set; } = 0;
    public Guid workoutid { get; set; } 
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