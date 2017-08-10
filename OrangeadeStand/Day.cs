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
            GetCustomers();
        }
        public Day(Weather prediction)
        {
            GenerateScurveyLevel();
            GetCurrentWeather(prediction);
            GetCustomers();
        }

        private void GetCurrentWeather(Weather prediction)
        {
            int weatherTest;
            weatherTest = CreateWeatherCheck();
            CheckWeatherAccuracy(weatherTest, prediction);
        }
        private int CreateWeatherCheck()
        {
            return random.Next(1, 3);
        }
        private void  CheckWeatherAccuracy(int weatherTest, Weather prediction)
        {
            switch (weatherTest)
            {
                case 1:
                    todaysWeather = prediction;
                    break;
                case 2:
                    todaysWeather = new Weather(prediction.temperature, prediction.PercipitationChance);
                    break;
                default:
                    todaysWeather = new Weather();
                    break;
            }
        }
        private void GenerateScurveyLevel()
        {
            ScurveyLevel = random.Next(1, 100);
        }
        private void GetCustomers()
        {
            double weatherLoss;
            double customers = random.Next(100, 130);
            weatherLoss = todaysWeather.percipitationModifier + todaysWeather.cloudCoverage;
            CustomerAmounts =  (int)Math.Floor(customers - weatherLoss);
        }
    }
}
