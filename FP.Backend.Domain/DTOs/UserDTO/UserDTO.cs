namespace FP.Domain.DTOs;

public class UserDTO : UpdateUserDTO
{
    public string? Faculty { get; set; }

    public string? Department { get; set; }

    public string? Expertise { get; set; }

    public string? Level { get; set; }
}
