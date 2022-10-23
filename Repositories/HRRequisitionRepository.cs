using AutoMapper;
using HRVacancies.Data;
using HRVacancies.Dtos;
using HRVacancies.Models;
using Microsoft.EntityFrameworkCore;

namespace HRVacancies.Repositories
{
    public class HRRequisitionRepository : IHRRequisitionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HRRequisitionRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<HRRequisition>> GetHRRequisitions()
        {
            var result = await _context.HRRequisitions.ToListAsync();

            return result;
        }

        public HRRequisitionDto GetHRRequisitionById(int id)
        {
            var requisition = _context.HRRequisitions.FirstOrDefault(v => v.RequisitionId.Equals(id));

            var requisitionDto = _mapper.Map<HRRequisitionDto>(requisition);

            return requisitionDto;
        }

        public async Task<BaseResponse> AddHRRequisition(HRRequisition model)
        {

            await _context.HRRequisitions.AddAsync(model);
            await _context.SaveChangesAsync();

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "تم إضافة الإجازة بنجاح"
            };
        }

        public async Task<BaseResponse> EditHRRequisition(HRRequisitionVM model)
        {
            var result = _mapper.Map<HRRequisition>(model);
            result.CreatedBy = model.CreatedBy;

            _context.HRRequisitions.Update(result);

            await _context.SaveChangesAsync();

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "تم التعديل بنجاح"
            };
        }

        public async Task<List<HRManagerVacancyDto>> GetHRVacancies()
        {
            var HRRequisition = await _context.HRManagerVacancies.ToListAsync();

            var result = _mapper.Map<List<HRManagerVacancyDto>>(HRRequisition);

            return result;
        }
    }
}
