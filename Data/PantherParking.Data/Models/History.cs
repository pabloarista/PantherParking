using Newtonsoft.Json;
using PantherParking.Data.Models.enumerations;

namespace PantherParking.Data.Models
{
    public class History : BaseModel
    {
        public string garageId { get; set; }
        public AcademicCalendarSeason season { get; set; }
        public System.DateTime beginWeek { get; set; }
        public System.DateTime endWeek { get; set; }
        public int countAt9 { get; set; }
        public int countAt10 { get; set; }
        public int countAt11 { get; set; }
        public int countAt12 { get; set; }
        public int countAt13 { get; set; }
        public int countAt14 { get; set; }
        public int countAt15 { get; set; }
        public int countAt16 { get; set; }
        public int countAt17 { get; set; }
        public int countAt18 { get; set; }
    }
}