using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Contacts
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Relation { get; set; }
        public string Company { get; set; }
        public string BirthDay { get; set; }
        public string Notes { get; set; }

    }
}
