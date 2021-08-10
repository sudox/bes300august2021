using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppointmentsApi.Services
{
    public class CalendarHttpClient : ICalendarApi
    {
        private readonly HttpClient _httpClient;

        public CalendarHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<DateTime> GetNextDateAsync()
        {
            var response = await _httpClient.GetAsync("/availabledates");
            if(response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var responseObject = JsonSerializer.Deserialize<GetDateResponse>(responseJson);
                return responseObject.date;
            }
            else
            {
                // do something
                return DateTime.Now.AddDays(30);
            }
        }
    }

    public record GetDateResponse(DateTime date);
}
