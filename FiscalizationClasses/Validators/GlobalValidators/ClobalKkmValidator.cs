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
    public class GlobalKkmValidator<TData, TContext> : IGlobalValidator<TData, TContext> where TContext : IValidationContext where TData : IKkmDataAccessor
    { 
        public void Validate(object request, TData validationData, TContext validationContext)
        {
            if (request is not ISerialNumberRequire kkmRequest)
            {
                return;
            }
            Kkm kkm = validationData.Kkms.GetBySerialNumber(kkmRequest.SerialNumber);
            if (kkm == null)
            {
                throw new KkmException($"Kkm with serial number {kkmRequest.SerialNumber} does not exist.");
            }
            if (validationContext is IKkmValidationContextRequire kkmValidationContext)
            {
                kkmValidationContext.Kkm = kkm;
            }
        }
    }
}
