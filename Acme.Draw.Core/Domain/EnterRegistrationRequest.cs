using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.Draw.Core.Domain
{
    public class EnterRegistrationRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Serial { get; set; }
        public EnterRegistrationRequest()
        {
        }
    }
}