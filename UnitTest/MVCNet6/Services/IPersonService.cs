using MVCNet6.Models;

namespace MVCNet6.Services
{
    public interface IPersonService
    {
        List<PersonModel> GetAll();
        PersonModel? GetOne(int index);
        PersonModel Create(PersonModel model);
        PersonModel? Update(int index, PersonModel model);
        PersonModel? Delete(int index);
    }
}