using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Square;
using Square.Locations;

namespace sqRazorSample.Pages
{
    public class IndexModel : PageModel
    {
        public string WebPaymentsSdkUrl { get; set; }
        public string ApplicationId { get; set; }
        public string LocationId { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string IdempotencyKey { get; set; }

        private SquareClient client;

        public IndexModel(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            var environment = configuration["AppSettings:Environment"] == "sandbox" ?
                SquareEnvironment.Sandbox : SquareEnvironment.Production;

            var accessToken = configuration["AppSettings:AccessToken"];

            ApplicationId = configuration["AppSettings:ApplicationId"];
            LocationId = configuration["AppSettings:LocationId"];

            // Every payment you process with the SDK must have a unique idempotency key.
            // If you're unsure whether a particular payment succeeded, you can reattempt
            // it with the same idempotency key without worrying about double charging
            // the buyer.
            IdempotencyKey = NewIdempotencyKey();

            WebPaymentsSdkUrl = environment == SquareEnvironment.Sandbox ?
                "https://sandbox.web.squarecdn.com/v1/square.js" : "https://web.squarecdn.com/v1/square.js";

            client = new SquareClient(accessToken, new ClientOptions { BaseUrl = environment == SquareEnvironment.Sandbox ? "https://connect.squareupsandbox.com" : "https://connect.squareup.com" });
        }

        public async Task OnGetAsync() {
            var result = await client.Locations.GetAsync(new GetLocationsRequest { LocationId = this.LocationId });
            this.Country = result.Location.Country?.ToString();
            this.Currency = result.Location.Currency?.ToString();
        }

        private static string NewIdempotencyKey() {
          return Guid.NewGuid().ToString();
        }
    }
}
