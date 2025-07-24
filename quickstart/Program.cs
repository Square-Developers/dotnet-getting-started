using Square;
using Square.Locations;

using Microsoft.Extensions.Configuration;

namespace ExploreLocationsAPI
{
    public class Program
    {
        private static SquareClient client = null!;
        private static IConfigurationRoot config = null!;

        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .AddJsonFile($"appsettings.json", true, true);

            config = builder.Build();
            var accessToken = config["AppSettings:AccessToken"];

            client = new SquareClient(
                accessToken,
                new ClientOptions
                {
                    BaseUrl = SquareEnvironment.Sandbox
                }
            );

            await RetrieveLocationsAsync();
        }

        static async Task RetrieveLocationsAsync()
        {
            try
            {
                var response = await client.Locations.ListAsync();
                if (response.Locations != null)
                {
                    foreach (var location in response.Locations)
                    {
                        Console.WriteLine($"location: country = {location.Country} name = {location.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("No locations found.");
                }
            }
            catch (SquareApiException e)
            {
                Console.WriteLine("SquareApiException occurred:");
                Console.WriteLine("Status Code: {0}", e.StatusCode);
                Console.WriteLine("Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occurred: {e.Message}");
            }
        }
    }
}
