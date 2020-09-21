using System.Collections.Generic;
using MongoDB.Driver;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class WeatherService
    {
        private readonly IMongoCollection<Weather> _weathers;

        public WeatherService(IWeatherDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _weathers = database.GetCollection<Weather>(settings.WeatherCollectionName);
        }

        public List<Weather> Get() =>
            _weathers.Find(weather => true).ToList();

        public Weather Get(string id) =>
            _weathers.Find<Weather>(weather => weather.Id == id).FirstOrDefault();

        public Weather Create(Weather weather)
        {
            _weathers.InsertOne(weather);
            return weather;
        }

        public void Update(string id, Weather weatherIn) =>
            _weathers.ReplaceOne(weather => weather.Id == id, weatherIn);

        public void Remove(Weather weatherIn) =>
            _weathers.DeleteOne(weather => weather.Id == weatherIn.Id);

        public void Remove(string id) => 
            _weathers.DeleteOne(weather => weather.Id == id);
    }
}