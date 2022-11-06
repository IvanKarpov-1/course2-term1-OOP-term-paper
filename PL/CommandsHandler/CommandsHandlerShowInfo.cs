using BLL;
using BLL.Services;
using System;
using System.Collections.Generic;

namespace PL
{
    public static partial class CommandsHandler
    {
        public static void ShowCategories(SortingType sortingType = SortingType.None)
        {
            try
            {
                ShowInfo(InfoService.GetCategoriesInfo(sortingType));
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static string ShowConcreteCategory(out int index)
        {
            index = -1;
            try
            {
                index = InputHandler.InputIndex();
                var data = InfoService.GetConcreteCategoryInfo(index);

                return data.Data["Name"];
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }

            return string.Empty;
        }

        public static void ShowCategoryVacancies(int index)
        {
            try
            {
                var data = InfoService.GetConcreteCategoryInfo(index);
                ConsoleWorker.WriteItem("\r\t\t\t\t\r\b");
                foreach (var item in data.Data)
                {
                    if (item.Key == "Resumes") break;
                    ConsoleWorker.WriteItem(item.Value);
                }
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void ShowCategoryResumes(int index)
        {
            try
            {
                var isResumeInQueue = false;
                var data = InfoService.GetConcreteCategoryInfo(index);
                ConsoleWorker.WriteItem("\r\t\t\t\t\r\b");
                foreach (var item in data.Data)
                {
                    if (item.Key == "Resumes") isResumeInQueue = true;
                    if (isResumeInQueue)
                    {
                        ConsoleWorker.WriteItem(item.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void ShowCustomerCompanies(SortingType sortingType = SortingType.None)
        {
            try
            {
                ShowInfo(InfoService.GetCustomerCompaniesInfo(sortingType));
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void ShowConcreteCustomerCompanies()
        {
            try
            {
                ShowConcreteInfo(InfoService.GetCustomerCompaniesInfo());
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void ShowResumes(SortingType sortingType = SortingType.None)
        {
            try
            {
                ShowInfo(InfoService.GetResumesInfo(sortingType));
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void ShowConcreteResume()
        {
            try
            {
                ShowConcreteInfo(InfoService.GetResumesInfo());
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void ShowUnemployeds(SortingType sortingType = SortingType.None)
        {
            try
            {
                ShowInfo(InfoService.GetUnemployedsInfo(sortingType));
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static string ShowConcreteUnemployed(out int index)
        {
            index = -1;
            try
            {
                index = InputHandler.InputIndex();
                var data = InfoService.GetUnemployedsInfo()[index];

                return data.Data["FirstName"];
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }

            return string.Empty;
        }

        public static void ShowUnemployedResumes(int unemployedIndex)
        {
            try
            {
                var isResumeInQueue = false;
                var data = InfoService.GetConcreteUnemployedInfo(unemployedIndex);
                ConsoleWorker.WriteItem("\r\t\t\t\t\r\b");
                foreach (var item in data.Data)
                {
                    if (item.Key == "Resumes") isResumeInQueue = true;
                    if (isResumeInQueue)
                    {
                        ConsoleWorker.WriteItem(item.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void ShowVacancies(SortingType sortingType = SortingType.None)
        {
            try
            {
                ShowInfo(InfoService.GetVacanciesInfo(sortingType));
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static string ShowConcreteVacancy(out int index)
        {
            index = -1;
            try
            {
                index = InputHandler.InputIndex();
                var data = InfoService.GetVacanciesInfo()[index];

                return data.Data["Vacancy"];
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }

            return string.Empty;
        }

        private static void ShowInfo(List<DataPresenter> data)
        {
            foreach (var dataPresenter in data)
            {
                ConsoleWorker.WriteItem($"{dataPresenter.Index}) ", false);
                foreach (var item in dataPresenter.Data)
                {
                    ConsoleWorker.WriteItem(item.Value);
                }
            }
        }

        private static void ShowConcreteInfo(IReadOnlyList<DataPresenter> data)
        {
            var index = InputHandler.InputIndex();
            var concreteData = data[index];
            ConsoleWorker.WriteItem("\r\t\t\t\t\r");
            foreach (var item in concreteData.Data)
            {
                ConsoleWorker.WriteItem(item.Value);
            }
        }
    }
}