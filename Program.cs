using travai;
using travai.Middlewares;
using Microsoft.EntityFrameworkCore;
using travai.Repositories.GenericRepository;

using travai.Repositories.UserRepository;
using travai.Services;
// Final sync after manual drop
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Register Repositories
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<travai.Services.HotelService.IHotelService, travai.Services.HotelService.HotelService>();
builder.Services.AddScoped<travai.Services.FileStorage.IFileService, travai.Services.FileStorage.FileService>();

// --- Airline Services ---
builder.Services.AddScoped<travai.Airline.Services.AirportService.IAirportService, travai.Airline.Services.AirportService.AirportService>();
builder.Services.AddScoped<travai.Airline.Services.BookingService.IBookingService, travai.Airline.Services.BookingService.BookingService>();
builder.Services.AddScoped<travai.Airline.Services.ChatService.IChatService, travai.Airline.Services.ChatService.ChatService>();
builder.Services.AddScoped<travai.Airline.Services.CompanionService.ICompanionService, travai.Airline.Services.CompanionService.CompanionService>();
builder.Services.AddScoped<travai.Airline.Services.DashboardService.IDashboardService, travai.Airline.Services.DashboardService.DashboardService>();
builder.Services.AddScoped<travai.Airline.Services.FlightService.IFlightService, travai.Airline.Services.FlightService.FlightService>();
builder.Services.AddScoped<travai.Airline.Services.PassengerService.IPassengerService, travai.Airline.Services.PassengerService.PassengerService>();
builder.Services.AddScoped<travai.Airline.Services.ReviewService.IReviewService, travai.Airline.Services.ReviewService.ReviewService>();

// --- TourGuide Services ---
builder.Services.AddScoped<travai.TourGuide.Services.ITourGuideService, travai.TourGuide.Services.TourGuideService>();
builder.Services.AddScoped<travai.TourGuide.Services.ITourService, travai.TourGuide.Services.TourService>();
builder.Services.AddScoped<travai.TourGuide.Services.IBookingService, travai.TourGuide.Services.BookingService>();
builder.Services.AddScoped<travai.TourGuide.Services.IUrgentRequestService, travai.TourGuide.Services.UrgentRequestService>();
builder.Services.AddScoped<travai.TourGuide.Services.IWithdrawRequestService, travai.TourGuide.Services.WithdrawRequestService>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        // For development, we can be more permissive.
        // For production, Azure App Service handles some CORS, but we keep this flexible.
        policy.SetIsOriginAllowed(_ => true)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// Configure Forwarded Headers for Azure App Service (to handle HTTPS redirection behind proxy)
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("RequireUser", policy => policy.RequireRole("User"));
    // Add more policies as needed
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // <-- Required for Bearer Authentication
        BearerFormat = "JWT" // Optional, for documentation clarity
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    c.SwaggerDoc("Hotel", new OpenApiInfo { Title = "Hotel API", Version = "v1" });
    c.SwaggerDoc("Airline", new OpenApiInfo { Title = "Airline API", Version = "v1" });
    c.SwaggerDoc("TourGuide", new OpenApiInfo { Title = "TourGuide API", Version = "v1" });
    c.SwaggerDoc("Auth", new OpenApiInfo { Title = "Auth API", Version = "v1" });
});

var app = builder.Build();

// Forwarded Headers MUST be first to correctly identify HTTPS
app.UseForwardedHeaders();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// Custom Seed Command: dotnet run --seed
if (args.Contains("--seed"))
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApplicationDbContext>();
        Console.WriteLine("Command: Starting Database Seeding...");
        travai.Data.DbSeeder.Seed(context);
        Console.WriteLine("Command: Seeding Completed. Exiting.");
    }
    return;
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/Hotel/swagger.json", "Hotel API");
    c.SwaggerEndpoint("/swagger/Airline/swagger.json", "Airline API");
    c.SwaggerEndpoint("/swagger/TourGuide/swagger.json", "TourGuide API");
    c.SwaggerEndpoint("/swagger/Auth/swagger.json", "Auth API");
});

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

// Enable serving static files (for uploaded images)
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Database seeding is now disabled on startup.

// Restart trigger
app.Run();
 
