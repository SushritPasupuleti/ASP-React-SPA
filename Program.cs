var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication()
    .AddJwtBearer()
    .AddJwtBearer("LocalAuthIssuer");

builder.Services.AddAuthorization();

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("admin-only", policy => policy
            .RequireRole("admin")
            // .RequireClaim("scope", "admin-scope"));
			// .RequireScope("admin-scope"));
			);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.MapGet("/", () => "Hello There");
app.MapGet("/admin-hello", () => "Hello There, Admin")
    .RequireAuthorization("admin-only");

app.Run();
