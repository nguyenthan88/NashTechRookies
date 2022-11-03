using ASPNETAPI.Models;

namespace ASPNETAPI
{
    public interface IService
    {
        List<PersonModel> GetListPeople();

        public PersonModel? GetPerson(Guid id);

        public PersonModel? Create(PersonModel model);

        public PersonModel? Update(Guid id, PersonModel model);

        public PersonModel? Delete(Guid id);

        List<PersonModel> FilterList(string firstName, string lastName, string gender, string birthPlace);
    }
}