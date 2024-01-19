namespace ChallengeClean.Domain.Entities;

public class Address:BaseEntity
{    
    public required string Street { get; set; }
    public required string City { get; set; }
    public int PersonId { get; set; } // Foreign key
    public required Person Person { get; set; } // Navigation property
}
