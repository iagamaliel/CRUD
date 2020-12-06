using HugoApp.Core.Entities;
using HugoApp.Infrastructure.Interfaces;
using HugoApp.Infrastructure.Repository.InterfacesRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HugoApp.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        #region "ATRIBUTOS"
        private readonly IPersonServices _personServices;
        #endregion

        #region "CONSTRUCTOR"
        public PersonRepository(IPersonServices personServices)
        {
            _personServices = personServices ?? throw new ArgumentNullException(nameof(personServices));
        }
        #endregion

        #region "METODOS"
        public async Task<List<Person>> GetAllPerson()
        {
            return await _personServices.GetAllPerson();
        }

        public async Task<int> CreatePerson(Person person)
        {
            return await _personServices.CreatePerson(person);
        }

        public async Task<int> UpdatePerson(Person person)
        {
            return await _personServices.UpdatePerson(person);
        }

        public async Task<int> DeletePerson(int id)
        {
            return await _personServices.DeletePerson(id);
        }
        #endregion

    }
}
