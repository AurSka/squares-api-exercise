using MediatR;

namespace SquarePointsAS.Commands
{
    public class DeleteCommand : IRequest
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
