using MVCNet6.DataAccess.ApplicationModels;

namespace MVCNet6.DataAccess.DataAccess
{
    public interface IDataAccess
    {
        public List<People> GetListPeople();

        public People GetPerson(int personId);

        public People ViewPerson(int personId);

        public void AddPeople(People people);

        public void EditPerson(People people);

        public void ViewDetailPerson(People people);

        public void DeletePerson(int personId);
    }
}