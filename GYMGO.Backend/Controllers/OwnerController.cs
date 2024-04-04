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
    public class OwnerController : BaseController<Owner, OwnerDto>
    {
        private readonly IOwnerRepo _ownerRepo;
        public OwnerController(OwnerAssambler assembler, IOwnerRepo repo) : base(assembler, repo)
        {
            _ownerRepo = repo;
        }

        [HttpPost("queryparameters")]
        public async Task<IActionResult> GetOwners(OwnerQueryParametersDto dto)
        {
            OwnerQueryParameters parameters = dto.ToOwnerQueryParameters();
            if (!parameters.ValidYearRange)
            {
                ControllerResponse response = new ControllerResponse();
                response.AppendNewError("A születési év maximuma nagyobb kell legyen a születési év minimumánál!");
                return BadRequest(response);
            }
            else
            {
                if (_ownerRepo is null)
                {
                    ControllerResponse response = new ControllerResponse();
                    response.AppendNewError("A tulajdonosok szűrése születési év alapján nem lehetséges");
                    return BadRequest(response);
                }
                else
                {
                    List<Owner> result = await _ownerRepo.GetOwners(parameters).ToListAsync();
                    return Ok(result);
                }
            }

        }
    }
}
