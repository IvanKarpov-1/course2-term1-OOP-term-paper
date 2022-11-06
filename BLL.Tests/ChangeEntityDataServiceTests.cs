using BLL.Services;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using EntityOptions = BLL.Options.EntityOptions;

namespace BLL.Tests
{
    [TestClass]
    public class ChangeEntityDataServiceTests
    {
        private readonly string _customerCompaniesPath = ConfigurationManager.AppSettings.Get("CustomerCompanyPath");
        private readonly string _resumesPath = ConfigurationManager.AppSettings.Get("ResumePath");
        private readonly string _unemployedsPath = ConfigurationManager.AppSettings.Get("UnemployedPath");
        private readonly string _vacanciesPath = ConfigurationManager.AppSettings.Get("VacancyPath");

        [TestMethod]
        public void ChangeConcreteCustomerCompanyData_should_change_concrete_customer_company_data()
        {
            var oldOptions = new EntityOptions(
                entityPath: _customerCompaniesPath,
                customerCompanyName: "Samsung",
                customerCompanyCity: "London",
                customerCompanyAddress: "Backer street, 24",
                customerCompanyPhoneNumber: "0630000000");
            var newOptions = new EntityOptions(
                entityPath: _customerCompaniesPath,
                customerCompanyName: "Google",
                customerCompanyCity: "Каліформнія",
                customerCompanyAddress: "Backer street, 24",
                customerCompanyPhoneNumber: "0630000000");
            var convertedNewOptions = OptionsConverter.Convert(newOptions);
            var expected = EntityCreator<CustomerCompany>.CreateEntity(convertedNewOptions);
            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);
            EntityService.AddCustomerCompany(oldOptions);

            ChangeEntityDataService.ChangeConcreteCustomerCompanyData(0, newOptions);

            var actual = EntityContext<CustomerCompany>.ReadFile(_customerCompaniesPath)[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeConcreteCustomerCompanyData_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _customerCompaniesPath,
                customerCompanyName: "Samsung",
                customerCompanyCity: "London",
                customerCompanyAddress: "Backer street, 24",
                customerCompanyPhoneNumber: "0630000000");

            EntityContext<CustomerCompany>.ClearFile(_customerCompaniesPath);

            Assert.ThrowsException<Exception>(() => ChangeEntityDataService.ChangeConcreteCustomerCompanyData(0, options));
        }

        [TestMethod]
        public void ChangeConcreteResumeData_should_change_concrete_resume_data()
        {
            var oldOptions = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "Розробик ПЗ",
                resumeFirstName: "Сергій",
                resumeLastName: "Німцов",
                resumeAge: 34,
                resumeCity: "Одеса");
            var newOptions = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "Розробик ПЗ та тестер",
                resumeFirstName: "Сергій",
                resumeLastName: "Німцов",
                resumeAge: 45,
                resumeCity: "Київ");
            var convertedNewOptions = OptionsConverter.Convert(newOptions);
            var expected = EntityCreator<Resume>.CreateEntity(convertedNewOptions);
            EntityContext<Resume>.ClearFile(_resumesPath);
            EntityService.AddResume(oldOptions);

            ChangeEntityDataService.ChangeConcreteResumedData(0, newOptions);

            var actual = EntityContext<Resume>.ReadFile(_resumesPath)[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeConcreteResumeData_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _resumesPath,
                resumePosition: "Розробик ПЗ",
                resumeFirstName: "Сергій",
                resumeLastName: "Німцов",
                resumeAge: 34,
                resumeCity: "Одеса");

            EntityContext<Resume>.ClearFile(_resumesPath);

            Assert.ThrowsException<Exception>(() => ChangeEntityDataService.ChangeConcreteResumedData(0, options));
        }

        [TestMethod]
        public void ChangeConcreteVacancyData_should_change_concrete_vacancy_data()
        {
            var oldOptions = new EntityOptions(
                entityPath: _vacanciesPath,
                vacancyName: "Розробник ПЗ",
                vacancyDescription: "Розробка ПЗ",
                vacancySalary: "$123,45");
            var newOptions = new EntityOptions(
                entityPath: _vacanciesPath,
                vacancyName: "Розробник ПЗ та тестувальник",
                vacancyDescription: "Розробка ПЗ",
                vacancySalary: "$200,45");
            var convertedNewOptions = OptionsConverter.Convert(newOptions);
            var expected = EntityCreator<Vacancy>.CreateEntity(convertedNewOptions);
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            EntityService.AddVacancy(oldOptions);

            ChangeEntityDataService.ChangeConcreteVacancyData(0, newOptions);

            var actual = EntityContext<Vacancy>.ReadFile(_vacanciesPath)[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeConcreteVacancyData_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _vacanciesPath,
                vacancyName: "Розробник ПЗ",
                vacancyDescription: "Розробка ПЗ",
                vacancySalary: "$123,45");

            EntityContext<Vacancy>.ClearFile(_vacanciesPath);

            Assert.ThrowsException<Exception>(() => ChangeEntityDataService.ChangeConcreteVacancyData(0, options));
        }

        [TestMethod]
        public void ChangeConcreteUnemployedData_should_change_concrete_unemployed_data()
        {
            var oldOptions = new EntityOptions(
                entityPath: _unemployedsPath,
                unemployedFirstName: "Ivan",
                unemployedLastName: "Karpov",
                unemployedAge: 123,
                unemployedCity: "Kyiv");
            var newOptions = new EntityOptions(
                entityPath: _unemployedsPath,
                unemployedFirstName: "Ivan",
                unemployedLastName: "Karpov",
                unemployedAge: 18,
                unemployedCity: "Lviv");
            var convertedNewOptions = OptionsConverter.Convert(newOptions);
            var expected = EntityCreator<Unemployed>.CreateEntity(convertedNewOptions);
            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            EntityService.AddUnemployed(oldOptions);

            ChangeEntityDataService.ChangeConcreteUnemployedData(0, newOptions);

            var actual = EntityContext<Unemployed>.ReadFile(_unemployedsPath)[0];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeConcreteUnemployedData_should_throw_exception()
        {
            var options = new EntityOptions(
                entityPath: _unemployedsPath,
                unemployedFirstName: "Ivan",
                unemployedLastName: "Karpov",
                unemployedAge: 123,
                unemployedCity: "Kyiv");

            EntityContext<Unemployed>.ClearFile(_unemployedsPath);

            Assert.ThrowsException<Exception>(() => ChangeEntityDataService.ChangeConcreteUnemployedData(0, options));
        }
    }
}