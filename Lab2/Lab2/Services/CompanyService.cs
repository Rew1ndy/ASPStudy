namespace Lab2.Services
{
    public class CompanyService
    {
        private readonly IConfiguration _configuration;

        public CompanyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetCompanyWithMostEmployees()
        {
            var companies = _configuration.GetSection("Companies").GetChildren();
            string companyWithMostEmployees = string.Empty;
            int maxEmployees = 0;

            foreach (var company in companies)
            {
                int employees = int.Parse(company["Employees"]);
                if (employees > maxEmployees)
                {
                    maxEmployees = employees;
                    companyWithMostEmployees = company.Key;
                }
            }

            return companyWithMostEmployees;
        }
    }
}
