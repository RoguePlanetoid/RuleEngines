const int date_of_birth_minimum_age = 24;
const int registered_date_minimum_days = 30;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
.AddDemo(() => DateTime.UtcNow, date_of_birth_minimum_age, registered_date_minimum_days)
.AddScoped<Application>();

await builder.Build().RunAsync();
