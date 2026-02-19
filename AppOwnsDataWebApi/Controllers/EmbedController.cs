using System.Threading.Tasks;
using Microsoft.Identity.Web.Resource;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AppOwnsDataWebApi.Models;
using AppOwnsDataWebApi.Services;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using System;

namespace AppOwnsDataWebApi.Controllers {

  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  [RequiredScope("Reports.Embed")]
  [EnableCors("AllowOrigin")]
  public class EmbedController(PowerBiServiceApi powerBiServiceApi, ILogger<EmbedController> logger) : ControllerBase {

    private PowerBiServiceApi powerBiServiceApi = powerBiServiceApi;

        [HttpGet]
    public async Task<EmbeddedViewModel> Get() {
      try
      {
        string user = this.User.Identity?.Name;
      return await this.powerBiServiceApi.GetEmbeddedViewModel(user);
      }
      catch (Exception e)
      {
        logger.LogError(e, "Some error");
        throw;
      }
    }

  }

}
