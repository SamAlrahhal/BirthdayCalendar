using BirthdayCalendar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCalendar.Service
{
    public static class InternetCalendarService
    {
        
        static string BaseUrl = "https://localhost:44323/api";
        static string PersonUrl = BaseUrl + "api/Person";
        static HttpClient client;

        static InternetCalendarService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };

            
        }
        public static async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            var json = await client.GetStringAsync(PersonUrl);
            var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(json);
            Debug.WriteLine($"People: {people}");
            return people;
        }
    }
}
