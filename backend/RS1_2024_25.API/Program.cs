using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Helper;
using RS1_2024_25.API.Helper.Auth;
using RS1_2024_25.API.Services;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .AddEnvironmentVariables() 
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("db1")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.OperationFilter<MyAuthorizationSwaggerHeader>());
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<TwoFactorAuthService>();
builder.Services.AddScoped<MyAuthService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddTransient<MyTokenGenerator>();
builder.Services.AddTransient<PasswordHasherService>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

//builder.Services.AddMailKit(config => config.UseMailKit(builder.Configuration.GetSection("MailKitOptions").Get<MailKitOptions>()));


var app = builder.Build();

app.UseCors("AllowAllOrigins");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}



app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAngular"); 

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    var passwordHasherService = new PasswordHasherService(dbContext);

    passwordHasherService.HashPasswordsForAllUsers();
}


app.Run();
