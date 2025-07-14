namespace FP.Domain.DTOs
{
    public class UpdateUserDTO : CreateUserDTO
    {
        public required Guid Id { get; set; }
    }
}
