using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CategoryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private string weather = "Solar Index Service, Weather Forecast Service, Wind Intensity Service";
        private string news = "News Service";
        private string extra = "Time Service, FindStore Service, WordCount Service, Joke Generator Service";
        private string backend = "Catalog Service, Bank Service, Subscription Service, Encryption Service";

        // returns services available for the category
        public string GetItems(string category)
        {
            if (category.ToLower() == "weather")
                return weather;
            if (category.ToLower() == "news")
                return news;
            if (category.ToLower() == "extra")
                return extra;
            if (category.ToLower() == "backend")
                return backend;

            return "Invalid Category, use CatalogTypes to see list of categories";
        }

        // returns the category types
        public string CategoryTypes()
        {
            return "Weather, News, Backend, Extra";
        }
    }
}
