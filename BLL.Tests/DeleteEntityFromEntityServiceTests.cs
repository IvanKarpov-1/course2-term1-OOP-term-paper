using BLL.Services;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using EntityOptions = BLL.Options.EntityOptions;

namespace BLL.Tests
{
    [TestClass]
    public class DeleteEntityFromEntityServiceTests
    {
        private readonly string _categoriesPath = ConfigurationManager.AppSettings.Get("CategoryPath");
        private readonly string _customerCompaniesPath = ConfigurationManager.AppSettings.Get("CustomerCompanyPath");
        private readonly string _resumesPath = ConfigurationManager.AppSettings.Get("ResumePath");
        private readonly string _unemployedsPath = ConfigurationManager.AppSettings.Get("UnemployedPath");
        private readonly string _vacanciesPath = ConfigurationManager.AppSettings.Get("VacancyPath");

        [TestMethod]
        public void DeleteVacancyFromCategory_should_delete_vacancy_from_category_by_options()
        {
            var options = new EntityOptions(
                entityPath: _vacanciesPath,
                vacancyName: "Розробник ПЗ",
                vacancyDescription: "Розробка ПЗ",
                vacancySalary: "$123,45");
            const int expected = 0;
            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityService.AddCategory(new EntityOptions(_categoriesPath));
            AddEntityToEntityService.AddVacancyToCategory(0, options);

            DeleteEntityFromEntityService.DeleteVacancyFromCategory(0, options);

            var actual = EntityContext<Category>.ReadFile(_categoriesPath)[0].VacanciesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteVacancyFromCategory_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _vacanciesPath,
                vacancyName: "Розробник ПЗ",
                vacancyDescription: "Розробка ПЗ",
                vacancySalary: "$123,45");

            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);

            Assert.ThrowsException<Exception>(() => DeleteEntityFromEntityService.DeleteVacancyFromCategory(0, options));
        }

        [TestMethod]
        public void DeleteVacancyFromCategory_should_delete_vacancy_from_category_by_index()
        {
            const int expected = 0;
            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityService.AddCategory(new EntityOptions(_categoriesPath));
            EntityService.AddVacancy(new EntityOptions(_vacanciesPath));
            AddEntityToEntityService.AddVacancyToCategory(0, 0);

            DeleteEntityFromEntityService.DeleteVacancyFromCategory(0, 0);

            var actual = EntityContext<Category>.ReadFile(_categoriesPath)[0].VacanciesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteVacancyFromCategory_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);

            Assert.ThrowsException<Exception>(() => DeleteEntityFromEntityService.DeleteVacancyFromCategory(0, index));
        }

        [TestMethod]
        public void DeleteResumeFromCategory_should_delete_vacancy_from_category_by_options()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "DevOps",
                resumeFirstName: "Ivan",
                resumeLastName: "Karpov",
                resumeAge: 18);
            const int expected = 0;
            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Resume>.ClearFile(_resumesPath);
            EntityService.AddCategory(new EntityOptions(_categoriesPath));
            AddEntityToEntityService.AddResumeToCategory(0, options);

            DeleteEntityFromEntityService.DeleteResumeFromCategory(0, options);

            var actual = EntityContext<Category>.ReadFile(_categoriesPath)[0].ResumesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteResumeFromCategory_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "DevOps",
                resumeFirstName: "Ivan",
                resumeLastName: "Karpov",
                resumeAge: 18);

            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<Exception>(() => DeleteEntityFromEntityService.DeleteResumeFromCategory(0, options));
        }

        [TestMethod]
        public void DeleteResumeFromCategory_should_delete_vacancy_from_category_by_index()
        {
            const int expected = 0;
            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Resume>.ClearFile(_resumesPath);
            EntityService.AddCategory(new EntityOptions(_categoriesPath));
            EntityService.AddResume(new EntityOptions(_resumesPath));
            AddEntityToEntityService.AddResumeToCategory(0, 0);

            DeleteEntityFromEntityService.DeleteResumeFromCategory(0, 0);

            var actual = EntityContext<Category>.ReadFile(_categoriesPath)[0].VacanciesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteResumeFromCategory_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<Exception>(() => DeleteEntityFromEntityService.DeleteResumeFromCategory(0, index));
        }

        [TestMethod]
        public void DeleteResumeFromUnemployed_should_delete_vacancy_from_unemployed_by_options()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "DevOps",
                resumeFirstName: "Ivan",
                resumeLastName: "Karpov",
                resumeAge: 18);
            const int expected = 0;
            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityContext<Resume>.ClearFile(_resumesPath);
            EntityService.AddUnemployed(new EntityOptions(_unemployedsPath));
            AddEntityToEntityService.AddResumeToUnemployed(0, options);

            DeleteEntityFromEntityService.DeleteResumeFromUnemployed(0, options);

            var actual = EntityContext<Unemployed>.ReadFile(_unemployedsPath)[0].ResumesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteResumeFromUnemployed_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "DevOps",
                resumeFirstName: "Ivan",
                resumeLastName: "Karpov",
                resumeAge: 18);

            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<Exception>(() => DeleteEntityFromEntityService.DeleteResumeFromUnemployed(0, options));
        }

        [TestMethod]
        public void DeleteResumeFromUnemployed_should_delete_vacancy_from_unemployed_by_index()
        {
            const int expected = 0;
            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityContext<Resume>.ClearFile(_resumesPath);
            EntityService.AddUnemployed(new EntityOptions(_unemployedsPath));
            EntityService.AddResume(new EntityOptions(_resumesPath));
            AddEntityToEntityService.AddResumeToUnemployed(0, 0);

            DeleteEntityFromEntityService.DeleteResumeFromUnemployed(0, 0);

            var actual = EntityContext<Unemployed>.ReadFile(_unemployedsPath)[0].ResumesList.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteResumeFromUnemployed_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<Exception>(() => DeleteEntityFromEntityService.DeleteResumeFromUnemployed(0, index));
        }

        [TestMethod]
        public void DeleteCustomerCompanyFromVacancy_should_delete_customer_company_from_vacancy_by_options()
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

            DeleteEntityFromEntityService.DeleteCustomerCompanyFromVacancy(0, options);

            var actual = EntityContext<Vacancy>.ReadFile(_vacanciesPath)[0].CustomerCompany;
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void DeleteCustomerCompanyFromVacancy_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "DevOps",
                resumeFirstName: "Ivan",
                resumeLastName: "Karpov",
                resumeAge: 18);

            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);

            Assert.ThrowsException<Exception>(() => DeleteEntityFromEntityService.DeleteCustomerCompanyFromVacancy(0, options));
        }

        [TestMethod]
        public void DeleteCustomerCompanyFromVacancy_should_delete_customer_company_from_vacancy_by_index()
        {
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);
            EntityService.AddVacancy(new EntityOptions(_vacanciesPath));
            EntityService.AddCustomerCompany(new EntityOptions(_customerCompaniesPath));
            AddEntityToEntityService.AddCustomerCompanyToVacancy(0, 0);

            DeleteEntityFromEntityService.DeleteCustomerCompanyFromVacancy(0, 0);

            var vacancy = EntityContext<Vacancy>.ReadFile(_vacanciesPath)[0];
            Assert.IsNull(vacancy.CustomerCompany);
        }

        [TestMethod]
        public void DeleteCustomerCompanyFromVacancy_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);

            Assert.ThrowsException<Exception>(() => DeleteEntityFromEntityService.DeleteCustomerCompanyFromVacancy(0, index));
        }
    }
}