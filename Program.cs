using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using Fiscalizator.Logger;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.OperationHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddXmlSerializerFormatters().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddScoped<FiscalizationService>();
builder.Services.AddScoped<Fiscalizator.Logger.Logger>();
builder.Services.AddScoped<BillHandler>();
builder.Services.AddScoped<CloseShiftHandler>();
builder.Services.AddScoped<OpenShiftHandler>();
builder.Services.AddScoped<BillValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
NHibernateHelper.OpenSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
