using HumanCapital.Models;

namespace HumanCapital.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAllPeopleAsync(CancellationToken cancellationToken);
        
        Task<Person> AddPersonAsync(AddPersonRequest request, CancellationToken cancellationToken);

        Task<Person> EditPersonAsync(Person request, CancellationToken cancellationToken);

        Task DeletePersonAsync(int id, CancellationToken cancellationToken);
    }
}
