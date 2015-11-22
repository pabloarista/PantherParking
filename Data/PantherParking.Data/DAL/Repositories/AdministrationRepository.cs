using System;
using System.Threading.Tasks;
using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;
using PantherParking.Data.Models.Administration;
using PantherParking.Data.Models.enumerations;

namespace PantherParking.Data.DAL.Repositories
{
    public class AdministrationRepository : BaseRepository, IAdministrationRepository
    {
        
        private async Task<bool> SetStartDate2(DateTime begin)
        {
            int year = begin.Year;
            AcademicCalendarSeason season;
            if (begin.Month >= 8)
            {
                season = AcademicCalendarSeason.Fall;
            }//if
            else if (begin.Month >= 5)
            {
                season = AcademicCalendarSeason.Summer;
            }//else if
            else
            {
                season = AcademicCalendarSeason.Spring;
            }//else
            
            AcademicCalendar calendar = BaseParseObject.CreateMe<AcademicCalendar>();
            calendar.beginDateTime = begin;
            calendar.Season = season;
            calendar.year = year;

            calendar.Build();

            await calendar.SaveAsync();
        }

        public bool SetEndDate(DateTime end)
        {
            throw new NotImplementedException();
        }

        public bool SetHoliday(DateTime holiday)
        {
            throw new NotImplementedException();
        }
    }
}