using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;

using Training4Developers.Interfaces;
using Training4Developers.Models;

namespace Training4Developers.Controllers
{
  [Route("[controller]")]
  public class AccountController : Controller
  {
		private readonly IUserRepo _userRepo;
    private readonly IOptions<JwtOptions> _jwtOptions;

    public AccountController(IUserRepo userRepo, IOptions<JwtOptions> jwtOptions)
    {
			_userRepo = userRepo;
      _jwtOptions = jwtOptions;
    }

    [HttpPost]
    [AllowAnonymous]
		[Route("login")]
    public async Task<IActionResult> Get([FromBody] LoginUser loginUser)
    {
      var identity = await GetClaimsIdentity(loginUser);
      if (identity == null)
      {
        return BadRequest("Invalid credentials");
      }

      var claims = new[]
      {
        identity.FindFirst("Name"),
        identity.FindFirst("Role")
      };

			var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Value.Secret));     

      var encodedJwt = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
          claims: claims,
          signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
			));

      return new OkObjectResult(JsonConvert.SerializeObject(new { accessToken = encodedJwt }));
    }

    private Task<ClaimsIdentity> GetClaimsIdentity(LoginUser loginUser)
    {
			var user = _userRepo.GetByEmailAddressAndPassword(loginUser.EmailAddress, loginUser.Password);

			if (user == null) {
				return Task.FromResult<ClaimsIdentity>(null);
			}

			return Task.FromResult(new ClaimsIdentity(
        new GenericIdentity(user.EmailAddress, "Token"),
				new[] {
          new Claim("Name", user.FirstName + ' ' + user.LastName),
          new Claim("Role", "User")
        }
      ));
    }
  }
}
