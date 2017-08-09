using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeadeStand
{
    class Customer
    {
        private int maxPrice;
        private int thirstLevel;
        private bool willBuy;
        private int tartPreference;
        private int sweetPreference;
        private string pulpPreference;
        private double purchaseChance;
        Random random = new Random();

        public bool WillBuy
        {
            get
            {
                return willBuy;
            }
           private set
            {
                willBuy = value;
            }
        }
        public Customer(Weather currentWeather, Orangeade currentOrangeade)
        {
            DetermineMaxPrice();
            DetermineThirstLevel(currentWeather);
            tartPreference = DetermineModifiers();
            sweetPreference = DetermineModifiers();
        }
        private void DetermineMaxPrice()
        {
            maxPrice = (int)Math.Floor(purchaseChance / 2);
        }
        private void DeterminePulpPreference()
        {
            List<string> pulpOptions = new List<string> { "some", "none", "alot" };
            int pulpSelector;
            pulpSelector = random.Next(1, 3);
            pulpPreference = pulpOptions[pulpSelector];

        }
        private void DetermineThirstLevel(Weather currentWeather)
        {
            double thirstModifier;
            thirstModifier = ((currentWeather.temperature - 50) / 60) * 100 + random.Next(-10, 10);
            thirstLevel = (int)Math.Floor(thirstModifier);
        }
        private int DetermineModifiers()
        {
            int modifier;
            modifier = random.Next(1, 100);
            return modifier;
        }
        private double CreatePurchaseChanceModifier(double orangadeTrait, int customerPreference)
        {
            double purchaseChanceModifier;
            purchaseChanceModifier = (double)Math.Abs(orangadeTrait - customerPreference) / customerPreference *-1;
            return purchaseChanceModifier;
        }
        private double CreatePulpPreferenceModifier(string pulpLevel, string pulpPreference)
        {
            if (pulpPreference == pulpLevel)
            {
                return .2;
            }
            else
            {
                return 0;
            }
        }
        private double CreateWeatherModifier(Weather currentWeather)
        {
            if (currentWeather.isNice)
            {
                return .2;
            }
            else
            {
                return -.2;
            }
        }
        private void CollectPurchaseChanceModifiers(Orangeade currentOrangeade, Weather currentWeather)
        {
            double tartModifier;
            double sweetModifier;
            double thirstModifier;
            double pulpModifier;
            double weatherModifier;
            tartModifier = CreatePurchaseChanceModifier(currentOrangeade.Tart, tartPreference);
            sweetModifier = CreatePurchaseChanceModifier(currentOrangeade.Sweet, sweetPreference);
            thirstModifier = CreatePurchaseChanceModifier(currentOrangeade.Refresh, thirstLevel);
            pulpModifier = CreatePulpPreferenceModifier(currentOrangeade.Pulp, pulpPreference);
            weatherModifier = CreateWeatherModifier(currentWeather);
            purchaseChance = (1 + tartModifier + sweetModifier + thirstModifier + pulpModifier + weatherModifier) * 100;
        }
        private void CheckIfWillBuy(Orangeade currentOrangeade)
        {
            int purchaseCheck;
            purchaseCheck = random.Next(1, 100);
            if (purchaseCheck < purchaseChance && maxPrice <= currentOrangeade.Cost)
            {
                willBuy = true;
            }
            else
            {
                willBuy = false;
            }
        }
    }
}
