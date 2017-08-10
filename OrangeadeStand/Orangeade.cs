using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Orangeade
    {
        private int cost;
        public List<InventoryItems> oranges;
        public List<InventoryItems> sugars;
        public List<InventoryItems> iceCubes;
        public List<InventoryItems> cups;
        private string pulp;
        private double tart;
        private double sweet;
        private double refresh;

        public int Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }
        public string Pulp
        {
            get
            {
                return pulp;
            }
            set
            {
                pulp = value;
            }
        }
        public double Tart
        {
            get
            {
                return tart;
            }
            set
            {
                tart = value;
            }
        }
        public double Sweet
        {
            get
            {
                return sweet;
            }
            set
            {
                sweet = value;
            }
        }
        public double Refresh
        {
            get
            {
                return refresh;
            }
            set
            {
                refresh = value;
            }
        }

        private void SetRecipie()
        {
            Console.WriteLine("How many oranges would you like per pitcher?");
            oranges = int.Parse(Console.ReadLine());
            Console.WriteLine("How much sugar would you like per pitcher? (in cups)");
            sugar = int.Parse(Console.ReadLine());
            Console.WriteLine("How much pulp will you leave in? (None, Some, or Alot)");
            pulp = Console.ReadLine().ToLower();
            Console.WriteLine("How many icecubes will you put in each cup?");
            ice = int.Parse(Console.ReadLine());
        }
        private void SetCost()
        {
            Console.WriteLine("How many Reales will you sell your orangeade for?");
            cost = int.Parse(Console.ReadLine());
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
