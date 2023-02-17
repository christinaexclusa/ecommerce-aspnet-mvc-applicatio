using ConcertData.DataModels;
using ConcertData.Enums;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eTickets.Controllers
{
	public class HomeController : Controller
	{
        private readonly IHttpClientFactory httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
		{
            this.httpClientFactory = httpClientFactory;
        }
		
		public IActionResult Index()
		{
			var apiModel = new BaseModel<BandModel>(httpClientFactory);
			BandModel model = new() {
				Id=5,
				FullName = "John Moseley",
				Bio = "Don't have one",
				PreformerCategory = GenreEnum.Country,
				ProfilePictureUrl = @"https://lh3.googleusercontent.com/p/AF1QipOCzZhPE1I7VOx6sqrXTbaaE9DZm2lYkrHYPzCF=s680-w680-h510"
            };
			//var b = apiModel.DeleteByIdAsync(6);
			//var r = apiModel.AddAsync(model);
			var e = apiModel.UpdateAsync(5, model);
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}