using BLL.Services;
using System;

namespace PL
{
    public static partial class CommandsHandler
    {
        public static void DeleteCategory()
        {
            try
            {
                ConsoleWorker.WriteItem("Дані категорії відомі? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion() == false)
                {
                    EntityService.DeleteCategory(InputHandler.InputIndex() - 1);
                }
                else
                {
                    EntityService.DeleteCategory(GetCategoryOptions());
                }
                ConsoleWorker.WriteItem("\rКатегорію видалено\t\t\t\t\t\t\t");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteCustomerCompany()
        {
            try
            {
                ConsoleWorker.WriteItem("Дані компанії замовника відомі? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion() == false)
                {
                    EntityService.DeleteCustomerCompany(InputHandler.InputIndex() - 1);
                }
                else
                {
                    EntityService.DeleteCustomerCompany(GetCustomerCompanyOptions());
                }
                ConsoleWorker.WriteItem("\rКомпанію замовника видалено\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteResume()
        {
            try
            {
                ConsoleWorker.WriteItem("Дані резюме відомі? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion() == false)
                {
                    EntityService.DeleteResume(InputHandler.InputIndex() - 1);
                }
                else
                {
                    EntityService.DeleteResume(GetResumeOptions());
                }
                ConsoleWorker.WriteItem("\rРезюме видалено\t\t\t\t\t\t\t");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteUnemployed()
        {
            try
            {
                ConsoleWorker.WriteItem("Дані безробітного відомі? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion() == false)
                {
                    EntityService.DeleteUnemployed(InputHandler.InputIndex() - 1);
                }
                else
                {
                    EntityService.DeleteUnemployed(GetUnemployedOptions());
                }
                ConsoleWorker.WriteItem("\rБезробітного видалено\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteVacancy()
        {
            try
            {
                ConsoleWorker.WriteItem("Дані вакансії відомі? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion() == false)
                {
                    EntityService.DeleteVacancy(InputHandler.InputIndex() - 1);
                }
                else
                {
                    EntityService.DeleteVacancy(GetVacancyOptions());
                }
                ConsoleWorker.WriteItem("\rВакансію видалено\t\t\t\t\t\t\t");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DeleteResumeFromCategory(int categoryIndex)
        {
            categoryIndex--;
            try
            {
                ConsoleWorker.WriteItem("Видалити резюме за його даними? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion())
                {
                    DeleteEntityFromEntityService.DeleteResumeFromCategory(categoryIndex, GetResumeOptions());
                }
                else
                {
                    var resumeIndex = InputHandler.InputIndex();
                    DeleteEntityFromEntityService.DeleteResumeFromCategory(categoryIndex, resumeIndex - 1);
                }
                ConsoleWorker.WriteItem("\r\rРезюме видалено\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void DeleteVacancyFromCategory(int categoryIndex)
        {
            categoryIndex--;
            try
            {
                ConsoleWorker.WriteItem("Видалити вакансію за її даними? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion())
                {
                    DeleteEntityFromEntityService.DeleteVacancyFromCategory(categoryIndex, GetVacancyOptions());
                }
                else
                {
                    var vacancyIndex = InputHandler.InputIndex();
                    DeleteEntityFromEntityService.DeleteVacancyFromCategory(categoryIndex, vacancyIndex - 1);
                }
                ConsoleWorker.WriteItem("\r\rВакансію видалено\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void DeleteResumeFromUnemployed(int categoryIndex)
        {
            categoryIndex--;
            try
            {
                ConsoleWorker.WriteItem("Видалити резюме за його даними? (Y/N, Т/Н, Yes/No, Так/Ні): ", false);
                if (InputHandler.InputYesNoQuestion())
                {
                    DeleteEntityFromEntityService.DeleteResumeFromUnemployed(categoryIndex, GetResumeOptions());
                }
                else
                {
                    var resumeIndex = InputHandler.InputIndex();
                    DeleteEntityFromEntityService.DeleteResumeFromUnemployed(categoryIndex, resumeIndex - 1);
                }
                ConsoleWorker.WriteItem("\r\rРезюме видалено\t\t\t\t\t\t\t\t\t\t");
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void DeleteCustomerCompanyFromVacancy(int vacancyIndex)
        {
            vacancyIndex--;
            try
            {
                DeleteEntityFromEntityService.DeleteCustomerCompanyFromVacancy(vacancyIndex, 0);
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }
    }
}