# MercadoPago.DependencyInjection
### This project is an extension of the MercadoPago SDK, it configures the injection of dependencies for projects that require it.

<hr/>

## Build status
![.NET Core](https://github.com/cantte/MercadoPago.DependencyInjection/workflows/.NET/badge.svg)


## Usage (Example for ASP.NET core)
Configure in StartUp class.
```csharp
using MercadoPago.DependencyInjection;
// ...
// ...

public void ConfigureServices(IServiceCollection services)
{
  // ....
  services.AddMercadoPago(Configuration);
  // ....
}
```

Once configured, the MercadoPago clients can be used in the same way as other injected services.

Visit the MercadoPago repository for more information [Click here.](https://github.com/mercadopago/sdk-dotnet)
