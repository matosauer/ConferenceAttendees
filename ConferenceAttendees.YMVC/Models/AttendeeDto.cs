using System.ComponentModel.DataAnnotations;

namespace ConferenceAttendees.YMVC.Models
{
    public class AttendeeDto
    {
        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50)]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(50)]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [MaxLength(150)]
        public required string EmailAddress { get; set; }
        [MaxLength(14)]
        [Required(ErrorMessage = "Phone number is required")]
        public required string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(150)]
        public required string CompanyName { get; set; }
        [Required(ErrorMessage = "Referral source is required")]
        public Guid ReferralSourceId { get; set; }
        [Required(ErrorMessage = "Job role is required")]
        public Guid JobRoleId { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public Guid GenderId { get; set; }
    }
}
