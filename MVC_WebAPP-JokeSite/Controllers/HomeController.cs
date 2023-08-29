using MVC_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_WebApp;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Client;
using MVC_WebAPP_JokeSite.Data;
using MVC_WebAPP_JokeSite.Models;
using MVC_WebAPP_JokeSite.API;
using Microsoft.AspNetCore.Identity;
using MVC_WebAPP_JokeSite.Areas.Identity.Data;
using NuGet.Protocol;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SQLitePCL;
using System.Security.Claims;
using Newtonsoft.Json;

namespace MVC_WebApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserStore<ApplicationUser> _userStore;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationUser _currentUser;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext Context)
        {
            _logger = logger;
            _context = Context;
            _userStore = new UserStore<ApplicationUser>(_context);
            _userManager = new UserManager<ApplicationUser>(_userStore, null, null, null, null, null, null, null, null);     
        }
        [AllowAnonymous]
        public async Task<IActionResult> IndexAsync(int numjokes)
        {
            string currentUserFName = "";
            if (this.User.Identity.Name!= null)
            {
                ApplicationUser CurrentUser = await _userManager.GetUserAsync(User);
                currentUserFName = CurrentUser.FirstName;   
            }
            ViewBag.User = currentUserFName;
            RootModel ReturnRoot = new RootModel();
            ViewData["myString"] = "Welcome to my ASP.NET MVC Joke Site";
            if (numjokes < 2)
            { numjokes = 2; }//single joke is sent as object rather than array of objects. breaks when ienumerable<JokeModel>Jokes = null.
            //possible improvement: add method for numjokes=1 that expects single jokeModel object.
            var APIResults = API.CallAPI(numjokes);//int 2-10
            var res = APIResults.Result;
            ReturnRoot.JokesList = res.jokes.ToList();
            using (_context)
            {
                foreach (JokeModel joke in ReturnRoot.JokesList)
                {
                    joke.id = 0;
                    _context.JokeModel.Add(joke);
                }
                _context.SaveChanges();
            }


            return View(ReturnRoot);
        }
        [AllowAnonymous]
        public IActionResult UserJokes(JokeModel joke)
        {

            return View();
        }
        [HttpPost]
        //[Authorize]
        [AllowAnonymous]
        public IActionResult postUserJokes(JokeModel newJoke)
        {
            newJoke.UserJoke = true;
            using (_context)
            {
                _context.JokeModel.Add(newJoke);
                _context.SaveChanges();
            }

            return View("UserJokes",newJoke);

        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult postUserJokesJSON(JokeModel newJoke)
        {
            newJoke.UserJoke = true;
            using (_context)
            {
                _context.JokeModel.Add(newJoke);
                _context.SaveChanges();
            }
   var result = JsonConvert.SerializeObject(newJoke);


            return Json(result);

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult OutputDB()
        {
            RootModel root = new RootModel();
            using (_context)
            {

                //root.JokesList = _context.JokeModel.OrderByDescending(j => j.userJoke).ToList();
               
                var jokesLists = from j in _context.JokeModel
                                 orderby j.UserJoke descending
                                 select j;

                   root.JokesList = jokesLists.ToList();

            
            }
            return View(root);


        }
        [HttpPost]
        [Authorize]
        public IActionResult resetOutputDB()
        {
            RootModel Root = new RootModel();
            using (_context)
            {
                Root.JokesList = _context.JokeModel.ToList();
                _context.JokeModel.RemoveRange(Root.JokesList);
                _context.SaveChanges();
            }

            return View("OutputDB");
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { Id = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}