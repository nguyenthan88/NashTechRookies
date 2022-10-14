using MVCNet6.Service.Requests;
using MVCNet6.Service.ViewModels;

namespace MVCNet6.Service.Services
{
    public interface IService
    {
        public List<PeopleViewModel> GetListPeople();

        public UpdatePeopleRequest GetPerson(int personId);
        public ViewDetailPeopleRequest ViewPerson(int personId);

        public void AddPeople(CreatePeopleRequest people);

        public void EditPerson(UpdatePeopleRequest updatePeopleRequest);

        public void ViewDetailPerson(ViewDetailPeopleRequest viewDetailPeopleRequest);

        public void DeletePerson(int personId);
    }
}