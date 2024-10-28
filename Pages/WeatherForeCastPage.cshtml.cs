using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Controllers;

namespace WebApplication1.Pages
{
    [Authorize]
    public class WeatherForeCastModel : PageModel
    {
        private readonly WeatherForecastController _controller;

        public WeatherForeCastModel(WeatherForecastController controller)
        {
            _controller = controller;
            Forecasts = Enumerable.Empty<WeatherForecast>(); // Initialize Forecasts
        }

        public IEnumerable<WeatherForecast> Forecasts { get; private set; }

        public void OnGet()
        {
            Forecasts = _controller.Get();
        }
    }
}
