using System.ComponentModel;

namespace nashtechaspmvcday_2.Models
{
    public class PersonUpdateModel
    {
        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("BirthPlace")]
        public string? BirthPlace { get; set; }
    }
}