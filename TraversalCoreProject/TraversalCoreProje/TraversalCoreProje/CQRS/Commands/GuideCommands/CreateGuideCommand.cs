using MediatR;

namespace TraversalCoreProje.CQRS.Commands.GuideCommands
{
    public class CreateGuideCommand:IRequest
    {  //quires ile results birlikte çalışır
       //handlers ile commands birlikte çalışır
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
