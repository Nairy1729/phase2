using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign12
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public bool IsValid()
        {
            // Validation logic will be added in the Validator class
            return Validator.ValidateEmail(Email) &&
                   Validator.ValidatePhoneNumber(PhoneNumber) &&
                   Validator.ValidateDateOfBirth(DateOfBirth);
        }
    }
}
