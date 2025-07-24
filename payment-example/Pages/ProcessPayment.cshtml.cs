using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using Square;
using Square.Payments;
using Square.Locations;

namespace sqRazorSample.Pages
{
  public class ProcessPaymentModel : PageModel
  {
    private SquareClient client;
    private string locationId;

    public ProcessPaymentModel(Microsoft.Extensions.Configuration.IConfiguration configuration)
    {
      var environment = configuration["AppSettings:Environment"] == "sandbox" ?
          SquareEnvironment.Sandbox : SquareEnvironment.Production;

      var accessToken = configuration["AppSettings:AccessToken"];

      client = new SquareClient(accessToken, new ClientOptions { BaseUrl = environment == SquareEnvironment.Sandbox ? "https://connect.squareupsandbox.com" : "https://connect.squareup.com" });

      locationId = configuration["AppSettings:LocationId"];
    }

    public async Task<IActionResult> OnPostAsync()
    {
      var request = JObject.Parse(await new StreamReader(Request.Body).ReadToEndAsync());
      var token = (String)request["token"];
      var idempotencyKey = (String)request["idempotencyKey"];

      // Get the currency for the location
      var retrieveLocationResponse = await client.Locations.GetAsync(new GetLocationsRequest { LocationId = locationId });
      var currency = retrieveLocationResponse.Location.Currency;

      // Monetary amounts are specified in the smallest unit of the applicable currency.
      // This amount is in cents. It's also hard-coded for $1.00,
      // which isn't very useful.
      var amount = new Money { Amount = 100L, Currency = currency };

      // To learn more about splitting payments with additional recipients,
      // see the Payments API documentation on our [developer site]
      // (https://developer.squareup.com/docs/payments-api/overview).
      var createPaymentRequest = new CreatePaymentRequest
      {
        SourceId = token,
        IdempotencyKey = idempotencyKey,
        AmountMoney = amount
      };

      try
      {
        var response = await client.Payments.CreateAsync(createPaymentRequest);
        return new JsonResult(new { payment = response.Payment });
      }
      catch (SquareApiException e)
      {
        return new JsonResult(new { errors = e.Errors });
      }
    }
  }
}
