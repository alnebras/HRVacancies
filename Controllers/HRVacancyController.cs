using HRVacancies.Dtos;
using HRVacancies.Models;
using HRVacancies.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRVacancies.Controllers
{
    //[Authorize(Roles = "NormalUser")] 
    [AllowAnonymous]
    public class HRVacancyController : Controller
    {
        private readonly IHRVacancyRepository _HRVacancy;
        private readonly UserManager<ApplicationUser> _userManager;
 
        public HRVacancyController(IHRVacancyRepository hRVacancy, UserManager<ApplicationUser> userManager)
        {
            _HRVacancy = hRVacancy;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            //var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var user = await _userManager.FindByIdAsync(userId);  

            //var role = await _userManager.GetRolesAsync(user);

            var model = new HRVacancyVM
            {
                HRVacanciesList = await _HRVacancy.GetHRVacancies()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddHRVcancy(HRManagerVacancy model)
        {

            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            model.UserId = userId;
            model.CreatedBy = userId;
            model.CreatedOn = DateTime.Now;

            await _HRVacancy.AddHRVacancy(model);

            var vacancies = new HRVacancyVM
            {
                HRVacanciesList = await _HRVacancy.GetHRVacancies()
            };

            return View("Index", vacancies);

        }

        [HttpGet]
        public async Task<IActionResult> EditHRVacancy([FromQuery(Name = "Id")] int Id)
        {
            var vacancy = await _HRVacancy.GetHRVacancyById(Id);

            return View("_EditHRVcancyForm", vacancy);
        }

        [HttpPost]
        public async Task<IActionResult> EditHRVacancy(HRManagerVacancy model)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            model.UserId = userId;
            model.UpdatedBy = userId;
            model.UpdatedOn = DateTime.Now;

            await _HRVacancy.EditHRVacancy(model);

            var vacancies = new HRVacancyVM
            {
                HRVacanciesList = await _HRVacancy.GetHRVacancies()
            };

            return View("Index", vacancies);
        }

    }
}
