using System;
using System.Threading;
using System.Threading.Tasks;
using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;
using PantherParking.Data.Models.Administration;
using PantherParking.Data.Models.enumerations;

namespace PantherParking.Data.DAL.Repositories
{
    public class AdministrationRepository : BaseRepository, IAdministrationRepository
    {
        private AcademicCalendarSeason GetSeason(int month)
        {
            AcademicCalendarSeason season;

            if (month >= 8)
            {
                season = AcademicCalendarSeason.Fall;
            }//if
            else if (month >= 5)
            {
                season = AcademicCalendarSeason.Summer;
            }//else if
            else
            {
                season = AcademicCalendarSeason.Spring;
            }//else

            return season;
        }

        public bool SetAcademicCalendar(DateTime begin, DateTime end)
        {
            int year = begin.Year;
            AcademicCalendarSeason season = this.GetSeason(begin.Month);

            AcademicCalendar calendar = new AcademicCalendar
            {
                beginDateTime = begin,
                season = season,
                year = year
            };

            return false;
        }

        public bool SetHoliday(DateTime holiday)
        {
            AcademicCalendarSeason season = this.GetSeason(holiday.Month);
            int year = holiday.Year;

            throw new NotImplementedException();
        }
    }
}