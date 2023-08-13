namespace MVC_WebAPP_JokeSite.Models
{
    public class ErrorViewModel
    {
        public string? Id { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(Id);
    }
}