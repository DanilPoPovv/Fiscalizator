using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.OperationHandlers;
using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Validators.CloseShift;
using Fiscalizator.FiscalizationClasses.Validators.OpenShift;
using Fiscalizator.FiscalizationClasses.Services;
using Fiscalizator.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;

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

builder.Services.AddScoped<FiscalizationService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<Fiscalizator.Logger.Logger>();
builder.Services.AddScoped<BillHandler>();
builder.Services.AddScoped<CloseShiftHandler>();
builder.Services.AddScoped<OpenShiftHandler>();
builder.Services.AddScoped<BillValidator>();

builder.Services.AddScoped(typeof(ValidatorManager<>));
builder.Services.AddScoped<IValidator<BillDTO>, KkmValidator>();
builder.Services.AddScoped<IValidator<BillDTO>, Fiscalizator.FiscalizationClasses.Validators.OpenShiftValidator>();
builder.Services.AddScoped<IValidator<BillDTO>, BillTimeValidator>();
builder.Services.AddScoped<IValidator<BillDTO>, BillValidator>();
builder.Services.AddScoped<IValidator<CloseShiftDTO>, CloseShiftValidator>();

builder.Services.AddScoped<IValidator<OpenShiftDTO>, Fiscalizator.FiscalizationClasses.Validators.OpenShift.OpenShiftValidator>();
builder.Services.AddScoped<IValidator<OpenShiftDTO>, OpenShiftTimeValidator>();
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
