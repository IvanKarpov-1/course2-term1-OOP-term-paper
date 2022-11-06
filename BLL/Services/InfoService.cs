using BLL.Exceptions;
using DAL;
using DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace BLL.Services
{
    public class InfoService
    {
        public static List<DataPresenter> GetCategoriesInfo(SortingType sortingType = SortingType.None)
        {
            try
            {
                var data = new List<DataPresenter>();
                var categoriesList =
                    EntityContext<Category>.ReadFile(ConfigurationManager.AppSettings.Get("CategoryPath"));

                var i = 1;
                foreach (var category in categoriesList)
                {
                    var dataPresenter = new DataPresenter(i);
                    dataPresenter.SetData("Name", $"Категорія: {category.Name}")
                        .SetData("Vacancies", $"Вакансій: {category.VacanciesList.Count}")
                        .SetData("Resumes", $"Резюме: {category.ResumesList.Count}");
                    data.Add(dataPresenter);
                    i++;
                }

                if (sortingType == SortingType.Ascending)
                    data.Sort((x, y) => string.Compare(x.Data["Name"], y.Data["Name"], StringComparison.Ordinal));

                return data;
            }
            catch (TheFileIsEmptyException)
            {
                throw new EntitiesEmptyException("Список категорій порожній");
            }
        }

        public static DataPresenter GetConcreteCategoryInfo(int index)
        {
            try
            {
                var data = new DataPresenter();
                var categoriesList = EntityContext<Category>.ReadFile(ConfigurationManager.AppSettings.Get("CategoryPath"));

                var category = categoriesList[index - 1];

                data.SetData("Name", $"Категорія: {category.Name}");
                data.SetData("Vacancies", "Вакансії:");
                var i = 1;
                foreach (var vacancy in category.VacanciesList)
                {
                    data.SetData($"{i}_Vacancy", $"{i})\tНазва: {vacancy.Name}")
                        .SetData($"{i}_Description", $"\tОпис: {vacancy.Description}")
                        .SetData($"{i}_Salary", $"\tЗарплата: {vacancy.Salary}")
                        .SetData($"{i}_VacancyCity", $"\tМісто: {vacancy.City}")
                        .SetData($"{i}_CustomerCompany", $"\tКомпанія замовник: {vacancy.CustomerCompany?.Name}");
                    i++;
                }
                data.SetData("Resumes", "Резюме: ");
                i = 1;
                foreach (var resume in category.ResumesList)
                {
                    data.SetData($"{i}_Position", $"{i})\tПозиція: {resume.Position}")
                        .SetData($"{i}_FirstName", $"\tІм'я: {resume.FirstName}")
                        .SetData($"{i}_LastName", $"\tПрізвище: {resume.LastName}")
                        .SetData($"{i}_Age", $"\tВік: {resume.Age}")
                        .SetData($"{i}_ResumeCity", $"\tМісто: {resume.City}")
                        .SetData($"{i}_PhoneNumber", $"\tНомер телефону: {resume.PhoneNumber}")
                        .SetData($"{i}_Email", $"\tE-mail: {resume.Email}");
                    i++;
                }

                return data;
            }
            catch (TheFileIsEmptyException)
            {
                throw new EntitiesEmptyException("Список категорій порожній");
            }
        }

        public static List<DataPresenter> GetCustomerCompaniesInfo(SortingType sortingType = SortingType.None)
        {
            try
            {
                var data = new List<DataPresenter>();
                var customerCompaniesList =
                    EntityContext<CustomerCompany>.ReadFile(
                        ConfigurationManager.AppSettings.Get("CustomerCompanyPath"));

                var i = 1;
                foreach (var customerCompany in customerCompaniesList)
                {
                    var dataPresenter = new DataPresenter(i);
                    dataPresenter.SetData("Name", $"Назва каомпанії: {customerCompany.Name}")
                        .SetData("FirstName", $"Ім'я замовника: {customerCompany.FirstName}")
                        .SetData("LastName", $"Прізвище замовника: {customerCompany.LastName}")
                        .SetData("Description", $"Опис компанії: {customerCompany.Description}")
                        .SetData("HomePage", $"Домашня сторінка: {customerCompany.HomePage}")
                        .SetData("PhoneNumber", $"Номер телефону: {customerCompany.PhoneNumber}")
                        .SetData("City", $"Місто: {customerCompany.City}")
                        .SetData("Address", $"Адреса: {customerCompany.Address}");
                    data.Add(dataPresenter);
                    i++;
                }

                switch (sortingType)
                {
                    case SortingType.ByFirstName:
                        data.Sort((x, y) => string.Compare(x.Data["FirstName"], y.Data["FirstName"], StringComparison.Ordinal));
                        break;
                    case SortingType.ByLastName:
                        data.Sort((x, y) => string.Compare(x.Data["LastName"], y.Data["LastName"], StringComparison.Ordinal));
                        break;
                }

                return data;
            }
            catch (TheFileIsEmptyException)
            {
                throw new EntitiesEmptyException("Список компаній замовників порожній");
            }
        }

        public static List<DataPresenter> GetResumesInfo(SortingType sortingType = SortingType.None)
        {
            try
            {
                var data = new List<DataPresenter>();
                var resumesList = EntityContext<Resume>.ReadFile(ConfigurationManager.AppSettings.Get("ResumePath"));

                var i = 1;
                foreach (var resume in resumesList)
                {
                    var dataPresenter = new DataPresenter(i);
                    dataPresenter.SetData("Position", $"Позиція: {resume.Position}")
                        .SetData("FirstName", $"Ім'я: {resume.FirstName}")
                        .SetData("LastName", $"Прізвище: {resume.LastName}")
                        .SetData("Age", $"Вік: {resume.Age}")
                        .SetData("City", $"Місто: {resume.City}")
                        .SetData("PhoneNumber", $"Номер телефону: {resume.PhoneNumber}")
                        .SetData("Email", $"E-mail: {resume.Email}");
                    data.Add(dataPresenter);
                    i++;
                }

                switch (sortingType)
                {
                    case SortingType.Ascending:
                        data.Sort((x, y) => string.Compare(x.Data["Position"], y.Data["Position"], StringComparison.Ordinal));
                        break;
                    case SortingType.ByFirstName:
                        data.Sort((x, y) => string.Compare(x.Data["FirstName"], y.Data["FirstName"], StringComparison.Ordinal));
                        break;
                    case SortingType.ByLastName:
                        data.Sort((x, y) => string.Compare(x.Data["LastName"], y.Data["LastName"], StringComparison.Ordinal));
                        break;
                }

                return data;
            }
            catch (TheFileIsEmptyException)
            {
                throw new EntitiesEmptyException("Список резюме порожній");
            }
        }

        public static List<DataPresenter> GetUnemployedsInfo(SortingType sortingType = SortingType.None)
        {
            try
            {
                var data = new List<DataPresenter>();
                var unemployedsList =
                    EntityContext<Unemployed>.ReadFile(ConfigurationManager.AppSettings.Get("UnemployedPath"));

                var i = 1;
                foreach (var unemployed in unemployedsList)
                {
                    var dataPresenter = new DataPresenter(i);
                    dataPresenter.SetData("FirstName", $"Ім'я: {unemployed.FirstName}")
                        .SetData("LastName", $"Прізвище: {unemployed.LastName}")
                        .SetData("Age", $"Вік: {unemployed.Age}")
                        .SetData("City", $"Місто: {unemployed.City}")
                        .SetData("Resumes", $"Резюме: {unemployed.ResumesList.Count}");
                    data.Add(dataPresenter);
                    i++;
                }

                switch (sortingType)
                {
                    case SortingType.ByFirstName:
                        data.Sort((x, y) => string.Compare(x.Data["FirstName"], y.Data["FirstName"], StringComparison.Ordinal));
                        break;
                    case SortingType.ByLastName:
                        data.Sort((x, y) => string.Compare(x.Data["LastName"], y.Data["LastName"], StringComparison.Ordinal));
                        break;
                }

                return data;
            }
            catch (TheFileIsEmptyException)
            {
                throw new EntitiesEmptyException("Список безробітних порожній");
            }
        }

        public static DataPresenter GetConcreteUnemployedInfo(int index)
        {
            try
            {
                var data = new DataPresenter();
                var unemployedsList = EntityContext<Unemployed>.ReadFile(ConfigurationManager.AppSettings.Get("UnemployedPath"));

                var unemployed = unemployedsList[index - 1];

                data.SetData("FirstName", $"Ім'я: {unemployed.FirstName}");
                data.SetData("LastName", $"Прізвище: {unemployed.LastName}");
                data.SetData("Age", $"Вік: {unemployed.Age}");
                data.SetData("City", $"Місто: {unemployed.City}");
                data.SetData("Resumes", "Резюме: ");
                var i = 1;
                foreach (var resume in unemployed.ResumesList)
                {
                    data.SetData($"{i}_Position", $"{i})\tПозиція: {resume.Position}")
                        .SetData($"{i}_FirstName", $"\tІм'я: {resume.FirstName}")
                        .SetData($"{i}_LastName", $"\tПрізвище: {resume.LastName}")
                        .SetData($"{i}_Age", $"\tВік: {resume.Age}")
                        .SetData($"{i}_City", $"\tМісто: {resume.City}")
                        .SetData($"{i}_PhoneNumber", $"\tНомер телефону: {resume.PhoneNumber}")
                        .SetData($"{i}_Email", $"\tE-mail: {resume.Email}");
                    i++;
                }

                return data;
            }
            catch (TheFileIsEmptyException)
            {
                throw new EntitiesEmptyException("Список безробітних порожній");
            }
        }

        public static List<DataPresenter> GetVacanciesInfo(SortingType sortingType = SortingType.None)
        {
            try
            {
                var data = new List<DataPresenter>();
                var vacanciesList =
                    EntityContext<Vacancy>.ReadFile(ConfigurationManager.AppSettings.Get("VacancyPath"));

                var i = 1;
                foreach (var vacancy in vacanciesList)
                {
                    var dataPresenter = new DataPresenter(i);
                    dataPresenter.SetData("Vacancy", $"Вакансія: {vacancy.Name}")
                        .SetData("Description", $"Опис: {vacancy.Description}")
                        .SetData("Salary", $"Зарплата: {vacancy.Salary}")
                        .SetData("City", $"Місто: {vacancy.City}")
                        .SetData("CustomerCompany", $"Компанія замовник: {vacancy.CustomerCompany?.Name}");
                    data.Add(dataPresenter);
                    i++;
                }

                if (sortingType == SortingType.Ascending) data.Sort((x, y) => string.Compare(x.Data["Vacancy"], y.Data["Vacancy"], StringComparison.Ordinal));

                return data;
            }
            catch (TheFileIsEmptyException)
            {
                throw new EntitiesEmptyException("Список вакансій порожній");
            }
        }
    }
}