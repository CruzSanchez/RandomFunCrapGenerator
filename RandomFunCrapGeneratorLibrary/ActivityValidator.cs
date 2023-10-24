// Ignore Spelling: Validator

using RandomFunCrapGeneratorLibrary.Helpers.Extensions;
using RandomFunCrapGeneratorLibrary.Models;

namespace RandomFunCrapGeneratorLibrary
{
    public static class ActivityValidator
    {
        public static void Validate(Activity activityToValidate)
        {
            if (activityToValidate == null)
            {
                throw new NullReferenceException("Activity was null, please try again");
            }

            ValidationTicket ticket = new ValidationTicket();
            activityToValidate.ValidationTicket = ticket;

            if (activityToValidate.Name.IsNullOrWhiteSpaceOrEmpty())
            {
                activityToValidate.ValidationTicket.DenialReason = "Name was not given or in the correct format. Please try again";
                return;
            }

            activityToValidate.ValidationTicket.PassedValidationCheck = true;
        }
    }
}
