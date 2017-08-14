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
        public Orangeade(int cost, int oranges, int sugar, int ice, string pulp)
        {
            this.sugar = sugar;
            this.cost = cost;
            this.ice = ice;
            this.oranges = oranges;
            this.pulp = pulp;
        }
        public void SetRecipie()
        {
            SetCost();
            SetOranges();
            SetSugar();
            SetPulp();
            SetIce();
        }
        private void SetOranges()
        {
            Console.WriteLine("How many oranges would you like per pitcher?");
            try
            {
                oranges = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"Input not recognized please type in an integer");
                SetRecipie();
                return;
            }
        }
        private void SetSugar()
        {
            Console.WriteLine("How much sugar would you like per pitcher? (in cups)");
            try
            {
                sugar = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"Input not recognized please type in an integer");
                SetRecipie();
                return;
            }
        }
        private void SetPulp()
        {
            Console.WriteLine("How much pulp will you leave in? (None, Some, or Alot)");
            pulp = Console.ReadLine().ToLower();
        }
        private void SetIce()
        {
            Console.WriteLine("How many icecubes will you put in each cup?");
            try
            {
                ice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"Input not recognized please type in an integer");
                SetRecipie();
                return;
            }
        }
        private void SetCost()
        {

            Console.WriteLine("How much will you charge per cup?");
            try
            {
                cost = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"Input not recognized please type in an integer");
                SetRecipie();
                return;
            }
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
