using System.Diagnostics;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using nashtechaspmvcday_1.Models;

namespace nashtechaspmvcday_1.Controllers;
[Route("/nashtech/rookies")]
public class RookiesController : Controller
{
    List<PersonModel> lsPersons = new List<PersonModel>()
            {
                new PersonModel("Van Anh","Nguyen","Male", new DateTime(2002,09,22),"0987654","Ha Nam",true),
                new PersonModel("Van Nga","Tran","Female", new DateTime(2001,05,22),"0987654","Ha Noi",false),
                new PersonModel("Thai Tuan","Do","Male", new DateTime(1998,05,22),"0987654","Ha Noi",true),
                new PersonModel("Hoang Nam","Vu","Male", new DateTime(2002,09,22),"0987654","Vinh Phuc",true),
                new PersonModel("Van Anh","Hoang","Male", new DateTime(2000,09,12),"0987654","Ha Noi",false),
                new PersonModel("Thai Lan","Kim","Female", new DateTime(1989,05,22),"0987654","HCM",true),
                new PersonModel("The Mau","Dang","Male", new DateTime(2002,09,22),"0987654","Hai Phong",false),
                new PersonModel("Thi Van","Tran","Female", new DateTime(1990,09,22),"0987654","Cao Bang",false),
            };
    private readonly ILogger<RookiesController> _logger;
    public RookiesController(ILogger<RookiesController> logger)
    {
        _logger = logger;
    }
    [Route("ListMaleMember")]
    public IActionResult ListMaleMember()
    {
        var memberMales = lsPersons.Where(p => p.Gender == "Male").ToList();

        return View(memberMales);
    }
    [Route("ListOldestMember")]
    public IActionResult ListOldestMember()
    {
        var oldestMember = lsPersons.OrderByDescending(x => x.Age).FirstOrDefault();

        return View(oldestMember);
    }
    [Route("ListFullNameMember")]
    public IActionResult ListFullNameMember()
    {
        var fullNames = lsPersons.Select(x => x.FullName);
        return Json(fullNames);
    }
    [Route("ListMember")]
    public IActionResult ListMember()
    {
        var member2000 = lsPersons.Where(p => p.DateOfBirth.Year == 2000).ToList();

        return View(member2000);
    }
    [Route("ListMemberGreater")]
    public IActionResult ListMemberGreater()
    {
        var memberGreater2000 = lsPersons.Where(p => p.DateOfBirth.Year > 2000).ToList();

        return View(memberGreater2000);
    }
    [Route("ListMemberLess")]
    public IActionResult ListMemberLess()
    {
        var memberLess2000 = lsPersons.Where(p => p.DateOfBirth.Year < 2000).ToList();

        return View(memberLess2000);
    }
    public IActionResult Index()
    {
        return View();
    }
    private byte[] WriteCsvToMemory(IEnumerable<PersonModel> lsPersons)
    {
        using (var memoryStream = new MemoryStream())
        using (var streamWriter = new StreamWriter(memoryStream))
        using (var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.CurrentCulture))
        {
            csvWriter.WriteRecords(lsPersons);
            streamWriter.Flush();
            return memoryStream.ToArray();
        }
    }
    public FileStreamResult Export()
    {
        var result = WriteCsvToMemory(lsPersons);
        var memoryStream = new MemoryStream(result);
        return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "Persons.csv" };
    }
}