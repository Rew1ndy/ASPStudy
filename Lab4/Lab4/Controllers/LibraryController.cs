using Lab4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    [Route("Library")]
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Content("Welcome to Library");
        }

        [HttpGet("Books")]
        public IActionResult Books()
        {
            var books = _libraryService.GetBooks();
            return Json(books);
        }

        [HttpGet("Profile/{id?}")]
        public IActionResult Profile(int? id)
        {
            var users = _libraryService.GetUsers();
            if (id.HasValue && id >= 0 && id <= 5)
            {
                var user = users.FirstOrDefault(x => x.Id == id.Value);
                if (user != null)
                {
                    return Json(user);
                }
                return NotFound("User not Found");
            }
            else
            {
                var currentUser = users.FirstOrDefault(x => x.Id == 0);
                return Json(currentUser);
            }
        }
    }
}
