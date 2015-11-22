using System;
using Newtonsoft.Json;
using PantherParking.Data.Models.enumerations;

namespace PantherParking.Data.Models.Administration
{
    public class AcademicCalendar : BaseParseObject
    {
        //[JsonProperty("objectID")]
        //public string ID { get; set; }
        //[JsonProperty("beginDateTime")]
        public DateTime beginDateTime { get; set; }
        //[JsonProperty("endDateTime")]
        public DateTime endDateTime { get; set; }
        //[JsonProperty("season")]
        public AcademicCalendarSeason Season { get; set; }
        //[JsonProperty("year")]
        public int year { get; set; }
    }
}