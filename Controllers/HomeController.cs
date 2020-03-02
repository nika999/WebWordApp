using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebWord.Models;
using WebWord.Data;


namespace WebWord.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Instantiate an instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="dbContext">The <see cref="ApplicationDbContext"/> data base context for injection.</param>
        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            //отримуємо з БД всі об'єкти Book
            IEnumerable<Word> words = _dbContext.Words.ToList();

            //повертаємо відображення 
            return View(words);
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
