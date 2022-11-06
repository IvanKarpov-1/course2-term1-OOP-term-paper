using DAL;
using DAL.Interfaces;
using System;
using System.Configuration;
using EntityOptions = BLL.Options.EntityOptions;

namespace BLL.Services
{
    public static class AddEntityToEntityService
    {
        public static void AddVacancyToCategory(int categoryIndex, EntityOptions options)
        {
            try
            {
                AddEntityToEntity<Vacancy, Category>(options, categoryIndex, ConfigurationManager.AppSettings.Get("CategoryPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddVacancyToCategory(int categoryIndex, int vacancyIndex)
        {
            try
            {
                AddEntityToEntity<Vacancy, Category>(vacancyIndex, categoryIndex,
                    ConfigurationManager.AppSettings.Get("VacancyPath"),
                    ConfigurationManager.AppSettings.Get("CategoryPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddResumeToCategory(int unemployedIndex, EntityOptions options)
        {
            try
            {
                AddEntityToEntity<Resume, Category>(options, unemployedIndex, ConfigurationManager.AppSettings.Get("CategoryPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddResumeToCategory(int unemployedIndex, int resumeIndex)
        {
            try
            {
                AddEntityToEntity<Resume, Category>(resumeIndex, unemployedIndex,
                    ConfigurationManager.AppSettings.Get("ResumePath"),
                    ConfigurationManager.AppSettings.Get("CategoryPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddResumeToUnemployed(int unemployedIndex, EntityOptions options)
        {
            try
            {
                AddEntityToEntity<Resume, Unemployed>(options, unemployedIndex, ConfigurationManager.AppSettings.Get("UnemployedPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddResumeToUnemployed(int unemployedIndex, int resumeIndex)
        {
            try
            {
                AddEntityToEntity<Resume, Unemployed>(resumeIndex, unemployedIndex,
                    ConfigurationManager.AppSettings.Get("ResumePath"),
                    ConfigurationManager.AppSettings.Get("UnemployedPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddCustomerCompanyToVacancy(int vacancyIndex, EntityOptions options)
        {
            try
            {
                AddEntityToEntity<CustomerCompany, Vacancy>(options, vacancyIndex, ConfigurationManager.AppSettings.Get("VacancyPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddCustomerCompanyToVacancy(int vacancyIndex, int customerCompanyIndex)
        {
            try
            {
                AddEntityToEntity<CustomerCompany, Vacancy>(customerCompanyIndex, vacancyIndex,
                    ConfigurationManager.AppSettings.Get("CustomerCompanyPath"),
                    ConfigurationManager.AppSettings.Get("VacancyPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void AddEntityToEntity<TToAdd, TAddTo>(EntityOptions toAddEntityOptions, int addToIndex, string addToPath)
            where TToAdd : class, IEntity, new()
            where TAddTo : class, IEntity, IContainsOtherEntities
        {
            var convertedOptions = OptionsConverter.Convert(toAddEntityOptions);
            var entitiesWhereToAdd = EntityContext<TAddTo>.ReadFile(addToPath);
            var entityToAdd = EntityCreator<TToAdd>.CreateEntity(convertedOptions);
            entitiesWhereToAdd[addToIndex].AddEntity(entityToAdd);
            EntityContext<TToAdd>.Write(toAddEntityOptions.EntityPath, entityToAdd);
            EntityContext<TAddTo>.ClearFile(addToPath);
            foreach (var entity in entitiesWhereToAdd)
            {
                EntityContext<TAddTo>.Write(addToPath, entity);
            }
        }

        private static void AddEntityToEntity<TToAdd, TAddTo>(int toAddIndex, int addToIndex,
            string toAddPath, string addToPath)
            where TToAdd : class, IEntity 
            where TAddTo : class, IEntity, IContainsOtherEntities
        {
            var firstEntity = EntityContext<TToAdd>.ReadFile(toAddPath)[toAddIndex];
            var secondEntities = EntityContext<TAddTo>.ReadFile(addToPath);
            secondEntities[addToIndex].AddEntity(firstEntity);
            EntityContext<TAddTo>.ClearFile(addToPath);
            foreach (var secondEntity in secondEntities)
            {
                EntityContext<TAddTo>.Write(addToPath, secondEntity);
            }
        }
    }
}