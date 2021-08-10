using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsApi.Services
{
    public class DoctorAppointmentFinder : ILookupDoctorAppointmentTimes
    {
        private readonly ICalendarApi _calendarApi;

        public DoctorAppointmentFinder(ICalendarApi calendarApi)
        {
            _calendarApi = calendarApi;
        }

        public async Task<DateTime> GetNextAvailableAppointmentFor(string doctor)
        {
            DateTime nextDate = await _calendarApi.GetNextDateAsync();
            // Error handling
            return nextDate;
        }
    }
}
