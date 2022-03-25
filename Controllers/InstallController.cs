using Microsoft.AspNetCore.Mvc;

namespace HttpRedirector.Controllers
{
    [Route("redirect/")]
    [ApiController]
    public class InstallController : ControllerBase
    {

        // GET api/<InstallController>
        [HttpGet]
        public string Get()
        {
            // Fetch promo code, use this to get other params
            string promocode = Request.Query["promocode"];

            if (promocode == "" ) {
                // What do you do here?
            }

            // Read all headers
            Dictionary<string, string> requestHeaders = new();
            foreach (var header in Request.Headers)
            {
                requestHeaders.Add(header.Key, header.Value);
            }

            // Add your logger here


            // Check for user agent to redirect
            if (requestHeaders["User-Agent"].Contains("Android"))
            {
                Response.Redirect("https://play.google.com/store/apps/details?id=com.yazam.empower.passenger");
            }
            else if (requestHeaders["User-Agent"].Contains("iPhone"))
            {
                Response.Redirect("https://play.google.com/store/apps/details?id=com.yazam.empower.driver");
            }
            else {
                Response.Redirect("http://www.google.com");
            }
            return string.Join(Environment.NewLine, requestHeaders);
        }
    }
}
