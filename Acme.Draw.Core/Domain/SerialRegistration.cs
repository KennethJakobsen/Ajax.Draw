using System;
using LinqToDB.Mapping;

namespace Acme.Draw.Core.Domain
{
    [Table(Name = nameof(SerialRegistration))]
    public class SerialRegistration
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column(Name = "FirstName"), NotNull]
        public string FirstName { get;  set; }

        [Column(Name = "LastName"), NotNull]
        public string LastName { get;  set; }

        [Column(Name = "Email"), NotNull]
        public string Email { get;  set; }

        [Column(Name = "Phone"), NotNull]
        public string Phone { get;  set; }

        [Column(Name = "DateOfBirth"), NotNull]
        public DateTime DateOfBirth { get;  set; }

        [Column(Name = "Serial"), NotNull]
        public string Serial { get;  set; }

        [Column(Name = "Registered"), NotNull]
        public DateTime Registered { get;  set; }

        public SerialRegistration()
        {
            
        }
        public SerialRegistration(string firstName, string lastName, string email, string phone, DateTime dateOfBirth, string serial, DateTime registered)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            Serial = serial;
            Registered = registered;
        }
    }
}
