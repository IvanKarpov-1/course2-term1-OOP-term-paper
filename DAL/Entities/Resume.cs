using DAL.Interfaces;
using System;

namespace DAL
{
    [Serializable]
    public class Resume : IEntity
    {
        public string Position { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string City { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public IEntity SetData(EntityOptions options)
        {
            Position = options.ResumePosition;
            FirstName = options.ResumeFirstName;
            LastName = options.ResumeLastName;
            Age = options.ResumeAge;
            City = options.ResumeCity;
            Email = options.ResumeEmail;
            PhoneNumber = options.ResumePhoneNumber;

            return this;
        }

        public void ChangeData(EntityOptions options)
        {
            Position = options.ResumePosition == "" ? Position : options.ResumePosition;
            FirstName = options.ResumeFirstName == "" ? FirstName : options.ResumeFirstName;
            LastName = options.ResumeLastName == "" ? LastName : options.ResumeLastName;
            Age = options.ResumeAge == int.MinValue ? 0 : options.ResumeAge;
            City = options.ResumeCity == "" ? City : options.ResumeCity;
            Email = options.ResumeEmail == "" ? Email : options.ResumeEmail;
            PhoneNumber = options.ResumePhoneNumber== "" ? PhoneNumber : options.ResumePhoneNumber;
        }

        public override string ToString()
        {
            return $"Позиція: {Position}\n" +
                   $"Ім'я та прізвище: {FirstName} {LastName}\n" +
                   $"Вік: {Age}\n" +
                   $"Місто: {City}\n" +
                   $"E-mail: {Email}\n" +
                   $"Номер телефону: {PhoneNumber}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 23 + Position.GetHashCode();
            hash = hash * 23 + FirstName.GetHashCode();
            hash = hash * 23 + LastName.GetHashCode();
            hash = hash * 23 + Age.GetHashCode();
            hash = hash * 23 + City.GetHashCode();
            hash = hash * 23 + Email.GetHashCode();
            hash = hash * 23 + PhoneNumber.GetHashCode();
            return hash;
        }
    }
}