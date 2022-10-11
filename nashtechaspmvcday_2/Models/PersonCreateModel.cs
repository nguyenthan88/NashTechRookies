using System.ComponentModel;

namespace nashtechaspmvcday_2.Models
{
    public class PersonCreateModel
    {
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

        [DisplayName("Is Graduated")]
        public Boolean IsGraduated { get; set; }
    }
}