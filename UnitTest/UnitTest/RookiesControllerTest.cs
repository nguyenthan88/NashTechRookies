using Moq;
using MVCNet6.Controllers;
using NUnit.Framework;
using MVCNet6.Services;
using Microsoft.Extensions.Logging;
using MVCNet6.Models;
using Microsoft.AspNetCore.Mvc;

public class Tests
{
    private RookiesController? _rookiesController;

    private Mock<IPersonService>? _personServiceMock;

    private Mock<ILogger<RookiesController>>? _loggerMock;

    private static List<PersonModel> _people = new List<PersonModel>{
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
    };

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<RookiesController>>();
        _personServiceMock = new Mock<IPersonService>();
        _rookiesController = new RookiesController(_loggerMock.Object, _personServiceMock.Object);
        _personServiceMock.Setup(q => q.GetAll()).Returns(_people);
    }

    [Test]
    public void GetAllMember_Test()
    {
        var result = _rookiesController.Index();

        Assert.IsInstanceOf<ViewResult>(result);

        var view = (ViewResult)result;

        Assert.IsInstanceOf<List<PersonModel>>(view.ViewData.Model);
        Assert.IsAssignableFrom<List<PersonModel>>(view.ViewData.Model);

        var list = (List<PersonModel>?)view.ViewData.Model;

        Assert.AreEqual(3, list?.Count());
    }

    [Test]
    public void DeleteOnePerson_Test()
    {
        int index = 2;
        _personServiceMock?.Setup(p => p.Delete(index)).Callback(() =>
        {
            _people.Remove(_people[2]);
        }).Returns(_people[2]);

        var controller = new RookiesController(_loggerMock.Object, _personServiceMock.Object);
        var expected = _people.Count - 1;

        var result = controller.Delete(2);
        var actual = _people.Count;

        Assert.IsInstanceOf<RedirectToActionResult>(result);
        Assert.IsNotNull(result);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Create_RedirectToAction()
    {
        _rookiesController.ModelState.AddModelError("FirstName", "Required");
        var result = _rookiesController.Create(model: null);

        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public void Create_ReturnView()
    {
        var newCreatePerson = new PersonCreateModel()
        {
            FirstName = "Than",
        };
        var result = _rookiesController.Create(newCreatePerson);
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        var actual = (RedirectToActionResult)result;
        Assert.AreEqual("Index", actual.ActionName);
    }

    [Test]
    public void Update_RedirectToAction()
    {
        _rookiesController.ModelState.AddModelError("FirstName", "Required");

        var index = 1;
        var updatePerson = new PersonUpdateModel();
        var result = _rookiesController.Update(index, updatePerson);

        Assert.IsInstanceOf<BadRequestObjectResult>(result);

        var badRequest = (BadRequestObjectResult)result;
        var serialize = (SerializableError)badRequest.Value;
        var actual = badRequest.Value.ToString();

        Assert.AreEqual("FirstName", serialize.Keys.ToList()[0] as string);
    }
}