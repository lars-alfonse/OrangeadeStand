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
        private int CustomerAmounts;
        Weather todaysWeather;
        
        private void GenerateScurveyLevel()
        {
            ScurveyLevel = random.Next(1, 100);
        }
        private void retrieveWeather()
        {

        } 
    }
}
