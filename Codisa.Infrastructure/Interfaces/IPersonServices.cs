using HugoApp.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HugoApp.Infrastructure.Interfaces
{
    public interface IPersonServices
    {
        Task<List<Person>> GetAllPerson();
        Task<int> CreatePerson(Person person);
        Task<int> UpdatePerson(Person person);
        Task<int> DeletePerson(int id);
    }
}
