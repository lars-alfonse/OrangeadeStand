using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Weather
    {
        public int cloudCoverage;
        private string weatherType;
        public int temperature;
        private bool isPercipitating;
        private int percipitationChance;
        private string percipitationType;
        public int percipitationModifier;
        
        Random random = new Random();
        List<string> perciptitationOptions = new List<string> { "drizzle", "rain", "monsoon" };

        public Weather()
        {
            getCloudCoverage();
            getPercipitationChance();
            CheckIfPercipitating();
            GetPercipitationType();
            getTemperature();
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
            }
            else if (cloudCoverage > 50)
            {
                weatherType = "Party Cloudy";
            }
            else if (cloudCoverage > 20)
            {
                weatherType = "Mostly Sunny";
            }
            else
            {
                weatherType = "Sunny";
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
