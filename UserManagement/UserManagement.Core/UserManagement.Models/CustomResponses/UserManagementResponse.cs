namespace UserManagement.Models.CustomResponses
{
    public class UserManagementResponse<T>
    {
        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public T Data { get; set; }
    }
}
