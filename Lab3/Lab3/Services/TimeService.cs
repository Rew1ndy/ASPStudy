namespace Lab3.Services
{
    public class TimeService
    {
        public string GetDayTime()
        {
            var currentTime = DateTime.Now.TimeOfDay;

            switch (currentTime.Hours)
            {
                case int hours when (hours >= 6 && hours < 12):
                    return "Now is morning!";

                case int hours when (hours >= 12 && hours < 18):
                    return "Now is afternoon!";

                case int hours when (hours >= 18 && hours < 24):
                    return "Now is evening!";

                default:
                    return "Now is night!";
            }
        }
    }
}
