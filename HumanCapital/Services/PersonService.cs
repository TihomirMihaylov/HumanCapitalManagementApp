using HumanCapital.Data.Repositories;
using HumanCapital.Exceptions;
using HumanCapital.Models;

namespace HumanCapital.Services
{
    public class PersonService : IPersonService
    {
        private readonly IDeletableEntityRepository<Person> _repository;
        private readonly ILogger<PersonService> _logger;

        public PersonService(
            IDeletableEntityRepository<Person> personRepository,
            ILogger<PersonService> logger
        )
        {
            _repository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Person>> GetAllPeopleAsync(CancellationToken cancellationToken)
    => await _repository.AllAsNoTrackingAsync(cancellationToken);

        public async Task<Person> AddPersonAsync(AddPersonRequest request, CancellationToken cancellationToken)
        {
            var model = new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Salary = request.Salary,
                Department = request.Department
            };

            await _repository.AddAsync(model, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            //var allPeople = await _personRepository.AllAsNoTrackingAsync(cancellationToken);
            //var newPerson = allPeople.OrderByDescending(x => x.Id).First();

            return model; //check if this contains the newly assigned id
        }

        public async Task<Person> EditPersonAsync(Person request, CancellationToken cancellationToken)
        {
            var personToEdit = await _repository.GetByIdAsync(cancellationToken, request.Id);
            if (personToEdit == null)
            {
                _logger.LogWarning("Person with id {Id} not found in the database", request.Id);
                throw new PersonNotFoundException($"Could not find in the database a person with id: {request.Id}");
            }

            personToEdit.FirstName = request.FirstName;
            personToEdit.LastName = request.LastName;
            personToEdit.Salary = request.Salary;
            personToEdit.Department = request.Department;

            _repository.Update(personToEdit);
            await _repository.SaveChangesAsync(cancellationToken);

            return personToEdit;
        }

        public async Task DeletePersonAsync(int id, CancellationToken cancellationToken)
        {
            var personToDelete = await _repository.GetByIdAsync(cancellationToken, id);
            if (personToDelete == null)
            {
                _logger.LogWarning("Person with id {Id} not found in the database", id);
                throw new PersonNotFoundException($"Could not find in the database a person with id: {id}");
            }

            _repository.Delete(personToDelete);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
