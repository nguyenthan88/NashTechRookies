using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCNet6.Service.Requests
{
    public class CreatePeopleRequest
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Gender")]
        public string? Gender { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        [DisplayName("Birth Place")]
        public string? BirthPlace { get; set; }
    }
}
