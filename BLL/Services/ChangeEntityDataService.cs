using DAL;
using DAL.Interfaces;
using System;
using EntityOptions = BLL.Options.EntityOptions;

namespace BLL.Services
{
    public static class ChangeEntityDataService
    {
        public static void ChangeConcreteCustomerCompanyData(int customerCompanyIndex, EntityOptions options)
        {
            try
            {
                ChangeConcreteEntityData<CustomerCompany>(customerCompanyIndex, options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ChangeConcreteResumedData(int resumeIndex, EntityOptions options)
        {
            try
            {
                ChangeConcreteEntityData<Resume>(resumeIndex, options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ChangeConcreteVacancyData(int vacancyIndex, EntityOptions options)
        {
            try
            {
                ChangeConcreteEntityData<Vacancy>(vacancyIndex, options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ChangeConcreteUnemployedData(int unemployedIndex, EntityOptions options)
        {
            try
            {
                ChangeConcreteEntityData<Unemployed>(unemployedIndex, options);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void ChangeConcreteEntityData<T>(int index, EntityOptions options) where T : class, IEntity
        {
            var convertedOptions = OptionsConverter.Convert(options);
            var entities = EntityContext<T>.ReadFile(options.EntityPath);
            entities[index].ChangeData(convertedOptions);
            EntityContext<T>.ClearFile(options.EntityPath);
            foreach (var entity in entities)
            {
                EntityContext<T>.Write(options.EntityPath, entity);
            }
        }
    }
}