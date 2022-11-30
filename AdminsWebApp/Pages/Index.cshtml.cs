using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Runtime.Serialization;

namespace AdminsWebApp.Pages
{
    [EnableCors]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        public async Task OnGet()
        {
            var Baseurl = configuration["ApiUrl"];

            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    RequestUri = new Uri(Baseurl+"fleets"),
                    Method = HttpMethod.Get
                };

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    //API call success, Do your action
                }

                else
                {
                    //API Call Failed, Check Error Details
                }
            }
        }
    }
}