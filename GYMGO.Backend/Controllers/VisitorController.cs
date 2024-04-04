using GYMGO.Backend.Repos;
using GYMGO.Shared.Assamblers;
using GYMGO.Shared.Dtos;
using GYMGO.Shared.Extensions;
using GYMGO.Shared.Models;
using GYMGO.Shared.Parameters;
using GYMGO.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GYMGO.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : BaseController<Visitor, VisitorDto>
    {
        private readonly IVisitorRepo _visitorRepo;
        public VisitorController(VisitorAssambler assembler, IVisitorRepo repo) : base(assembler, repo)
        {
            _visitorRepo = repo;
        }

        [HttpPost("queryparameters")]
        public async Task<IActionResult> GetVisitors(VisitorQueryParametersDto dto)
        {
            VisitorQueryParameters parameters = dto.ToVisitorQueryParameters();
            if (!parameters.ValidYearRange)
            {
                ControllerResponse response = new ControllerResponse();
                response.AppendNewError("A születési év maximuma nagyobb kell legyen a születési év minimumánál!");
                return BadRequest(response);
            }
            else
            {
                if (_visitorRepo is null)
                {
                    ControllerResponse response = new ControllerResponse();
                    response.AppendNewError("A látogatók szűrése születési év alapján nem lehetséges");
                    return BadRequest(response);
                }
                else
                {
                    List<Visitor> result = await _visitorRepo.GetVisitors(parameters).ToListAsync();
                    return Ok(result);
                }
            }

        }
    }
}
