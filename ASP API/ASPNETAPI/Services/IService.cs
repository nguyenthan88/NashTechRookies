using ASPNETAPI.Models;

namespace ASPNETAPI
{
    public interface IService
    {
        List<PersonModel> GetListPeople();

        public PersonModel? GetPerson(int index);

        public PersonModel? Create(PersonModel model);

        public PersonModel? Update(int index, PersonModel model);

        public PersonModel? Delete(int index);

        List<PersonModel> FilterList(string firstName, string lastName, string gender, string birthPlace);
    }
}