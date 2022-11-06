using BLL.Exceptions;
using BLL.Services;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace BLL.Tests
{
    [TestClass]
    public class SearchServiceTests
    {
        private readonly string _unemployedsPath = ConfigurationManager.AppSettings.Get("UnemployedPath");
        private readonly string _vacanciesPath = ConfigurationManager.AppSettings.Get("VacancyPath");

        [TestMethod]
        public void SearchVacancies_should_return_list_of_data_presenters_with_matches_info()
        {
            const string keyWord = "ops";
            var vacancies = new List<Vacancy>();
            var allData = new List<DataPresenter>();
            vacancies.Add(EntityCreator<Vacancy>.CreateEntity(new EntityOptions(vacancyName: "Tester", vacancySalary: "$123,45")));
            vacancies.Add(EntityCreator<Vacancy>.CreateEntity(new EntityOptions(vacancyName: "DevOps", vacancySalary: "$543,21")));
            vacancies.Add(EntityCreator<Vacancy>.CreateEntity(new EntityOptions(vacancyName: "GameDev", vacancySalary: "$543,21", vacancyDescription: "GameDev with DevOps")));
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);
            var i = 1;
            foreach (var vacancy in vacancies)
            {
                EntityContext<Vacancy>.Write(_vacanciesPath, vacancy);
                allData.Add(new DataPresenter(i).SetData("Vacancy", $"Вакансія: {vacancy.Name}")
                    .SetData("Description", $"Опис: {vacancy.Description}")
                    .SetData("Salary", $"Зарплата: {vacancy.Salary}")
                    .SetData("City", $"Місто: {vacancy.City}")
                    .SetData("CustomerCompany", $"Компанія замовник: {vacancy.CustomerCompany?.Name}"));
                i++;
            }
            var expectedStrings = allData.Where(dataPresenter => dataPresenter.Data.Values.Any(value => value.ToLower().Contains(keyWord.ToLower()))).ToList();

            var actualData = SearchService.SearchVacancies(keyWord);

            i = 0;
            foreach (var actualString in actualData.Select(data => data.ToString()))
            {
                var expectedString = expectedStrings[i].ToString();
                Assert.AreEqual(expectedString, actualString);
                i++;
            }
        }

        [TestMethod]
        public void SearchVacancies_should_throw_exception_about_empty_list()
        {
            var vacancy =
                EntityCreator<Vacancy>.CreateEntity(new EntityOptions(vacancyName: "Tester", vacancySalary: "$123,45"));

            EntityContext<Vacancy>.Write(_vacanciesPath, vacancy);

            Assert.ThrowsException<NoMatchesFoundException>(() => SearchService.SearchVacancies("keyWord"));
        }

        [TestMethod]
        public void SearchVacancies_should_throw_exception_about_no_matches()
        {
            EntityContext<Vacancy>.ClearFile(_vacanciesPath);

            Assert.ThrowsException<EntitiesEmptyException>(() => SearchService.SearchVacancies("keyWord"));
        }

        [TestMethod]
        public void SearchUnemployeds_should_return_list_of_data_presenters_with_matches_info()
        {
            const string keyWord = "Kyiv";
            var unemployeds = new List<Unemployed>();
            var allData = new List<DataPresenter>();
            unemployeds.Add(EntityCreator<Unemployed>.CreateEntity(new EntityOptions(unemployedFirstName: "Ivan", unemployedLastName: "Karpov", unemployedCity: "Kyiv")));
            unemployeds.Add(EntityCreator<Unemployed>.CreateEntity(new EntityOptions(unemployedFirstName: "Anrew", unemployedLastName: "Zen", unemployedCity: "Kyiv")));
            unemployeds.Add(EntityCreator<Unemployed>.CreateEntity(new EntityOptions(unemployedFirstName: "Igor", unemployedLastName: "Zen", unemployedCity: "Odessa")));
            EntityContext<Unemployed>.ClearFile(_unemployedsPath);
            var i = 1;
            foreach (var unemployed in unemployeds)
            {
                EntityContext<Unemployed>.Write(_unemployedsPath, unemployed);
                allData.Add(new DataPresenter(i).SetData("FirstName", $"Ім'я: {unemployed.FirstName}")
                    .SetData("LastName", $"Прізвище: {unemployed.LastName}")
                    .SetData("Age", $"Вік: {unemployed.Age}")
                    .SetData("City", $"Місто: {unemployed.City}")
                    .SetData("Resumes", $"Резюме: {unemployed.ResumesList.Count}"));
                i++;
            }
            var expectedStrings = allData.Where(dataPresenter => dataPresenter.Data.Values.Any(value => value.ToLower().Contains(keyWord.ToLower()))).ToList();

            var actualData = SearchService.SearchUnemployeds(keyWord);

            i = 0;
            foreach (var actualString in actualData.Select(data => data.ToString()))
            {
                var expectedString = expectedStrings[i].ToString();
                Assert.AreEqual(expectedString, actualString);
                i++;
            }
        }

        [TestMethod]
        public void SearchUnemployeds_should_throw_exception_about_empty_list()
        {
            var unemployed =
                EntityCreator<Unemployed>.CreateEntity(new EntityOptions(unemployedFirstName: "Igor", unemployedLastName: "Zen", unemployedCity: "Odessa"));

            EntityContext<Unemployed>.Write(_unemployedsPath, unemployed);

            Assert.ThrowsException<NoMatchesFoundException>(() => SearchService.SearchUnemployeds("keyWord"));
        }

        [TestMethod]
        public void SearchUnemployeds_should_throw_exception_about_no_matches()
        {
            EntityContext<Unemployed>.ClearFile(_unemployedsPath);

            Assert.ThrowsException<EntitiesEmptyException>(() => SearchService.SearchUnemployeds("keyWord"));
        }
    }
}