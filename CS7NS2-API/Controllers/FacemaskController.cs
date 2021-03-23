using Microsoft.AspNetCore.Mvc;
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
            //using (StreamReader reader = new StreamReader(Request.Body))
            //{
            //    string data = await reader.ReadToEndAsync();
            //    await Helpers.SaveData(data);
            //}
            using (MemoryStream ms = new MemoryStream(32768))
            {
                await Request.Body.CopyToAsync(ms);
                await Helpers.SaveByteData(ms.ToArray());
                await Helpers.SaveImage(ms.ToArray());
            }
            string res = await Helpers.CallFacemaskModel();
            return Ok(res);
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
            return Ok("(ﾉ◕ヮ◕)ﾉ*:･ﾟ✧ www.youtube.com/watch?v=dQw4w9WgXcQ");
        }
    }
}
