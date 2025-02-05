using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Commands.GuideCommands;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{                                          //1)Normalde listelemelerde veya parametreli
                                           //veya şartlı listelemelerde iki parametre kullanıyordum
                                           //<istek,yanıt> gibi 2)ekleme,silme,güncellemelerde ise
                                           //<istek> kullanıyorum
    public class CreateGuideCommanHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommanHandler(Context context)
        {
            _context = context;
        }
             //task<Unit>->void gibi kullanılabilir demek
        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description= request.Description,
                Image= request.Image,
                Status=true
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
