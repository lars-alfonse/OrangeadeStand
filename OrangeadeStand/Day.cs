using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    public class Day
    {
        Random random = new Random();
        private int dayNumber;
        private int ScurveyLevel;
        public int CustomerAmounts;
        public Weather todaysWeather;
        public Orangeade todaysOrangeade;
        private int sales;
        private int profit;

        public int DayNumber
        {
            get
            {
                return dayNumber;
            }
            set
            {
                dayNumber = value;
            }
        }
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
        public Day(int number)
        {
            dayNumber = number;
            GenerateScurveyLevel();
            todaysWeather = new Weather();
            GetCustomers();
        }
        public Day(Weather prediction, int number)
        {
            GenerateScurveyLevel();
            dayNumber = number;
            GetCurrentWeather(prediction);
            GetCustomers();
        }
        public void AddRecipie(Orangeade currentOrangeAde)
        {
            todaysOrangeade = currentOrangeAde;
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
        public void ReportDay()
        {
            Console.WriteLine($"Day: {dayNumber}\nWeather: {todaysWeather.WeatherType}, Percipitation: {todaysWeather.PercipitationType}, chance: {todaysWeather.PercipitationChance}\nDaily Sales: {sales} Profit: {profit}\nRecipie: Oranges per pitcher - {todaysOrangeade.Oranges}, Cups of Sugar per pitcher - {todaysOrangeade.Sugar}, Ice cubes per cup -  {todaysOrangeade.Ice}, Pulp: {todaysOrangeade.Pulp}");
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
