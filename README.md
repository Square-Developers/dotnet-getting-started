# Square .NET SDK Quickstart

This quickstart sample creates a Square client instance with your Square access token and then lists the locations in your account.
The sample is based on the [.NET SDK Quickstart guide](https://developer.squareup.com/docs/sdks/dotnet/quick-start).

## Setup

[Install .NET](https://learn.microsoft.com/en-us/dotnet/core/install/) - If you don't have dotnet already installed on your machine.

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

1. You should see and output similar to this in the console
    ```
    location:
      country =  US name = Default Test Account
    ```

## Resources

[Square .NET SDK Guide](https://developer.squareup.com/docs/sdks/dotnet/using-dot-net-sdk) - details on how to use / configure the Square client.

[Nuget Repository for Square](https://www.nuget.org/packages/Square) - Where the package files are hosted

[Dotnet SDK Source Code](https://github.com/square/square-dotnet-sdk) - Github repo with sdk source code