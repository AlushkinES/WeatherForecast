using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication.Models
{
    public class Weather
    {
        [BsonId] 
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        [BsonElement("WeatherBody")]
        public List<WeatherBody> Body { get; set; }
    }

    public class WeatherBody
    {
        public string Date { get; set; }
        public double Temperature { get; set; }
    }

}