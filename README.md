# Get Started

[Install .NET](https://learn.microsoft.com/en-us/dotnet/core/install/) - If you don't have dotnet already installed on your machine.

[Square .NET SDK Guide](https://developer.squareup.com/docs/sdks/dotnet/using-dot-net-sdk) - details on how to use / configure the Square client.

[.NET Quickstart guide](https://developer.squareup.com/docs/sdks/dotnet/quick-start) - The quickstart directory is based off of this document.

[Nuget Repository for Square](https://www.nuget.org/packages/Square)

##  Quickstart Instructions
1. Change into the `quickstart` directory

1. Copy the example settings file to `appsettings.json`
    ```
    $ cp appsettings.example.json appsettings.json
    ```
1. Place your sandbox access token in `appsettings.json`

    ```json
    {
      "AppSettings": {
        "AccessToken": "YOUR-SANDBOX-ACCESS-TOKEN"
      }
    }
    ```

1. Install the package for Square

    ```
    $ dotnet add package square
    ```

1. Run the code
    ```
    $ dotnet run
    ```

You should see and output similar to this in the console
```
location:
  country =  US name = Default Test Account
```