namespace BLL.Options
{
    public class EntityOptions
    {
        public string EntityPath { get; }

        public string CategoryName { get; }

        public string CustomerCompanyName { get; }
        public string CustomerCompanyFirstName { get; }
        public string CustomerCompanyLastName { get; }
        public string CustomerCompanyDescription { get; }
        public string CustomerCompanyPhoneNumber { get; }
        public string CustomerCompanyAddress { get; }
        public string CustomerCompanyCity { get; }
        public string CustomerCompanyHomePage { get; }

        public string ResumePosition { get; }
        public string ResumeFirstName { get; }
        public string ResumeLastName { get; }
        public int ResumeAge { get; }
        public string ResumeCity { get; }
        public string ResumeEmail { get; }
        public string ResumePhoneNumber { get; }

        public string UnemployedFirstName { get; }
        public string UnemployedLastName { get; }
        public int UnemployedAge { get; }
        public string UnemployedCity { get; }

        public string VacancyName { get; }
        public string VacancyDescription { get; }
        public string VacancySalary { get; }


        public EntityOptions(string entityPath, string categoryName = "", string customerCompanyName = "",
            string customerCompanyFirstName = "", string customerCompanyLastName = "",
            string customerCompanyDescription = "", string customerCompanyPhoneNumber = "",
            string customerCompanyAddress = "", string customerCompanyCity = "", string customerCompanyHomePage = "",
            string resumePosition = "", string resumeFirstName = "", string resumeLastName = "",
            int resumeAge = int.MinValue, string resumeCity = "", string resumeEmail = "",
            string resumePhoneNumber = "", string unemployedFirstName = "", string unemployedLastName = "",
            int unemployedAge = int.MinValue, string unemployedCity = "", string vacancyName = "",
            string vacancyDescription = "", string vacancySalary = "")

        {
            EntityPath = entityPath;
            CategoryName = categoryName;
            CustomerCompanyName = customerCompanyName;
            CustomerCompanyFirstName = customerCompanyFirstName;
            CustomerCompanyLastName = customerCompanyLastName;
            CustomerCompanyDescription = customerCompanyDescription;
            CustomerCompanyPhoneNumber = customerCompanyPhoneNumber;
            CustomerCompanyAddress = customerCompanyAddress;
            CustomerCompanyCity = customerCompanyCity;
            CustomerCompanyHomePage = customerCompanyHomePage;
            ResumePosition = resumePosition;
            ResumeFirstName = resumeFirstName;
            ResumeLastName = resumeLastName;
            ResumeAge = resumeAge;
            ResumeCity = resumeCity;
            ResumeEmail = resumeEmail;
            ResumePhoneNumber = resumePhoneNumber;
            UnemployedFirstName = unemployedFirstName;
            UnemployedLastName = unemployedLastName;
            UnemployedAge = unemployedAge;
            UnemployedCity = unemployedCity;
            VacancyName = vacancyName;
            VacancyDescription = vacancyDescription;
            VacancySalary = vacancySalary;
        }
    }
}