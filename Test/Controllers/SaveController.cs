using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Test.Models;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveController : ControllerBase
    {
        private readonly HackDbContext _context;

        public SaveController(HackDbContext context)
        {
            _context = context;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostSave(SaveMeal saveMeal)
        {
            Debug.WriteLine("inside save");

            saveMeal.Print();
            MealPlan mealPlan = new MealPlan();

            mealPlan.UserId = saveMeal.user.UserId;

            List<Meal> meals = saveMeal.root.Meals;


            Debug.WriteLine("saving meals");
            foreach (var meal in meals)
            {
                meal.PrintMeal();
               /* _context.Meal.Add(meal);*/
                await _context.SaveChangesAsync();

            }

            await _context.SaveChangesAsync();

            mealPlan.Meal1Id = meals[0].Id;
            mealPlan.Meal2Id = meals[1].Id;
            mealPlan.Meal3Id = meals[2].Id;

            double value;
            bool hasCalories = saveMeal.root.Nutrients.TryGetValue("calories", out value);
            if (hasCalories)
            {
                mealPlan.Calories = (int)value;
            }

            _context.MealPlan.Add(mealPlan);

            await _context.SaveChangesAsync();


            /* Debug.WriteLine("inside");

             var temp = _context.User.Where(x => x.UserName == user.UserName && x.Email == user.Email)
                 .FirstOrDefault();

             if (temp == null)
             {

                 await _context.SaveChangesAsync();
             }
             else
                 user = temp;
 */
            return Ok(saveMeal);

        }
    }
}

