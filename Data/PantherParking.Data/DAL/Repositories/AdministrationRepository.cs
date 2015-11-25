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

        public async Task<bool> SetAcademicCalendar(DateTime begin, DateTime end)
        {
            int year = begin.Year;
            AcademicCalendarSeason season = this.GetSeason(begin.Month);
            
            
            AcademicCalendar calendar = BaseParseObject.CreateMe<AcademicCalendar>();
            calendar.beginDateTime = begin;
            calendar.season = season;
            calendar.year = year;

            calendar.Build();

            Task saveTask = calendar.SaveAsync();

            switch (saveTask.Status)
            {
                case TaskStatus.Created:
                    return await Task.FromResult(true);
                case TaskStatus.WaitingForActivation:
                case TaskStatus.WaitingToRun:
                case TaskStatus.Running:
                case TaskStatus.WaitingForChildrenToComplete:
                case TaskStatus.RanToCompletion:
                case TaskStatus.Canceled:
                case TaskStatus.Faulted:
                default:
                    return await Task.FromResult(false);
            }//switch
        }

        public async Task<bool> SetHoliday(DateTime holiday)
        {
            AcademicCalendarSeason season = this.GetSeason(holiday.Month);
            int year = holiday.Year;

            throw new NotImplementedException();
        }
    }
}