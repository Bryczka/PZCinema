using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClientCinemaApp.Services
{
    public static class ApiConnector
    {
        static IpConfig ipConfig = new IpConfig();
        static readonly Uri uri = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");

        public static async Task<List<Ticket>> GetTicketListService(string urlPart)
        {
            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {
                    string responseString = "tickets/" +urlPart;
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Ticket>>(result);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Logging error...");
                    return null;
                }
            }

        }

        public static async Task<FilmShow> GetFilmShowService(int FilmShowId)
        {
            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {
                    string responseString = "filmshows/?id=" + FilmShowId + "&filmshow=filmshow";
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<FilmShow>(result);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Logging error...");
                    return null;
                }
            }
        }

        public static async Task<Film> GetFilmService(int FilmId)
        {

            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {
                    string responseString = "films/" + FilmId;
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Film>(result);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Logging error...");
                    return null;
                }
            }
        }

        public static async Task<List<Price>> GetPriceListService()
        {
            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {
                    string responseString = "prices";
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Price>>(result.ToString());
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    return null;
                }
            }
        }

        public static async Task<Ticket> GetTicketService(string ticket_Id)
        {
            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {                   
                    string checkresponseString = "tickets/?id=" + ticket_Id + "&tick=ticket";
                    HttpResponseMessage responseCheck = await client.GetAsync(checkresponseString);
                    var result = await responseCheck.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Ticket>(result);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    return null;
                }
            }            
        }

        public static async Task<bool> PutTicketService(Ticket ticket)
        {
            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {
                    string responseString = "tickets/" + ticket.Id;
                    var json = JsonConvert.SerializeObject(ticket);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(responseString, content);
                    return true;
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    return false;
                }
            }

        }

        public static async Task<List<Film>> CheckConnection()
        {

            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {
                    DependencyService.Get<IMessage>().ShortAlert("Checking connection...");
                    string ip = "http://" + ipConfig.GetIpAsync() + ":9095/api/";
                    client.BaseAddress = new Uri(ip);
                    HttpResponseMessage response = await client.GetAsync("films");
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Film>>(result);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Fail to connect. Wrong IP address. Try again!");
                    return null;
                }

            }
        }

        public static async Task<bool> LogEmployeeService(string IdEntry, string PasswordEntry)
        {
            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {
                    string responseString = "employees/" + IdEntry;
                    var json = JsonConvert.SerializeObject(BitConverter.ToString(Crypto.Hash(PasswordEntry)));
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(responseString, content);
                    var result = await response.Content.ReadAsStringAsync();
                    return Boolean.Parse(result);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Can not find this ID...");
                    return false;
                }
            }
        }

        public static async Task<List<FilmShow>> GetFilmShowListService(int selectedID)
        {
            using (var client = new HttpClient() { BaseAddress = uri })
            {               
                try
                {
                    string responseString = "filmShows/" + selectedID;
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<FilmShow>>(result);   
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    return null;
                }
            }
        }

        public static async Task<List<Film>> GetFilmListService()
        {
            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("films");
                    var result = await response.Content.ReadAsStringAsync();
                    List<Film> ListFilms = new List<Film>();
                    return JsonConvert.DeserializeObject<List<Film>>(result);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    return null;
                }
            }

        }

        public static async void DeleteUseTicketService(string ticketId)
        {
            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {
                    string responseString = "tickets/" + ticketId;
                    HttpResponseMessage response = await client.DeleteAsync(responseString);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                }
            }
        }

        public static async Task<Room> GetRoomService(int roomId)
        {
            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {
                    string responseString = "rooms/" + roomId;
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var resultRoom = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Room>(resultRoom);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    return null;
                }
            }
        }

        public static async Task<bool> PutTicketService(int ticketId, Ticket ticket)
        {
            using (var client = new HttpClient() { BaseAddress = uri })
            {
                try
                {
                    string responseString = "tickets/" + ticketId;
                    var json = JsonConvert.SerializeObject(ticket);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(responseString, content);
                    return true;
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    return false;
                }
            }
        }

    }
}