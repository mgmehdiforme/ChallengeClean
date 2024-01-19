using ChallengeClean.Application.Common.Interfaces;
using ChallengeClean.Application.Models;

namespace ChallengeClean.Application.Persons.Queries.GetAllPersons;
public record GetAllPersonsQuery : IRequest<IEnumerable<PersonDTO>>;

public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, IEnumerable<PersonDTO>>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IMapper _mapper;
    public GetAllPersonsQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
    {
        _applicationDbContext = applicationDbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PersonDTO>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
    {
        var result= _applicationDbContext.Persons.Include(x => x.Addresses);
        return await Task.Run(() => _mapper.ProjectTo<PersonDTO>(result));
    }
}
