using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidationEx.Data;
using ValidationEx.ViewModels;

namespace ValidationEx.Controllers
{
    public class MovieController:Controller
    {
        private readonly ValidationExDbContext _db;

        public MovieController(ValidationExDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()  //bütün filmlerin listelendiği sayfa
        {
            return View(_db.Movies.ToList());
        }
        public IActionResult Create()  //doğrulama işlemlerini gösterebilmek adına . bu httpget işlemi için çalışacak olan
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie model)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Add(model);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            ModelState.AddModelError("", "Lütfen gereklilikleri karşılayın!");
            return View(model);
        }


    }
}
