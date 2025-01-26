using MediatR;
using SquarePointsAS.Entities;

namespace SquarePointsAS.Commands
{
    public class GetCommand : IRequest<List<List<SquarePoint>>>
    {
    }
}
