using Microsoft.AspNetCore.Mvc;
using AppOwnsDataShared.Models;
using AppOwnsDataShared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AppOwnsDataWebApi.Controllers {

  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  [RequiredScope("Reports.Embed")]
  [EnableCors("AllowOrigin")]
  public class UserLoginController : ControllerBase {

    private AppOwnsDataDBService appOwnsDataDBService;
    private ILogger<UserLoginController> logger;

    public UserLoginController(AppOwnsDataDBService appOwnsDataDBService, ILogger<UserLoginController> logger) {
      this.appOwnsDataDBService = appOwnsDataDBService;
      this.logger = logger;
    }

    [HttpPost]
    public ActionResult<User> PostUser(User user) {
      // Log all claims for debugging
      foreach (var claim in this.User.Claims) {
        logger.LogInformation("Claim: {Type} = {Value}", claim.Type, claim.Value);
      }

      string authenticatedUser = this.User.Identity?.Name;
      logger.LogInformation("authenticatedUser from token: '{AuthUser}', user.LoginId from POST body: '{LoginId}'", authenticatedUser, user.LoginId);

      if (authenticatedUser != null && user.LoginId.Equals(authenticatedUser, System.StringComparison.OrdinalIgnoreCase)) {
        this.appOwnsDataDBService.ProcessUserLogin(user);
        return NoContent();
      }
      else {
        logger.LogWarning("Login FORBIDDEN - authenticatedUser='{AuthUser}', user.LoginId='{LoginId}'", authenticatedUser, user.LoginId);
        return Forbid();
      }
    }
  }
}
