using System;
using DAL;
using System.Configuration;
using EntityOptions = BLL.Options.EntityOptions;
using DAL.Interfaces;

namespace BLL.Services
{
    public static class DeleteEntityFromEntityService
    {
        public static void DeleteVacancyFromCategory(int categoryIndex, EntityOptions options)
        {
            try
            {
                DeleteEntityFromEntity<Vacancy, Category>(options, categoryIndex, ConfigurationManager.AppSettings.Get("CategoryPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteVacancyFromCategory(int categoryIndex, int vacancyIndex)
        {
            try
            {
                DeleteEntityFromEntity<Vacancy, Category>(vacancyIndex, categoryIndex,
                    ConfigurationManager.AppSettings.Get("VacancyPath"),
                    ConfigurationManager.AppSettings.Get("CategoryPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteResumeFromCategory(int categoryIndex, EntityOptions options)
        {
            try
            {
                DeleteEntityFromEntity<Resume, Category>(options, categoryIndex, ConfigurationManager.AppSettings.Get("CategoryPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteResumeFromCategory(int categoryIndex, int resumeIndex)
        {
            try
            {
                DeleteEntityFromEntity<Resume, Category>(resumeIndex, categoryIndex,
                    ConfigurationManager.AppSettings.Get("ResumePath"),
                    ConfigurationManager.AppSettings.Get("CategoryPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteResumeFromUnemployed(int categoryIndex, EntityOptions options)
        {
            try
            {
                DeleteEntityFromEntity<Resume, Unemployed>(options, categoryIndex, ConfigurationManager.AppSettings.Get("UnemployedPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteResumeFromUnemployed(int unemployedIndexIndex, int resumeIndex)
        {
            try
            {
                DeleteEntityFromEntity<Resume, Unemployed>(resumeIndex, unemployedIndexIndex,
                    ConfigurationManager.AppSettings.Get("ResumePath"),
                    ConfigurationManager.AppSettings.Get("UnemployedPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCustomerCompanyFromVacancy(int vacancyIndex, EntityOptions options)
        {
            try
            {
                DeleteEntityFromEntity<CustomerCompany, Vacancy>(options, vacancyIndex, ConfigurationManager.AppSettings.Get("VacancyPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCustomerCompanyFromVacancy(int vacancyIndex, int customerCompanyIndex)
        {
            try
            {
                DeleteEntityFromEntity<CustomerCompany, Vacancy>(customerCompanyIndex, vacancyIndex,
                    ConfigurationManager.AppSettings.Get("CustomerCompanyPath"),
                    ConfigurationManager.AppSettings.Get("VacancyPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void DeleteEntityFromEntity<TTo, TFrom>(EntityOptions toDeleteEntityOptions, int deleteFromIndex, string deleteFromPath)
            where TTo : class, IEntity, new()
            where TFrom : class, IEntity, IContainsOtherEntities
        {
            var convertedOptions = OptionsConverter.Convert(toDeleteEntityOptions);
            var entitiesWhereToDelete = EntityContext<TFrom>.ReadFile(deleteFromPath);
            var entityToDelete = EntityCreator<TTo>.CreateEntity(convertedOptions);
            entitiesWhereToDelete[deleteFromIndex].DeleteEntity(entityToDelete);
            EntityContext<TFrom>.ClearFile(deleteFromPath);
            foreach (var entity in entitiesWhereToDelete)
            {
                EntityContext<TFrom>.Write(deleteFromPath, entity);
            }
        }

        private static void DeleteEntityFromEntity<TTo, TFrom>(int toDeleteIndex, int deleteFromIndex,
            string toDeletePath, string deleteFromPath)
            where TTo : class, IEntity
            where TFrom : class, IEntity, IContainsOtherEntities
        {
            var entityToDelete = EntityContext<TTo>.ReadFile(toDeletePath)[0];
            var entitiesWhereToDelete = EntityContext<TFrom>.ReadFile(deleteFromPath);
            entitiesWhereToDelete[deleteFromIndex].DeleteEntity(entityToDelete, toDeleteIndex);
            EntityContext<TFrom>.ClearFile(deleteFromPath);
            foreach (var entity in entitiesWhereToDelete)
            {
                EntityContext<TFrom>.Write(deleteFromPath, entity);
            }
        }
    }
}