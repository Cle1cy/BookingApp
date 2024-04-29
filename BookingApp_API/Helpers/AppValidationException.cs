namespace BookingApp_API.Helpers
{
    public class AppValidationException:Exception
    {
        public AppValidationException(string message) : base(message) { }
    }
}
