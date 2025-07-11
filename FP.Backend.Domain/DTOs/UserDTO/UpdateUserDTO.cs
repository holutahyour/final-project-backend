namespace FP.Domain.DTOs
{
    public class UpdateUserDTO : CreateUserDTO
    {
        public required long Id { get; set; }
    }
}
