using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.Models;
using PantherParking.Data.Models.Administration;
using PantherParking.Data.Models.enumerations;
using PantherParking.Data.Models.Parse;
using PantherParking.Data.Models.ResponseModels;

namespace PantherParking.Data.DAL.Repositories
{
    public class AdministrationRepository : BaseRepository, IAdministrationRepository
    {
        internal AcademicCalendarSeason GetSeason(int month)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public bool SetAcademicCalendar(DateTime begin, DateTime end, string username, string sessionToken)
        {
            int year = begin.Year;
            AcademicCalendarSeason season = this.GetSeason(begin.Month);

            Calendar calendar = new Calendar
            {
                startDate = begin,
                endDate = end,
                season = season,
                year = year
            };

            Dictionary<string, string> constraints = new Dictionary<string, string>(2)
            {
                {"season", (int) season + ""},
                {"year", year + ""}
            };


            //ResponseDatastore<ObjectGetAllResponse<User>> rr = br.GetObject<ObjectGetAllResponse<User>, User>("", new Dictionary<string, string>(1) { { "username", u.username } });

            ResponseDatastore<ObjectGetAllResponse<Calendar>> calendarParse = base.GetObject< ObjectGetAllResponse<Calendar>,Calendar>(sessionToken, constraints);

            if (calendarParse?.ResponseBody?.results?.Length > 0)
            {
                calendar.updateModel = true;

                ResponseDatastore<ObjectUpdatedResponse> rr = base.UpdateObject(calendar, sessionToken);

                return rr?.ResponseBody?.updatedAt != null;
            }//if
            else
            {
                ResponseDatastore<ObjectCreatedResponse> rr = base.CreateObject<ObjectCreatedResponse>(calendar, sessionToken);
                return rr?.ResponseBody?.createdAt != null;
            }//if
        }

        public bool SetHoliday(DateTime holiday, string username, string sessionToken)
        {
            AcademicCalendarSeason season = this.GetSeason(holiday.Month);
            int year = holiday.Year;


            Calendar calendar = new Calendar
            {
                season = season,
                year = year
            };

            Dictionary<string, string> constraints = new Dictionary<string, string>(2)
            {
                {"season", (int) season + ""},
                {"year", year + ""}
            };


            ResponseDatastore<ObjectGetAllResponse<Calendar>> calendarParse = base.GetObject< ObjectGetAllResponse < Calendar >, Calendar >(sessionToken, constraints);

            if (calendarParse?.ResponseBody?.results?.Length < 1) return false;

            //calendar.updateModel = true;
            Calendar c = calendarParse.ResponseBody.results?[0];
            Type t = typeof(Calendar);
            bool didSet = false;
            for (int i = 1; i < 10; ++i)
            {
                PropertyInfo pi = t.GetProperty("holiday" + i);
                object val = pi?.GetValue(c, null);
                if (val == null) continue;

                pi.SetValue(c, holiday);
                didSet = true;
                break;
            }//for i

            return didSet;
        }
    }
}