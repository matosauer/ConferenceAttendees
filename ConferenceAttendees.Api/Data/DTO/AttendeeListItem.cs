namespace ConferenceAttendees.Api.Data.DTO
{
    public class AttendeeListItem
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CompanyName { get; set; }
        public string? ReferralSourceName { get; set; }
        public string? JobRoleName { get; set; }
        public string? GenderName { get; set; }

    }
}
