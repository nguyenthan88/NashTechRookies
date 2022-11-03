using ASPNETAPIDAY_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETAPIDAY_1.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskRequestController : ControllerBase
{
    private readonly ILogger<TaskRequestController> _logger;

    private readonly IService _service;

    public TaskRequestController(ILogger<TaskRequestController> logger, IService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("all")]
    public List<TaskRequestModel> GetAll()
    {
        return _service.GetAll();
    }

    [HttpPost]
    public TaskRequestModel CreateTask(TaskRequestModel requestModel)
    {
        var _requestModel = new TaskRequestModel
        {
            Id = Guid.NewGuid(),
            Title = requestModel.Title,
            IsCompleted = requestModel.IsCompleted,
        };
        return _service.Add(_requestModel);
    }

    [HttpPut("{id}")]
    public IActionResult Edit(string id, TaskRequestModel model)
    {
        try
        {
            var _editId = _service.GetByID(id);

            if (_editId == null)
            {
                return NotFound();
            }

            _editId.Title = model.Title;
            _editId.IsCompleted = model.IsCompleted;

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        try
        {
            var _deleteId = _service.GetByID(id);

            if (_deleteId == null)
            {
                return NotFound();
            }

            _service.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost("/multiple-add")]
    public List<TaskRequestModel> AddMultiple(List<TaskRequestModel> models)
    {
        var _tasks = new List<TaskRequestModel>();

        foreach (var item in models)
        {
            _tasks.Add(new TaskRequestModel
            {
                Id = Guid.NewGuid(),
                Title = item.Title,
                IsCompleted = item.IsCompleted
            });
        }
        return _service.Add(_tasks);
    }

    [HttpDelete("/multiple-delete")]
    public IActionResult DeleteMultiple(List<Guid> id)
    {
        _service.Delete(id);
        return Ok();
    }
}