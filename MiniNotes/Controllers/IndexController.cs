using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniNotes.Models.Requests;
using MiniNotes.Models.ViewModels;
using MiniNotes_TodoList.Data.Repositories;
using MiniNotes_TodoList.Models;

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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest request)
        {
            var user = await _userRepo.GetUserByLogin(request.Login, request.Password);

            if (user == null)
            {
                ViewBag.Error = "Usuário ou senha incorretos!";
                return View(request);
            }
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
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Dashboard()
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
