using MediatR;
using System.Collections.Generic;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Queries.GuideQueries
{                             //IRequest->using.mediatR
                              //bu sınıfım handle'ma köprü görevi görmektedir
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
