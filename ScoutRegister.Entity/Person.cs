using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutRegister.Entity
{
    /// <summary>
    /// Abstract class with information about the name of a person.
    /// Must be inherited to be used.
    /// </summary>
    public abstract class Person
    {
        private string firstName;
        private string lastName;
        private DateTime birthday;

        /// <summary>
        /// Creates a Person with the first name and last name
        /// </summary>
        /// <param name="firstName">First name of the person</param>
        /// <param name="lastName">Last name of the person</param>
        protected Person(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        /// <summary>
        /// Gets or sets the first name of the person.
        /// When saving the name, it must not be null, empty or white spaces only
        /// </summary>
        public string FirstName
        {
            get => firstName;
            set
            {
                if (value is null) throw new ArgumentNullException(nameof(FirstName));
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException($"{nameof(FirstName)} must not be empty or only white spaces.");

                firstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// When saving the name, it must not be null, empty or white spaces only
        /// </summary>
        public string LastName
        {
            get => lastName;
            set
            {
                if (value is null) throw new ArgumentNullException(nameof(LastName));
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException($"{nameof(LastName)} must not be empty or only white spaces.");

                lastName = value;
            }
        }

        /// <summary>
        /// Concatenates the first and last name to the full name.
        /// Throws exception if FirstName or LastName is null
        /// </summary>
        public string FullName
        {
            get
            {
                if (FirstName is null) throw new ArgumentNullException(nameof(FirstName));
                if (LastName is null) throw new ArgumentNullException(nameof(LastName));

                return $"{FirstName} {LastName}";
            }
        }

        /// <summary>
        /// Gets or sets the birthday of the person. Only returns the date part.
        /// Throws exception if the value is set to the future.
        /// </summary>
        public DateTime Birthday
        {
            get => birthday.Date;
            set
            {
                if (value.Date > DateTime.Today) throw new ArgumentOutOfRangeException(nameof(Birthday), $"{Birthday} can't be in the future.");
                birthday = value.Date;
            }
        }
    }
}
