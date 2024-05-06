# Get Started

[Install .NET](https://learn.microsoft.com/en-us/dotnet/core/install/) - If you don't have dotnet already installed on your machine.

[Square .NET SDK Guide](https://developer.squareup.com/docs/sdks/dotnet/using-dot-net-sdk) - details on how to use / configure the Square client.

[.NET Quickstart guide](https://developer.squareup.com/docs/sdks/dotnet/quick-start) - The quickstart directory is based off of this document.

##  Quickstart Instructions
Change into the `quickstart` directory

Copy the example settings file to `appsettings.json`
```
$ cp appsettings.example.json appsettings.json
```
Place your sandbox access token in `appsettings.json`

```json
{
  "AppSettings": {
    "AccessToken": "YOUR-SANDBOX-ACCESS-TOKEN"
  }
}

```
Run the code
```
$ dotnet run
```

You should see your `Square Sandbox Seller account's` location logged in the console.