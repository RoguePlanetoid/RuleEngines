const int date_of_birth_minimum_age = 24;
const int registered_date_minimum_days = 30;

await new ServiceCollection().AddDemo(() => DateTime.UtcNow, date_of_birth_minimum_age, registered_date_minimum_days)
.AddScoped<Application>().BuildServiceProvider().GetService<Application>()!.RunAsync();