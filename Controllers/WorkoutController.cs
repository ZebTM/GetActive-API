using Microsoft.AspNetCore.Mvc;
using GetActive_API.Models;
using GetActive_API.DatabaseContext;
using Microsoft.EntityFrameworkCore;
namespace GetActive_API.Controllers;

[ApiController]
[Route("workouts")]
public class WorkoutController : ControllerBase
{
    private readonly MyDatabaseContext _dbcontext;

    public WorkoutController(MyDatabaseContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    [HttpGet]
    public async Task<IActionResult> GetWorkouts()
    {
        try {
            List<Workout> workouts = _dbcontext.workouts
                .Include(w => w.Exercises)
                .ToList();

            return Ok(workouts);
        } catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetWorkout(Guid id)
    {
        try {
            Workout? workout = await _dbcontext.workouts
                .Include(w => w.Exercises)
                .FirstOrDefaultAsync(x => x.Id == id);

            return Ok(workout);
        } catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkout(NewWorkout _workout)
    {
        try {
            Guid id = Guid.NewGuid();

            Workout workout = new Workout()
            {
                Id = id,
                Title = _workout.Title,
            };

            await _dbcontext.workouts.AddAsync(workout);
            foreach( NewExercise _exercise in _workout.Exercises)
            {
                Exercise exercise = new Exercise()
                {
                    id = Guid.NewGuid(),
                    workoutid = id,
                    title = _exercise.Title,
                    sets = _exercise.Sets,
                    reps = _exercise.Reps
                };
                
                await _dbcontext.exercises.AddAsync(exercise);
            }

            await _dbcontext.SaveChangesAsync();
            
            return Ok(_workout);
        } catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteWorkout(Guid Id)
    {
        Workout? workout = await _dbcontext.workouts.FindAsync(Id);
        if (workout != null)
        {  
            List<Exercise> exercise = _dbcontext.exercises.Where(e => e.workoutid == workout.Id).ToList<Exercise>();

            exercise.ForEach(e => _dbcontext.exercises.Remove(e));
            _dbcontext.workouts.Remove(workout);

            _dbcontext.SaveChanges();
            return Ok(workout);
        }
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> EditWorkout(Workout workout)
    {
        Workout? dbWorkout = await _dbcontext.workouts.FindAsync(workout.Id);
        if (dbWorkout != null)
        {
            dbWorkout.Title = workout.Title;
        } else 
        {
            await _dbcontext.workouts.AddAsync(workout);
        }

        return Ok(workout);
    }
}