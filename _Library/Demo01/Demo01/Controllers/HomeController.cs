using System.Diagnostics;
using Demo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index() // Méthode publique d'un controller => correspond à une route http
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public string SayHello()
		{
			return "Hello you";
		}
		// Home/SayHelloA?personne=Guillaume
		public string SayHello(string personne)
		{
			return $"Hello {personne}";
		}

		public string Count(int id)
		{
			string chain = "";
			for (int i = 0; i < id; i++)
			{
				chain += i + ",  ";
			}
			return $"Count {chain}";
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
