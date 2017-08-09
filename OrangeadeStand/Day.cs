using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Day
    {
        Random random = new Random();
        private int ScurveyLevel;
        public int CustomerAmounts;
        public Weather todaysWeather;
        private int sales;
        private int profit;

        public int Sales
        {
            get
            {
                return sales;
            }
            set
            {
                sales = value;
            }
        }
        public int Profit
        {
            get
            {
                return profit;
            }
            set
            {
                profit = value;
            }
        }
        public Day()
        {
            GenerateScurveyLevel();
            todaysWeather = new Weather();
        }
        private void GenerateScurveyLevel()
        {
            ScurveyLevel = random.Next(1, 100);
        }
        private void GetCustomers()
        {
            double weatherLoss;
            double customers = random.Next(100, 130);
            weatherLoss = todaysWeather.percipitationModifier + 50 * (todaysWeather.cloudCoverage / 100);
            CustomerAmounts =  (int)Math.Floor(customers - weatherLoss);
        }
    }
}
