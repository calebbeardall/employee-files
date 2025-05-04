using System.Diagnostics;
using EmployeeFilesApp.Models;
using EmployeeFilesApp.Services;
using EmployeeFilesApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeFilesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DepartmentService _departmentService;

        public HomeController(ILogger<HomeController> logger, DepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }


        public IActionResult Index()
        {
            LandingViewModel viewModel = new LandingViewModel();

            viewModel.DepartmentList = _departmentService.GetAllDepartments();

            return View(viewModel);
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
