using System;
using System.Threading.Tasks;

namespace AppointmentsApi.Services
{
    public interface ILookupDoctorAppointmentTimes
    {
        Task<DateTime> GetNextAvailableAppointmentFor(string doctor);
    }
}