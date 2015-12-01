using Newtonsoft.Json;
using PantherParking.Data.Models.enumerations;

namespace PantherParking.Data.Models
{
    public class Calendar: BaseModel
    {
        public string semesterID { get; set; }
        public int year { get; set; }
        public System.DateTime? startDate { get; set; }
        public System.DateTime? endDate { get; set; }
        public System.DateTime ?holiday1 { get; set; }
        public System.DateTime ?holiday2 { get; set; }
        public System.DateTime ?holiday3 { get; set; }
        public System.DateTime ?holiday4 { get; set; }
        public System.DateTime ?holiday5 { get; set; }
        public System.DateTime ?holiday6 { get; set; }
        public System.DateTime ?holiday7 { get; set; }
        public System.DateTime ?holiday8 { get; set; }
        public System.DateTime ?holiday9 { get; set; }
        public AcademicCalendarSeason season { get; set; }
    }
}