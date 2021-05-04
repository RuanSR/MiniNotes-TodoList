using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniNotes.Library.Filters;
using MiniNotes.Models.Requests;
using MiniNotes.Models.ViewModels;
using MiniNotes.Data.Repositories;
using MiniNotes.Models;

namespace MiniNotes.Controllers
{
    
    public class IndexController : Controller
    {
        private readonly ILogger<IndexController> _logger;
        private readonly IUserRepository _userRepo;

        public IndexController(ILogger<IndexController> logger, IUserRepository userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("Login") != null)
            {
                return RedirectToAction(nameof(Dashboard));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            if(!ModelState.IsValid)
            {
                return View(request);
            }
            
            var user = await _userRepo.GetUserByLogin(request.Login, request.Password);

            if (user == null)
            {
                ViewBag.Error = "Usuário ou senha incorretos!";
                return View(request);
            }

            HttpContext.Session.SetString("Login", "true");

            return RedirectToAction(nameof(Dashboard));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                TempData["CREATE_ERR_MSG"] = "Erro ao criar usuário!";
                return View(user);
            }

            TempData["CREATED_ACCOUNT_MSG"] = "Conta criada com sucesso!";
            TempData["USER_NAME_ACCOUNT"] = user.UserName;

            _userRepo.AddUser(user);
            return RedirectToAction(nameof(Index));
        }

        [Login]
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
