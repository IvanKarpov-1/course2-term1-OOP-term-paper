using DAL;
using DAL.Interfaces;
using System;
using System.Configuration;
using EntityOptions = BLL.Options.EntityOptions;

namespace BLL.Services
{
    public static class EntityService
    {
        #region AddEntity

        public static void AddCategory(EntityOptions options)
        {
            AddEntity<Category>(options);
        }

        public static void AddCustomerCompany(EntityOptions options)
        {
            AddEntity<CustomerCompany>(options);
        }

        public static void AddResume(EntityOptions options)
        {
            AddEntity<Resume>(options);
        }

        public static void AddUnemployed(EntityOptions options)
        {
            AddEntity<Unemployed>(options);
        }

        public static void AddVacancy(EntityOptions options)
        {
            AddEntity<Vacancy>(options);
        }

        #endregion


        #region DeleteEntity

        public static void DeleteCategory(EntityOptions options)
        {
            try
            {
                DeleteEntity<Category>(options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCategory(int index)
        {
            try
            {
                DeleteEntity<Category>(index, ConfigurationManager.AppSettings.Get("CategoryPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCustomerCompany(EntityOptions options)
        {
            try
            {
                DeleteEntity<CustomerCompany>(options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteCustomerCompany(int index)
        {
            try
            {
                DeleteEntity<CustomerCompany>(index, ConfigurationManager.AppSettings.Get("CustomerCompanyPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteResume(EntityOptions options)
        {
            try
            {
                DeleteEntity<Resume>(options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteResume(int index)
        {
            try
            {
                DeleteEntity<Resume>(index, ConfigurationManager.AppSettings.Get("ResumePath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteUnemployed(EntityOptions options)
        {
            try
            {
                DeleteEntity<Unemployed>(options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteUnemployed(int index)
        {
            try
            {
                DeleteEntity<Unemployed>(index, ConfigurationManager.AppSettings.Get("UnemployedPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteVacancy(EntityOptions options)
        {
            try
            {
                DeleteEntity<Vacancy>(options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteVacancy(int index)
        {
            try
            {
                DeleteEntity<Vacancy>(index, ConfigurationManager.AppSettings.Get("VacancyPath"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        private static void AddEntity<T>(EntityOptions options) where T : class, IEntity, new()
        {
            var convertedOptions = OptionsConverter.Convert(options);
            EntityContext<T>.Write(options.EntityPath,
                EntityCreator<T>.CreateEntity(convertedOptions));
        }

        private static void DeleteEntity<T>(EntityOptions options) where T : class, IEntity, new()
        {
            var convertedOptions = OptionsConverter.Convert(options);
            var entitiesList = EntityContext<T>.ReadFile(options.EntityPath);
            entitiesList.Remove(EntityCreator<T>.CreateEntity(convertedOptions));
            EntityContext<T>.ClearFile(options.EntityPath);
            foreach (var entity in entitiesList)
            {
                EntityContext<T>.Write(options.EntityPath, entity);
            }
        }

        private static void DeleteEntity<T>(int index, string entityPath) where T : class, IEntity
        {
            var entitiesList = EntityContext<T>.ReadFile(entityPath);
            entitiesList.RemoveAt(index);
            EntityContext<T>.ClearFile(entityPath);
            foreach (var entity in entitiesList)
            {
                EntityContext<T>.Write(entityPath, entity);
            }
        }
    }
}