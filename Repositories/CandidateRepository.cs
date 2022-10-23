using AutoMapper;
using HRVacancies.Data;
using HRVacancies.Dtos;
using HRVacancies.Models;
using Microsoft.EntityFrameworkCore;

namespace HRVacancies.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public CandidateRepository(ApplicationDbContext context, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<BaseResponse> AddCandidate(CandidatesDto model)
        {
            string uniqueFileName = null;

            if (model.CVFile != null)
            {                
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
                
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CVFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                
                await model.CVFile.CopyToAsync(new FileStream(filePath, FileMode.Create));
            }

            var cadidate = _mapper.Map<VacancyCadidate>(model);

            cadidate.CVPath = uniqueFileName;

            cadidate.RequisitionId = model.RequisitionId;

            await _context.VacancyCadidates.AddAsync(cadidate);

           await _context.SaveChangesAsync();

            return new BaseResponse
            {
                Message = "تم إضافة المرشح بنجاح",
                IsSuccess = true
            };
        }

        public async Task<List<CandidateVM>> GetCandidates()
        {
            var candidate = await _context.VacancyCadidates.ToListAsync();

            var candidateVM = _mapper.Map<List<CandidateVM>>(candidate);

            return candidateVM;
        }

        public async Task<List<CandidateVM>> GetCandidatesByRequisitionId(string requisitionId)
        {
            var candidate = await _context.VacancyCadidates.Where(c =>c.RequisitionId.Equals(requisitionId)).ToListAsync();

            var candidateVM = _mapper.Map<List<CandidateVM>>(candidate);

            return candidateVM;
        }

        public async Task<List<HRRequisition>> GetHRRequisitions()
        {
            var result = await _context.HRRequisitions.ToListAsync();

            return result;
        }

        public async Task<List<HRManagerVacancyDto>> GetHRVacancies()
        {
            var HRRequisition = await _context.HRManagerVacancies.ToListAsync();

            var result = _mapper.Map<List<HRManagerVacancyDto>>(HRRequisition);

            return result;
        }
    }
}
