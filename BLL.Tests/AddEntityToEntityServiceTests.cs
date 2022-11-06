using System;
using BLL.Services;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using EntityOptions = BLL.Options.EntityOptions;

namespace BLL.Tests
{
    [TestClass]
    public class AddEntityToEntityServiceTests
    {
        private readonly string _categoriesPath = ConfigurationManager.AppSettings.Get("CategoryPath");
        private readonly string _customerCompaniesPath = ConfigurationManager.AppSettings.Get("CustomerCompanyPath");
        private readonly string _resumesPath = ConfigurationManager.AppSettings.Get("ResumePath");
        private readonly string _unemployedsPath = ConfigurationManager.AppSettings.Get("UnemployedPath");
        private readonly string _vacanciesPath = ConfigurationManager.AppSettings.Get("VacancyPath");

        [TestMethod]
        public void AddVacancyToCategory_should_add_vacancy_to_category_by_options()
        {
            var options = new EntityOptions(
                entityPath: _vacanciesPath,
                vacancyName: "Розробник ПЗ",
                vacancyDescription: "Розробка ПЗ",
                vacancySalary: "$123,45");
            const int expected = 1;
            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityService.AddCategory(new EntityOptions(_categoriesPath));

            AddEntityToEntityService.AddVacancyToCategory(0, options);

            var actual = EntityContext<Category>.ReadFile(_categoriesPath)[0].VacanciesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddVacancyToCategory_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _vacanciesPath,
                vacancyName: "Розробник ПЗ",
                vacancyDescription: "Розробка ПЗ",
                vacancySalary: "$123,45");

            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);

            Assert.ThrowsException<Exception>(() => AddEntityToEntityService.AddVacancyToCategory(0, options));
        }

        [TestMethod]
        public void AddVacancyToCategory_should_add_vacancy_to_category_by_index()
        {
            const int expected = 1;
            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityService.AddCategory(new EntityOptions(_categoriesPath));
            EntityService.AddVacancy(new EntityOptions(_vacanciesPath));

            AddEntityToEntityService.AddVacancyToCategory(0, 0);

            var actual = EntityContext<Category>.ReadFile(_categoriesPath)[0].VacanciesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddVacancyToCategory_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);

            Assert.ThrowsException<Exception>(() => AddEntityToEntityService.AddVacancyToCategory(0, index));
        }

        [TestMethod]
        public void AddResumeToCategory_should_add_resume_to_category_by_options()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "DevOps",
                resumeFirstName: "Ivan",
                resumeLastName: "Karpov",
                resumeAge: 18);
            const int expected = 1;
            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Resume>.ClearFile(_resumesPath);
            EntityService.AddCategory(new EntityOptions(_categoriesPath));

            AddEntityToEntityService.AddResumeToCategory(0, options);

            var actual = EntityContext<Category>.ReadFile(_categoriesPath)[0].ResumesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddResumeToCategory_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "DevOps",
                resumeFirstName: "Ivan",
                resumeLastName: "Karpov",
                resumeAge: 18);

            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<Exception>(() => AddEntityToEntityService.AddResumeToCategory(0, options));
        }

        [TestMethod]
        public void AddResumeToCategory_should_add_resume_to_category_by_index()
        {
            const int expected = 1;
            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Resume>.ClearFile(_resumesPath);
            EntityService.AddCategory(new EntityOptions(_categoriesPath));
            EntityService.AddResume(new EntityOptions(_resumesPath));

            AddEntityToEntityService.AddResumeToCategory(0, 0);

            var actual = EntityContext<Category>.ReadFile(_categoriesPath)[0].ResumesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddResumeToCategory_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<Exception>(() => AddEntityToEntityService.AddResumeToCategory(0, index));
        }

        [TestMethod]
        public void AddResumeToUnemployed_should_add_resume_to_unemployed_by_options()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "DevOps",
                resumeFirstName: "Ivan",
                resumeLastName: "Karpov",
                resumeAge: 18);
            const int expected = 1;
            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityContext<Resume>.ClearFile(_resumesPath);
            EntityService.AddUnemployed(new EntityOptions(_unemployedsPath));

            AddEntityToEntityService.AddResumeToUnemployed(0, options);

            var actual = EntityContext<Unemployed>.ReadFile(_unemployedsPath)[0].ResumesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddResumeToUnemployed_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "DevOps",
                resumeFirstName: "Ivan",
                resumeLastName: "Karpov",
                resumeAge: 18);

            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<Exception>(() => AddEntityToEntityService.AddResumeToUnemployed(0, options));
        }

        [TestMethod]
        public void AddResumeToUnemployed_should_add_resume_to_unemployed_by_index()
        {
            const int expected = 1;
            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityContext<Resume>.ClearFile(_resumesPath);
            EntityService.AddUnemployed(new EntityOptions(_unemployedsPath));
            EntityService.AddResume(new EntityOptions(_resumesPath));

            AddEntityToEntityService.AddResumeToUnemployed(0, 0);

            var actual = EntityContext<Unemployed>.ReadFile(_unemployedsPath)[0].ResumesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddResumeToUnemployed_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<Exception>(() => AddEntityToEntityService.AddResumeToUnemployed(0, index));
        }

        [TestMethod]
        public void AddCustomerCompanyToVacancy_should_add_customer_company_to_vacancy_by_options()
        {
            var options = new EntityOptions(
                entityPath: _customerCompaniesPath,
                customerCompanyName: "Samsung",
                customerCompanyCity: "Kyiv",
                customerCompanyHomePage: "samsung.com.ua");
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);
            EntityService.AddVacancy(new EntityOptions(_vacanciesPath));

            AddEntityToEntityService.AddCustomerCompanyToVacancy(0, options);

            var vacancy = EntityContext<Vacancy>.ReadFile(_vacanciesPath)[0];
            Assert.IsNotNull(vacancy.CustomerCompany);
        }

        [TestMethod]
        public void AddCustomerCompanyToVacancy_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _customerCompaniesPath,
                customerCompanyName: "Samsung",
                customerCompanyCity: "Kyiv",
                customerCompanyHomePage: "samsung.com.ua");

            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);

            Assert.ThrowsException<Exception>(() => AddEntityToEntityService.AddCustomerCompanyToVacancy(0, options));
        }

        [TestMethod]
        public void AddCustomerCompanyToVacancy_should_add_customer_company_to_vacancy_by_index()
        {
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);
            EntityService.AddVacancy(new EntityOptions(_vacanciesPath));
            EntityService.AddCustomerCompany(new EntityOptions(_customerCompaniesPath));

            AddEntityToEntityService.AddCustomerCompanyToVacancy(0, 0);

            var vacancy = EntityContext<Vacancy>.ReadFile(_vacanciesPath)[0];
            Assert.IsNotNull(vacancy.CustomerCompany);
        }

        [TestMethod]
        public void AddCustomerCompanyToVacancy_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);

            Assert.ThrowsException<Exception>(() => AddEntityToEntityService.AddCustomerCompanyToVacancy(0, index));
        }
    }
}