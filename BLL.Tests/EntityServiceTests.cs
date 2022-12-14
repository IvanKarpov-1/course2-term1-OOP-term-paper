using BLL.Services;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using EntityOptions = BLL.Options.EntityOptions;

namespace BLL.Tests
{
    [TestClass]
    public class EntityServiceTests
    {
        private readonly string _categoriesPath = ConfigurationManager.AppSettings.Get("CategoryPath");
        private readonly string _customerCompaniesPath = ConfigurationManager.AppSettings.Get("CustomerCompanyPath");
        private readonly string _resumesPath = ConfigurationManager.AppSettings.Get("ResumePath");
        private readonly string _unemployedsPath = ConfigurationManager.AppSettings.Get("UnemployedPath");
        private readonly string _vacanciesPath = ConfigurationManager.AppSettings.Get("VacancyPath");

        [TestMethod]
        public void AddCategory_should_add_category()
        {
            var options = new EntityOptions(
                entityPath: _categoriesPath,
                categoryName: "DevOps");
            var convertedOptions = OptionsConverter.Convert(options);
            var expected = EntityCreator<Category>.CreateEntity(convertedOptions);

            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityService.AddCategory(options);

            var actual = EntityContext<Category>.ReadFile(_categoriesPath)[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddCustomerCompany_should_add_customer_company()
        {
            var options = new EntityOptions(
                entityPath: _customerCompaniesPath,
                customerCompanyName: "Samsung",
                customerCompanyCity: "London",
                customerCompanyAddress: "Backer street, 24",
                customerCompanyPhoneNumber: "0630000000");
            var convertedOptions = OptionsConverter.Convert(options);
            var expected = EntityCreator<CustomerCompany>.CreateEntity(convertedOptions);

            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);
            EntityService.AddCustomerCompany(options);

            var actual = EntityContext<CustomerCompany>.ReadFile(_customerCompaniesPath)[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddResume_should_add_resume()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "Розробик ПЗ",
                resumeFirstName: "Сергій",
                resumeLastName: "Німцов",
                resumeAge: 34,
                resumeCity: "Одеса");
            var convertedOptions = OptionsConverter.Convert(options);
            var expected = EntityCreator<Resume>.CreateEntity(convertedOptions);

            EntityContext<Resume>.ClearFile(_resumesPath);
            EntityService.AddResume(options);

            var actual = EntityContext<Resume>.ReadFile(_resumesPath)[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddUnemployed_should_add_unemployed()
        {
            var options = new EntityOptions(
                entityPath: _unemployedsPath,
                unemployedFirstName: "Ivan",
                unemployedLastName: "Karpov",
                unemployedAge: 123,
                unemployedCity: "Kyiv");
            var convertedOptions = OptionsConverter.Convert(options);
            var expected = EntityCreator<Unemployed>.CreateEntity(convertedOptions);

            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityService.AddUnemployed(options);

            var actual = EntityContext<Unemployed>.ReadFile(_unemployedsPath)[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddVacancy_should_add_vacancy()
        {
            var options = new EntityOptions(
                entityPath: _vacanciesPath,
                vacancyName: "Розробник ПЗ",
                vacancyDescription: "Розробка ПЗ",
                vacancySalary: "$123,45");
            var convertedOptions = OptionsConverter.Convert(options);
            var expected = EntityCreator<Vacancy>.CreateEntity(convertedOptions);

            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityService.AddVacancy(options);

            var actual = EntityContext<Vacancy>.ReadFile(_vacanciesPath)[0];
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DeleteCategory_should_delete_category_by_options()
        {
            var options = new EntityOptions(
                entityPath: _categoriesPath,
                categoryName: "DevOps");
            const int expected = 1;

            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityService.AddCategory(options);
            EntityService.AddCategory(options);
            EntityService.DeleteCategory(options);
            var categories = EntityContext<Category>.ReadFile(_categoriesPath);

            Assert.AreEqual(expected, categories.Count);
        }

        [TestMethod]
        public void DeleteCategory_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _categoriesPath,
                categoryName: "DevOps");

            EntityContext<Category>.ClearFile(_categoriesPath);

            Assert.ThrowsException<Exception>(() => EntityService.DeleteCategory(options));
        }

        [TestMethod]
        public void DeleteCategory_should_delete_category_by_index()
        {
            const int index = 0;
            const int expected = 1;

            EntityContext<Category>.ClearFile(_categoriesPath);
            EntityService.AddCategory(new EntityOptions(_categoriesPath));
            EntityService.AddCategory(new EntityOptions(_categoriesPath));
            EntityService.DeleteCategory(index);
            var categories = EntityContext<Category>.ReadFile(_categoriesPath);

            Assert.AreEqual(expected, categories.Count);
        }

        [TestMethod]
        public void DeleteCategory_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Category>.ClearFile(_categoriesPath);

            Assert.ThrowsException<Exception>(() => EntityService.DeleteCategory(index));
        }

        [TestMethod]
        public void DeleteCustomerCompany_should_delete_customer_company_by_options()
        {
            var options = new EntityOptions(
                entityPath: _customerCompaniesPath,
                customerCompanyName: "Samsung",
                customerCompanyCity: "London",
                customerCompanyAddress: "Backer street, 24",
                customerCompanyPhoneNumber: "0630000000");
            const int expected = 1;

            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);
            EntityService.AddCustomerCompany(options);
            EntityService.AddCustomerCompany(options);
            EntityService.DeleteCustomerCompany(options);
            var customerCompanies = EntityContext<CustomerCompany>.ReadFile(_customerCompaniesPath);

            Assert.AreEqual(expected, customerCompanies.Count);
        }

        [TestMethod]
        public void DeleteCustomerCompany_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _customerCompaniesPath,
                customerCompanyName: "Samsung",
                customerCompanyCity: "London",
                customerCompanyAddress: "Backer street, 24",
                customerCompanyPhoneNumber: "0630000000");

            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);

            Assert.ThrowsException<Exception>(() => EntityService.DeleteCustomerCompany(options));
        }

        [TestMethod]
        public void DeleteCustomerCompany_should_delete_customer_company_by_index()
        {
            const int index = 0;
            const int expected = 1;

            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);
            EntityService.AddCustomerCompany(new EntityOptions(_customerCompaniesPath));
            EntityService.AddCustomerCompany(new EntityOptions(_customerCompaniesPath));
            EntityService.DeleteCustomerCompany(index);
            var customerCompanies = EntityContext<CustomerCompany>.ReadFile(_customerCompaniesPath);

            Assert.AreEqual(expected, customerCompanies.Count);
        }

        [TestMethod]
        public void DeleteCustomerCompany_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);

            Assert.ThrowsException<Exception>(() => EntityService.DeleteCustomerCompany(index));
        }

        [TestMethod]
        public void DeleteResume_should_delete_resume_by_options()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "Розробик ПЗ",
                resumeFirstName: "Сергій",
                resumeLastName: "Німцов",
                resumeAge: 34,
                resumeCity: "Одеса",
                resumeEmail: "",
                resumePhoneNumber: "");
            const int expected = 1;

            EntityContext<Resume>.ClearFile(_resumesPath);
            EntityService.AddResume(options);
            EntityService.AddResume(options);
            EntityService.DeleteResume(options);
            var resumes = EntityContext<Resume>.ReadFile(_resumesPath);

            Assert.AreEqual(expected, resumes.Count);
        }

        [TestMethod]
        public void DeleteResume_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "Розробик ПЗ",
                resumeFirstName: "Сергій",
                resumeLastName: "Німцов",
                resumeAge: 34,
                resumeCity: "Одеса",
                resumeEmail: "",
                resumePhoneNumber: "");

            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<Exception>(() => EntityService.DeleteResume(options));
        }

        [TestMethod]
        public void DeleteResume_should_delete_resume_by_index()
        {
            const int index = 0;
            const int expected = 1;

            EntityContext<CustomerCompany>.ClearFile(_resumesPath);
            EntityService.AddResume(new EntityOptions(_resumesPath));
            EntityService.AddResume(new EntityOptions(_resumesPath));
            EntityService.DeleteResume(index);
            var resumes = EntityContext<Resume>.ReadFile(_resumesPath);

            Assert.AreEqual(expected, resumes.Count);
        }

        [TestMethod]
        public void DeleteResume_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<Exception>(() => EntityService.DeleteResume(index));
        }

        [TestMethod]
        public void DeleteUnemployed_should_delete_unemployed_by_options()
        {
            var options = new EntityOptions(
                entityPath: _unemployedsPath,
                unemployedFirstName: "Ivan",
                unemployedLastName: "Karpov",
                unemployedAge: 123,
                unemployedCity: "Kyiv");
            const int expected = 1;

            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityService.AddUnemployed(options);
            EntityService.AddUnemployed(options);
            EntityService.DeleteUnemployed(options);
            var unemployeds = EntityContext<Unemployed>.ReadFile(_unemployedsPath);

            Assert.AreEqual(expected, unemployeds.Count);
        }

        [TestMethod]
        public void DeleteUnemployed_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _unemployedsPath,
                unemployedFirstName: "Ivan",
                unemployedLastName: "Karpov",
                unemployedAge: 123,
                unemployedCity: "Kyiv");

            EntityContext<Unemployed>.ClearFile(_unemployedsPath);

            Assert.ThrowsException<Exception>(() => EntityService.DeleteUnemployed(options));
        }

        [TestMethod]
        public void DeleteUnemployed_should_delete_unemployed_by_index()
        {
            const int index = 0;
            const int expected = 1;

            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityService.AddUnemployed(new EntityOptions(_unemployedsPath));
            EntityService.AddUnemployed(new EntityOptions(_unemployedsPath));
            EntityService.DeleteUnemployed(index);
            var unemployeds = EntityContext<Unemployed>.ReadFile(_unemployedsPath);

            Assert.AreEqual(expected, unemployeds.Count);
        }

        [TestMethod]
        public void DeleteUnemployed_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Unemployed>.ClearFile(_unemployedsPath);

            Assert.ThrowsException<Exception>(() => EntityService.DeleteUnemployed(index));
        }

        [TestMethod]
        public void DeleteVacancy_should_delete_vacancy_by_options()
        {
            var options = new EntityOptions(
                entityPath: _vacanciesPath,
                vacancyName: "Розробник ПЗ",
                vacancyDescription: "Розробка ПЗ",
                vacancySalary: "$123,45");
            const int expected = 1;

            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityService.AddVacancy(options);
            EntityService.AddVacancy(options);
            EntityService.DeleteVacancy(options);
            var vacancies = EntityContext<Vacancy>.ReadFile(_vacanciesPath);

            Assert.AreEqual(expected, vacancies.Count);
        }

        [TestMethod]
        public void DeleteVacancy_by_options_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _vacanciesPath,
                vacancyName: "Розробник ПЗ",
                vacancyDescription: "Розробка ПЗ",
                vacancySalary: "$123,45");

            EntityContext<Unemployed>.ClearFile(_vacanciesPath);

            Assert.ThrowsException<Exception>(() => EntityService.DeleteVacancy(options));
        }

        [TestMethod]
        public void DeleteVacancy_should_delete_vacancy__by_index()
        {
            const int index = 0;
            const int expected = 1;

            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityService.AddVacancy(new EntityOptions(_vacanciesPath));
            EntityService.AddVacancy(new EntityOptions(_vacanciesPath));
            EntityService.DeleteVacancy(index);
            var vacancies = EntityContext<Vacancy>.ReadFile(_vacanciesPath);

            Assert.AreEqual(expected, vacancies.Count);
        }

        [TestMethod]
        public void DeleteVacancy_by_index_should_throw_exception()
        {
            const int index = 0;

            EntityContext<Vacancy>.ClearFile(_vacanciesPath);

            Assert.ThrowsException<Exception>(() => EntityService.DeleteVacancy(index));
        }
    }
}
