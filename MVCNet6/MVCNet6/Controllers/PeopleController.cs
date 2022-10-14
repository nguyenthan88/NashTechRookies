using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCNet6.DataAccess.ApplicationModels;
using MVCNet6.Models;
using MVCNet6.Service.Requests;
using MVCNet6.Service.Services;

namespace MVCNet6.Controllers;

public class PeopleController : Controller
{
    private readonly ILogger<PeopleController> _logger;

    private readonly IService _service;

    public PeopleController(ILogger<PeopleController> logger, IService service)
    {
        _logger = logger;
        _service = service;
    }

    public IActionResult Index()
    {
        return View(_service.GetListPeople());
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(CreatePeopleRequest request)
    {
        _service.AddPeople(request);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Edit(UpdatePeopleRequest updatePeopleRequest)
    {
        _service.EditPerson(updatePeopleRequest);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int personId)
    {
        var person = _service.GetPerson(personId);
        return View(person);
    }

    [HttpPost]
    public IActionResult ViewDetail(ViewDetailPeopleRequest viewDetailPeopleRequest)
    {
        _service.ViewDetailPerson(viewDetailPeopleRequest);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult ViewDetail(int personId)
    {
        var person = _service.ViewPerson(personId);
        return View(person);
    }

    public IActionResult Delete(int personId)
    {
        _service.DeletePerson(personId);
        return RedirectToAction("Index");
    }

    public IActionResult DeleteAndRedirectToResultView(int personId)
    {
        var person = _service.ViewPerson(personId);
        _service.DeletePerson(personId);
        HttpContext.Session.SetString("DeletedPersonName", person.FirstName);
        return RedirectToAction("DeleteResult");
    }

    public IActionResult DeleteResult()
    {
        ViewBag.DeletedPersonName = HttpContext.Session.GetString("DeletedPersonName");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
