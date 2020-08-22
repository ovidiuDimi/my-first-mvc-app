using System;
using System.ComponentModel.DataAnnotations;

namespace MyFirstMvcApp.Models
{
    public class ContactListEntry
    {
        [Key]
        [Required]

        public int ID { get; set; }
        [Display(Name="Contact Type")]
        [Required]
        public ContactType ContactType { get; set; }
        [Required]
        [StringLength(100)]

        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOFBirth { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(50)]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}