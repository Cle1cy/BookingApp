namespace ToDoApp_API.Helpers
{
    public class DbOperationException: Exception
    {
        public DbOperationException(string message) : base(message) { }
    }
}
