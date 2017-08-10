using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Weather
    {
        public bool isNice;
        public int cloudCoverage;
        private string weatherType;
        public int temperature;
        private bool isPercipitating;
        private int percipitationChance;
        private string percipitationType;
        public int percipitationModifier;
        Random random = new Random();
        List<string> perciptitationOptions = new List<string> { "drizzle", "rain", "monsoon" };

        public string PercipitationType
        {
            get
            {
                return percipitationType;
            }
        }
        public int PercipitationChance
        {
            get
            {
                return percipitationChance;
            }
            set
            {
                percipitationChance = value;
            }
        }
        public string WeatherType
        {
            get
            {
                return weatherType;
            }
        }

        public Weather()
        {
            getCloudCoverage();
            getPercipitationChance();
            CheckIfPercipitating();
            GetPercipitationType();
            getTemperature();
            GetWeatherType();
        }
        public Weather(int temperature, int percipitationChance)
        {
            getCloudCoverage();
            this.percipitationChance = percipitationChance + random.Next(-20, 20);
            CheckIfPercipitating();
            GetPercipitationType();
            this.temperature = temperature + random.Next(-10, 10);
            GetWeatherType();
        }
        private void getPercipitationChance()
        {
            percipitationChance = random.Next(1, 100);
        }
        private void CheckIfPercipitating()
        {
            int percipitationCheck;
            percipitationCheck = random.Next(1, 100);
            if (percipitationCheck <= percipitationChance)
            {
                isPercipitating = true;
            }
            else
            {
                isPercipitating = false;
            }
        }
        private void GetPercipitationType()
        {
            if (isPercipitating)
            {
                int percipitationSelector = random.Next(1, 3);
                percipitationType = perciptitationOptions[percipitationSelector];
            }
            else
            {
                percipitationType = "none";
            }
        }
        private void getCloudCoverage()
        {
            cloudCoverage = random.Next(1, 100);
        }
        private void GetWeatherType()
        {
            if (cloudCoverage > 80)
            {
                weatherType = "Overcast";
                isNice = false;
            }
            else if (cloudCoverage > 50)
            {
                weatherType = "Party Cloudy";
                isNice = false;
            }
            else if (cloudCoverage > 20)
            {
                weatherType = "Mostly Sunny";
                isNice = true;
            }
            else
            {
                weatherType = "Sunny";
                isNice = true;
            }
        }
        private void getTemperature()
        {
            temperature = random.Next(50, 110);
        }
        private void GetPerciptiationModifiers()
        {
            switch(percipitationType)
            {
                case "none":
                percipitationModifier = 0;
                    break;
                case "rain":
                    percipitationModifier = 10;
                    break;
                case "drizzle":
                    percipitationModifier = 5;
                    break;
                case "monsoon":
                    percipitationModifier = 20;
                    break;
                default:
                    break;
            }
        }

    }
}
