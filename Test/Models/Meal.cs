using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Test.Models
{
    public class Meal
    {
        [JsonProperty("readyInMinutes")]
        public int ReadyInMinutes { get; set; }

        [JsonProperty("sourceUrl")]
        [Column(TypeName = "nvarchar(255)")]
        public string SourceUrl { get; set; }

        [JsonProperty("servings")]
        public int Servings { get; set; }

        [JsonProperty("id")]
        [Key]
        public int Id { get; set; }

        [JsonProperty("title")]
        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [JsonProperty("imageType")]
        [Column(TypeName = "nvarchar(50)")]
        public string ImageType { get; set; }

        public void PrintMeal()
        {
            Debug.WriteLine($"Ready in minutes: {ReadyInMinutes}");
            Debug.WriteLine($"Source URL: {SourceUrl}");
            Debug.WriteLine($"Servings: {Servings}");
            Debug.WriteLine($"ID: {Id}");
            Debug.WriteLine($"Title: {Title}");
            Debug.WriteLine($"Image type: {ImageType}");
        }
    }
}
