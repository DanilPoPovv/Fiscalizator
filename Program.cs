using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.OperationHandlers;
using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Validators.CloseShift;
using Fiscalizator.FiscalizationClasses.Validators.OpenShift;
using Fiscalizator.FiscalizationClasses.Services;
using Fiscalizator.Repository;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;

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
builder.Services.AddScoped<KkmService>();

builder.Services.AddScoped(typeof(ValidatorManager<,>));
builder.Services.AddScoped<IValidator<BillDTO,ValidationContext>, KkmValidator>();
builder.Services.AddScoped<IValidator<BillDTO,ValidationContext>, Fiscalizator.FiscalizationClasses.Validators.OpenShiftValidator>();
builder.Services.AddScoped<IValidator<BillDTO,ValidationContext>, BillTimeValidator>();
builder.Services.AddScoped<IValidator<BillDTO, ValidationContext>, BillValidator>();

builder.Services.AddScoped<IValidator<CloseShiftDTO, ValidationContext>, CloseShiftValidator>();
builder.Services.AddScoped<IValidator<CloseShiftDTO, ValidationContext>, Fiscalizator.FiscalizationClasses.Validators.CloseShift.ShiftClosedValidator>();


builder.Services.AddScoped<IValidator<OpenShiftDTO,ValidationContext>, Fiscalizator.FiscalizationClasses.Validators.OpenShift.OpenShiftBaseValidator>();
builder.Services.AddScoped<IValidator<OpenShiftDTO, ValidationContext>, Fiscalizator.FiscalizationClasses.Validators.OpenShift.ShiftOpenedValidator>();
builder.Services.AddScoped<IValidator<OpenShiftDTO,ValidationContext>, OpenShiftTimeValidator>();

builder.Services.AddScoped<IValidator<KkmDTO, KkmValidationContext>, KkmUniqueSerialNumberCreateValidator>();
builder.Services.AddScoped<IValidator<KkmUpdateDTO, KkmValidationContext>, KkmUniqueSerialNumberUpdateValidator>();

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
