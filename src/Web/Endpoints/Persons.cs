using ChallengeClean.Application.Models;
using ChallengeClean.Application.Persons.Queries.GetAllPersons;

namespace ChallengeClean.Web.Endpoints;

public class Persons : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)            
            .MapGet(GetAllPerson);
    }

    public async Task<IEnumerable<PersonDTO>> GetAllPerson(ISender sender)
    {        
        return await sender.Send(new GetAllPersonsQuery());
    }
}
