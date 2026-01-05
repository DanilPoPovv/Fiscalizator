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
using Fiscalizator.FiscalizationClasses.Dto.Bill;
using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Dto.Shift;
using Fiscalizator.FiscalizationClasses.Dto.Kkm;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Dto.Cashier;
using Fiscalizator.FiscalizationClasses.Validators.CashierCrudValidators;

namespace Fiscalizator.Helpers
{
    public static class DependencyHelper 
    {
        public static IServiceCollection AddFiscalizatorValidators(this IServiceCollection services)
        {
            services.AddScoped(typeof(ValidatorManager<,,>));

            // Bill validators
            //services.AddScoped<IValidator<BillDTO, ValidationContext>, OpenShiftValidator>();
            services.AddScoped<IValidator<BillDTO,BaseOperationDataAccessor, ValidationContext>, BillTimeValidator>();
            services.AddScoped<IValidator<BillDTO, BaseOperationDataAccessor, ValidationContext>, BillValidator>();

            // Close shift
            //services.AddScoped<IValidator<CloseShiftDTO, ValidationContext>, CloseShiftValidator>();
            services.AddScoped<IValidator<CloseShiftDTO, BaseOperationDataAccessor, ValidationContext>, ShiftClosedValidator>();

            // Open shift
            //services.AddScoped<IValidator<OpenShiftDTO, ValidationContext>, OpenShiftBaseValidator>();
            services.AddScoped<IValidator<OpenShiftDTO, BaseOperationDataAccessor, ValidationContext>, ShiftOpenedValidator>();
            services.AddScoped<IValidator<OpenShiftDTO, BaseOperationDataAccessor, ValidationContext>, OpenShiftTimeValidator>();

            // KKM
            services.AddScoped<IValidator<KkmDTO,KkmCrudDataAccessor, KkmValidationContext>, KkmUniqueSerialNumberCreateValidator>();
            services.AddScoped<IValidator<KkmUpdateDTO, KkmCrudDataAccessor, KkmValidationContext>, KkmUniqueSerialNumberUpdateValidator>();
            services.AddScoped<IValidator<KkmDeleteDTO, KkmCrudDataAccessor, KkmValidationContext>, KkmDeleteValidator>();
            // Client
            services.AddScoped<IValidator<ClientDTO,ClientCrudDataAccesor, ClientValidationContext>, ClientCreateUniqueValidator>();
            services.AddScoped<IValidator<ClientChangeDTO, ClientCrudDataAccesor,ClientValidationContext>, ClientUpdateUnique>();
            services.AddScoped<IValidator<ClientDeleteDTO, ClientCrudDataAccesor, ClientValidationContext>, ClientDeleteValidator>();

            //Cashier
            services.AddScoped<IValidator<CashierAddDto, CashierCrudDataAccessor, CashierValidationContext>, CashierAddvalidator>();
            services.AddScoped<IValidator<CashierUpdateDto, CashierCrudDataAccessor, CashierValidationContext>, CashierUpdateValidator>();

            //Income

            // Global
            services.AddScoped(typeof(IGlobalValidator<,>), typeof(GlobalKkmValidator<,>));
            services.AddScoped(typeof(IGlobalValidator<,>), typeof(GlobalCashierValidator<,>));
            services.AddScoped(typeof(IGlobalValidator<,>), typeof(GlobalShiftOpenValidator<,>));
            services.AddScoped(typeof(IGlobalValidator<,>), typeof(GlobalClientValidator<,>));
            services.AddScoped(typeof(IGlobalValidator<,>), typeof(GlobalCashValidator<,>));
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
            services.AddScoped<CashierService>();
            services.AddScoped<IncomeHandler>();

            return services;
        }
    }
}

