namespace AdvoSecure.Application.Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDateTime { get; set; }

        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDateTime { get; set; }

        public string? DeletedBy { get; set; }
        public DateTime? DeletedDateTime { get; set; }
    }
}
