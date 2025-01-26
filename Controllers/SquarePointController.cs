using MediatR;
using Microsoft.AspNetCore.Mvc;
using SquarePointsAS.Commands;
using SquarePointsAS.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace SquarePointsAS.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SquarePointController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private readonly ILogger<SquarePointController> _logger;

        public SquarePointController(ILogger<SquarePointController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Imports an array of points. 
        /// Make sure the X and Y coordinates of each point are in the right order.
        /// </summary>
        /// <param name="x">The x coordinates of the points</param>
        /// <param name="y">The y coordinates of the points</param>
        /// <param name="overwrite">True by default, overwrites existing points if true</param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Imports an array of points. Make sure the X and Y coordinates of each point are in the right order.")]
        public async Task<ActionResult> Import([FromQuery]int[] x, [FromQuery] int[] y, bool overwrite = true)
        {
            await Mediator.Send(new ImportCommand
            {
                x = x,
                y = y,
                overwrite = overwrite
            });
            return NoContent();
        }

        /// <summary>
        /// Adds a point at the input coordinates if one doesn't already exist.
        /// </summary>
        /// <param name="x">The x coordinate of the point</param>
        /// <param name="y">The y coordinate of the point</param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adds a point at the input coordinates if one doesn't already exist.")]
        public async Task<ActionResult> Add(int x, int y)
        {
            await Mediator.Send(new AddCommand { 
                x = x, 
                y = y});
            return NoContent();
        }

        /// <summary>
        /// Deletes a point at the input coordinates if one exists.
        /// </summary>
        /// <param name="x">The x coordinate of the point</param>
        /// <param name="y">The y coordinate of the point</param>
        /// <returns></returns>
        [HttpDelete]
        [SwaggerOperation(Summary = "Deletes a point at the input coordinates if one exists.")]
        public async Task<ActionResult> Delete(int x, int y)
        {
            await Mediator.Send(new DeleteCommand
            {
                x = x,
                y = y
            });
            return NoContent();
        }

        /// <summary>
        /// Gets the list of lists of points that make up a square. Includes rotated squares.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Gets the list of lists of points that make up a square. Includes rotated squares.")]
        public async Task<ActionResult<List<List<SquarePoint>>>> Get()
        {
            return await Mediator.Send(new GetCommand { });
        }
    }
}
