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
            
            DetermineThirstLevel(currentWeather);
            DeterminePulpPreference();
            tartPreference = DetermineModifiers();
            sweetPreference = DetermineModifiers();
            DetermineMaxPrice(currentWeather.temperature);
            CollectPurchaseChanceModifiers(currentOrangeade, currentWeather);
            CheckIfWillBuy(currentOrangeade);
        }
        private void DetermineMaxPrice(int temperature)
        {
            maxPrice = temperature/ 2;
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
            thirstModifier = (currentWeather.temperature - 50);
            thirstModifier = thirstModifier / 60;
            thirstLevel = (int)Math.Floor(thirstModifier*100);
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
            purchaseChanceModifier = ((100- (double)Math.Abs(orangadeTrait - customerPreference))/100 ) * 10;
            return purchaseChanceModifier;
        }
        private double CreatePulpPreferenceModifier(string pulpLevel, string pulpPreference)
        {
            if (pulpPreference == pulpLevel)
            {
                return 10;
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
                return 10;
            }
            else
            {
                return -10;
            }
        }
        private void CollectPurchaseChanceModifiers(Orangeade currentOrangeade, Weather currentWeather)
        {
            double tartModifier;
            double sweetModifier;
            double thirstModifier;
            double pulpModifier;
            double weatherModifier;
            double priceModifier;
            priceModifier = DeterminePriceModifier(currentOrangeade.Cost);
            tartModifier = CreatePurchaseChanceModifier(currentOrangeade.Tart, tartPreference);
            sweetModifier = CreatePurchaseChanceModifier(currentOrangeade.Sweet, sweetPreference);
            thirstModifier = CreatePurchaseChanceModifier(currentOrangeade.Refresh, thirstLevel);
            pulpModifier = CreatePulpPreferenceModifier(currentOrangeade.Pulp, pulpPreference);
            weatherModifier = CreateWeatherModifier(currentWeather);
            purchaseChance = (tartModifier + sweetModifier + thirstModifier + pulpModifier + weatherModifier + priceModifier);
        }
        private int DeterminePriceModifier(int cost)
        {
            return (int)(((100 - (double)Math.Abs(cost - maxPrice)) / 100) * 50);
        }
        private void CheckIfWillBuy(Orangeade currentOrangeade)
        {
            int purchaseCheck;
            purchaseCheck = random.Next(1, 50);
            if (purchaseCheck < purchaseChance)
            {
               willBuy = maxPrice >= currentOrangeade.Cost ?  true : false;
                
            }
            else
            {
                willBuy = false;
            }
        }
    }
}
