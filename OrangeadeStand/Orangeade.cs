using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Orangeade
    {
        private double cost;
        private double oranges;
        private double sugar;
        private double ice;
        public string pulp;
        public double tart;
        public double sweet;
        public double refresh;

        private void SetRecipie()
        {
            Console.WriteLine("How many oranges would you like per pitcher?");
            oranges = double.Parse(Console.ReadLine());
            Console.WriteLine("How much sugar would you like per pitcher? (in cups)");
            sugar = double.Parse(Console.ReadLine());
            Console.WriteLine("How much pulp will you leave in? (None, Some, or Alot)");
            pulp = Console.ReadLine().ToLower();
            Console.WriteLine("How many icecubes will you put in each cup?");
            ice = double.Parse(Console.ReadLine());
        }
        private void SetCost()
        {
            Console.WriteLine("How many Reales will you sell your orangeade for?");
            cost = double.Parse(Console.ReadLine());
        }
        private void GetTraits()
        {
            refresh = CalculateIngredientPercentage(ice);
            sweet = CalculateIngredientPercentage(sugar);
            tart = CalculateIngredientPercentage(oranges);
        }
        private double CalculateIngredientPercentage(double ingredient)
        {
            return (ingredient / (sugar + ice + oranges)) * 300;
        }
    }
}
