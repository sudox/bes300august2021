using System;
using System.Threading.Tasks;

namespace AppointmentsApi.Services
{
    public interface ICalendarApi
    {
        Task<DateTime> GetNextDateAsync();
    }
}