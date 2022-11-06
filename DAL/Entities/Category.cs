using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace DAL
{
    [Serializable]
    public class Category : IEntity, IContainsOtherEntities
    {
        public string Name { get; private set; }
        public List<Vacancy> VacanciesList { get; private set; }
        public List<Resume> ResumesList { get; private set; }
        
        public IEntity SetData(EntityOptions options)
        {
            Name = options.CategoryName;
            VacanciesList = new List<Vacancy>();
            ResumesList = new List<Resume>();

            return this;
        }

        public void ChangeData(EntityOptions options)
        {
            Name = options.CategoryName == "" ? Name : options.CategoryName;
        }

        public void AddEntity(IEntity entity)
        {
            if (entity.GetType() == typeof(Resume)) ResumesList.Add((Resume)entity);
            if (entity.GetType() == typeof(Vacancy)) VacanciesList.Add((Vacancy)entity);
        }

        public void DeleteEntity(IEntity entity)
        {
            if (entity.GetType() == typeof(Resume)) ResumesList.Remove((Resume)entity);
            if (entity.GetType() == typeof(Vacancy)) VacanciesList.Remove((Vacancy)entity);
        }

        public void DeleteEntity(IEntity entity, int index)
        {
            if (entity.GetType() == typeof(Resume)) ResumesList.RemoveAt(index);
            if (entity.GetType() == typeof(Vacancy)) VacanciesList.RemoveAt(index);
        }

        public override string ToString()
        {
            return $"Категорія: {Name}\n" +
                   $"Кількість вакансій: {VacanciesList.Count}\n" +
                   $"Кількість резюме: {ResumesList.Count}";
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
            hash = hash * 23 + ResumesList.GetHashCode();
            hash = hash * 23 + VacanciesList.GetHashCode();
            return hash;
        }
    }
}