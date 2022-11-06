using BLL.Options;

namespace BLL
{
    public class OptionsConverter
    {
        public static DAL.EntityOptions Convert(EntityOptions options)
        {
            return new DAL.EntityOptions(
                categoryName: options.CategoryName,
                customerCompanyName: options.CustomerCompanyName,
                customerCompanyFirstName: options.CustomerCompanyFirstName,
                customerCompanyLastName: options.CustomerCompanyLastName,
                customerCompanyDescription: options.CustomerCompanyDescription,
                customerCompanyPhoneNumber: options.CustomerCompanyPhoneNumber,
                customerCompanyAddress: options.CustomerCompanyAddress,
                customerCompanyCity: options.CustomerCompanyCity,
                customerCompanyHomePage: options.CustomerCompanyHomePage,
                resumePosition: options.ResumePosition,
                resumeFirstName: options.ResumeFirstName,
                resumeLastName: options.ResumeLastName,
                resumeAge: options.ResumeAge,
                resumeCity: options.ResumeCity,
                resumeEmail: options.ResumeEmail,
                resumePhoneNumber: options.ResumePhoneNumber,
                unemployedFirstName: options.UnemployedFirstName,
                unemployedLastName: options.UnemployedLastName,
                unemployedAge: options.UnemployedAge,
                unemployedCity: options.UnemployedCity,
                vacancyName: options.VacancyName,
                vacancyDescription: options.VacancyDescription,
                vacancySalary: options.VacancySalary);
        }
    }
}