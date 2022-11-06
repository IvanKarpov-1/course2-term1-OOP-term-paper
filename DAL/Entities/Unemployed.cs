using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL
{
    [Serializable]
    public class Unemployed : IEntity, IContainsOtherEntities
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string City { get; private set; }
        public List<Resume> ResumesList { get; private set; }

        public IEntity SetData(EntityOptions options)
        {
            FirstName = options.UnemployedFirstName;
            LastName = options.UnemployedLastName;
            Age = options.UnemployedAge;
            City = options.UnemployedCity;
            ResumesList = new List<Resume>();

            return this;
        }

        public void ChangeData(EntityOptions options)
        {
            FirstName = options.UnemployedFirstName == "" ? FirstName : options.UnemployedFirstName;
            LastName = options.UnemployedLastName == "" ? LastName : options.UnemployedLastName;
            Age = options.UnemployedAge == int.MinValue ? Age : options.UnemployedAge;
            City = options.UnemployedCity == "" ? City : options.UnemployedCity;
        }

        public void AddEntity(IEntity entity)
        {
            if (entity.GetType() == typeof(Resume)) ResumesList.Add((Resume)entity);
        }

        public void DeleteEntity(IEntity entity)
        {
            if (entity.GetType() == typeof(Resume)) ResumesList.Remove((Resume)entity);
        }

        public void DeleteEntity(IEntity entity, int index)
        {
            ResumesList.RemoveAt(index);
        }

        public override string ToString()
        {
            return $"Ім'я та прізвище: {FirstName} {LastName}\n" +
                   $"Вік: {Age}\n" +
                   $"Місто: {City}\n" +
                   $"Кількість резюме {ResumesList.Count}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash * 23 + FirstName.GetHashCode();
            hash = hash * 23 + LastName.GetHashCode();
            hash = hash * 23 + Age.GetHashCode();
            hash = hash * 23 + City.GetHashCode();
            hash = hash * 23 + ResumesList.GetHashCode();
            return hash;
        }
    }
}