using AutoMapper;
using HugoApp.Application.Models.Person;
using HugoApp.Core.Entities;

namespace HugoApp.Application.Mapping
{
    public class ApplicationMapping : Profile
    {
        #region CONTRUCTOR
        public ApplicationMapping()
        {
            Mapping();
        }
        #endregion

        #region METODOS
        private void Mapping()
        {
            CreateMap<Person, CreatePerson>().ReverseMap();
            CreateMap<Person, UpdatePerson>().ReverseMap();
        }
        #endregion

    }
}
