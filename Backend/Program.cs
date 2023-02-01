using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;



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


// IdentityUser
builder.Services.AddIdentity<Account, IdentityRole>(options =>
		options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

// Configure JWT
builder.Services.AddAuthentication(opt =>
    {
     opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
     opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(opt =>
        {
            opt.RequireHttpsMetadata = false;
            opt.SaveToken = true;
            opt.TokenValidationParameters = new TokenValidationParameters()
        {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7295/",
        ValidAudience = "https://localhost:7295/",
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("awef98awef978haweof8g7aw789efhh789awef8h9awh89efh89awe98f89uawef9j8aw89hefawef"))
    };
});

// Database connection
builder.Services.AddDbContext<DatabaseContext>(optionsAction: options =>
    options.UseSqlite("Data Source=database.db"));

// JWT Exception
builder.Services.AddMvc(options =>
{
    options.Filters.Add<JwtExceptionFilter>();
});

// TwoFactorAuthentication
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
app.UseCors(policy => policy.WithOrigins("MyAllowedSpecificOrigins", "http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials().Build());
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
