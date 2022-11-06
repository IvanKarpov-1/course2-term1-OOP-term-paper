using System.Collections.Generic;
using BLL.Services;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Linq;
using BLL.Exceptions;
using System;

namespace BLL.Tests
{
    [TestClass]
    public class InfoServiceTests
    {
        private readonly string _categoriesPath = ConfigurationManager.AppSettings.Get("CategoryPath");
        private readonly string _customerCompaniesPath = ConfigurationManager.AppSettings.Get("CustomerCompanyPath");
        private readonly string _resumesPath = ConfigurationManager.AppSettings.Get("ResumePath");
        private readonly string _unemployedsPath = ConfigurationManager.AppSettings.Get("UnemployedPath");
        private readonly string _vacanciesPath = ConfigurationManager.AppSettings.Get("VacancyPath");

        [TestMethod]
        public void GetCategoriesInfo_should_return_list_of_data_presenters_with_categories_info()
        {
            var categories = new List<Category>();
            var expectedData = new List<DataPresenter>();
            categories.Add(EntityCreator<Category>.CreateEntity(new EntityOptions(categoryName: "ABC")));
            categories.Add(EntityCreator<Category>.CreateEntity(new EntityOptions(categoryName: "АБВ")));
            EntityContext<Category>.ClearFile(_categoriesPath);
            var i = 1;
            foreach (var category in categories)
            {
                EntityContext<Category>.Write(_categoriesPath, category);
                expectedData.Add(new DataPresenter(i).SetData("Name", $"Категорія: {category.Name}")
                    .SetData("Vacancies", $"Вакансій: {category.VacanciesList.Count}")
                    .SetData("Resumes", $"Резюме: {category.ResumesList.Count}"));
                i++;
            }
            var expectedString = expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter);

            var actualData = InfoService.GetCategoriesInfo();
            var actualString = actualData.Aggregate("", (current, dataPresenter) => current + dataPresenter);

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void GetCategoriesInfo_should_return_sorted_by_ascending_list_of_data_presenters_with_categories_info()
        {
            var categories = new List<Category>();
            var expectedData = new List<DataPresenter>();
            categories.Add(EntityCreator<Category>.CreateEntity(new EntityOptions(categoryName: "ABC")));
            categories.Add(EntityCreator<Category>.CreateEntity(new EntityOptions(categoryName: "АБВ")));
            EntityContext<Category>.ClearFile(_categoriesPath);
            var i = 1;
            foreach (var category in categories)
            {
                EntityContext<Category>.Write(_categoriesPath, category);
                expectedData.Add(new DataPresenter(i).SetData("Name", $"Категорія: {category.Name}")
                    .SetData("Vacancies", $"Вакансій: {category.VacanciesList.Count}")
                    .SetData("Resumes", $"Резюме: {category.ResumesList.Count}"));
                i++;
            }
            expectedData.Sort((x, y) => string.Compare(x.Data["Name"], y.Data["Name"], StringComparison.Ordinal));
            var expectedString = expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter);

            var actualData = InfoService.GetCategoriesInfo(SortingType.Ascending);
            var actualString = actualData.Aggregate("", (current, dataPresenter) => current + dataPresenter);

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void GetCategoriesInfo_should_throw_exception_about_empty_list()
        {
            EntityContext<Category>.ClearFile(_categoriesPath);

            Assert.ThrowsException<EntitiesEmptyException>(() => InfoService.GetCategoriesInfo());
        }

        [TestMethod]
        public void GetConcreteCategoryInfo_should_return_data_presenter_with_concrete_category_info_by_index()
        {
            var category = EntityCreator<Category>.CreateEntity(new EntityOptions(categoryName: "ABC"));
            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Category>.Write(_categoriesPath, category);
            var expectedData = new DataPresenter();
            expectedData.SetData("Name", $"Категорія: {category.Name}");
            expectedData.SetData("Vacancies", "Вакансії:");
            var i = 1;
            foreach (var vacancy in category.VacanciesList)
            {
                expectedData.SetData($"{i}_Vacancy", $"{i})\tНазва: {vacancy.Name}")
                    .SetData($"{i}_Description", $"\tОпис: {vacancy.Description}")
                    .SetData($"{i}_Salary", $"\tЗарплата: {vacancy.Salary}")
                    .SetData($"{i}_VacancyCity", $"\tМісто: {vacancy.City}")
                    .SetData($"{i}_CustomerCompany", $"\tКомпанія замовник: {vacancy.CustomerCompany?.Name}");
                i++;
            }
            expectedData.SetData("Resumes", "Резюме: ");
            i = 1;
            foreach (var resume in category.ResumesList)
            {
                expectedData.SetData($"{i}_Position", $"{i})\tПозиція: {resume.Position}")
                    .SetData($"{i}_FirstName", $"\tІм'я: {resume.FirstName}")
                    .SetData($"{i}_LastName", $"\tПрізвище: {resume.LastName}")
                    .SetData($"{i}_Age", $"\tВік: {resume.Age}")
                    .SetData($"{i}_ResumeCity", $"\tМісто: {resume.City}")
                    .SetData($"{i}_PhoneNumber", $"\tНомер телефону: {resume.PhoneNumber}")
                    .SetData($"{i}_Email", $"\tE-mail: {resume.Email}");
                i++;
            }
            var expectedString = expectedData.ToString();

            var actualData = InfoService.GetConcreteCategoryInfo(1);
            var actualString = actualData.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void GetConcreteCategoryInfo_should_throw_exception_about_empty_list()
        {
            EntityContext<Category>.ClearFile(_categoriesPath);

            Assert.ThrowsException<EntitiesEmptyException>(() => InfoService.GetConcreteCategoryInfo(1));
        }

        [TestMethod]
        public void GetCustomerCompaniesInfo_should_return_list_of_data_presenters_with_customer_companies_info()
        {
            var customerCompanies = new List<CustomerCompany>();
            var expectedData = new List<DataPresenter>();
            customerCompanies.Add(EntityCreator<CustomerCompany>.CreateEntity(new EntityOptions(customerCompanyName: "Samsung", customerCompanyFirstName: "Ivan", customerCompanyLastName: "Karpov")));
            customerCompanies.Add(EntityCreator<CustomerCompany>.CreateEntity(new EntityOptions(customerCompanyName: "Apple", customerCompanyFirstName: "Anrew", customerCompanyLastName: "Zen")));
            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);
            var i = 1;
            foreach (var customerCompany in customerCompanies)
            {
                EntityContext<CustomerCompany>.Write(_customerCompaniesPath, customerCompany);
                expectedData.Add(new DataPresenter(i).SetData("Name", $"Назва каомпанії: {customerCompany.Name}")
                    .SetData("FirstName", $"Ім'я замовника: {customerCompany.FirstName}")
                    .SetData("LastName", $"Прізвище замовника: {customerCompany.LastName}")
                    .SetData("Description", $"Опис компанії: {customerCompany.Description}")
                    .SetData("HomePage", $"Домашня сторінка: {customerCompany.HomePage}")
                    .SetData("PhoneNumber", $"Номер телефону: {customerCompany.PhoneNumber}")
                    .SetData("City", $"Місто: {customerCompany.City}")
                    .SetData("Address", $"Адреса: {customerCompany.Address}"));
                i++;
            }
            var expectedStrings = new List<string>();
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));
            expectedData.Sort((x, y) => string.Compare(x.Data["FirstName"], y.Data["FirstName"], StringComparison.Ordinal));
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));
            expectedData.Sort((x, y) => string.Compare(x.Data["LastName"], y.Data["LastName"], StringComparison.Ordinal));
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));

            var actualData = new List<List<DataPresenter>>
            {
                InfoService.GetCustomerCompaniesInfo(),
                InfoService.GetCustomerCompaniesInfo(SortingType.ByFirstName),
                InfoService.GetCustomerCompaniesInfo(SortingType.ByLastName)
            };

            i = 0;
            foreach (var actualString in actualData.Select(data => data.Aggregate("", (current, dataPresenter) => current + dataPresenter)))
            {
                var expectedString = expectedStrings[i];
                Assert.AreEqual(expectedString, actualString);
                i++;
            }
        }

        [TestMethod]
        public void GetCustomerCompaniesInfo_should_throw_exception_about_empty_list()
        {
            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);

            Assert.ThrowsException<EntitiesEmptyException>(() => InfoService.GetCustomerCompaniesInfo());
        }

        [TestMethod]
        public void GetResumesInfo_should_return_list_of_data_presenters_with_resumes_info()
        {
            var resumes = new List<Resume>();
            var expectedData = new List<DataPresenter>();
            resumes.Add(EntityCreator<Resume>.CreateEntity(new EntityOptions(resumePosition: "DevOps", resumeFirstName: "Ivan", resumeLastName: "Karpov")));
            resumes.Add(EntityCreator<Resume>.CreateEntity(new EntityOptions(resumePosition: "Tester", resumeFirstName: "Anrew", resumeLastName: "Zen")));
            EntityContext<Resume>.ClearFile(_resumesPath);
            var i = 1;
            foreach (var resume in resumes)
            {
                EntityContext<Resume>.Write(_resumesPath, resume);
                expectedData.Add(new DataPresenter(i).SetData("Position", $"Позиція: {resume.Position}")
                    .SetData("FirstName", $"Ім'я: {resume.FirstName}")
                    .SetData("LastName", $"Прізвище: {resume.LastName}")
                    .SetData("Age", $"Вік: {resume.Age}")
                    .SetData("City", $"Місто: {resume.City}")
                    .SetData("PhoneNumber", $"Номер телефону: {resume.PhoneNumber}")
                    .SetData("Email", $"E-mail: {resume.Email}"));
                i++;
            }
            var expectedStrings = new List<string>();
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));
            expectedData.Sort((x, y) => string.Compare(x.Data["Position"], y.Data["Position"], StringComparison.Ordinal));
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));
            expectedData.Sort((x, y) => string.Compare(x.Data["FirstName"], y.Data["FirstName"], StringComparison.Ordinal));
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));
            expectedData.Sort((x, y) => string.Compare(x.Data["LastName"], y.Data["LastName"], StringComparison.Ordinal));
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));

            var actualData = new List<List<DataPresenter>>
            {
                InfoService.GetResumesInfo(),
                InfoService.GetResumesInfo(SortingType.Ascending),
                InfoService.GetResumesInfo(SortingType.ByFirstName),
                InfoService.GetResumesInfo(SortingType.ByLastName)
            };

            i = 0;
            foreach (var actualString in actualData.Select(data => data.Aggregate("", (current, dataPresenter) => current + dataPresenter)))
            {
                var expectedString = expectedStrings[i];
                Assert.AreEqual(expectedString, actualString);
                i++;
            }
        }

        [TestMethod]
        public void GetResumesInfo_should_throw_exception_about_empty_list()
        {
            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<EntitiesEmptyException>(() => InfoService.GetResumesInfo());
        }

        [TestMethod]
        public void GetUnemployedsInfo_should_return_list_of_data_presenters_with_unemployeds_info()
        {
            var unemployeds = new List<Unemployed>();
            var expectedData = new List<DataPresenter>();
            unemployeds.Add(EntityCreator<Unemployed>.CreateEntity(new EntityOptions(unemployedAge: 18, unemployedFirstName: "Ivan", unemployedLastName: "Karpov")));
            unemployeds.Add(EntityCreator<Unemployed>.CreateEntity(new EntityOptions(unemployedAge: 20, unemployedFirstName: "Anrew", unemployedLastName: "Zen")));
            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            var i = 1;
            foreach (var unemployed in unemployeds)
            {
                EntityContext<Unemployed>.Write(_unemployedsPath, unemployed);
                expectedData.Add(new DataPresenter(i).SetData("FirstName", $"Ім'я: {unemployed.FirstName}")
                    .SetData("LastName", $"Прізвище: {unemployed.LastName}")
                    .SetData("Age", $"Вік: {unemployed.Age}")
                    .SetData("City", $"Місто: {unemployed.City}")
                    .SetData("Resumes", $"Резюме: {unemployed.ResumesList.Count}"));
                i++;
            }
            var expectedStrings = new List<string>();
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));
            expectedData.Sort((x, y) => string.Compare(x.Data["FirstName"], y.Data["FirstName"], StringComparison.Ordinal));
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));
            expectedData.Sort((x, y) => string.Compare(x.Data["LastName"], y.Data["LastName"], StringComparison.Ordinal));
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));

            var actualData = new List<List<DataPresenter>>
            {
                InfoService.GetUnemployedsInfo(),
                InfoService.GetUnemployedsInfo(SortingType.ByFirstName),
                InfoService.GetUnemployedsInfo(SortingType.ByLastName)
            };

            i = 0;
            foreach (var actualString in actualData.Select(data => data.Aggregate("", (current, dataPresenter) => current + dataPresenter)))
            {
                var expectedString = expectedStrings[i];
                Assert.AreEqual(expectedString, actualString);
                i++;
            }
        }

        [TestMethod]
        public void GetUnemployedsInfo_should_throw_exception_about_empty_list()
        {
            EntityContext<Unemployed>.ClearFile(_unemployedsPath);

            Assert.ThrowsException<EntitiesEmptyException>(() => InfoService.GetUnemployedsInfo());
        }

        [TestMethod]
        public void GetConcreteUnemployedInfo_should_return_data_presenter_with_concrete_unemployed_info_by_index()
        {
            var unemployed = EntityCreator<Unemployed>.CreateEntity(new EntityOptions(unemployedAge: 18, unemployedFirstName: "Ivan", unemployedLastName: "Karpov"));
            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityContext<Unemployed>.Write(_unemployedsPath, unemployed);
            var expectedData = new DataPresenter();
            expectedData.SetData("FirstName", $"Ім'я: {unemployed.FirstName}");
            expectedData.SetData("LastName", $"Прізвище: {unemployed.LastName}");
            expectedData.SetData("Age", $"Вік: {unemployed.Age}");
            expectedData.SetData("City", $"Місто: {unemployed.City}");
            expectedData.SetData("Resumes", "Резюме: ");
            var i = 1;
            foreach (var resume in unemployed.ResumesList)
            {
                expectedData.SetData($"{i}_Position", $"{i})\tПозиція: {resume.Position}")
                    .SetData($"{i}_FirstName", $"\tІм'я: {resume.FirstName}")
                    .SetData($"{i}_LastName", $"\tПрізвище: {resume.LastName}")
                    .SetData($"{i}_Age", $"\tВік: {resume.Age}")
                    .SetData($"{i}_City", $"\tМісто: {resume.City}")
                    .SetData($"{i}_PhoneNumber", $"\tНомер телефону: {resume.PhoneNumber}")
                    .SetData($"{i}_Email", $"\tE-mail: {resume.Email}");
                i++;
            }
            var expectedString = expectedData.ToString();

            var actualData = InfoService.GetConcreteUnemployedInfo(1);
            var actualString = actualData.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void GetConcreteUnemployedInfo_should_throw_exception_about_empty_list()
        {
            EntityContext<Unemployed>.ClearFile(_unemployedsPath);

            Assert.ThrowsException<EntitiesEmptyException>(() => InfoService.GetConcreteUnemployedInfo(1));
        }

        [TestMethod]
        public void GetVacanciesInfo_should_return_list_of_data_presenters_with_vacancies_info()
        {
            var vacancies = new List<Vacancy>();
            var expectedData = new List<DataPresenter>();
            vacancies.Add(EntityCreator<Vacancy>.CreateEntity(new EntityOptions(vacancyName: "Tester", vacancySalary: "$123,45")));
            vacancies.Add(EntityCreator<Vacancy>.CreateEntity(new EntityOptions(vacancyName: "DevOps", vacancySalary: "$543,21")));
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            var i = 1;
            foreach (var vacancy in vacancies)
            {
                EntityContext<Vacancy>.Write(_vacanciesPath, vacancy);
                expectedData.Add(new DataPresenter(i).SetData("Vacancy", $"Вакансія: {vacancy.Name}")
                    .SetData("Description", $"Опис: {vacancy.Description}")
                    .SetData("Salary", $"Зарплата: {vacancy.Salary}")
                    .SetData("City", $"Місто: {vacancy.City}")
                    .SetData("CustomerCompany", $"Компанія замовник: {vacancy.CustomerCompany?.Name}"));
                i++;
            }
            var expectedStrings = new List<string>();
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));
            expectedData.Sort((x, y) => string.Compare(x.Data["Vacancy"], y.Data["Vacancy"], StringComparison.Ordinal));
            expectedStrings.Add(expectedData.Aggregate("", (current, dataPresenter) => current + dataPresenter));

            var actualData = new List<List<DataPresenter>>
            {
                InfoService.GetVacanciesInfo(),
                InfoService.GetVacanciesInfo(SortingType.Ascending)
            };

            i = 0;
            foreach (var actualString in actualData.Select(data => data.Aggregate("", (current, dataPresenter) => current + dataPresenter)))
            {
                var expectedString = expectedStrings[i];
                Assert.AreEqual(expectedString, actualString);
                i++;
            }
        }

        [TestMethod]
        public void GetVacanciesInfo_should_throw_exception_about_empty_list()
        {
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);

            Assert.ThrowsException<EntitiesEmptyException>(() => InfoService.GetVacanciesInfo());
        }
    }
}