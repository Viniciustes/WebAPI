namespace WebAPI.Models
{
    public class ReturnServiceModel
    {
        public ReturnServiceModel()
        {
            Result = true;
            ErrorMessage = string.Empty;
        }

        public bool Result { get; set; }

        public string ErrorMessage { get; set; }
    }
}