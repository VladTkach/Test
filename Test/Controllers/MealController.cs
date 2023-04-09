using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly HackDbContext _context;

        public MealController(HackDbContext context)
        {
            _context = context;
        }

        // GET: api/TestMeal
        [HttpGet/*("{calories}")*/]
        public async Task<ActionResult<IEnumerable<RootObject>>> GetMeal(/*int calories*/)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/mealplans/generate?timeFrame=day&targetCalories=2000&diet=vegetarian&exclude=shellfish%2C%20olives"),
                Headers =
    {
        { "X-RapidAPI-Key", "191afd9e9fmsh756a2a18b2f1ee9p1b9d0djsn1d76b609e3d8" },
        { "X-RapidAPI-Host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" },
    },
            };
            string jsonString;
            using (var response = await client.SendAsync(request))
            {
                Debug.WriteLine(response);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Debug.WriteLine("Body:");
                Debug.WriteLine(body);
                Debug.WriteLine("End");
                jsonString = await response.Content.ReadAsStringAsync();
            }


            Debug.WriteLine(jsonString);
            RootObject root = JsonConvert.DeserializeObject<RootObject>(jsonString);

            List<Meal> meals = root.Meals;

            foreach (Meal meal in meals)
            {
                meal.PrintMeal();
            }

            /*if (_context.TestMeal == null)
          {
              return NotFound();
          }*/
            return Ok(root);
            /*return await _context.TestMeal.ToListAsync();*/
        }

        // GET: api/TestMeals/5
       /* [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetMeal(int id)
        {
            if (_context.Meal == null)
            {
                return NotFound();
            }
            var testMeal = await _context.Meal.FindAsync(id);

            if (testMeal == null)
            {
                return NotFound();
            }

            return testMeal;
        }*/

        // PUT: api/TestMeals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestMeal(int id, Meal testMeal)
        {
            if (id != testMeal.Id)
            {
                return BadRequest();
            }

            _context.Entry(testMeal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestMealExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TestMeals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Meal>> PostTestMeal(Meal testMeal)
        {
            if (_context.Meal == null)
            {
                return Problem("Entity set 'HackDbContext.Meal'  is null.");
            }
            _context.Meal.Add(testMeal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeal", new { id = testMeal.Id }, testMeal);
        }

        // DELETE: api/TestMeals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestMeal(int id)
        {
            if (_context.Meal == null)
            {
                return NotFound();
            }
            var testMeal = await _context.Meal.FindAsync(id);
            if (testMeal == null)
            {
                return NotFound();
            }

            _context.Meal.Remove(testMeal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestMealExists(int id)
        {
            return (_context.Meal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
