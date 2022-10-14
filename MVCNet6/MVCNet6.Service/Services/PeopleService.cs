using MVCNet6.DataAccess.ApplicationModels;
using MVCNet6.DataAccess.DataAccess;
using MVCNet6.Service.Requests;
using MVCNet6.Service.ViewModels;
using System;

namespace MVCNet6.Service.Services
{
    public class PeopleService : IService
    {
        private readonly IDataAccess _dataAccess;

        public PeopleService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<PeopleViewModel> GetListPeople()
        {
            var lsPersonEntities = _dataAccess.GetListPeople();
            var lsPersonViewModels = new List<PeopleViewModel>();

            foreach (var item in lsPersonEntities)
            {
                lsPersonViewModels.Add(new PeopleViewModel
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Gender = item.Gender,
                    DateOfBirth = item.DateOfBirth,
                    PhoneNumber = item.PhoneNumber,
                    BirthPlace = item.BirthPlace,
                });
            }

            return lsPersonViewModels;
        }

        public void AddPeople(CreatePeopleRequest request)
        {
            People people = new People()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                BirthPlace = request.BirthPlace,
            };
            _dataAccess.AddPeople(people);
        }

        public UpdatePeopleRequest GetPerson(int personId)
        {
            var personEntity = _dataAccess.GetPerson(personId);
            return new UpdatePeopleRequest
            {
                Id = personEntity.Id,
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                Gender = personEntity.Gender,
                PhoneNumber = personEntity.PhoneNumber,
                BirthPlace = personEntity.BirthPlace,
            };
        }

        public ViewDetailPeopleRequest ViewPerson(int personId)
        {
            var personEntity = _dataAccess.ViewPerson(personId);
            return new ViewDetailPeopleRequest
            {
                Id = personEntity.Id,
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                PhoneNumber = personEntity.PhoneNumber,
                BirthPlace = personEntity.BirthPlace,
            };
        }

        public void EditPerson(UpdatePeopleRequest updatePeopleRequest)
        {
            People people = new People()
            {
                Id = updatePeopleRequest.Id,
                FirstName = updatePeopleRequest.FirstName,
                LastName = updatePeopleRequest.LastName,
                Gender = updatePeopleRequest.Gender,
                PhoneNumber = updatePeopleRequest.PhoneNumber,
                BirthPlace = updatePeopleRequest.BirthPlace,
            };
            _dataAccess.EditPerson(people);
        }

        public void DeletePerson(int personId)
        {
            _dataAccess.DeletePerson(personId);
        }

        public void ViewDetailPerson(ViewDetailPeopleRequest viewDetailPeopleRequest)
        {
            People people = new People()
            {
                Id = viewDetailPeopleRequest.Id,
                FirstName = viewDetailPeopleRequest.FirstName,
                LastName = viewDetailPeopleRequest.LastName,
                PhoneNumber = viewDetailPeopleRequest.PhoneNumber,
                BirthPlace = viewDetailPeopleRequest.BirthPlace,
            };
            _dataAccess.ViewDetailPerson(people);
        }
    }
}
