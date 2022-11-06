using BLL.Services;
using System;

namespace PL
{
    public static partial class CommandsHandler
    {
        public static void AddCategory()
        {
            try
            {
                EntityService.AddCategory(GetCategoryOptions());
                ConsoleWorker.WriteItem("\rКатегорію додано\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void AddCustomerCompany()
        {
            try
            {
                EntityService.AddCustomerCompany(GetCustomerCompanyOptions());
                ConsoleWorker.WriteItem("\rКомпанію замовник додано\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void AddResume()
        {
            try
            {
                EntityService.AddResume(GetResumeOptions());
                ConsoleWorker.WriteItem("\rРезюме додано\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void AddUnemployed()
        {
            try
            {
                EntityService.AddUnemployed(GetUnemployedOptions());
                ConsoleWorker.WriteItem("\rБезробітного додано\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void AddVacancy()
        {
            try
            {
                EntityService.AddVacancy(GetVacancyOptions());
                ConsoleWorker.WriteItem("\rВакансію додано\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void AddResumeyToCategory(int categoryIndex)
        {
            categoryIndex--;
            try
            {
                ConsoleWorker.WriteItem("Додати існуюче резюме? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion() == false)
                {
                    AddEntityToEntityService.AddResumeToCategory(categoryIndex, GetResumeOptions());
                }
                else
                {
                    var vacancyIndex = InputHandler.InputIndex();
                    AddEntityToEntityService.AddResumeToCategory(categoryIndex, vacancyIndex - 1);
                }
                ConsoleWorker.WriteItem("\rРезюме додано\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void AddVacancyToCategory(int categoryIndex)
        {
            categoryIndex--;
            try
            {
                ConsoleWorker.WriteItem("Додати існуючу вакансію? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion() == false)
                {
                    AddEntityToEntityService.AddVacancyToCategory(categoryIndex, GetVacancyOptions());
                }
                else
                {
                    var vacancyIndex = InputHandler.InputIndex();
                    AddEntityToEntityService.AddVacancyToCategory(categoryIndex, vacancyIndex - 1);
                }
                ConsoleWorker.WriteItem("\rВакансію додано\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void AddResumeToUnemployed(int unemployedIndex)
        {
            unemployedIndex--;
            try
            {
                ConsoleWorker.WriteItem("Додати існуюче резюме? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion() == false)
                {
                    AddEntityToEntityService.AddResumeToUnemployed(unemployedIndex, GetResumeOptions());
                }
                else
                {
                    var resumeIndex = InputHandler.InputIndex();
                    AddEntityToEntityService.AddResumeToUnemployed(unemployedIndex, resumeIndex - 1);
                }
                ConsoleWorker.WriteItem("\r\b\rРезюме додано\t\t\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void AddCustomerCompanyToVacancy(int vacancyIndex)
        {
            vacancyIndex--;
            try
            {
                ConsoleWorker.WriteItem("Додати існуючу компанію замовник? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion() == false)
                {
                    AddEntityToEntityService.AddCustomerCompanyToVacancy(vacancyIndex, GetCustomerCompanyOptions());
                }
                else
                {
                    var customerCompanyIndex = InputHandler.InputIndex();
                    AddEntityToEntityService.AddCustomerCompanyToVacancy(vacancyIndex, customerCompanyIndex - 1);
                }
                ConsoleWorker.WriteItem("\r\b\rКомпанію замовник додано\t\t\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }
    }
}