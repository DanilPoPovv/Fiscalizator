using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;
using Fiscalizator.Repository;
using NHibernate.SqlCommand;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalKkmValidator<TRequest,TData, TContext> : IGlobalValidator<TRequest, TData, TContext> 
        where TContext : IValidationContext 
        where TData : IKkmDataAccessor
        where TRequest : ISerialNumberRequire
    { 
        public void Validate(TRequest request, TData validationData, TContext validationContext)
        {
            Kkm kkm = validationData.Kkms.GetBySerialNumber(request.SerialNumber);
            if (kkm == null)
            {
                throw new KkmException($"Kkm with serial number {request.SerialNumber} does not exist.");
            }
            if (validationContext is IKkmValidationContextRequire kkmValidationContext)
            {
                kkmValidationContext.Kkm = kkm;
            }
        }
    }
}
