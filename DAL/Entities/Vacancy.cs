using DAL.Interfaces;
using System;

namespace DAL
{
    [Serializable]
    public class Vacancy : IEntity, IContainsOtherEntities
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Salary { get; private set; }
        public CustomerCompany CustomerCompany { get; private set; }
        public string City { get; private set; }

        public IEntity SetData(EntityOptions options)
        {
            Name = options.VacancyName;
            Description = options.VacancyDescription;
            Salary = options.VacancySalary;
            City = CustomerCompany?.City ?? "";

            return this;
        }

        public void ChangeData(EntityOptions options)
        {
            Name = options.VacancyName == "" ? Name : options.VacancyName;
            Description = options.VacancyDescription == "" ? Description : options.VacancyDescription;
            Salary = options.VacancySalary == "" ? Salary : options.VacancySalary;
            City = CustomerCompany?.City ?? "";
        }

        public void AddEntity(IEntity entity)
        {
            CustomerCompany = entity as CustomerCompany;
            City = CustomerCompany?.City ?? "";
        }

        public void DeleteEntity(IEntity entity)
        {
            CustomerCompany = null;
        }

        public void DeleteEntity(IEntity entity, int index)
        {
            CustomerCompany = null;
        }

        public override string ToString()
        {
            return $"Назва: {Name}\n" +
                   $"Опис: {Description}\n" +
                   $"Зарплата: {Salary}\n" +
                   $"Компанія замовник: {CustomerCompany?.Name}\n" +
                   $"Місто: {City}";
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
            hash = hash * 23 + Description.GetHashCode();
            hash = hash * 23 + Salary.GetHashCode();
            return hash;
        }
    }
}