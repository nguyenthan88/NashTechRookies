using System.ComponentModel.DataAnnotations;

namespace MVCNet6.Models
{
    public class PersonModel
    {
        [Required]
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduated { get; set; }
        public uint Age { get { return (uint)(DateTime.Now.Year - DateOfBirth.Year); } }
        public string FullName
        {
            get
            {
                var FullName = LastName + " " + FirstName;
                return FullName;
            }
        }
    }
}