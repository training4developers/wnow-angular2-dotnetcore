using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using Training4Developers.Interfaces;
using Training4Developers.Models;
using Microsoft.Extensions.Options;

namespace Training4Developers.Controllers
{
  [Route("[controller]")]
  public class AccountController : Controller
  {
		private readonly IStudentRepo _studentRepo;
    private readonly IOptions<JwtOptions> _jwtOptions;

    public AccountController(IStudentRepo studentRepo, IOptions<JwtOptions> jwtOptions)
    {
			_studentRepo = studentRepo;
      _jwtOptions = jwtOptions;
    }

    [HttpPost]
    [AllowAnonymous]
		[Route("login")]
    public async Task<IActionResult> Get([FromBody] ApplicationUser applicationUser)
    {
      var identity = await GetClaimsIdentity(applicationUser);
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

    private Task<ClaimsIdentity> GetClaimsIdentity(ApplicationUser user)
    {
			var student = _studentRepo.GetByEmailAddressAndPassword(user.EmailAddress, user.Password);

			if (student == null) {
				return Task.FromResult<ClaimsIdentity>(null);
			}

			return Task.FromResult(new ClaimsIdentity(
        new GenericIdentity(user.EmailAddress, "Token"),
				new[] {
          new Claim("Name", student.FirstName + ' ' + student.LastName),
          new Claim("Role", "Student")
        }
      ));
    }
  }
}
