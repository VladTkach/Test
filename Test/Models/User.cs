using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Test.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        public void Print()
        {
            Debug.WriteLine($"User ID: {UserId}");
            Debug.WriteLine($"User Name: {UserName}");
            Debug.WriteLine($"Email: {Email}");
        }
    }
}
