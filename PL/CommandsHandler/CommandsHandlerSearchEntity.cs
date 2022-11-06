using BLL;
using BLL.Services;
using System;
using System.Collections.Generic;

namespace PL
{
    public static partial class CommandsHandler
    {
        public static void SearchVacancies()
        {
            try
            {
                SearchEntity(SearchService.SearchVacancies);
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        public static void SearchUnemployeds()
        {
            try
            {
                SearchEntity(SearchService.SearchUnemployeds);
            }
            catch (Exception ex)
            {
                ConsoleWorker.WriteItem(ex.Message, foregroundColor: ConsoleColor.Red);
            }
        }

        private static void SearchEntity(Func<string, List<DataPresenter>> searchMethod)
        {
            var keyWord = InputHandler.InputKeyWord();
            ConsoleWorker.WriteItem("\rРезюльтат пошуку:\t\t\t\t\t\t\t\t");
            ShowInfo(searchMethod.Invoke(keyWord));
        }
    }
}