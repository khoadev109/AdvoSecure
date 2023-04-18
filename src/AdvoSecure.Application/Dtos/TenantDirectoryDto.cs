namespace AdvoSecure.Application.Dtos
{
    public class TenantDirectoryDto
    {
        public Guid TenantIdentifier { get; set; }

        public Guid UserIdentifier { get; set; }
    }

    public class RegisterTenantRequestDto
    {
        public string UserIdentifier { get; set; }
    }

    public class RegisterTenantResponseDto
    {
        public TenantDirectoryDto Data { get; set; }

        public string Message { get; set; }
    }
}
