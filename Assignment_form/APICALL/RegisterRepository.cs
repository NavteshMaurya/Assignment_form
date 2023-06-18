using System.Net.Http.Headers;
using Assignment_models;
using Newtonsoft.Json;
namespace Assignment_form.APICALL
{
    public class RegisterRepository : IRegisterRepository
    {
        public async Task<List<City>> CityGet()
        { 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5020/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Post Method
                HttpResponseMessage response = await client.GetAsync("api/Home/CityDetail");

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    List<City> _usrDetail = JsonConvert.DeserializeObject<List<City>>(stringResponse);
                    return _usrDetail;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            return null;
        }

        public async Task<Registration> Registration(Registration obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5020/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //POST Method
                HttpResponseMessage response = await client.PostAsJsonAsync<Registration>("api/Home/Registrationdetail", obj);

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    Registration _usrDetail = JsonConvert.DeserializeObject<Registration>(stringResponse);

                    return _usrDetail;
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                    return null;
                }
            }
        }

        public async Task<List<Alldetail>> ListGet(Alldetail obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5020/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Post Method
                HttpResponseMessage response = await client.GetAsync("api/Home/ListGet");

                if (response.IsSuccessStatusCode)
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    List<Alldetail> _usrDetail = JsonConvert.DeserializeObject<List<Alldetail>>(stringResponse);
                    return _usrDetail;

                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

            return null;
        }

    }
}
