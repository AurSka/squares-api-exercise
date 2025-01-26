using MediatR;

namespace SquarePointsAS.Commands
{
    public class AddCommand : IRequest
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
