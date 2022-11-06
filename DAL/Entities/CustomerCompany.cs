using DAL.Interfaces;
using System;

namespace DAL
{
    [Serializable]
    public class CustomerCompany : IEntity
    {
        public string Name { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Description { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string HomePage { get; private set; }
        
        public IEntity SetData(EntityOptions options)
        {
            Name = options.CustomerCompanyName;
            FirstName = options.CustomerCompanyFirstName;
            LastName = options.CustomerCompanyLastName;
            Description = options.CustomerCompanyDescription;
            PhoneNumber = options.CustomerCompanyPhoneNumber;
            Address = options.CustomerCompanyAddress;
            City = options.CustomerCompanyCity;
            HomePage = options.CustomerCompanyHomePage;

            return this;
        }

        public void ChangeData(EntityOptions options)
        {
            Name = options.CustomerCompanyName == "" ? Name : options.CustomerCompanyName;
            FirstName = options.CustomerCompanyFirstName == "" ? FirstName : options.CustomerCompanyFirstName;
            LastName = options.CustomerCompanyLastName == "" ? LastName : options.CustomerCompanyLastName;
            Description = options.CustomerCompanyDescription == "" ? Description : options.CustomerCompanyDescription;
            PhoneNumber = options.CustomerCompanyPhoneNumber == "" ? PhoneNumber : options.CustomerCompanyPhoneNumber;
            Address = options.CustomerCompanyAddress == "" ? Address : options.CustomerCompanyAddress;
            City = options.CustomerCompanyCity == "" ? City : options.CustomerCompanyCity;
            HomePage = options.CustomerCompanyHomePage == "" ? HomePage : options.CustomerCompanyHomePage;
        }

        public override string ToString()
        {
            return $"Назва компанії: {Name}\n" +
                   $"Ім'я та фамілія замовника: {FirstName} {LastName}\n" +
                   $"Опис компанії: {Description}\n" +
                   $"Номер телефону: {PhoneNumber}\n" +
                   $"Місто: {City}\n" +
                   $"Адреса: {Address}\n" +
                   $"Домашня сторінка: {HomePage}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 23 + Name.GetHashCode();
            hash = hash * 23 + FirstName.GetHashCode();
            hash = hash * 23 + LastName.GetHashCode();
            hash = hash * 23 + Description.GetHashCode();
            hash = hash * 23 + PhoneNumber.GetHashCode();
            hash = hash * 23 + City.GetHashCode();
            hash = hash * 23 + Address.GetHashCode();
            hash = hash * 23 + HomePage.GetHashCode();
            return hash;
        }
    }
}