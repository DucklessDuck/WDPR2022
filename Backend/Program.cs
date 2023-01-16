using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;


// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>{
     options.AddPolicy(name: "MyAllowedSpecificOrigins",
                       policy  =>
                       {
                           policy.AllowAnyOrigin()
                           .AllowAnyHeader().AllowAnyMethod(); // add the allowed origins
                       });
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
		options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();
                
builder.Services.AddDbContext<DatabaseContext>(optionsAction: options =>
    options.UseSqlite("Data Source=database.db"));

builder.Services.AddAuthorization(options =>
    options.AddPolicy("TwoFactorEnabled", x => x.RequireClaim("amr", "mfa")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
   app.UseDefaultFiles();
   app.UseStaticFiles();
}
app.UseCors("MyAllowedSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
