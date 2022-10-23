using HRVacancies.Dtos;
using HRVacancies.Models;
using HRVacancies.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRVacancies.Controllers
{
    //[Authorize(Roles = "NormalUser")] // Authorization Based Authentication
    [AllowAnonymous]
    public class HRRequisitionController : Controller
    {
        private readonly IHRRequisitionRepository _HrRequisition;

        public HRRequisitionController(IHRRequisitionRepository requisitionRepository)
        {
            _HrRequisition = requisitionRepository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = new HRRequisitionDto
            {
                hRRequisitionsList = await _HrRequisition.GetHRRequisitions(),

                VacanciesList = await _HrRequisition.GetHRVacancies()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddHRRequisition(HRRequisition model)
        {

            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //model.UserId = userId;
            model.CreatedBy = userId;
            model.CreatedOn = DateTime.Now;

            await _HrRequisition.AddHRRequisition(model);

            var vacancies = new HRRequisitionDto
            {
                hRRequisitionsList = await _HrRequisition.GetHRRequisitions(),
                VacanciesList = await _HrRequisition.GetHRVacancies()
            };

            return View("Index", vacancies);

        }

        [HttpGet]
        public async Task<IActionResult> EditHRRequisition([FromQuery(Name = "Id")] int Id)
        {
            //var requisition = await _HrRequisition.GetHRRequisitionById(Id);

            var requisition = new HRRequisitionDto
            {
                RequisitionName =  _HrRequisition.GetHRRequisitionById(Id).RequisitionName,
                
                VacancyId =  _HrRequisition.GetHRRequisitionById(Id).VacancyId,

                VacanciesList = await _HrRequisition.GetHRVacancies(),
            };

            return View("_EditHRRequisitionForm", requisition);
        }

        [HttpPost]
        public async Task<IActionResult> EditHRRequisition(HRRequisitionVM model)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.CreatedBy = userId;
             model.UpdatedBy = userId;
            model.UpdatedOn = DateTime.Now;

            await _HrRequisition.EditHRRequisition(model);

            var vacancies = new HRRequisitionDto
            {
                hRRequisitionsList = await _HrRequisition.GetHRRequisitions(),
                VacanciesList = await _HrRequisition.GetHRVacancies()
            };

            return View("Index", vacancies);
        }

    }
}
