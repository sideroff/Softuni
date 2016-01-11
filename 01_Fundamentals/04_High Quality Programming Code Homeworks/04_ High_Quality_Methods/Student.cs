using System;

namespace Methods
{
    class Student
    {
        private string firstName;
        private string lastName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="firstName">
        /// First name.
        /// </param>
        /// <param name="lastName">
        /// Last name.
        /// </param>
        /// <param name="otherInfo">
        /// Other info.
        /// </param>
        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        /// <summary>
        /// Gets or sets the First name.
        /// </summary>
        /// <exception cref="ArgumentException"> Throws ArgumentException if string supplied is less than 3 characters long.
        /// </exception>
        public string FirstName
        {
            get
            {
                return this.FirstName;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name cannot be less than 3 characters long.");
                }
            } 
        }

        /// <summary>
        /// Gets or sets the Last name.
        /// </summary>
        /// <exception cref="ArgumentException">Throws ArgumentException if string supplied is less than 3 characters long.
        /// </exception>
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot be less than 3 characters long.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the other info.
        /// </summary>
        public string OtherInfo { get; set; }

        /// <summary>
        /// Checks if person is older than the one taken as argument.
        /// </summary>
        /// <param name="other">
        /// Other person.
        /// </param>
        /// <returns>
        /// Returns true if "this" is older than "other"
        /// </returns>
        public bool IsOlderThan(Student other)
        {
            DateTime firstDate =
                DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            DateTime secondDate =
                DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));

            return firstDate > secondDate;
        }

        /// <summary>
        /// The ToString method of Person class.
        /// </summary>
        /// <returns>
        /// Person details as string.
        /// </returns>
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
