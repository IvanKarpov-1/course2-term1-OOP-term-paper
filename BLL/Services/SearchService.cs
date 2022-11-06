using BLL.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public static class SearchService
    {
        public static List<DataPresenter> SearchVacancies(string keyWord)
        {
            try
            {
                var matches = SearchEntity(keyWord, InfoService.GetVacanciesInfo());
                if (matches.Count == 0)
                    throw new NoMatchesFoundException($"Вакансій за ключовим словом \"{keyWord}\" не знайдено");
                return matches;
            }
            catch (EntitiesEmptyException)
            {
                throw new EntitiesEmptyException("Список вакансій порожній");
            }
        }

        public static List<DataPresenter> SearchUnemployeds(string keyWord)
        {
            try
            {
                var matches = SearchEntity(keyWord, InfoService.GetUnemployedsInfo());
                if (matches.Count == 0)
                    throw new NoMatchesFoundException($"Безробітних за ключовим словом \"{keyWord}\" не знайдено");
                return matches;
            }
            catch (EntitiesEmptyException)
            {
                throw new EntitiesEmptyException("Список безробітних порожній");
            }
        }

        private static List<DataPresenter> SearchEntity(string keyWord, IEnumerable<DataPresenter> allEntities)
        {
            return allEntities.Where(vacancy => vacancy.Data.Values.Any(value => value.ToLower().Contains(keyWord.ToLower())))
                .ToList();
        }
    }
}