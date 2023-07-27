using Microsoft.AspNetCore.Mvc;
using GetActive_API.Models;
using GetActive_API.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace GetActive_API.Controllers;

[ApiController]
[Route("posts")]
public class PostController : ControllerBase
{
    private readonly MyDatabaseContext _dbcontext;

    public PostController(MyDatabaseContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts()
    {
        try {
            List<Post> posts = _dbcontext.fitness_posts
                .Include(p => p.Workout)
                .Include(w => w.Workout.Exercises)
                .ToList();

            return Ok(posts);
        } catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetPost(Guid id)
    {
        try {
            Post? post = await _dbcontext.fitness_posts
                .Include(w => w.Workout)
                .Include(p => p.Workout.Exercises)
                .FirstOrDefaultAsync(x => x.id == id);

            return Ok(post);
        } catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePosts(NewPost _post)
    {
        try {
            Guid id = Guid.NewGuid();
            Post post = new Post()
            {
                id = id,
                title = _post.Title,
                description = _post.Description,
                workoutid = _post.WorkoutId
            };

            await _dbcontext.fitness_posts.AddAsync(post);
            await _dbcontext.SaveChangesAsync();

            return Ok(post);
        } catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    // [HttpDelete]
    // public async Task<IActionResult> DeleteWorkout(Guid Id)
    // {
    //     Workout? workout = await _dbcontext.workouts.FindAsync(Id);
    //     if (workout != null)
    //     {  
    //         List<Exercise> exercise = _dbcontext.exercises.Where(e => e.WorkoutId == workout.Id).ToList<Exercise>();
            
    //         exercise.ForEach(e => _dbcontext.exercises.Remove(e));
    //         _dbcontext.workouts.Remove(workout);

    //         _dbcontext.SaveChanges();
    //         return Ok(workout);
    //     }
    //     return Ok();
    // }

    // [HttpPut]
    // public async Task<IActionResult> EditWorkout(Workout workout)
    // {
    //     Workout? dbWorkout = await _dbcontext.workouts.FindAsync(workout.Id);
    //     if (dbWorkout != null)
    //     {
    //         dbWorkout.Title = workout.Title;
    //     } else 
    //     {
    //         await _dbcontext.workouts.AddAsync(workout);
    //     }

    //     return Ok(workout);
    // }
}