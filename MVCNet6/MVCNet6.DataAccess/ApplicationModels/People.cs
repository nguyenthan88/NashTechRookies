﻿namespace MVCNet6.DataAccess.ApplicationModels
{
    public class People
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }

        public string? BirthPlace { get; set; }

        public Boolean? IsGraduated { get; set; }
    }
}
