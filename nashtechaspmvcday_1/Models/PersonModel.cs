namespace nashtechaspmvcday_1.Models
{
    public class PersonModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public Boolean IsGraduated { get; set; }
        public string? FullName
        {
            get
            {
                return LastName + FirstName;
            }
        }
        public uint Age
        {
            get
            {
                return (uint)(DateTime.Now.Year - DateOfBirth.Year);
            }
        }
        public PersonModel(string firstName, string lastName, string gender, DateTime dateOfBirth,
                      string phoneNumber, string birthPlace, Boolean isGraduated)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated;
        }
    }
}