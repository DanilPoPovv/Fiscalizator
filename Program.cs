using Fiscalizator.CustomMidlwares;
using Fiscalizator.Helpers;

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
builder.Services.AddHttpContextAccessor();
builder.Services.AddAppServices();
builder.Services.AddFiscalizatorValidators();
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.AddSwaggerBearer();


builder.AddBearerAuthentication();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowLocalHost");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
