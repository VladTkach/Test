using System.Diagnostics;

namespace Test.Models
{
    public class SaveMeal
    {
        public User user { get; set; }

        public RootObject root { get; set; }
        public void Print()
        {
            user.Print();

            Debug.WriteLine("Meals:");
            root.PrintData();
        }

    }
}
