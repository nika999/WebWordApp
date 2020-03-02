using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebWord.Models;
using WebWord.Data;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Create()
        {
            return View();
        }

        //метод, що відповідає за додавання даних до БД.
        [HttpPost]
        public IActionResult Create(Word word)
        {
            if (word != null)
            {
                _dbContext.Words.Add(word);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
        // Id отримує через параметр Id word, який потім через змінну ViewBag передається далі у відображення
        public async Task<ActionResult> Learn(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            var word = await _dbContext.Words.FirstOrDefaultAsync(b => b.Id == Id.Value);

            if (word != null)
            {
                return View(word);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Learn(Vocabulary vocabulary)
        {
            if (vocabulary == null)
            {
                return BadRequest();
            }

            var student = await _dbContext.Students
                .FirstOrDefaultAsync(c => c.Id == vocabulary.StudentId);

            if (student == null)
            {
                return BadRequest();
            }

            vocabulary.Student = student;
            vocabulary.Date = DateTime.Now;

            vocabulary.Id = null;

            //додаємо інформацію про купівлю в БД
            _dbContext.Vocabularies.Add(vocabulary);
            //зберігаємо у БД всі зміни
            _dbContext.SaveChanges();


            return View($"You, {student.Person}, added!");
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
