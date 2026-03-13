using Fiscalizator.FiscalizationClasses.Authorization;
using Fiscalizator.Helpers;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddXmlSerializerFormatters().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalHost", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddAppServices();
builder.Services.AddFiscalizatorValidators();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SameClientOnly", policy =>
        policy.Requirements.Add(new SameClientRequirement()));

    //options.AddPolicy("GlobalAdmin", policy =>
    //    policy.Requirements.Add(new GlobalAdminRequirement()));
});

builder.Services.AddEndpointsApiExplorer();
builder.AddSwaggerBearer();


builder.AddBearerAuthentication();


var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowLocalHost");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
