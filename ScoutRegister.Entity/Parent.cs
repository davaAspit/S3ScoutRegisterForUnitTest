using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutRegister.Entity
{
    public class Relative : Person
    {
        private string phoneNumber;

        public Relative(string firstName, string lastName, string phoneNumber, DateTime birthday) : base(firstName, lastName, birthday)
        {
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Gets or sets the phone number.
        /// The phone number must be exactly 8 digits and can't start with a 0.
        /// </summary>
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set {
                (bool isValid, string errorMessage) = ValidatePhoneNumber(value);
                if(isValid) phoneNumber = value;
                throw new ArgumentException(errorMessage);
            }
        }

        private (bool isValid, string errorMessage) ValidatePhoneNumber(string value)
        {
            if (value.Length != 8)
            {
                return (false, "The length must be exactly 8 for a danish phone number");
            }
            else if (!int.TryParse(value, out int number))
            {
                return (false, "The phone number can only contain digits");
            }
            else if (value[0] =='0')
            {
                return (false, "A phonenumber can't start with a 0");
            }
            return (true, string.Empty);
        }
    }
}
