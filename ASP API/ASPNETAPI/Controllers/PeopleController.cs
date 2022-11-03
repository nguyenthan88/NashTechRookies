using Microsoft.AspNetCore.Mvc;
using ASPNETAPI.Models;

namespace ASPNETAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private readonly ILogger<PeopleController> _logger;

    private readonly IService _service;

    public PeopleController(ILogger<PeopleController> logger, IService service)
    {
        _logger = logger;
        _service = service;
    }
    [HttpGet]
    public IEnumerable<PersonModel> GetListPeople()
    {
        var data = _service.GetListPeople();
        return from person in data
               select new PersonModel
               {
                   Id = person.Id,
                   FirstName = person.FirstName,
                   LastName = person.LastName,
                   Gender = person.Gender,
                   DateOfBirth = person.DateOfBirth,
                   BirthPlace = person.BirthPlace,
               };
    }
    [HttpGet("{Id:Guid}")]
    public IActionResult? GetPerson(Guid id)
    {
        try
        {
            var data = _service.GetPerson(id);
            if (data == null) { return NotFound(); }
            return new JsonResult(new PersonModel
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Gender = data.Gender,
                DateOfBirth = data.DateOfBirth,
                BirthPlace = data.BirthPlace,
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }

    }
    [HttpPost]
    public IActionResult Create(PersonCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var person = new PersonModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                BirthPlace = model.BirthPlace,

            };
            var result = _service.Create(person);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut("{Id:Guid}")]
    public IActionResult Update(Guid id, PersonUpdateModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        try
        {
            var data = _service.GetPerson(id);

            if (data == null)
            {
                return NotFound();
            }

            {
                data.FirstName = model.FirstName;
                data.LastName = model.LastName;
                data.Gender = model.Gender;
                data.DateOfBirth = model.DateOfBirth;
                data.BirthPlace = model.BirthPlace;

                var result = _service.Update(id, data);

                return new JsonResult(result);
            }
        }

        catch (Exception ex)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpDelete("{id:Guid}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            var data = _service.GetPerson(id);

            if (data == null)
            {
                return NotFound();
            }

            var result = _service.Delete(id);

            return new JsonResult(result);
        }

        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("filter-list")]
    public List<PersonModel> GetFilterList(string firstName, string lastName, string gender, string birthPlace)
    {
        return _service.FilterList(firstName, lastName, gender, birthPlace);
    }
}