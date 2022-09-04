using AutoComplete.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoComplete.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetStaticAutoComplete(string? term)
        {
            term = term ?? string.Empty;
            var terms = term.Split('\u0020').ToList();

            var api = new GitHubAPI();
            var res = api.SearchIssues(terms);
            var result = res.items
                .Select(item => new
                {
                    value = item.name,
                    label = item.display_name,
                    desc = trimDescription(item.description)
                })
                .Where(item => !String.IsNullOrWhiteSpace(item.label))
                .ToList();

            return Json(result);
        }

        private string trimDescription(string desc)
        {
            var maxLength = 40;

            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(desc))
            {
                result = desc.Length <= maxLength ? desc : desc.Substring(0, maxLength) + " ... ";
            }

            return result;
        }
    }
}