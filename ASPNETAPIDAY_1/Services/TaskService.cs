namespace ASPNETAPIDAY_1.Services
{
    public class TaskService : IService
    {
        public static List<TaskRequestModel> taskList = new List<TaskRequestModel>();

        public List<TaskRequestModel> GetAll()
        {
            return taskList;
        }

        public TaskRequestModel? GetByID(string id)
        {
            var _getId = taskList.FirstOrDefault(p => p.Id == Guid.Parse(id));
            return _getId;
        }

        public List<TaskRequestModel> Add(List<TaskRequestModel> taskRequestModel)
        {
            taskList.AddRange(taskRequestModel);
            return taskRequestModel;
        }

        public TaskRequestModel Add(TaskRequestModel requestModel)
        {
            taskList.Add(requestModel);
            return requestModel;
        }

        public TaskRequestModel? Edit(string id, TaskRequestModel model)
        {
            var _editId = taskList.FirstOrDefault(p => p.Id == Guid.Parse(id));
            if (_editId != null)
            {
                _editId.Title = model.Title;
                _editId.IsCompleted = model.IsCompleted;

                return _editId;
            }
            return null;
        }

        public void Delete(string id)
        {
            var _deleteId = taskList.SingleOrDefault(p => p.Id == Guid.Parse(id));

            if (_deleteId != null)
            {
                taskList.Remove(_deleteId);
            }
        }

        public void Delete(List<Guid> id)
        {
            taskList.RemoveAll(t => id.Contains(t.Id));
        }
    }
}