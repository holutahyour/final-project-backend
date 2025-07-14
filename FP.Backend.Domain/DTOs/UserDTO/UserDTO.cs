namespace FP.Domain.DTOs;

public class UserDTO : UpdateUserDTO
{
    public string? FullName
    {
        get
        {
            return $"{Title} {FirstName} {LastName}";
        }
    }

    public string? Faculty { get; set; }

    public string? Department { get; set; }

    public string? Expertise { get; set; }

    public string? Level { get; set; }
}
