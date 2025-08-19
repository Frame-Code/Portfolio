using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.DTO;
using Portfolio.Models;

namespace Portfolio.Controllers
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
            var projectsViewModel = new HomeViewModel()
            {
                User = new UserEntity()
                {
                    Names = "Daniel",
                    LastNames = "Mora Cantillo",
                    BirthDay = new DateTime(2005, 8, 31)
                },
                Projects = GetProjects().ToList()
            };
            return View(projectsViewModel);
        }

        private List<ProjectEntity> GetProjects()
        {
            return 
            [
                new ProjectEntity()
                {
                    Id = 1,
                    Name = "Cab Management System",
                    Description = "Un proyecto RestFul API para administrar taxis hecho en java con Spring Boot",
                    ImageURL = "images/users_management.png",
                    Link = "#"
                },
                new ProjectEntity()
                {
                    Id = 2,
                    Name = "Users Management System",
                    Description = "Un project RestFul API para administrar usuarios hecho con java Spring boot y bootstrap",
                    ImageURL = "images/users_management.png",
                    Link = "#"
                },
                new ProjectEntity()
                {
                    Id = 3,
                    Name = "PortFolio",
                    Description = "Este mismo proyecto siendo mi portfolio de presentación hecho con ASP.NET Core MVC",
                    ImageURL = "images/portfolio.png",
                    Link = ""
                },
                new ProjectEntity()
                {
                    Id = 4,
                    Name = "Pomodoro - terminal",
                    Description = "Una aplicación nativamente en la terminal que ejecuta un temporizador tipo pomodoro, hecha completamente en java",
                    ImageURL = "images/pomodoro-terminal.png",
                    Link = "https://github.com/Frame-Code/pomodoro_terminal"
                },
                new ProjectEntity()
                {
                    Id = 5,
                    Name = "Library Management System",
                    Description = "Una aplicación de escritorio hecha completamente en java para administrar una librería",
                    ImageURL = "images/users_management.png",
                    Link = "#"
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
