using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_WeatherProject.Context;
using System.Linq;
using WebApi_WeatherProject.Entities;
using System.Reflection.Metadata.Ecma335; // LINQ kullanımı için eklenmeli

namespace WebApi_WeatherProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        WeatherContext context = new WeatherContext();

        // HttpGet metodunun doğru yazımı
        [HttpGet]
        public IActionResult WeatherCityList()
        {
            var values = context.Cities.ToList(); // ToList için doğru using direktifi eklenmeli
            return Ok(values); // Ok fonksiyonu doğru
        }

        [HttpPost]
        public IActionResult CreateWeatherCity(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return Ok("Şehir başarıyla eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            context.Cities.Remove(value);
            context.SaveChanges();
            return Ok("Şehir başarıyla silindi.");
        }

        [HttpPut]
        public IActionResult PutWeatherCity(City city)
        {
            var value = context.Cities.Find(city.CityId);
            value.CityName = city.CityName;
            value.Temp = city.Temp;
            value.Detail = city.Detail;
            value.Country = city.Country;
            context.SaveChanges();
            return Ok("Şehir başarıyla güncellendi.");
        }


        [HttpGet("GetByIdWeatherCity")]

        public IActionResult GetByIdWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            return Ok(value);
        }

        [HttpGet("TotalCityCount")]
        public IActionResult TotalCityCount()
        {
            var value = context.Cities.Count();
            return Ok(value);
        }

        [HttpGet("MaxTempCityName")]
        public IActionResult MaxTempCityName()
        {
            var value = context.Cities.OrderByDescending(x => x.Temp).Select(y => y.CityName).FirstOrDefault();
            return Ok(value);
        }



        [HttpGet("MinTempCityName")]
        public IActionResult MinTempCityName()
        {
            var value = context.Cities.OrderBy(x => x.Temp).Select(y => y.CityName).FirstOrDefault();
            return Ok(value);
        }
    }
}
