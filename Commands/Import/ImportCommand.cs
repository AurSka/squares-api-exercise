using MediatR;

namespace SquarePointsAS.Commands
{
    public class ImportCommand : IRequest
    {
        public int[] x { get; set; }
        public int[] y { get; set; }
        public bool overwrite { get; set; }
    }
}
