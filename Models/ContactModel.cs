using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage ="This Field is Required!")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
        public string Relation { get; set; }
        public string Company { get; set; }
        public string BirthDay { get; set; }
        public string Notes { get; set; }
    }
}
