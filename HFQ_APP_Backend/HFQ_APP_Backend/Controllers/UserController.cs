using HFQ_APP_Backend.Models;
using HFQ_APP_Backend.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace HFQ_APP_Backend.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        private readonly AppSettings _appSettings = new AppSettings();

        [HttpGet]
        [Route("api/user/details")]
        public async Task<UserViewModel> GetUserDetailsAsync()
        {
            UserViewModel userViewModel = new UserViewModel();

            var apiUrl = $"{_appSettings.UserService}/api/test";

            var users = await GetUserList(apiUrl);

            if (users != null)
            {
                //A list of each colour in the data set with the frequency of each colour, order by highest quantity then alphabetically
                // Calculate Colour frequency
                var colourFrequency = users
                    .GroupBy(user => user.FavouriteColour) // Group By Color 
                    .Select(group => new { Colour = group.Key, Count = group.Count() }) // Count Each Colours
                    .OrderByDescending(item => item.Count) // Descending Order By  Colour Count 
                    .ThenBy(item => item.Colour) //Ascending order by Color Name
                    .ToList();

                userViewModel.topColoursBOs = colourFrequency.Select(c => new TopColoursBO() // Assign to Model for Better View 
                {
                    Colour = c.Colour,
                    Count = c.Count
                }).ToList();

                userViewModel.userBOs = users;
                userViewModel.agesBOs = users.Select(x=>x.agesBO).ToList();
            }
            return userViewModel;
        }

        public  async Task<List<UserBO>> GetUserList(string apiUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(apiUrl);
                    return JsonConvert.DeserializeObject<List<UserBO>>(response);
                }
            }
            catch (Exception ex)
            {
               // Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}