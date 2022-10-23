using HRVacancies.Dtos;
using HRVacancies.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRVacancies.Controllers
{
    [AllowAnonymous]
    public class CandidateController : Controller
    {
        private readonly ICandidateRepository _candidates;

        public CandidateController(ICandidateRepository candidates)
        {
            _candidates = candidates;
        }

        public async Task<IActionResult> Index(string requisitionId)
        {
            if (string.IsNullOrEmpty(requisitionId))
            {
                var model = new CandidatesDto
                {
                    VacanciesList = await _candidates.GetHRVacancies(),

                    RequisitionsList = await _candidates.GetHRRequisitions(),

                    CandidatesList = await _candidates.GetCandidates()
                };
                return View(model);
            }
            else
            {
                var model = new CandidatesDto
                {
                    VacanciesList = await _candidates.GetHRVacancies(),

                    RequisitionsList = await _candidates.GetHRRequisitions(),

                    CandidatesList = await _candidates.GetCandidatesByRequisitionId(requisitionId)
                };
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate(CandidatesDto model)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            model.CreatedBy = userId;

            model.CreatedOn = DateTime.Now;

            var response = await _candidates.AddCandidate(model);

            var candidate = new CandidatesDto
            {
                VacanciesList = await _candidates.GetHRVacancies(),

                RequisitionsList = await _candidates.GetHRRequisitions(),

                CandidatesList = await _candidates.GetCandidates()
            };

            if (response.IsSuccess)
            {

                return View("Index", candidate);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
