namespace UserManagement.Models.Responses
{
    public class UserManagementResponse<T>
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public T Data { get; set; }
    }
}
