namespace ChallengeClean.Application.Models;

public class PersonDTO
{
    public required string FullName { get; set; }
    public List<AddressDTO> Addresses { get; set; } = new List<AddressDTO>();
}
