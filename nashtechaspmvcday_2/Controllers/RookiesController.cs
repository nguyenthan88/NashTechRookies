using Microsoft.AspNetCore.Mvc;
using nashtechaspmvcday_2.Models;

namespace nashtechaspmvcday_2.Controllers;
public class RookiesController : Controller
{
    public static List<PersonModel> lsPersons = new List<PersonModel>
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
    private readonly ILogger<RookiesController> _logger;
    public RookiesController(ILogger<RookiesController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View(lsPersons);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(PersonCreateModel model)
    {
        var person = new PersonModel
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Gender = model.Gender,
            DateOfBirth = model.DateOfBirth,
            BirthPlace = model.BirthPlace,
            PhoneNumber = model.PhoneNumber,
            IsGraduated = false
        };
        lsPersons.Add(person);

        return RedirectToAction("index");
    }

    [HttpGet]
    public IActionResult Edit(int index)
    {
        if (index >= 0 && index < lsPersons.Count)
        {
            var person = lsPersons[index];
            var model = new PersonUpdateModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                BirthPlace = person.BirthPlace,
            };
            ViewData["Index"] = index;

            return View(model);
        }
        return View();
    }

    [HttpPost]
    public IActionResult Update(int index, PersonUpdateModel model)
    {
        if (ModelState.IsValid)
        {
            if (index >= 0 && index < lsPersons.Count)
            {
                var person = lsPersons[index];
                person.LastName = model.LastName;
                person.FirstName = model.FirstName;
                person.DateOfBirth = model.DateOfBirth;
                person.BirthPlace = model.BirthPlace;
            };
            return RedirectToAction("Index");
        }
        return View(model);
    }


    [HttpPost]
    public IActionResult Delete(int index)
    {
        if (index >= 0 && index < lsPersons.Count)
        {
            lsPersons.RemoveAt(index);
        };
        return RedirectToAction("Index");
    }
}