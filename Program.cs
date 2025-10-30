using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using Fiscalizator.Logger;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.OperationHandlers;
using Fiscalizator.NHibernate;
using Fiscalizator.FiscalizationClasses.Entities;
using System.Globalization;
using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Validators.CloseShift;
using Fiscalizator.Repository;

var builder = WebApplication.CreateBuilder(args);
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

builder.Services.AddScoped(typeof(ValidatorManager<>));
builder.Services.AddScoped<IValidator<BillDTO>, KkmValidator>();
builder.Services.AddScoped<IValidator<BillDTO>, OpenShiftValidator>();
builder.Services.AddScoped<IValidator<BillDTO>, BillTimeValidator>();
builder.Services.AddScoped<IValidator<BillDTO>, BillValidator>();

builder.Services.AddScoped<IValidator<CloseShiftDTO>, CloseShiftValidator>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
