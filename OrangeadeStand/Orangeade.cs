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
        private int oranges;
        private int sugar;
        private int ice;
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
        public int Oranges
        {
            get
            {
                return oranges;
            }
            set
            {
                oranges = value;
            }
        }
        public int Sugar
        {
            get
            {
                return sugar;
            }
            set
            {
                sugar = value;
            }
        }
        public int Ice
        {
            get
            {
                return ice;
            }
            set
            {
                ice = value;
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

        public Orangeade()
        {
            sugar = 3;
            oranges = 3;
            ice = 3;
            pulp = "some";
            cost = 10;
            GetTraits();
        }
        public void SetRecipie()
        {
            Console.WriteLine("How much will you charge per cup?");
            cost = int.Parse(Console.ReadLine());
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
