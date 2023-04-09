using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Test.Models
{
    public class RootObject
    {
        [JsonProperty("meals")]
        public List<Meal> Meals { get; set; }

        [JsonProperty("nutrients")]
        public Dictionary<string, double> Nutrients { get; set; }

        public void PrintData()
        {
            Debug.WriteLine("Meals:");
            foreach (Meal meal in Meals)
            {
                meal.PrintMeal();
            }

            Debug.WriteLine("\nNutrients:");
            foreach (KeyValuePair<string, double> nutrient in Nutrients)
            {
                Debug.WriteLine($"- {nutrient.Key}: {nutrient.Value}");
            }
        }
    }
}

