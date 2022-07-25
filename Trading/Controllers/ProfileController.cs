using TradingApp.Interface;
using TradingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TradingApp.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfiles _IProfile;

        public ProfileController(IProfiles IProfile)
        {
            _IProfile = IProfile;
        }

        //GET: api/profile>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> Get()
        {
            return await Task.FromResult(_IProfile.GetProfiles());
        }

        // GET api/profile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> Get(int id)
        {
            var profiles = await Task.FromResult(_IProfile.GetProfiles(id));
            if (profiles == null)
            {
                return NotFound();
            }
            return profiles;
        }

        // POST api/profile
        [HttpPost]
        public async Task<ActionResult<Profile>> Post(Profile profile)
        {
            _IProfile.AddProfile(profile);
            return await Task.FromResult(profile);
        }

        // PUT api/profile/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Profile>> Put(int id, Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }
            try
            {
                _IProfile.UpdateProfile(profile);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(profile);
        }

        // DELETE api/profile/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> Delete(int id)
        {
            var profile = _IProfile.DeleteProfile(id);
            return await Task.FromResult(profile);
        }

        private bool ProfileExists(int id)
        {
            return _IProfile.CheckProfile(id);
        }

    }
}