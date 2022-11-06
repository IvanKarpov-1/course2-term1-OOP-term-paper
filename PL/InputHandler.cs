using System.Configuration;
using System;

namespace PL
{
    public class InputHandler
    {
        public static string InputName()
        {
            return InputData("Введіть назву: ", ConfigurationManager.AppSettings.Get("Description"));
        }

        public static string InputDescription()
        {
            return InputData("Введіть опис: ", ConfigurationManager.AppSettings.Get("Description"));
        }

        public static string InputPhoneNamber()
        {
            return InputData("Введіть номер телефону: ", ConfigurationManager.AppSettings.Get("PhoneNumber"));
        }

        public static string InputAddress()
        {
            return InputData("Введіть адресу: ", "");
        }

        public static string InputCity()
        {
            return InputData("Введіть місто: ", ConfigurationManager.AppSettings.Get("Name"));
        }

        public static string InputHomePage()
        {
            return InputData("Введіть домашню сторінку: ", ConfigurationManager.AppSettings.Get("HomePage"));
        }

        public static string InputPosition()
        {
            return InputData("Введіть позицию на яку претендує: ", ConfigurationManager.AppSettings.Get("Description"));
        }

        public static string InputFirstName()
        {
            return InputData("Введіть ім'я: ", ConfigurationManager.AppSettings.Get("Name"));
        }

        public static string InputLastName()
        {
            return InputData("Введіть прізвище: ", ConfigurationManager.AppSettings.Get("Name"));
        }

        public static int InputAge()
        {
            return int.Parse(InputData("Введіть вік: ", ConfigurationManager.AppSettings.Get("Age")));
        }

        public static string InputEmail()
        {
            return InputData("Введіть e-mail: ", ConfigurationManager.AppSettings.Get("Email"));
        }

        public static string InputSalary()
        {
            return InputData("Введіть зарплату (формат: $123,22): ", ConfigurationManager.AppSettings.Get("Salary"));
        }

        public static int InputIndex()
        {
            return int.Parse(InputData("Введіть номер: ", ConfigurationManager.AppSettings.Get("Age")));
        }

        public static bool InputYesNoQuestion()
        {
            var valueString = InputData("", ConfigurationManager.AppSettings.Get("YesNoQuestion"));
            return valueString == "Y" || valueString == "Т" || valueString == "Yes" || valueString == "Так" || valueString == "";
        }

        public static string InputKeyWord()
        {
            return InputData("Введіть ключове слово: ", ConfigurationManager.AppSettings.Get("Description"));
        }

        private static string InputData(string message, string rule)
        {
            ConsoleWorker.WriteItem(message, false);
            var name = ConsoleWorker.ReadItem(foregroundColor: ConsoleColor.Yellow);
            if (name == string.Empty) return name;
            var checker = new InputChecker(name, rule);
            return checker.Check(ConsoleColor.Yellow);
        }
    }
}