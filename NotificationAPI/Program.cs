using NotificationAPI;

var builder = WebApplication.CreateBuilder(args);
// you can add more Loggers with builder.Loggers
// Add 3rd party loggers like Serilog

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<NotificationsDataStore>();

// no DB context?

// Interface builder
// Is this how we connect to the database?
builder.Services.AddTransient<INotificationRepository, NotificationRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting(); // do I need this
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
