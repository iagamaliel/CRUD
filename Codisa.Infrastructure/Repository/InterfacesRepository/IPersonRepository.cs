using HugoApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HugoApp.Infrastructure.Repository.InterfacesRepository
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllPerson();
        Task<int> CreatePerson(Person person);
        Task<int> UpdatePerson(Person person);
        Task<int> DeletePerson(int id);
    }
}
