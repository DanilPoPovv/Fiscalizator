using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using Fiscalizator.Logger;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.OperationHandlers;
using Fiscalizator.FiscalizationClasses.Entities;
using System.Globalization;

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var s = NHibernateHelper.OpenSession();
using (var session = NHibernateHelper.OpenSession())
using (var transaction = session.BeginTransaction())
{
    var Cashier = new Cashier() { Name ="Cashier" };
    session.Save(Cashier);

    transaction.Commit();
}

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
