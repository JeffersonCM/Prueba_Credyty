using AutoMapper;
using Credyty.Aplication.DTO;
using Credyty.Domain.Entities.Models;

namespace Credyty.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePersonDTO, Mod_CreatePerson>().ReverseMap();
            CreateMap<CreateRequestCreditDTO, Mod_CreateRequestCredit>().ReverseMap();
            CreateMap<DeleteDTO, Mod_Delete>().ReverseMap();
            CreateMap<ModifyPersonDTO, Mod_ModifyPerson>().ReverseMap();
            CreateMap<ModifyRequestCreditDTO, Mod_ModifyRequestCredit>().ReverseMap();
        }        
    }
}
