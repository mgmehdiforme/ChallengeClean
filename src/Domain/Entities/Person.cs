using System;
using System.Net;

namespace ChallengeClean.Domain.Entities;

public class Person : BaseEntity
{
    public required string FullName { get; set; }
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}
