﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Membership type")]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Is subscribed to newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }
    }
}