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
        builder.WithOrigins("http://127.0.0.1:5500")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddAppServices();
builder.Services.AddFiscalizatorValidators();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalHost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
