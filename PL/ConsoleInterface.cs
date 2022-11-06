using BLL;

namespace PL
{
    public static class ConsoleInterface
    {
        public static void Start()
        {
            var categoryIndex = 0;
            var unemployedIndex = 0;
            var vacancyIndex = 0;

            var categoryVacancies = new Menu("")
                .Add("Переглянути список вакансій категорії", () => CommandsHandler.ShowCategoryVacancies(categoryIndex))
                .Add("Додати вакансію", () => CommandsHandler.AddVacancyToCategory(categoryIndex))
                .Add("Видалити вакансію", () => CommandsHandler.DeleteVacancyFromCategory(categoryIndex))
                .Add("Назад", Menu.Close);
            var categoryResumes = new Menu("")
                .Add("Переглянути список резюме категорії", () => CommandsHandler.ShowCategoryResumes(categoryIndex))
                .Add("Додати резюме", () => CommandsHandler.AddResumeyToCategory(categoryIndex))
                .Add("Видалити резюме", () => CommandsHandler.DeleteResumeFromCategory(categoryIndex))
                .Add("Назад", Menu.Close);
            var unemployedResume = new Menu("")
                .Add("Переглянути список резюме безробітного", () => CommandsHandler.ShowUnemployedResumes(unemployedIndex))
                .Add("Додати резюме", () => CommandsHandler.AddResumeToUnemployed(unemployedIndex))
                .Add("Видалити резюме", () => CommandsHandler.DeleteResumeFromUnemployed(unemployedIndex))
                .Add("Назад", Menu.Close);
            var vacancyCustomerCompany = new Menu("")
                .Add("Додати компанію замовник", () => CommandsHandler.AddCustomerCompanyToVacancy(vacancyIndex))
                .Add("Видалити компанію замовник", () => CommandsHandler.DeleteCustomerCompanyFromVacancy(vacancyIndex))
                .Add("Назад", Menu.Close);

            var concreteCategory = new Menu("");
            concreteCategory
                .Add("Вакансії", () =>
                {
                    categoryVacancies.SetTile(concreteCategory.Title + " / Вакансії");
                    categoryVacancies.Run(concreteCategory.CurrentBuffer);
                })
                .Add("Резюме", () =>
                {
                    categoryResumes.SetTile(concreteCategory.Title + " / Резюме");
                    categoryResumes.Run(concreteCategory.CurrentBuffer);
                })
                .Add("Назад", Menu.Close);

            var concreteUnemployed = new Menu("");
            concreteUnemployed
                .Add("Резюме", () =>
                {
                    unemployedResume.SetTile(concreteUnemployed.Title + " / Резюме");
                    unemployedResume.Run(concreteUnemployed.CurrentBuffer);
                })
                .Add("Назад", Menu.Close);

            var concreteVacancy = new Menu("");
            concreteVacancy
                .Add("Компанія замовник", () =>
                {
                    vacancyCustomerCompany.SetTile(concreteVacancy.Title + " / Вакансії");
                    vacancyCustomerCompany.Run(concreteVacancy.CurrentBuffer);
                })
                .Add("Назад", Menu.Close);

            var categoryMenu = new Menu("Категорії");
            categoryMenu
                .Add("Додати категорію", CommandsHandler.AddCategory)
                .Add("Видалити категорію", CommandsHandler.DeleteCategory)
                .Add("Показати категорії", () => CommandsHandler.ShowCategories())
                .Add("Показати категорії (відсортовано)", () => CommandsHandler.ShowCategories(SortingType.Ascending))
                .Add("Показати конкретну категорію", () =>
                {
                    concreteCategory.SetTile(CommandsHandler.ShowConcreteCategory(out categoryIndex));
                    concreteCategory.Run(categoryMenu.CurrentBuffer);
                })
                .Add("Назад", Menu.Close);
            var customerCompanyMenu = new Menu("Компанії замовники");
            customerCompanyMenu
                .Add("Додати компанію замовник", CommandsHandler.AddCustomerCompany)
                .Add("Видалити компанію замовника", CommandsHandler.DeleteCustomerCompany)
                .Add("Змінити дані компанії замовника", CommandsHandler.ChangeConcreteCustomerCompanyData)
                .Add("Показати компанії замовники", () => CommandsHandler.ShowCustomerCompanies())
                .Add("Показати компанії замовники (відсортовано за іменем)", () => CommandsHandler.ShowCustomerCompanies(SortingType.ByFirstName))
                .Add("Показати компанії замовники (відсортовано за прізвищем)", () => CommandsHandler.ShowCustomerCompanies(SortingType.ByLastName))
                .Add("Показати конкретну компанію замовник", CommandsHandler.ShowConcreteCustomerCompanies)
                .Add("Назад", Menu.Close);
            var resumeMenu = new Menu("Резюме");
            resumeMenu
                .Add("Додати резюме", CommandsHandler.AddResume)
                .Add("Видалити резюме", CommandsHandler.DeleteResume)
                .Add("Змінити дані резюме", CommandsHandler.ChangeConcreteResumeData)
                .Add("Показати список резюме", () => CommandsHandler.ShowResumes())
                .Add("Показати список резюме (відсортовано за назвою)", () => CommandsHandler.ShowResumes(SortingType.Ascending))
                .Add("Показати список резюме (відсортовано за іменем)", () => CommandsHandler.ShowResumes(SortingType.ByFirstName))
                .Add("Показати список резюме (відсортовано за прізвищем)", () => CommandsHandler.ShowResumes(SortingType.ByLastName))
                .Add("Показати конкретне резюме", CommandsHandler.ShowConcreteResume)
                .Add("Назад", Menu.Close);
            var unemployedMenu = new Menu("Безробітні");
            unemployedMenu
                .Add("Додати безробітнього", CommandsHandler.AddUnemployed)
                .Add("Видалити безробітного", CommandsHandler.DeleteUnemployed)
                .Add("Змінити дані безробітного", CommandsHandler.ChangeConcreteUnEmployedData)
                .Add("Показати безробітних", () => CommandsHandler.ShowUnemployeds())
                .Add("Показати безробітних (відсортовано за іменем)", () => CommandsHandler.ShowUnemployeds(SortingType.ByFirstName))
                .Add("Показати безробітних (відсортовано за прізвищем)", () => CommandsHandler.ShowUnemployeds(SortingType.ByLastName))
                .Add("Показати конкретного безробітного", () =>
                {
                    concreteUnemployed.SetTile(CommandsHandler.ShowConcreteUnemployed(out unemployedIndex));
                    concreteUnemployed.Run(unemployedMenu.CurrentBuffer);
                })
                .Add("Назад", Menu.Close);
            var vacancyMenu = new Menu("Вакансії");
            vacancyMenu
                .Add("Додати вакансію", CommandsHandler.AddVacancy)
                .Add("Видалити вакансію", CommandsHandler.DeleteVacancy)
                .Add("Змінити дані вакансії", CommandsHandler.ChangeConcreteVacancyData)
                .Add("Показати вакансії", () => CommandsHandler.ShowVacancies())
                .Add("Показати вакансії (відсортовано)", () => CommandsHandler.ShowVacancies(SortingType.Ascending))
                .Add("Показати конкретну вакансію", () =>
                {
                    concreteVacancy.SetTile(CommandsHandler.ShowConcreteVacancy(out vacancyIndex));
                    concreteVacancy.Run(vacancyMenu.CurrentBuffer);
                })
                .Add("Назад", Menu.Close);
            var searchMenu = new Menu("Пошук");
            searchMenu
                .Add("Пошук вакансій по ключовому слову", CommandsHandler.SearchVacancies)
                .Add("Пошук безробітних по ключовому слову", CommandsHandler.SearchUnemployeds)
                .Add("Назад", Menu.Close);

            var mainMenu = new Menu("Біржа праці");
            mainMenu
                .Add("Категорія", () => categoryMenu.Run(mainMenu.CurrentBuffer))
                .Add("Компанія замовник", () => customerCompanyMenu.Run(mainMenu.CurrentBuffer))
                .Add("Резюме", () => resumeMenu.Run(mainMenu.CurrentBuffer))
                .Add("Безробітний", () => unemployedMenu.Run(mainMenu.CurrentBuffer))
                .Add("Вакансія", () => vacancyMenu.Run(mainMenu.CurrentBuffer))
                .Add("Пошук", () => searchMenu.Run(mainMenu.CurrentBuffer))
                .Add("Вихід", Menu.Close);

            mainMenu.Run();
        }
    }
}