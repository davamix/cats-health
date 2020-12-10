using System;
using System.Collections.Generic;
using System.Linq;
using CatsHealth.API.Dtos;
using CatsHealth.API.Services.ProfileService;
using Microsoft.AspNetCore.Mvc;

namespace CatsHealth.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProfileResponseDto>> Get()
        {
            var profiles = profileService.GetProfiles();

            if (profiles.Any()) return Ok(profiles);

            return NoContent();
        }

        [HttpPost]
        public ActionResult<ProfileResponseDto> AddProfile([FromBody] ProfileRequestDto profile)
        {
            var response = profileService.Save(profile);

            return Ok(response);
        }
    }
}