using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
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
        /// POST api/facemask
        /// Check if there is a person wearing a mask
        /// </summary>
        /// <returns>A HTTP response</returns>
        [HttpPost]
        public async Task<IActionResult> CheckMask()
        {
            string timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds().ToString();
            using (MemoryStream ms = new MemoryStream(32768))
            {
                await Request.Body.CopyToAsync(ms);
                await Helpers.SaveImage(ms.ToArray(), timestamp);
            }
            string res = await Helpers.CallFacemaskModel(timestamp);
            if (res.Contains("Image Not Found"))
            {
                return BadRequest("Image not found");
            }
            else if(res.Contains("1 mask, Done."))
            {
                return Ok(true);
            }
            else if (res.Contains("1 no_mask, Done."))
            {
                return Ok(false);
            }
            else if (res.Contains("Done. "))
            {
                return BadRequest("Face not found");
            }
            else
            {
                return StatusCode(500, $"Unexpected script response: /n{res}");
            }
        }

        /// <summary>
        /// GET api/facemask
        /// Ping the api for a fun response!
        /// </summary>
        /// <returns>A fun response</returns>
        [HttpGet]
        public IActionResult Get()
        {
            //return new RedirectResult("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            return Ok("(╯°□°）╯︵ ┻━┻ WRONG ENDPOINT!");
        }
    }
}
