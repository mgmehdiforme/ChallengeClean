using System.ComponentModel.DataAnnotations.Schema;

namespace ChallengeClean.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }

}
