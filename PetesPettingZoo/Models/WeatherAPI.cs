using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetesPettingZoo.Models
{
   
        public partial class WeatherAPI
        {
            [JsonProperty("latitude")]
            public double Latitude { get; set; }

            [JsonProperty("daily")]
            public Daily Daily { get; set; }

            [JsonProperty("alerts")]
            public Alert[] Alerts { get; set; }

            [JsonProperty("flags")]
            public Flags Flags { get; set; }

            [JsonProperty("offset")]
            public double Offset { get; set; }

            [JsonProperty("longitude")]
            public double Longitude { get; set; }

            [JsonProperty("timezone")]
            public string Timezone { get; set; }
        }

        public partial class Daily
        {
            [JsonProperty("icon")]
            public string Icon { get; set; }

            [JsonProperty("data")]
            public Datum[] Data { get; set; }

            [JsonProperty("summary")]
            public string Summary { get; set; }
        }

        public partial class Datum
        {
            [JsonProperty("precipIntensity")]
            public double PrecipIntensity { get; set; }

            [JsonProperty("apparentTemperatureMinTime")]
            public long ApparentTemperatureMinTime { get; set; }

            [JsonProperty("apparentTemperatureLowTime")]
            public long ApparentTemperatureLowTime { get; set; }

            [JsonProperty("apparentTemperatureHighTime")]
            public long ApparentTemperatureHighTime { get; set; }

            [JsonProperty("apparentTemperatureHigh")]
            public double ApparentTemperatureHigh { get; set; }

            [JsonProperty("apparentTemperatureLow")]
            public double ApparentTemperatureLow { get; set; }

            [JsonProperty("apparentTemperatureMaxTime")]
            public long ApparentTemperatureMaxTime { get; set; }

            [JsonProperty("apparentTemperatureMax")]
            public double ApparentTemperatureMax { get; set; }

            [JsonProperty("apparentTemperatureMin")]
            public double ApparentTemperatureMin { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }

            [JsonProperty("dewPoint")]
            public double DewPoint { get; set; }

            [JsonProperty("cloudCover")]
            public double CloudCover { get; set; }

            [JsonProperty("humidity")]
            public double Humidity { get; set; }

            [JsonProperty("ozone")]
            public double Ozone { get; set; }

            [JsonProperty("moonPhase")]
            public double MoonPhase { get; set; }

            [JsonProperty("precipAccumulation")]
            public double? PrecipAccumulation { get; set; }

            [JsonProperty("sunsetTime")]
            public long SunsetTime { get; set; }

            [JsonProperty("temperatureMinTime")]
            public long TemperatureMinTime { get; set; }

            [JsonProperty("precipType")]
            public string PrecipType { get; set; }

            [JsonProperty("precipIntensityMaxTime")]
            public long PrecipIntensityMaxTime { get; set; }

            [JsonProperty("precipIntensityMax")]
            public double PrecipIntensityMax { get; set; }

            [JsonProperty("precipProbability")]
            public double PrecipProbability { get; set; }

            [JsonProperty("summary")]
            public string Summary { get; set; }

            [JsonProperty("pressure")]
            public double Pressure { get; set; }

            [JsonProperty("sunriseTime")]
            public long SunriseTime { get; set; }

            [JsonProperty("temperatureLowTime")]
            public long TemperatureLowTime { get; set; }

            [JsonProperty("temperatureHighTime")]
            public long TemperatureHighTime { get; set; }

            [JsonProperty("temperatureHigh")]
            public double TemperatureHigh { get; set; }

            [JsonProperty("temperatureLow")]
            public double TemperatureLow { get; set; }

            [JsonProperty("temperatureMaxTime")]
            public long TemperatureMaxTime { get; set; }

            [JsonProperty("temperatureMax")]
            public double TemperatureMax { get; set; }

            [JsonProperty("temperatureMin")]
            public double TemperatureMin { get; set; }

            [JsonProperty("visibility")]
            public long? Visibility { get; set; }

            [JsonProperty("uvIndex")]
            public long UvIndex { get; set; }

            [JsonProperty("time")]
            public long Time { get; set; }

            [JsonProperty("uvIndexTime")]
            public long UvIndexTime { get; set; }

            [JsonProperty("windGust")]
            public double WindGust { get; set; }

            [JsonProperty("windBearing")]
            public long WindBearing { get; set; }

            [JsonProperty("windGustTime")]
            public long WindGustTime { get; set; }

            [JsonProperty("windSpeed")]
            public double WindSpeed { get; set; }
        }

        public partial class Alert
        {
            [JsonProperty("severity")]
            public string Severity { get; set; }

            [JsonProperty("expires")]
            public long Expires { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("regions")]
            public string[] Regions { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("time")]
            public long Time { get; set; }

            [JsonProperty("uri")]
            public string Uri { get; set; }
        }

        public partial class Flags
        {
            [JsonProperty("sources")]
            public string[] Sources { get; set; }

            [JsonProperty("isd-stations")]
            public string[] IsdStations { get; set; }

            [JsonProperty("units")]
            public string Units { get; set; }
        }
    }


