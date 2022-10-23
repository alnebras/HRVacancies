using AutoMapper;
using HRVacancies.Dtos;
using HRVacancies.Models;

namespace HRVacancies.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Users
            CreateMap<UserRegisterDto, ApplicationUser>().ReverseMap();
            CreateMap<RoleRegisterDto, AppRole>().ReverseMap();

            // Vacancies & Requisitions 
            CreateMap<HRManagerVacancy, List<HRManagerVacancyDto>>().ReverseMap();

            CreateMap<HRRequisitionVM, HRRequisition>().ReverseMap();

            CreateMap<HRRequisitionDto, HRRequisition>().ReverseMap();

            // candidates
            CreateMap<CandidateVM, VacancyCadidate>().ReverseMap();
            CreateMap<CandidatesDto, VacancyCadidate>().ReverseMap();
        }
    }
}
