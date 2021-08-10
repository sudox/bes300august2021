using AppointmentsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentsApi.Controllers
{
    public class AppointmentsController : ControllerBase
    {
        private readonly ILookupDoctorAppointmentTimes _appointmentLookup;

        public AppointmentsController(ILookupDoctorAppointmentTimes appointmentLookup)
        {
            _appointmentLookup = appointmentLookup;
        }

        [HttpPost("appointments")]
        public async Task<ActionResult> ScheduleAnAppointment([FromBody] PostAppointmentRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var random = new Random();
                var response = new PostAppointmentResponse(
                    request.For,
                    request.With,
                    await _appointmentLookup.GetNextAvailableAppointmentFor(request.With));

                return Ok(response);
            }
        }
    }

    public record PostAppointmentRequest
    {
        [Required]
        public string For { get; init; }
        [Required]
        public string With { get; init; }
    }

    public record PostAppointmentResponse(string For, string With, DateTime When);
}
