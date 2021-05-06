namespace AppAdeptsApp.Models
{
    public class Error
    {
        public readonly string ErrorMessage;
        
        public Error(string message = "")
        {
            ErrorMessage = message;
        }
        
    }
}