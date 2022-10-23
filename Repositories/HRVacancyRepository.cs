using HRVacancies.Data;
using HRVacancies.Dtos;
using HRVacancies.Models;
using Microsoft.EntityFrameworkCore;

namespace HRVacancies.Repositories
{
    public class HRVacancyRepository : IHRVacancyRepository
    {
        private readonly ApplicationDbContext _context;

        public HRVacancyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HRManagerVacancy>> GetHRVacancies()
        {
            var result = await _context.HRManagerVacancies.ToListAsync();

            return result;
        }

        public async Task<HRManagerVacancy> GetHRVacancyById(int id)
        {
            var result = await _context.HRManagerVacancies.FirstOrDefaultAsync(v => v.VacancyId.Equals(id));

            return result;
        }

        public async Task<BaseResponse> AddHRVacancy(HRManagerVacancy model)
        {

            await _context.HRManagerVacancies.AddAsync(model);
            await _context.SaveChangesAsync();

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "تم إضافة الإجازة بنجاح"
            };
        }

        public async Task<BaseResponse> EditHRVacancy(HRManagerVacancy model)
        {

            _context.HRManagerVacancies.Update(model);

            await _context.SaveChangesAsync();

            return new BaseResponse
            {
                IsSuccess = true,
                Message = "تم التعديل بنجاح"
            };
        }


    }
}
