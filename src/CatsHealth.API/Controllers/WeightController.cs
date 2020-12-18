using CatsHealth.API.Dtos;
using CatsHealth.API.Services.ProfileService;
using CatsHealth.API.Services.WeightService;
using Microsoft.AspNetCore.Mvc;

namespace CatsHealth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeightController : ControllerBase
    {
        private readonly IProfileService profileService;
        private readonly IWeightService weightService;

        public WeightController(IProfileService profileService, IWeightService weightService)
        {
            this.profileService = profileService;
            this.weightService = weightService;
        }

        [HttpPost]
        public ActionResult<WeightResponse> AddWeight([FromBody] AddWeightRequest dto)
        {
            profileService.SetWeight(dto);
            var response = weightService.Save(dto);

            return Ok(response);

        }
    }
}