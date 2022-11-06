using BLL.Services;
using System;

namespace PL
{
    public static partial class CommandsHandler
    {
        public static void ChangeConcreteCustomerCompanyData()
        {
            try
            {
                var index = InputHandler.InputIndex();
                ChangeEntityDataService.ChangeConcreteCustomerCompanyData(index, GetCustomerCompanyOptions());
                ConsoleWorker.WriteItem("\r\b\rКомпанію замовник змінено\t\t\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void ChangeConcreteVacancyData()
        {
            try
            {
                var index = InputHandler.InputIndex();
                ChangeEntityDataService.ChangeConcreteVacancyData(index, GetVacancyOptions());
                ConsoleWorker.WriteItem("\r\b\rВакансію змінено\t\t\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void ChangeConcreteUnEmployedData()
        {
            try
            {
                var index = InputHandler.InputIndex();
                ChangeEntityDataService.ChangeConcreteUnemployedData(index, GetUnemployedOptions());
                ConsoleWorker.WriteItem("\r\b\rБезробітного змінено\t\t\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void ChangeConcreteResumeData()
        {
            try
            {
                var index = InputHandler.InputIndex();
                ChangeEntityDataService.ChangeConcreteResumedData(index, GetResumeOptions());
                ConsoleWorker.WriteItem("\r\b\rРезюме змінено\t\t\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }
    }
}