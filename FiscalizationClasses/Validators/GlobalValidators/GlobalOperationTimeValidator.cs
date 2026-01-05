using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Requests;
using Fiscalizator.FiscalizationClasses.Validators.DataAccessors.interfaces;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts;
using Fiscalizator.FiscalizationClasses.Validators.ValidationContexts.interfaces;
using FluentNHibernate.MappingModel;
using NHibernate.SqlCommand;

namespace Fiscalizator.FiscalizationClasses.Validators.GlobalValidators
{
    public class GlobalOperationTimeValidator<TData, TContext> : IGlobalValidator<TData,TContext> where TContext : ValidationContext where TData : IShiftDataAccessor
    {
        public void Validate(object request, TData validationData, TContext validationContext)
        {
            if (request is not IHasOperationTime requestTime)
                return;
            if (validationContext.Shift != null && requestTime.OperationDateTime <= validationContext.Shift.LastOperationDateTime)
            {
               throw new Exception("Operation time cannot be earlier than the last operation time in the current shift.");
            }
        }
    }
}
