using System.ComponentModel;
namespace MVCNet6.Service.Requests
{
    public class UpdatePeopleRequest
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Gender")]
        public string? Gender { get; set; }

        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Birth Place")]
        public string? BirthPlace { get; set; }
    }
}
