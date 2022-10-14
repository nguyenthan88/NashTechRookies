using MVCNet6.DataAccess.ApplicationModels;

namespace MVCNet6.DataAccess.DataAccess
{
    public class StaticPeopleDataAccess : IDataAccess
    {
        public static List<People> People = new List<People>()
  {
                new People{
                Id = 1,
                FirstName = "Than",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 03, 18),
                PhoneNumber = "0967820905",
                BirthPlace = "Vinh Phuc",
                IsGraduated = true},
                new People
                {
                Id = 2,
                FirstName = "Van Nga",
                LastName = "Tran",
                Gender = "Female",
                DateOfBirth = new DateTime(2001,05,22),
                PhoneNumber = "0987654",
                BirthPlace = "Ha Noi",
                IsGraduated = true
                },
                new People
                {
                Id = 3,
                FirstName = "Thai Tuan",
                LastName = "Do",
                Gender = "Male",
                DateOfBirth = new DateTime(1998,05,22),
                PhoneNumber = "0987654",
                BirthPlace = "Ha Noi",
                IsGraduated = true
                },
                new People
                {
                Id = 4,
                FirstName = "Hoang Nam",
                LastName = "Vu",
                Gender = "Male",
                DateOfBirth = new DateTime(2002,09,22),
                PhoneNumber = "0987654",
                BirthPlace = "Vinh Phuc",
                IsGraduated = true
                },
                new People
                {
                Id = 5,
                FirstName = "Van Anh",
                LastName = "Hoang",
                Gender = "Male",
                DateOfBirth = new DateTime(2000,09,12),
                PhoneNumber = "0987654",
                BirthPlace = "Ha Noi",
                IsGraduated = false
                },
                new People
                {
                Id = 6,
                FirstName = "Thai Lan",
                LastName = "Kim",
                Gender = "Female",
                DateOfBirth = new DateTime(1989,05,22),
                PhoneNumber = "0987654",
                BirthPlace = "HCM",
                IsGraduated = true
                },
                new People
                {
                Id = 7,
                FirstName = "The Mau",
                LastName = "Dang",
                Gender = "Male",
                DateOfBirth = new DateTime(2002,09,22),
                PhoneNumber = "0987654",
                BirthPlace = "Hai Phong",
                IsGraduated = false
                },
                new People
                {
                Id = 8,
                FirstName = "Thi Van",
                LastName = "Tran",
                Gender = "Female",
                DateOfBirth = new DateTime(1990,09,22),
                PhoneNumber = "0987654",
                BirthPlace = "Cao Bang",
                IsGraduated = false
                },
            };

        public List<People> GetListPeople()
        {
            return People;
        }

        public void AddPeople(People people)
        {
            People.Add(people);
        }

        public People GetPerson(int personId)
        {
            return People.Where(p => p.Id == personId).FirstOrDefault();
        }

        public People ViewPerson(int personId)
        {
            return People.Where(p => p.Id == personId).FirstOrDefault();
        }
        public void EditPerson(People people)
        {
            var _people = People.Where(p => p.Id == people.Id).FirstOrDefault();
            _people.FirstName = people.FirstName;
            _people.LastName = people.LastName;
            _people.Gender = people.Gender;
            _people.PhoneNumber = people.PhoneNumber;
            _people.BirthPlace = people.BirthPlace;
        }

        public void DeletePerson(int personId)
        {
            var person = People.Where(p => p.Id == personId).FirstOrDefault();
            People.Remove(person);
        }

        public void ViewDetailPerson(People people)
        {
            var _people = People.Where(p => p.Id == people.Id).FirstOrDefault();
            _people.FirstName = people.FirstName;
            _people.LastName = people.LastName;
            _people.PhoneNumber = people.PhoneNumber;
            _people.BirthPlace = people.BirthPlace;
        }
    }
}
