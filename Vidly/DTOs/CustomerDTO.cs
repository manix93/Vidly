using System;

namespace Vidly.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public byte MembershipTypeId { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
    }
}