using BLL.Options;
using System.Configuration;

namespace PL
{
    public static partial class CommandsHandler
    {
        private static EntityOptions GetCategoryOptions()
        {
            var name = InputHandler.InputName();
            var options = new EntityOptions(ConfigurationManager.AppSettings.Get("CategoryPath"), categoryName: name);
            return options;
        }

        private static EntityOptions GetCustomerCompanyOptions()
        {
            var name = InputHandler.InputName();
            var firstName = InputHandler.InputFirstName();
            var lastName = InputHandler.InputLastName();
            var description = InputHandler.InputDescription();
            var phoneNumber = InputHandler.InputPhoneNamber();
            var address = InputHandler.InputAddress();
            var city = InputHandler.InputCity();
            var homePage = InputHandler.InputHomePage();
            var options = new EntityOptions(
                ConfigurationManager.AppSettings.Get("CustomerCompanyPath"),
                customerCompanyName: name,
                customerCompanyFirstName: firstName,
                customerCompanyLastName: lastName,
                customerCompanyDescription: description,
                customerCompanyPhoneNumber: phoneNumber,
                customerCompanyCity: city,
                customerCompanyAddress: address,
                customerCompanyHomePage: homePage);
            return options;
        }

        private static EntityOptions GetResumeOptions()
        {
            var position = InputHandler.InputPosition();
            var firstName = InputHandler.InputFirstName();
            var lastName = InputHandler.InputLastName();
            var age = InputHandler.InputAge();
            var city = InputHandler.InputCity();
            var email = InputHandler.InputEmail();
            var phoneNumber = InputHandler.InputPhoneNamber();
            var options = new EntityOptions(
                ConfigurationManager.AppSettings.Get("ResumePath"),
                resumePosition: position,
                resumeFirstName: firstName,
                resumeLastName: lastName,
                resumeAge: age,
                resumeCity: city,
                resumeEmail: email,
                resumePhoneNumber: phoneNumber);
            return options;
        }

        private static EntityOptions GetUnemployedOptions()
        {

            var firstName = InputHandler.InputFirstName();
            var lastName = InputHandler.InputLastName();
            var age = InputHandler.InputAge();
            var city = InputHandler.InputCity();
            var options = new EntityOptions(
                ConfigurationManager.AppSettings.Get("UnemployedPath"),
                unemployedFirstName: firstName,
                unemployedLastName: lastName,
                unemployedAge: age,
                unemployedCity: city);
            return options;
        }

        private static EntityOptions GetVacancyOptions()
        {
            var name = InputHandler.InputName();
            var description = InputHandler.InputDescription();
            var salary = InputHandler.InputSalary();
            var options = new EntityOptions(
                ConfigurationManager.AppSettings.Get("VacancyPath"),
                vacancyName: name,
                vacancyDescription: description,
                vacancySalary: salary);
            return options;
        }
    }
}