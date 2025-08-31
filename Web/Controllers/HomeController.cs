using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Services.Interfaces;
using Portfolio.Domain.Models;
using Portfolio.Shared.DTO;

namespace Portfolio.Web.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IProjectEntityService service)
        : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IProjectEntityService _service = service;

        public IActionResult Index()
        {
            var projectsViewModel = new HomeViewModel()
            {
                User = new UserEntity()
                {
                    Names = "Daniel",
                    LastNames = "Mora Cantillo",
                    BirthDay = new DateTime(2005, 8, 31)
                },
                Projects = _service.FindAllAsync().Result.Take(3)
            };
            return View(projectsViewModel);
        }

        public IActionResult Projects()
        {
            var projects = _service.FindAllAsync().Result;
            return View(projects);

        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(MessageEntity message)
        {
            return RedirectToAction("Thanks");
        }

        public IActionResult Thanks()
        {
            return View();
        }
        
        private List<ProjectEntity> GetProjects()
        {
            return 
            [
                new ProjectEntity()
                {
                    Name = "Cab Management System",
                    Description = "Un proyecto RestFul API para administrar taxis hecho en java con Spring Boot",
                    ImageUrl = "images/users_management.png",
                    Link = "#"
                },
                new ProjectEntity()
                {
                    Name = "Users Management System",
                    Description = "Un project RestFul API para administrar usuarios hecho con java Spring boot y SB admin2",
                    ImageUrl = "images/users_management.png",
                    Link = "#"
                },
                new ProjectEntity()
                {
                    Name = "PortFolio",
                    Description = "Este mismo proyecto siendo mi portfolio de presentación hecho con ASP.NET Core MVC",
                    ImageUrl = "images/portfolio.png",
                    Link = "#"
                },
                new ProjectEntity()
                {
                    Name = "Pomodoro - terminal",
                    Description = "Una aplicación nativamente en la terminal que ejecuta un temporizador tipo pomodoro, hecha completamente en java",
                    ImageUrl = "images/pomodoro-terminal.png",
                    Link = "https://github.com/Frame-Code/pomodoro_terminal"
                },
                new ProjectEntity()
                {
                    Name = "Library Management System",
                    Description = "Una aplicación de escritorio hecha completamente en java para administrar una librería",
                    ImageUrl = "images/library_management.png",
                    Link = "https://github.com/Frame-Code/Library-Management-System/releases/tag/v1.0"
                }
            ];
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
