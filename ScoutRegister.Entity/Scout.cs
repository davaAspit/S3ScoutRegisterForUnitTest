using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoutRegister.Entity
{
    public class Scout : Person, IComparable<Scout>
    {
        private const int minimumAgeAtRegistration = 6;
        private DateTime registrationDate;
        private List<Relative> ices = new List<Relative>();

        public Scout(string firstName, string lastName, DateTime birthday, DateTime registrationDate) : base(firstName, lastName, birthday)
        {
            RegistrationDate = registrationDate;
        }

        /// <summary>
        /// Gets or sets the registration date of the scout.
        /// The Scout can't registrate any sooner than the year he/she turns 6.
        /// </summary>
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set {
                if (value.Date.Year - Birthday.Date.Year < minimumAgeAtRegistration) throw new ArgumentOutOfRangeException(nameof(RegistrationDate),$"You can't registrate any sooner than the year you turn 6.");
                registrationDate = value;
            }
        }

        /// <summary>
        /// Gets a readonly list of the ICE relatives.
        /// </summary>
        public ReadOnlyCollection<Relative> Ices
        {
            get { return ices.AsReadOnly(); }
        }

        /// <summary>
        /// Adds the relative to the list of ICE persons.
        /// </summary>
        /// <param name="relative">The relative to be added. Can't be null.</param>
        /// <returns>An int describing the number of ICEs in the list</returns>
        public int AddIce(Relative relative)
        {
            if (relative is null) throw new ArgumentNullException(nameof(relative));
            ices.Add(relative);
            return ices.Count;
        }


        /// <summary>
        /// Compare two Scout based on how long they have been scouts.
        /// </summary>
        /// <param name="other">The other scout</param>
        /// <returns></returns>
        public int CompareTo(Scout other)
        {
            return RegistrationDate.CompareTo(other.RegistrationDate);
        }
    }
}
