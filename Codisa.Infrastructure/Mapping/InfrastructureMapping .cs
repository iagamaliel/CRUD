using AutoMapper;
using HugoApp.Core.Entities;
using HugoApp.Infrastructure.ParamsDTO;

namespace HugoApp.Infrastructure.Mapping
{
    public class InfrastructureMapping : Profile
    {
        #region CONTRUCTOR
        public InfrastructureMapping()
        {
            Mapping();
        }
        #endregion

        #region "METODOS"
        public void Mapping()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
        #endregion
    }
}
