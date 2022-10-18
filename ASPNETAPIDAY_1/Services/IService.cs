namespace ASPNETAPIDAY_1.Services
{
    public interface IService
    {
        public List<TaskRequestModel> GetAll();

        public TaskRequestModel? GetByID(string id);

        public List<TaskRequestModel> Add(List<TaskRequestModel> taskRequestModel);

        public TaskRequestModel Add(TaskRequestModel requestModel);

        public TaskRequestModel? Edit(string id, TaskRequestModel model);

        public void Delete(string id);

        public void Delete(List<Guid> id);
    }
}