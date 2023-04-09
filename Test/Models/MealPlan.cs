using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class MealPlan
    {
        [Key]
        public int MealPlanId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Meal")]
        public int Meal1Id { get; set; }
        [ForeignKey("Meal")]
        public int Meal2Id { get; set; }
        [ForeignKey("Meal")]
        public int Meal3Id { get; set; }

        public int? Calories { get; set; }
    }
}
