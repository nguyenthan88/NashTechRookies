using MVCNet6.Models;

namespace MVCNet6.Services
{
    public class PersonService : IPersonService
    {
        public static List<PersonModel> _people = new List<PersonModel>
        {
            new PersonModel{
                FirstName = "Than",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 03, 18),
                PhoneNumber = "0967820905",
                BirthPlace = "Vinh Phuc",
                IsGraduated = true},
                new PersonModel
                {
                FirstName = "Van Nga",
                LastName = "Tran",
                Gender = "Female",
                DateOfBirth = new DateTime(2001,05,22),
                PhoneNumber = "0987654",
                BirthPlace = "Ha Noi",
                IsGraduated = true
                },
                new PersonModel
                {
                FirstName = "Thai Tuan",
                LastName = "Do",
                Gender = "Male",
                DateOfBirth = new DateTime(1998,05,22),
                PhoneNumber = "0987654",
                BirthPlace = "Ha Noi",
                IsGraduated = true
                },
                new PersonModel
                {
                FirstName = "Hoang Nam",
                LastName = "Vu",
                Gender = "Male",
                DateOfBirth = new DateTime(2002,09,22),
                PhoneNumber = "0987654",
                BirthPlace = "Vinh Phuc",
                IsGraduated = true
                },
                new PersonModel
                {
                FirstName = "Van Anh",
                LastName = "Hoang",
                Gender = "Male",
                DateOfBirth = new DateTime(2000,09,12),
                PhoneNumber = "0987654",
                BirthPlace = "Ha Noi",
                IsGraduated = false
                },
                new PersonModel
                {
                FirstName = "Thai Lan",
                LastName = "Kim",
                Gender = "Female",
                DateOfBirth = new DateTime(1989,05,22),
                PhoneNumber = "0987654",
                BirthPlace = "HCM",
                IsGraduated = true
                },
                new PersonModel
                {
                FirstName = "The Mau",
                LastName = "Dang",
                Gender = "Male",
                DateOfBirth = new DateTime(2002,09,22),
                PhoneNumber = "0987654",
                BirthPlace = "Hai Phong",
                IsGraduated = false
                },
                new PersonModel
                {
                FirstName = "Thi Van",
                LastName = "Tran",
                Gender = "Female",
                DateOfBirth = new DateTime(1990,09,22),
                PhoneNumber = "0987654",
                BirthPlace = "Cao Bang",
                IsGraduated = false
                },
        };

        public List<PersonModel> GetAll()
        {
            return _people;
        }

        public PersonModel? GetOne(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                return _people[index];
            }
            return null;
        }

        public PersonModel Create(PersonModel model)
        {
            _people.Add(model);

            return model;
        }

        public PersonModel? Update(int index, PersonModel model)
        {
            if (index >= 0 && index < _people.Count)
            {
                _people[index] = model;

                return model;
            }
            return null;
        }

        public PersonModel? Delete(int index)
        {
            if (index >= 0 && index < _people.Count)
            {
                var person = _people[index];
                _people.RemoveAt(index);

                return person;
            }
            return null;
        }
    }
}