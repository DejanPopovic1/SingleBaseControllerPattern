using BestPractice.Database;
using BestPractice.Inputs;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BestPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationContext _context;
        private readonly IEntityRepository<Actor, Guid> _actorRepository;
        private readonly IEntityRepository<Movie, Guid> _movieRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEntityRepository<Actor, Guid> actorRepository, IEntityRepository<Movie, Guid> movieRepository, ApplicationContext context)
        {
            _logger = logger;
            _actorRepository = actorRepository;
            _movieRepository = movieRepository;
            _context = context;
        }

        [HttpPost(Name = "PostActor")]

        public async Task PostActor(ExtendedCreateInput input)
        {
            //await _context.Movies.AddAsync(
            //    new Movie()
            //    {
            //        Name = "test",
            //        Budget = "1000000"
            //    });


            await _context.Actors.AddAsync(
               new Actor()
               {
                   Name = "test",
                   AnnualIncome = "1000000",
                   AdditionalInformation = JsonDocument.Parse(JsonSerializer.Serialize(new Dictionary<string, string>() { { "key1", "value1" }, { "key2", "value2"} }))
               });

            _context.SaveChanges();
        }

        [HttpGet(Name = "GetWeatherForecast")]

        public IEnumerable<WeatherForecast> GetWeather()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "GetWeatherActorData")]

        public async Task GetData()
        {
            var results = await (_actorRepository.FindAllAsync());

            var results2 = await _actorRepository.FindAllByConditionAsync(x => x.Where(y => true), false);
            var results3 = await (_movieRepository.FindAllAsync());
            int i = 1;
        }
    }
}
