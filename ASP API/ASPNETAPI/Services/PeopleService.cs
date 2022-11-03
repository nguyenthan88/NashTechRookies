using ASPNETAPI.Models;
namespace ASPNETAPI.Services;

public class PeopleService : IService
{
    private static List<PersonModel> _people = new List<PersonModel>
            {
                new PersonModel{
                Id = Guid.NewGuid(),
                FirstName = "Than",
                LastName = "Nguyen Van",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 03, 18),
                BirthPlace = "Vinh Phuc",
                },
                new PersonModel
                {
                Id = Guid.NewGuid(),
                FirstName = "Van Nga",
                LastName = "Tran",
                Gender = "Female",
                DateOfBirth = new DateTime(2001,05,22),
                BirthPlace = "Ha Noi",
                },
                new PersonModel
                {
                Id = Guid.NewGuid(),
                FirstName = "Thai Tuan",
                LastName = "Do",
                Gender = "Male",
                DateOfBirth = new DateTime(1998,05,22),
                BirthPlace = "Ha Noi",
                                },
                new PersonModel
                {
                Id = Guid.NewGuid(),
                FirstName = "Hoang Nam",
                LastName = "Vu",
                Gender = "Male",
                DateOfBirth = new DateTime(2002,09,22),
                BirthPlace = "Vinh Phuc",
                                },
                new PersonModel
                {
                Id = Guid.NewGuid(),
                FirstName = "Van Anh",
                LastName = "Hoang",
                Gender = "Male",
                DateOfBirth = new DateTime(2000,09,12),
                BirthPlace = "Ha Noi",

                },
                new PersonModel
                {
                Id = Guid.NewGuid(),
                FirstName = "Thai Lan",
                LastName = "Kim",
                Gender = "Female",
                DateOfBirth = new DateTime(1989,05,22),
                BirthPlace = "HCM",
                                },
                new PersonModel
                {
                Id = Guid.NewGuid(),
                FirstName = "The Mau",
                LastName = "Dang",
                Gender = "Male",
                DateOfBirth = new DateTime(2002,09,22),
                BirthPlace = "Hai Phong",

                },
                new PersonModel
                {
                Id = Guid.NewGuid(),
                FirstName = "Thi Van",
                LastName = "Tran",
                Gender = "Female",
                DateOfBirth = new DateTime(1990,09,22),
                BirthPlace = "Cao Bang",

                },
            };

    public PersonModel Create(PersonModel model)
    {
        _people.Add(model);
        return model;
    }

    public PersonModel? Delete(Guid id)
    {
        var index = _people.FindIndex(p => p.Id.Equals(id));

        if (index >= 0)
        {
            _people.RemoveAt(index);

            return _people[index];
        }

        return null;
    }

    public List<PersonModel> GetListPeople()
    {
        foreach (var person in _people)
        {
            person.Id = new Guid();
        };
        return _people;
    }

    public PersonModel? GetPerson(Guid id)
    {
        return _people.SingleOrDefault(p => p.Id.Equals(id));
    }

    public PersonModel? Update(Guid id, PersonModel model)
    {
        var index = _people.FindIndex(p => p.Id.Equals(id));

        if (index >= 0)
        {
            _people[index] = model;

            return _people[index];
        }

        return null;
    }
    public List<PersonModel> FilterList(string firstName, string lastName, string gender, string birthPlace)
    {
        var loop = _people
            .Where(f => f.FirstName == firstName)
            .Where(l => l.LastName == lastName)
            .Where(g => g.Gender?.ToLower().Trim() == gender.ToLower().Trim())
            .Where(b => b.BirthPlace?.ToLower().Trim() == birthPlace.ToLower().Trim());

        return loop.ToList();
    }

}