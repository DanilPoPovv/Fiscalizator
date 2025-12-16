using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Validators.BillValidators;
using Fiscalizator.FiscalizationClasses.Validators.CloseShift;
using Fiscalizator.FiscalizationClasses.Validators.GlobalValidators;
using Fiscalizator.FiscalizationClasses.Validators.KkmCrudValidators;
using Fiscalizator.FiscalizationClasses.Validators.OpenShift;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators;
using Fiscalizator.FiscalizationClasses.OperationHandlers;
using Fiscalizator.FiscalizationClasses.Services;
using Fiscalizator.FiscalizationClasses.Validators.ClientCrudValidator;

namespace Fiscalizator.Helpers
{
    public static class DependencyHelper 
    {
        public static IServiceCollection AddFiscalizatorValidators(this IServiceCollection services)
        {
            services.AddScoped(typeof(ValidatorManager<,>));

            // Bill validators
            //services.AddScoped<IValidator<BillDTO, ValidationContext>, OpenShiftValidator>();
            services.AddScoped<IValidator<BillDTO, ValidationContext>, BillTimeValidator>();
            services.AddScoped<IValidator<BillDTO, ValidationContext>, BillValidator>();

            // Close shift
            //services.AddScoped<IValidator<CloseShiftDTO, ValidationContext>, CloseShiftValidator>();
            services.AddScoped<IValidator<CloseShiftDTO, ValidationContext>, ShiftClosedValidator>();

            // Open shift
            //services.AddScoped<IValidator<OpenShiftDTO, ValidationContext>, OpenShiftBaseValidator>();
            services.AddScoped<IValidator<OpenShiftDTO, ValidationContext>, ShiftOpenedValidator>();
            services.AddScoped<IValidator<OpenShiftDTO, ValidationContext>, OpenShiftTimeValidator>();

            // KKM
            services.AddScoped<IValidator<KkmDTO, KkmValidationContext>, KkmUniqueSerialNumberCreateValidator>();
            services.AddScoped<IValidator<KkmUpdateDTO, KkmValidationContext>, KkmUniqueSerialNumberUpdateValidator>();
            services.AddScoped<IValidator<KkmDeleteDTO, KkmValidationContext>, KkmDeleteValidator>();
            // Client
            services.AddScoped<IValidator<ClientDTO, ClientValidationContext>, ClientCreateUniqueValidator>();
            services.AddScoped<IValidator<ClientChangeDTO, ClientValidationContext>, ClientUpdateUnique>();
            services.AddScoped<IValidator<ClientDeleteDTO, ClientValidationContext>, ClientDeleteValidator>();
            // Global
            services.AddScoped(typeof(IGlobalValidator<>), typeof(GlobalKkmValidator<>));
            services.AddScoped<IGlobalValidator<ValidationContext>, GlobalCashierValidator>();
            services.AddScoped<IGlobalValidator<ValidationContext>, GlobalShiftOpenValidator>();    
            services.AddScoped<IGlobalValidator<ClientValidationContext>, GlobalClientValidator>();

            return services;
        }
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<FiscalizationService>();
            services.AddScoped<ClientService>();
            services.AddScoped<Fiscalizator.Logger.Logger>();
            services.AddScoped<BillHandler>();
            services.AddScoped<CloseShiftHandler>();
            services.AddScoped<OpenShiftHandler>();
            services.AddScoped<BillValidator>();
            services.AddScoped<KkmService>();

            return services;
        }
    }
}

