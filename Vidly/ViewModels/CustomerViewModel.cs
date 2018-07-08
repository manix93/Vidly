using System;

namespace Vidly.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public byte MembershipTypeId { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
    }
}