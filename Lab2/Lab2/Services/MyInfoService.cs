namespace Lab2.Services
{
    public class MyInfoService
    {
        private readonly IConfiguration _configuration;
        public MyInfoService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public string GetInfo()
        {
            var firstName = _configuration["FirstName"];
            var lastName = _configuration["LastName"];
            var age = _configuration["Age"];
            var city = _configuration["City"];

            return $"Ім'я: {firstName}, Прізвище: {lastName}, Вік: {age}, Місто: {city}";
        }
    }
}
