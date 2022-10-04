class Member
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string BirthPlace { get; set; }
    public Boolean IsGraduated { get; set; }
    public uint Age
    {
        get
        {
            return (uint)(DateTime.Now.Year - DateOfBirth.Year);
        }
    }
    public String Information
    {
        get
        {
            String Graduated = (IsGraduated) ? "IsGraduated" : "not IsGraduated";
            return $"{FirstName,10}{LastName,20}{Gender,15}{DateOfBirth,25}{PhoneNumber,10}{BirthPlace,15}{Graduated,5}";
        }
    }

    public Member(string firstName, string lastName, string gender, DateTime dateOfBirth,
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