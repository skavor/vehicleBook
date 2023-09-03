using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text.Json;
using TechTalk.SpecFlow;
using VehiculeAPI.Interfaces;
using VehiculeAPI.Models;
using VehiculeTestDriveMicroservice.Specs.Repositories;

namespace VehiculeTestDriveMicroservice.Specs.StepDefinitions
{
    [Binding]
    public class VehicleStepDefinitions
    {
        private const string BaseAddress = "https://localhost:7038/";
        
        public WebApplicationFactory<Program> Factory { get; }
        public IVehicleService Repository { get; }
        public HttpClient Client { get; set; } = null!;
        private HttpResponseMessage Response { get; set; } = null!;
        public JsonFilesRepository JsonFilesRepo { get; }
       

        private JsonSerializerOptions JsonSerializerOptions { get; } = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true
        }; 

        [Given(@"I am a client")]
        public async Task GivenIamClient()
        {
            try
            {
                Client = Factory.CreateDefaultClient(new Uri(BaseAddress));
                Assert.NotNull(Client);
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        [Given(@"the repository has vehicle data")]
        public async Task GivenTheRepositoryHasWeatherData()
        {
            try
            {
                var weathersJson = JsonFilesRepo.Files["vehicles.json"];
                var weathers = System.Text.Json.JsonSerializer.Deserialize<IList<Vehicle>>(weathersJson, JsonSerializerOptions);
                if (weathers != null)
                    foreach (var weather in weathers)
                        await Repository.AddVehicle(weather);

                
            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        [When(@"I make a GET request")]
        public async Task WhenIMakeGettRequestTo()
        {
            try
            {
               var res =  Repository.GetAllVehicles();
                Response = new HttpResponseMessage
                {
                    Content = new StringContent(JsonConvert.SerializeObject(res), System.Text.Encoding.UTF8, "application/json")
                };
                Assert.NotNull(Response);


            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }

        [Then(@"the response status code should be '(.*)'")]
        public async Task ThenTheResultShouldBe(int statusCode)
        {
           try
            {
                var expected = (HttpStatusCode)statusCode;
                Assert.NotEqual(expected, Response.StatusCode);


            }
            catch (Exception ex)
            {
                Assert.False(false, ex.Message);
            }
        }
    }
}
