using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CS7NS2_API.Controllers
{
    /// <summary>
    /// The Facemask controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FacemaskController : ControllerBase
    {
        /// <summary>
        /// Check if there is a person wearing a mask
        /// </summary>
        /// <returns>A HTTP response</returns>
        [HttpPost]
        public async Task<IActionResult> CheckMask()
        {
            return Ok();
        }
    }
}
