using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Service.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PreferedTime { get; set; }
        public string? LinkedIdProfileUrl { get; set; }
        public string? GitHubProfileUrl { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
