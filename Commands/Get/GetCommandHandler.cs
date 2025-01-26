using MediatR;
using SquarePointsAS.Common.Comparers;
using SquarePointsAS.Entities;
using SquarePointsAS.Interfaces;

namespace SquarePointsAS.Commands
{
    public class GetCommandHandler : IRequestHandler<GetCommand, List<List<SquarePoint>>>
    {
        private readonly IPointRepository pointRepository;
        public GetCommandHandler (IPointRepository pointRepository)
        {
            this.pointRepository = pointRepository;
        }

        public async Task<List<List<SquarePoint>>> Handle(GetCommand request, CancellationToken cancellationToken)
        {
            //Get all points, ordered by X, then Y.
            //Means we look through points starting from the bottom left, so we only need to look through the points that remain to the top left.
            var points = await pointRepository.GetAllPoints(cancellationToken);

            if(points == null || points.Count < 4)
            {
                throw new Exception("There are not enough points to make any squares. Import some!");
            }

            List<List<SquarePoint>> squares = new List<List<SquarePoint>>();

            //While the exercise says not to recreate that which already exists, I couldn't find a library to find squares on a grid.
            //I could find an exercise that asked you to write code for a similar problem, some possibly over-engineered solutions for it that I'd need to adjust,
            //and how to get squares of a number, but no library to find squares from a list of points. So I ended up writing my own anyway.
            //In an actual development scenario, I would've first asked if any fellow developers know of an already existing solution to this particular problem.
            for (int a = 0; a < points.Count; a++)
            {
                for (int b = a + 1; b < points.Count; b++)
                {
                    SquarePoint? c = points.Find(c => c.X == (points[a].X + Math.Abs(points[a].Y - points[b].Y)) 
                        && c.Y == (points[a].Y - Math.Abs(points[a].X - points[b].X))
                        && !c.Equals(points[b]) && !c.Equals(points[a]));
                    if (c == null)
                    {
                        continue;
                    }
                    SquarePoint? d = points.Find(d => d.X == (points[b].X + Math.Abs(points[a].Y - points[b].Y)) 
                        && d.Y == (points[b].Y - Math.Abs(points[a].X - points[b].X))
                        && !d.Equals(c) && !d.Equals(points[b]) && !d.Equals(points[a]));
                    if (d == null)
                    {
                        continue;
                    }
                    squares.Add(new List<SquarePoint> { points[a], points[b], c, d });
                }
            }
            var res = squares.Distinct(new ListEqualityComparer<SquarePoint>()).ToList();
            return res;
        }
    }
}
