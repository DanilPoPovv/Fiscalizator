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
using Fiscalizator.FiscalizationClasses.Dto.Service;
using Fiscalizator.FiscalizationClasses.Validators.ServiceOperationValidators;
using Fiscalizator.FiscalizationClasses.OtherClassess;
using Microsoft.AspNetCore.Identity;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Validators.Authorization;
using Fiscalizator.FiscalizationClasses.Dto.User;

namespace Fiscalizator.Helpers
{
    public static class DependencyHelper 
    {
        public static IServiceCollection AddFiscalizatorValidators(this IServiceCollection services)
        {
            services.AddScoped(typeof(ValidatorManager<,,>));
            ///TODO : Separate to private methods
            // Bill validators
            services.AddScoped<IValidator<BillDTO, BaseOperationDataAccessor, ValidationContext>, BillValidator>();

            // Close shift
            services.AddScoped<IValidator<CloseShiftDTO, BaseOperationDataAccessor, ValidationContext>, ShiftClosedValidator>();

            // Open shift
            services.AddScoped<IValidator<OpenShiftDTO, BaseOperationDataAccessor, ValidationContext>, ShiftOpenedValidator>();
            services.AddScoped<IValidator<OpenShiftDTO, BaseOperationDataAccessor, ValidationContext>, OpenShiftTimeValidator>();

            // KKM
            services.AddScoped<IValidator<KkmDTO,KkmCrudDataAccessor, KkmValidationContext>, KkmUniqueSerialNumberCreateValidator>();
            services.AddScoped<IValidator<KkmUpdateDTO, KkmCrudDataAccessor, KkmValidationContext>, KkmUpdateValidator>();
            services.AddScoped<IValidator<KkmDeleteDTO, KkmCrudDataAccessor, KkmValidationContext>, KkmDeleteValidator>();
            // Client
            services.AddScoped<IValidator<ClientDTO,IClientDataAccessor, ClientValidationContext>, ClientCreateUniqueValidator>();
            services.AddScoped<IValidator<ClientChangeDTO, IClientDataAccessor, ClientValidationContext>, ClientUpdateUnique>();
            services.AddScoped<IValidator<ClientDeleteDTO, IClientDataAccessor, ClientValidationContext>, ClientDeleteValidator>();

            //Cashier
            services.AddScoped<IValidator<CashierAddDto, CashierCrudDataAccessor, CashierValidationContext>, CashierAddvalidator>();
            services.AddScoped<IValidator<CashierUpdateDto, CashierCrudDataAccessor, CashierValidationContext>, CashierUpdateValidator>();

            //Outcome
            services.AddScoped<IValidator<OutcomeOperationDto, BaseOperationDataAccessor, OutcomeCashVContext>, OutcomeOperationValidator>();

            //User
            services.AddScoped<IValidator<CreateClientUserDto, UserDataAccessor, UserValidationContext>, ClientUserValidator>();
            services.AddScoped<IValidator<CreateGlobalAdminDto, UserDataAccessor, UserValidationContext>, GlobalSystemUserValidator>();
            // Global
            services.AddScoped(typeof(IGlobalValidator<,,>), typeof(GlobalKkmValidator<,,>));
            services.AddScoped(typeof(IGlobalValidator<,,>), typeof(GlobalCashierValidator<,,>));
            services.AddScoped(typeof(IGlobalValidator<,,>), typeof(GlobalShiftOpenValidator<,,>));
            services.AddScoped(typeof(IGlobalValidator<,,>), typeof(GlobalClientValidator<,,>));
            services.AddScoped(typeof(IGlobalValidator<,,>), typeof(GlobalCashValidator<,,>));
            services.AddScoped(typeof(IGlobalValidator<,,>), typeof(GlobalOperationTimeValidator<,,>));
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
            services.AddScoped<OutcomeHandler>();
            services.AddScoped<AuthorizationService>();
            services.AddScoped<JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}

